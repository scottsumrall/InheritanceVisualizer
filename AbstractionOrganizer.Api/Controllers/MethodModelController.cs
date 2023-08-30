using AbstractionOrganizer.Api.Data;
using AbstractionOrganizer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbstractionOrganizer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MethodModelController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public MethodModelController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetMethodModels()
        {
            if (_appDbContext.MethodModels == null)
            {
                return NotFound();
            }
            var MethodModels = await _appDbContext.MethodModels
                                            .ToListAsync();
            return Ok(MethodModels);
        }



        [HttpGet("{id:int}")]
        public ActionResult<MethodModel> GetMethodModel(int id)
        {
            try
            {
                var result = _appDbContext.MethodModels
                                                .Where(c => c.Id == id)
                                                .FirstOrDefault();

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<MethodModel>> CreateMethodModel(MethodModel MethodModel)
        {
            try
            {
                _appDbContext.MethodModels.Add(MethodModel);
                var newMethodModel = await _appDbContext.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMethodModel), new { id = MethodModel.Id }, newMethodModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MethodModel>> UpdateMethodModel(int id, MethodModel MethodModel)
        {
            if (id != MethodModel.Id)
            {
                return BadRequest();
            }

            _appDbContext.Entry(MethodModel).State = EntityState.Modified;


            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MethodModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();

        }

        private bool MethodModelExists(long id)
        {
            return (_appDbContext.MethodModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<MethodModel>> DeleteMethodModel(int id)
        {
            try
            {
                if (_appDbContext.MethodModels == null)
                {
                    return NotFound();
                }
                var MethodModel = await _appDbContext.MethodModels.FindAsync(id);
                if (MethodModel == null)
                {
                    return NotFound();
                }
                _appDbContext.MethodModels.Remove(MethodModel);
                await _appDbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database.");
            }
        }
    }
}
