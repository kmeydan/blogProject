using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Straßenkarte.Abstract.Service;
using Straßenkarte.Models.ViewModels;
using Straßenkarte.Services;
using System;

namespace Straßenkarte.ViewComponents
{
	public class CategoryListViewComponent:ViewComponent
	{
		private readonly ICategoryService categoryService;

		public CategoryListViewComponent(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		public ViewViewComponentResult Invoke()
		{

			var model = new CategoryModelComponent
			{
				Categories = categoryService.GetAll(),
				SelectValue = Convert.ToInt32(HttpContext.Request.Query["category"])
			};
			return View(model);
		}

	}
}
