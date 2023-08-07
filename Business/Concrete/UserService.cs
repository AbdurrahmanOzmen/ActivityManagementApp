using Business.Abstract;
using Business.Dto.User;
using DataAccess.Abstract;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task Create(UserCreateDto user)
        {
            var newUser = new User();

            newUser.Name = user.Name;

            await _userDal.Add(newUser);
        }

        public async Task Update(UserUpdateDto user)
        {
            var newUser = new User();

            newUser.Name = user.Name;
            newUser.Id = user.Id;

            await _userDal.Update(newUser);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userDal.GetById(id);

            UserDto result = new UserDto
            {
                Id = user.Id,
                Name = user.Name
            };

            return result;
        }

        public async Task<List<UserDto>> GetList()
        {
            var users = await _userDal.GetList();

            var result = users.Select(a => new UserDto()
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();

            return result;
        }
    }
}
