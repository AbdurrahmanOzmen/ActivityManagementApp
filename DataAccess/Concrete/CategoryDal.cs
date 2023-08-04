using DataAccess.Abstract;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<List<Category>> GetList()
        {
            using (var context = new ActivityManagementDbContext())
            {
                return await context.Categories.ToListAsync();
            }
        }
    }
}
