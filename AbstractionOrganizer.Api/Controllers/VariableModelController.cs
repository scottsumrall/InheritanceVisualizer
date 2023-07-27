using AbstractionOrganizer.Api.Data;
using AbstractionOrganizer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AbstractionOrganizer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VariableModelController : ControllerBase
	{
		private readonly AppDbContext _appDbContext;

		public VariableModelController(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}

		[HttpGet]
		public async Task<ActionResult> GetVariableModels()
		{
			if (_appDbContext.VariableModels == null)
			{
				return NotFound();
			}
			return Ok(await _appDbContext.VariableModels.ToListAsync());
		}


		[HttpGet("{id:int}")]
		public async Task<ActionResult<VariableModel>> GetVariableModel(int id)
		{
			try
			{
				var result = await _appDbContext.VariableModels.FindAsync(id);

				if (result is null)
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
		public async Task<ActionResult<VariableModel>> CreateVariableModel(VariableModel variableModel)
		{
			try
			{
				_appDbContext.VariableModels.Add(variableModel);

				var newVariableModel = await _appDbContext.SaveChangesAsync();

				return CreatedAtAction(nameof(GetVariableModel), new { id = variableModel.Id }, newVariableModel);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<VariableModel>> UpdateVariableModel(int id, VariableModel VariableModel)
		{
			if (id != VariableModel.Id)
			{
				return BadRequest();
			}

			_appDbContext.Entry(VariableModel).State = EntityState.Modified;


			try
			{
				await _appDbContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!VariableModelExists(id))
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

		private bool VariableModelExists(long id)
		{
			return (_appDbContext.VariableModels?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<VariableModel>> DeleteVariableModel(int id)
		{
			try
			{
				if (_appDbContext.VariableModels == null)
				{
					return NotFound();
				}
				var variableModel = await _appDbContext.VariableModels.FindAsync(id);
				if (variableModel == null)
				{
					return NotFound();
				}
				_appDbContext.VariableModels.Remove(variableModel);
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
