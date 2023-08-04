﻿using Business.Dto.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetList();
        Task Create(CategoryCreateDto category);
    }
}