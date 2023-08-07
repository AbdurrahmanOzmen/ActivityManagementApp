using Business.Dto.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
     public interface IActivityService
    {
        Task<List<ActivityDto>> GetList();
        Task<ActivityDto> GetById(int id);
        Task Create(ActivityCreateDto activity);
        Task Update(ActivityUpdateDto activity);
    }
}
