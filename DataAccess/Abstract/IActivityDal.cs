using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IActivityDal
    {
        Task<List<Activity>> GetList();
        Task<Activity> GetById(int id);
        Task Add(Activity activity);
        Task Update(Activity activity);


    }
}
