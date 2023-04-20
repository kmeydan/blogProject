using System.IO;
using Straßenkarte.Abstract;

namespace Straßenkarte.Enitites
{
    public class Blog:BaseEntity, IEntity
    {
        public int Id { get; set; }
        public string BlogTitle { get; set; }
        public string Tag{ get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public string BlogDescription { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }


        public Category Category { get; set; }

    }
}
