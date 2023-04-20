using Microsoft.AspNetCore.Mvc.Rendering;
using Straßenkarte.Abstract.Repository;
using Straßenkarte.Abstract.Service;
using Straßenkarte.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Straßenkarte.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            category.CreateDate = DateTime.Now;
            categoryRepository.Add(category);
        }

        public void Delete(Category category)
        {
            categoryRepository.Delete(category);
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public List<SelectListItem> GetSelectListItems()
        {
            return categoryRepository.GetEx(x => x.CategoryId > 0).Select(x => new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
        }

        public void Update(Category category)
        {
            category.ModifiedDate= DateTime.Now;
            categoryRepository.Update(category);
        }
    }
}
