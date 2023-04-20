using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Straßenkarte.Enitites;

namespace Straßenkarte.Models.ViewModels
{
	public class TodoViewModels
	{
		public int Id { get; set; }
		[Required]
        public string TodoAction { get; set; }
        [Required]
        public string TodoDescription { get; set; }
        [Required]
        [DataType(DataType.Date)]
		public DateTime LastDateTime { get; set; }
		public Todo Todo { get; set; }
		public List<Todo> Todolist { get; set; }
	}
}
