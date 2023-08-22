using AutoMapper;
using Business.Abstract;
using Business.Dto.Activity;
using DataAccess.Abstract;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ActivityService : IActivityService
    {
        private IActivityDal _activityDal;
        private IMapper _mapper;

        public ActivityService(IActivityDal activityDal, IMapper mapper)
        {
            _activityDal = activityDal;
            _mapper = mapper;
        }

        public async Task Create(ActivityCreateDto activity)
        {
            var newActivity = new Activity();

            newActivity.CategoryId = activity.CategoryId;
            newActivity.ActivityDate = activity.ActivityDate;
            newActivity.Description = activity.Description;
            newActivity.Address = activity.Address;
            newActivity.Title = activity.Title;

            await _activityDal.Add(newActivity);
        }

        public async Task Update(ActivityUpdateDto activity)
        {
            var newActivity = new Activity();

            newActivity.Title = activity.Title;
            newActivity.Id = activity.Id;
            newActivity.Address = activity.Address;
            newActivity.ActivityDate = activity.ActivityDate;
            newActivity.Description = activity.Description;
            newActivity.CategoryId = activity.CategoryId;

            await _activityDal.Update(newActivity);
        }

        public async Task Delete(int id)
        {
            await _activityDal.Delete(id);
        }

        public async Task<ActivityDto> GetById(int id)
        {
            var activity = await _activityDal.GetById(id);

            var result = _mapper.Map<ActivityDto>(activity);

            //ActivityDto result = new ActivityDto
            //{
            //    Id = activity.Id,
            //    ActivityTitle = activity.Title,
            //    CategoryId = activity.CategoryId,
            //    Address = activity.Address,
            //    Description = activity.Description,
            //    ActivityDate = activity.ActivityDate
            //};

            return result;
        }

        public async Task<List<ActivityDto>> GetList()
        {
            var activities = await _activityDal.GetList();

            var result = _mapper.Map<List<ActivityDto>>(activities);

            //var result = activities.Select(a => new ActivityDto()
            //{
            //    Id = a.Id,
            //    ActivityTitle = a.Title,
            //    CategoryId = a.CategoryId,
            //    Address = a.Address,
            //    Description = a.Description,
            //    ActivityDate = a.ActivityDate

            //}).ToList();

            return result;
        }
    }
}
