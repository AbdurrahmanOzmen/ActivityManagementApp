using AutoMapper;
using Business.Abstract;
using Business.Dto.Category;
using DataAccess.Abstract;
using Entities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMapper _mapper;

        public CategoryService(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task Create(CategoryCreateDto category)
        {
            var newCategory = new Category();

            newCategory.Name = category.Name;

            await _categoryDal.Add(newCategory);
        }

        public async Task Update(CategoryUpdateDto category)
        {
            var newCategory = new Category();

            newCategory.Name = category.Name;
            newCategory.Id = category.Id;

            await _categoryDal.Update(newCategory);
        }
        public async Task Delete(int id)
        {
                        
            await _categoryDal.Delete(id);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryDal.GetById(id);

            var result = _mapper.Map<CategoryDto>(category);

            //CategoryDto result = new CategoryDto
            //{
            //    Id = category.Id,
            //    CategoryName = category.Name
            //};

            return result;
        }

        public async Task<List<CategoryDto>> GetList()
        {
            var categories = await _categoryDal.GetList();

            var result = _mapper.Map<List<CategoryDto>>(categories);

            //var result = categories.Select(a => new CategoryDto()
            //{
            //    Id = a.Id,
            //    CategoryName = a.Name
            //}).ToList();

            return result;
        }
        
    }
}
