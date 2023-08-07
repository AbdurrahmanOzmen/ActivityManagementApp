﻿using Business.Abstract;
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

        public CategoryService(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
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

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _categoryDal.GetById(id);

            CategoryDto result = new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.Name
            };

            return result;
        }

        public async Task<List<CategoryDto>> GetList()
        {
            var categories = await _categoryDal.GetList();

            var result = categories.Select(a => new CategoryDto()
            {
                Id = a.Id,
                CategoryName = a.Name
            }).ToList();

            return result;
        }
    }
}