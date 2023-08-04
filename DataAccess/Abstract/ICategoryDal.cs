using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal
    {
        Task<List<Category>> GetList();
        Task<Category> GetById(int id);
        Task Add(Category category);
    }
}
