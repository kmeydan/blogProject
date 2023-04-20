using Straßenkarte.Enitites;
using System;
using System.Collections.Generic;

namespace Straßenkarte.Models.ViewModels
{
    public class AdminIndexBlogViewModel
    {
        public int KullanıcıId { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciRol { get; set; }
        public bool Aktif { get; set; }
    }
    
    public class AdminBlogViewModel
    {
        public List<AppUser> users { get; set; }
		public List<Blog> blogs { get; set; }
        public AdminIndexBlogViewModel adminIndexBlogView { get; set; }
        public List<Todo> Todo {get;set;}
    }
}
