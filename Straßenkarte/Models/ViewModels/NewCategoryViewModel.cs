using System.Collections.Generic;
using Straßenkarte.Enitites;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Straßenkarte.Models.ViewModels
{
    public class NewCategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Kategori Adı")]
        [Required(ErrorMessage ="Lütfen {0} alanını boş bırakmayınız.")]
        public string CategoryName { get; set; }
        public List<Category> Categories { get; set; }
    }
}
