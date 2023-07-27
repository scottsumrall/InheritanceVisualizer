using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AbstractionOrganizer.Models;
using AbstractionOrganizer.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace AbstractionOrganizer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClassHeaderController : ControllerBase
	{
		private readonly AppDbContext _appDbContext;

		public ClassHeaderController(AppDbContext appDbContext)
		{
			this._appDbContext = appDbContext;
		}

		[HttpGet]
		public async Task<ActionResult> GetClassHeaders()
		{
			if (_appDbContext.ClassHeaders == null)
			{
				return NotFound();
			}
			var classHeaders = await _appDbContext.ClassHeaders
											.Include(c =>  c.VariableModels)
											.ToListAsync();
			return Ok(classHeaders);
		}



		[HttpGet("{id:int}")]
		public ActionResult<ClassModel> GetClassHeader(int id)
		{
			try
			{
				var result = _appDbContext.ClassHeaders
												.Include(c => c.VariableModels)
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
		public async Task<ActionResult<ClassModel>> CreateClassHeader(ClassModel classModel)
		{
			try
			{
				updateRelationships(classModel);

				_appDbContext.ClassHeaders.Add(classModel);
				var newClassHeader = await _appDbContext.SaveChangesAsync();

				return CreatedAtAction(nameof(GetClassHeader), new { id = classModel.Id }, newClassHeader);
			}
			catch (Exception) 
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
			}
		}

		// Ensure all related entities properly reference the class they belong to
		private void updateRelationships(ClassModel classModel)
		{
			foreach (VariableModel varModel in classModel.VariableModels!)
			{
				varModel.ClassModelId = classModel.Id;
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<ClassModel>> UpdateClassHeader(int id, ClassModel classModel)
		{
			if(id != classModel.Id)
			{
				return BadRequest();
			}

			updateRelationships(classModel);

			_appDbContext.Entry(classModel).State = EntityState.Modified;


			try
			{
				await _appDbContext.SaveChangesAsync();
			}
			catch(DbUpdateConcurrencyException)
			{
				if (!ClassModelExists(id))
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

		private bool ClassModelExists(long id)
		{
			return (_appDbContext.ClassHeaders?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<ClassModel>> DeleteClassHeader(int id)
		{
			try
			{
				if (_appDbContext.ClassHeaders == null)
				{
					return NotFound();
				}
				var classModel = await _appDbContext.ClassHeaders.FindAsync(id);
				if(classModel == null)
				{
					return NotFound();
				}
				_appDbContext.ClassHeaders.Remove(classModel);
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
