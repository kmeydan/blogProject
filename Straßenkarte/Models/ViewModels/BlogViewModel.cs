using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Straßenkarte.Enitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Straßenkarte.Models.ViewModels
{
	public class BlogViewModel
	{
		public int Id { get; set; }
		[Display(Name = "Başlık")]
		[Required(ErrorMessage = "{0} alanını boş bırkmayınız!")]
		public string BlogTitle { get; set; }
		public string BlogTag { get; set; }
		[Display(Name = "Açıklama")]
		public string BlogDescription { get; set; }
		public IFormFile File { get; set; }
		public string İmageName { get; set; }
		public DateTime CreateDate{ get; set; }
		[Display(Name ="Aktif Olsunmu?")]
		public bool Aktif { get; set; }
		[Display(Name = "Kategori")]
		[Required(ErrorMessage = "Lütfen bir kategori seçiniz!")]
		public int CategoryId { get; set; }

	}
	public class NewBlogViewModel
	{
		public BlogViewModel BlogViewModel { get; set; }
		public List<SelectListItem> CategoriesSelect { get; set; }
	}
	public class BlogsViewModel
	{
		public List<Blog> Blogs { get; set; }
		public List<SelectListItem> CategoriesSelect { get; set; }
		public int SelectCategory { get; set; }
		public int PageCount { get; internal set; }
		public int PageSize { get; internal set; }
		public int CurrentPage { get; internal set; }
		public int BlogsCount { get; internal set; }
    }
}
