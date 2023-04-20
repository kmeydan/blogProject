using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Straßenkarte.Abstract.Service;
using Straßenkarte.Enitites;
using Straßenkarte.Models.ViewModels;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;

namespace Straßenkarte.Controllers
{
    public class AdminController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly ICategoryService categoryService;
		private readonly IBlogService blogService;
		private readonly ITodoService todoService;

		public AdminController(ICategoryService categoryService, IBlogService blogService,ITodoService todo,UserManager<AppUser> user)
		{
			this.categoryService = categoryService;
			this.blogService = blogService;
			this.todoService = todo;
			this.userManager = user;
		}

		public IActionResult Index()
		{
			var model = new AdminBlogViewModel
			{
				blogs = blogService.GetAll(),
				users = userManager.Users.ToList(),
				Todo= todoService.GetAll()
				


			};
			return View(model);
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpGet]
		public IActionResult BlogCreate()
		{
			var model = new NewBlogViewModel
			{
				BlogViewModel = new BlogViewModel(),
				CategoriesSelect = categoryService.GetSelectListItems()
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> BlogCreate(NewBlogViewModel model)
		{
			string imgName = string.Empty;
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			if (model == null)
			{
				ModelState.AddModelError("", "Model Getirilemedi.");
				return View();
			}

			if (model.BlogViewModel.File == null)
			{
				ModelState.AddModelError("", "Lütfen Görsel Ekleyin.");
				return View(model);
			}

			if (model.BlogViewModel.File != null)
			{

				if (model.BlogViewModel.File.Length > 10485760)
				{
					ModelState.AddModelError("", "Resim Dosyası 10 Mbdan büyük olamaz.");
					return View(model);
				}

				var uzanti = Path.GetExtension(model.BlogViewModel.File.FileName);
				imgName = Guid.NewGuid().ToString() + uzanti;
				var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", imgName);
				using (var stream = new FileStream(filepath, FileMode.Create))
				{
					await model.BlogViewModel.File.CopyToAsync(stream);
				}
			}


			var blogs = new Blog
			{
				BlogTitle = model.BlogViewModel.BlogTitle,
				BlogDescription = model.BlogViewModel.BlogDescription,
				Tag = model.BlogViewModel.BlogTag,
				CategoryId = model.BlogViewModel.CategoryId,
				ImageUrl = imgName,
				Active = model.BlogViewModel.Aktif
			};
			blogService.Add(blogs);

			return RedirectToAction("Index");

		}

		public IActionResult Bloglar(int? categoryid = 0)
		{
			var result = blogService.GetAll();
			var model = new BlogsViewModel
			{
				Blogs = categoryid == 0 ? blogService.GetAll() : blogService.GetByCategoryId(categoryid.Value),
				CategoriesSelect = categoryService.GetSelectListItems(),
				SelectCategory = categoryid == 0 ? 0 : categoryid.Value,
				BlogsCount = result.Count


			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Bloglar(BlogsViewModel model)
		{
			return RedirectToAction("Bloglar", new { categoryid = model.SelectCategory });
		}

		[HttpGet]
		public IActionResult BlogUpdate(int id)
		{
			var model = blogService.GetById(id);

			if (model == null)
			{
				ModelState.AddModelError("", "Model Getirilemedi");
				return View(model);
			}



			var blogs = new NewBlogViewModel
			{
				BlogViewModel = new BlogViewModel
				{
					BlogTitle = model.BlogTitle,
					CategoryId = model.CategoryId,
					BlogTag = model.Tag,
					BlogDescription = model.BlogDescription,
					İmageName = model.ImageUrl,
					Aktif = model.Active,
					Id = model.Id
				},
				CategoriesSelect = categoryService.GetSelectListItems(),
			};

			return View(blogs);


		}

		[HttpPost]
		public async Task<IActionResult> BlogUpdate(NewBlogViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var blog = blogService.GetById(model.BlogViewModel.Id);

			if (blog == null)
			{
				ModelState.AddModelError("", "Hata model getirilemedi.");
				return View(blog);
			}


			if (model.BlogViewModel.File != null)
			{

				if (model.BlogViewModel.File.Length > 10485760)
				{
					ModelState.AddModelError("", "Resim Dosyası 10 Mbdan büyük olamaz.");
					return View(model);
				}

				var uzanti = Path.GetExtension(model.BlogViewModel.File.FileName);
				string imgName = Guid.NewGuid().ToString() + uzanti;
				var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Img", imgName);
				using (var stream = new FileStream(filepath, FileMode.Create))
				{
					await model.BlogViewModel.File.CopyToAsync(stream);
				}

				blog.ImageUrl = imgName;
			}






			blog.BlogTitle = model.BlogViewModel.BlogTitle;
			blog.BlogDescription = model.BlogViewModel.BlogDescription;
			blog.Tag = model.BlogViewModel.BlogTag;
			blog.CategoryId = model.BlogViewModel.CategoryId;
			blog.Active = model.BlogViewModel.Aktif;



			blogService.Update(blog);

			return RedirectToAction("Bloglar");
		}

		[HttpPost]
		public IActionResult BlogRemove(int id)
		{
			var blog = blogService.GetById(id);
			if (blog == null)
			{
				ModelState.AddModelError("", "Blog bulunamadı");
				return View(blog);
			}

			blogService.Delete(blog);


			return RedirectToAction("Bloglar");



		}
		[HttpGet]
		public IActionResult CategoryCreate()
		{
			var model = new NewCategoryViewModel()
			{
				Categories = categoryService.GetAll()
			};

			return View(model);
		}

		[HttpPost]
		public IActionResult CategoryCreate(NewCategoryViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Hata");
				return View(model);
			}

			var category = new Category
			{

				CategoryName = model.CategoryName
			};
			categoryService.Add(category);
			return RedirectToAction("CategoryCreate", "Admin");
		}
		[HttpGet]
		public IActionResult CategoryUpdate(int id)
		{
			var result = categoryService.GetById(id);
			var category = new NewCategoryViewModel()
			{
				CategoryName = result.CategoryName

			};
			return View(category);
		}
		[HttpPost]
		public IActionResult CategoryUpdate(NewCategoryViewModel model)
		{
			var result = categoryService.GetById(model.Id);

			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Hata");
				return View();
			}

			result.CategoryName = model.CategoryName;
			
			categoryService.Update(result);
			return RedirectToAction("CategoryCreate", "Admin");
		}

		[HttpPost]
		public IActionResult CategoryDelete(int id)
		{
			var result = categoryService.GetById(id);
			if (result==null)
			{
				ModelState.AddModelError("","Hata");
			}
			categoryService.Delete(result);

			return RedirectToAction("CategoryCreate","Admin");

		}

		[HttpGet]
		public IActionResult TodoList()
		{
			var model = new TodoViewModels()
			{
				Todolist = todoService.GetAll()
			};
			return View(model);
		}
		[HttpGet]
		public IActionResult CreateTodo()
		{
			return View(new TodoViewModels());
		}
		[HttpPost]
		public IActionResult CreateTodo(TodoViewModels model)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("","İlgili kısımları doldurunuz");
				return View();
			}

			var result = new Todo
			{
				TodoAction = model.TodoAction,
				LastDateTime = model.LastDateTime,
				Description = model.TodoDescription
			};
			todoService.Create(result);

			return RedirectToAction("TodoList","Admin");
		}

		[HttpGet]
		public IActionResult UpdateTodo(int id)
		{
			var model = todoService.GetById(id);
			var result = new TodoViewModels
			{
				TodoAction = model.TodoAction,
				TodoDescription = model.Description,
				LastDateTime = model.LastDateTime,
				
			};
			return View(result);
		}

		[HttpPost]
		public IActionResult UpdateTodo(TodoViewModels model)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("","Eksiksiz giriniz.");
			}
			var todo = todoService.GetById(model.Id);

			todo.LastDateTime = model.LastDateTime;
			todo.Description = model.TodoDescription;
			todo.TodoAction = model.TodoAction;
			todoService.Update(todo);
			return RedirectToAction("TodoList");
		}

		//Kullanıcı İşlemleri
		public IActionResult CreateUser()
		{

			return View(new AdminUserViewModel());
		}
		[HttpPost]
		public async Task<IActionResult> CreateUser(AdminUserViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			AppUser user = new AppUser
			{
				Email = model.Email,
				UserName = model.Username,
				PhoneNumber = model.PhoneNumber
				
			};
			var result = await userManager.CreateAsync(user, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");

			}
			else
			{ 
				result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
				return View(model);

			}

		}
		[HttpGet]
		public async Task<IActionResult> UserUpdate(string userId)
		{
			var user = await userManager.FindByIdAsync(userId);
			
			var model = new AdminUserViewModel
			{
				Email = user.Email,
				Username = user.UserName,
				PhoneNumber = user.PhoneNumber,
			};

			return View(model);


		}
		[HttpPost]
		public async Task<IActionResult> UserUpdate(AdminUserViewModel model)
		{
			var result = await userManager.FindByEmailAsync(model.Email);
			if (result==null)
			{
				ModelState.AddModelError("", "böyle bir kayıt yok");
				return View(model);
			}

			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("","Validasyon hatası");
				return View(model);
			}

			result.Email = model.Email;
			result.PhoneNumber= model.PhoneNumber;
			result.UserName = model.Username;
			
			var token = await userManager.GeneratePasswordResetTokenAsync(result);
			var password = await userManager.ResetPasswordAsync(result, token, model.Password);
			if (!password.Succeeded)
			{
				ModelState.AddModelError("", "Password kayıt edilmedi");
				return View();
			}

			var kayit = await userManager.UpdateAsync(result);
			if (!kayit.Succeeded)
			{
				ModelState.AddModelError("", "User Kayıt edilmedi");
				return View();
			}

			TempData["Message"] = "Başarılı bir şekilde güncellendi.";
			TempData["MessageType"] = "success";








			

			return RedirectToAction("Index");


		}
		//hata dönüyor düzenle
		[HttpPost]
		public async Task<IActionResult> DeleteUser(AdminUserViewModel model)
		{
			var result = await userManager.FindByEmailAsync(model.Email);
			if (result==null)
			{
				ModelState.AddModelError("","E mail bulunamadı.");
				return View("Index");

			}

			var deleted=await userManager.DeleteAsync(result);
			if (!deleted.Succeeded)
			{
				ModelState.AddModelError("","Silinme işlemi gerçekleştirilemedi");
				return View("Index");
			}

			TempData["Message"] = "Başarılı bir şekilde silinmiştir.";
			TempData["MessageType"] = "success";
			

			return RedirectToAction("Index");	
		}

		[HttpGet]
		public IActionResult Customers()
		{
			var model = new AdminBlogViewModel
			{
				users = userManager.Users.ToList(),

			};
			return View(model);
		}
	}





}




