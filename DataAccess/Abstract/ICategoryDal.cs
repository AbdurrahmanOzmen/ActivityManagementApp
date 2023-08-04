using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal
    {
        Task<List<Category>> GetList();

        Task Add(Category category);
    }
}
