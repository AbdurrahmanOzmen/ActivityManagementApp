using AutoMapper;
using Business.Dto.Activity;
using Business.Dto.Category;
using Business.Dto.User;
using Entities.Entities;

namespace Api.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //CreateMap<UserCreateDto, User>();
            //CreateMap<User, UserCreateDto>();

            //CreateMap<UserDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(u => u.FullName, opt => opt.MapFrom(x => $"{x.Name} {x.Surname}"));

            //CreateMap<UserUpdateDto, User>();
            //CreateMap<User, UserUpdateDto>();
            ////--//

            //CreateMap<CategoryCreateDto, Category>();
            //CreateMap<Category, CategoryCreateDto>();

            //CreateMap<CategoryUpdateDto, Category>();
            //CreateMap<Category, CategoryUpdateDto>();

            //CreateMap<CategoryDto, Category>();
            //CreateMap<Category, CategoryDto>();
            ////--//

            //CreateMap<ActivityCreateDto, Activity>();
            //CreateMap<Activity, ActivityCreateDto>();

            //CreateMap<ActivityUpdateDto, Activity>();
            //CreateMap<Activity, ActivityUpdateDto>();

            //CreateMap<ActivityDto, Activity>();
            //CreateMap<Activity, ActivityDto>();
        }
    }
}
