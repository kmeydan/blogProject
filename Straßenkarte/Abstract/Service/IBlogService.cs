using Straßenkarte.Enitites;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Straßenkarte.Abstract.Service
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        List<Blog> Search(string aranankelime);
        List<Blog> SearchTag(string aranankelime);
        List<Blog> GetByCategoryId(int id);
        void Add(Blog entity);
        void Update(Blog entity);
        void Delete(Blog entity);
    }
}
