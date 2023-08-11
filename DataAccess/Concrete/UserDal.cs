using DataAccess.Abstract;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserDal : IUserDal
    {
        public async Task Add(User user)
        {
            using (var context = new ActivityManagementDbContext())
            {
                await context.Users.AddAsync(user);

                await context.SaveChangesAsync();
            }
        }
        public async Task Update(User user)
        {
            using (var context = new ActivityManagementDbContext())
            {

                var entity = await context.Users.SingleOrDefaultAsync(c => c.Id == user.Id);

                entity.Name = user.Name;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            using (var context = new ActivityManagementDbContext())
            {

                var entity = await context.Users.SingleOrDefaultAsync(c => c.Id == id);
                entity.IsDeleted = true;

                await context.SaveChangesAsync();
            }
        }
        public async Task<User> GetById(int id)
        {
            using (var context = new ActivityManagementDbContext())
            {
                return await context.Users.SingleOrDefaultAsync(c => c.Id == id);
            }
        }

        public async Task<List<User>> GetList()
        {
            using (var context = new ActivityManagementDbContext())
            {
                return await context.Users.Where(x => !x.IsDeleted).ToListAsync();
            }
        }

        public async Task<User> Login(string email, string password)
        {
            using (var context = new ActivityManagementDbContext())
            {
                return await context.Users.SingleOrDefaultAsync(c => c.Email == email &&  c.Password == password && !c.IsDeleted);
            }
        }

    }
}
