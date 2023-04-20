using System.Collections.Generic;
using Straßenkarte.Abstract;

namespace Straßenkarte.Enitites
{
    public class Category:BaseEntity,IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
