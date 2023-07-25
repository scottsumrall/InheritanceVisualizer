using AbstractionOrganizer.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AbstractionOrganizer.Models;

namespace AbstractionOrganizer.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClassHeaderController : ControllerBase
	{
		private readonly IClassModelRepository classHeaderRepository;

		public ClassHeaderController(IClassModelRepository classHeaderRepository)
		{
			this.classHeaderRepository = classHeaderRepository;
		}

		[HttpGet]
		public async Task<ActionResult> GetClassHeaders()
		{
			return Ok(await classHeaderRepository.GetClassModels());
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ClassModel>> GetClassHeader(int id)
		{
			try
			{
				var result = await classHeaderRepository.GetClassModel(id);

				if(result == null)
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

		[HttpPost]
		public async Task<ActionResult<ClassModel>> CreateClassHeader(ClassModel classModel)
		{
			try
			{
				if(classModel == null)
				{
					return BadRequest();
				}

				var newClassHeader = await classHeaderRepository.AddClassModel(classModel);

				return CreatedAtAction(nameof(GetClassHeader), new { id = newClassHeader.Id }, newClassHeader);
			}
			catch (Exception) 
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
			}
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<ClassModel>> UpdateClassHeader(int id, ClassModel classHeader)
		{
			try
			{
				if(id != classHeader.Id)
				{
					return BadRequest();
				}

				var oldClassHeader = await classHeaderRepository.GetClassModel(id);

				if(oldClassHeader == null)
				{
					return NotFound($"Employee with Id = {id} not found.");
				}

				return await classHeaderRepository.UpdateClassModel(classHeader);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data from the database.");
			}
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<ClassModel>> DeleteClassHeader(int id)
		{
			try
			{
				var employeeToDelete = await classHeaderRepository.GetClassModel(id);

				if (employeeToDelete == null)
				{
					return NotFound($"Employee with Id = {id} not found");
				}

				return await classHeaderRepository.DeleteClassModel(id);
            }
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database.");
			}
		}
	}
}
