using Business.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IUserService
    {
        Task<List<UserDto>> GetList();
        Task<UserDto> GetById(int id);
        Task Create(UserCreateDto user);
    }
}
