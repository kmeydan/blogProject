using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Straßenkarte.Abstract.Repository;
using Straßenkarte.Abstract.Service;
using Straßenkarte.Enitites;
using Straßenkarte.Models;
using Straßenkarte.Models.ViewModels;
using Straßenkarte.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Xml;

namespace Straßenkarte.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;

        public HomeController(ILogger<HomeController> logger, IBlogService blogService, ICategoryService categoryService)
        {
            _logger = logger;
            this.blogService = blogService;
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index(int categoryId=0)
        {


            var blog = new BlogsViewModel
            {
                Blogs = blogService.GetByCategoryId(categoryId).ToList(),
                CategoriesSelect = categoryService.GetSelectListItems(),


            };
            return View(blog);

        }
        public IActionResult Contact()
        {
            return View();
        }
        
        public IActionResult PostDetail(int id)
        {

            var blog = blogService.GetById(id);
            var gelen = new BlogViewModel
            {
                BlogTitle = blog.BlogTitle,
                BlogDescription = blog.BlogDescription,
                CreateDate = blog.CreateDate,
                İmageName = blog.ImageUrl,
                CategoryId = blog.CategoryId,
                Id = blog.Id
                

            };
            return View(gelen);
        }
        [HttpGet]
        public IActionResult AllBlog(int page=1, int category=0, string tag=null)
        {
            var result = blogService.GetByCategoryId(category);
            int pageSize = 3;

            if (tag!=null)
            {
                var result2=blogService.SearchTag(tag);
                result = result2;


            }
            if (result.Count>1)
            {
                pageSize = 30;
            }
            var blog = new BlogsViewModel
            {

                Blogs = result.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(result.Count / (double)pageSize),
                PageSize = pageSize,
                SelectCategory = category,
                CurrentPage = page,



            };

            return View(blog);



        }
        [HttpGet]
        public IActionResult GetBlog(string aranankelime,int page=1)
        {
            int pageSize = 3;
            var result = blogService.Search(aranankelime).ToList();
            var blog = new BlogsViewModel
            {
                Blogs = result.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount=(int)Math.Ceiling(result.Count/(double)pageSize),
                PageSize=pageSize,
                CurrentPage=page,


            };

            return View(blog);

        }
    }
}
