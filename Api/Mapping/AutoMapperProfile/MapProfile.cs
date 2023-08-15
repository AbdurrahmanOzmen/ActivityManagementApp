using AutoMapper;
using Business.Concrete;
using Business.Dto.Activity;
using Business.Dto.Category;
using Business.Dto.User;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<LoginDto, UserService>();
            CreateMap<UserService, LoginDto>();

            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
            //--//

            CreateMap<CategoryCreateDto, Category>();
            CreateMap<Category, CategoryCreateDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            //--//

            CreateMap<ActivityCreateDto, Activity>();
            CreateMap<Activity, ActivityCreateDto>();

            CreateMap<ActivityUpdateDto, Activity>();
            CreateMap<Activity, ActivityUpdateDto>();

            CreateMap<ActivityDto, Activity>();
            CreateMap<Activity, ActivityDto>();
        }
    }
}
