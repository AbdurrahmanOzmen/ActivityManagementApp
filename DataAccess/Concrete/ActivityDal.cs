﻿using DataAccess.Abstract;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ActivityDal : IActivityDal
    {
        public async Task Add(Activity activity)
        {
            using (var context = new ActivityManagementDbContext())
            {
                await context.Activities.AddAsync(activity);

                await context.SaveChangesAsync();
            }
        }
        public async Task Update(Activity activity)
        {
            using (var context = new ActivityManagementDbContext())
            {
                var entity = await context.Activities.SingleOrDefaultAsync(c => c.Id == activity.Id);

                entity.Title = activity.Title;

                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            using (var context = new ActivityManagementDbContext())
            {

                var entity = await context.Activities.SingleOrDefaultAsync(c => c.Id == id);
                entity.IsDeleted = true;

                await context.SaveChangesAsync();
            }
        }
        public async Task<Activity> GetById(int id)
        {
            using (var context = new ActivityManagementDbContext())
            {
                return await context.Activities.SingleOrDefaultAsync(c => c.Id == id);
            }
        }

        public async Task<List<Activity>> GetList()
        {
            using (var context = new ActivityManagementDbContext())
            {
                return await context.Activities.Where(x => !x.IsDeleted).ToListAsync();
            }
        }


    }
}
