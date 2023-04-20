using System;

namespace Straßenkarte.Models.ViewModels
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Kullanıcı { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime Comments { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Search { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
    
}
