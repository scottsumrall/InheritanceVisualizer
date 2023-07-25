using AbstractionOrganizer.Api.Data;
using AbstractionOrganizer.Models;
using Microsoft.EntityFrameworkCore;

namespace AbstractionOrganizer.Api.Models
{
    public class ClassModelRepository : IClassModelRepository
	{
		private readonly AppDbContext _appDbContext;

		public ClassModelRepository(AppDbContext appDbContext) 
		{
			this._appDbContext = appDbContext;
		}

		public async Task<ClassModel> AddClassModel(ClassModel classModel)
		{
			var result = await _appDbContext.ClassHeaders.AddAsync(classModel);
			await _appDbContext.SaveChangesAsync();

			return result.Entity;
		}

		public async Task<ClassModel> DeleteClassModel(int classModelId)
		{
			var result = await _appDbContext.ClassHeaders.FirstOrDefaultAsync(e => e.Id == classModelId);

			if(result != null)
			{
				_appDbContext.ClassHeaders.Remove(result);
				await _appDbContext.SaveChangesAsync();
				return result;
			}

			return null;
		}

		public async Task<ClassModel> GetClassModel(int classModelId)
		{
			return await _appDbContext.ClassHeaders.FirstOrDefaultAsync(e => e.Id == classModelId);
		}

		public async Task<IEnumerable<ClassModel>> GetClassModels()
		{
			return await _appDbContext.ClassHeaders.ToListAsync();
		}

		public async Task<ClassModel> UpdateClassModel(ClassModel classModel)
		{
			var result = await _appDbContext.ClassHeaders.FirstOrDefaultAsync(e => e.Id == classModel.Id);

			if(result != null)
			{
                result.Name = classModel.Name;
                result.AccessModifier = classModel.AccessModifier;
                result.ClassModifier = classModel.ClassModifier;
                
				await _appDbContext.SaveChangesAsync();
            }

			return null;
        }
	}
}
