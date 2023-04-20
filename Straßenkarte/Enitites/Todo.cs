using System;
using Straßenkarte.Abstract;

namespace Straßenkarte.Enitites
{
	public class Todo:IEntity
	{
		public int Id { get; set; }
		public DateTime CreateDateTime { get; set; }
		public string TodoAction { get; set; }
		public DateTime LastDateTime { get; set; }
		public string Description { get; set; }
	}
}
