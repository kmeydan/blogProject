using Microsoft.AspNetCore.Mvc.Rendering;
using Straßenkarte.Enitites;
using System.Collections.Generic;

namespace Straßenkarte.Abstract.Service
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        List<SelectListItem> GetSelectListItems();
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
