using DataAccess.Abstract;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CategoryDal : ICategoryDal
    {
        public async Task Add(Category category)
        {
            using (var context = new ActivityManagementDbContext())
            {
                await context.Categories.AddAsync(category);

                await context.SaveChangesAsync();
            }
        }

        public async Task Update(Category category)
        {
            using (var context = new ActivityManagementDbContext())
            {

                var entity = await context.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);

                entity.Name = category.Name;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            using (var context = new ActivityManagementDbContext())
            {

                var entity = await context.Categories.SingleOrDefaultAsync(c => c.Id == id);
                entity.IsDeleted = true;

                await context.SaveChangesAsync();
            }
        }

        public async Task<Category> GetById(int id)
        {
            using (var context = new ActivityManagementDbContext())
            {
                return await context.Categories.SingleOrDefaultAsync(c => c.Id == id);
            }
        }

        public async Task<List<Category>> GetList()
        {
            using (var context = new ActivityManagementDbContext())
            {
                return await context.Categories.Where(x => !x.IsDeleted).ToListAsync();
            }
        }

    }
}
