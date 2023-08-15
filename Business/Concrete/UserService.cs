using AutoMapper;
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
        private IMapper _mapper;

        public UserService(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public async Task Create(UserCreateDto user)
        {
            var newUser = new User();

            newUser.UserType = user.UserType;
            newUser.Name = user.Name;
            newUser.Surname = user.Surname;
            newUser.Email = user.Email;
            newUser.Password = user.Password;

            await _userDal.Add(newUser);
        }

        public async Task Update(UserUpdateDto user)
        {
            var newUser = new User();

            newUser.Id = user.Id;
            newUser.Name = user.Name;
            newUser.UserType = user.UserType;
            newUser.Surname = user.Surname;
            newUser.Email = user.Email;
            newUser.Password = user.Password;

            await _userDal.Update(newUser);
        }

        public async Task Delete(int id)
        {

            await _userDal.Delete(id);
        }
        public async Task<UserDto> GetById(int id)
        {
            var user = await _userDal.GetById(id);

            var result = _mapper.Map<UserDto>(user);

            //UserDto result = new UserDto
            //{
            //    Id = user.Id,
            //    Name = user.Name,
            //    UserType = user.UserType,
            //    Surname = user.Surname,
            //    Email = user.Email,
            //    Password = user.Password
            //};

            return result;
        }

        public async Task<List<UserDto>> GetList()
        {
            var users = await _userDal.GetList();

            var result = _mapper.Map<List<UserDto>>(users);

            //var result = users.Select(a => new UserDto()
            //{
            //    Id = a.Id,
            //    Name = a.Name,
            //    UserType = a.UserType,
            //    Surname = a.Surname,
            //    Email = a.Email,
            //    Password = a.Password
            //}).ToList();

            return result;
        }

        public async Task<UserDto> Login(LoginDto loginDto)
        {
            var user = await _userDal.Login(loginDto.Email, loginDto.Password);

            UserDto result = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                UserType = user.UserType,
                Surname = user.Surname,
                Email = user.Email,
                Password = user.Password
            };

            return result;
        }

    }
}
