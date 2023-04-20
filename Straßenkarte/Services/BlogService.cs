using Microsoft.EntityFrameworkCore;
using Straßenkarte.Abstract.Repository;
using Straßenkarte.Abstract.Service;
using Straßenkarte.Enitites;
using Straßenkarte.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Straßenkarte.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public void Add(Blog entity)
        {
            entity.CreateDate = DateTime.Now;
            blogRepository.Add(entity);   
        }

        public void Delete(Blog entity)
        {
            blogRepository.Delete(entity);
        }

        public List<Blog> GetAll()
        {
            return blogRepository.GetAll().ToList();
        }

        

        public List<Blog> GetByCategoryId(int id)
        {
            return blogRepository.GetEx(x => x.CategoryId == id || id==0).ToList();
        }

        public Blog GetById(int id)
        {
            return blogRepository.GetById(id);
        }

		public List<Blog> OrderByDate()
		{
            return blogRepository.GetEx(x=>x.CreateDate>=DateTime.Now.AddDays(3)).OrderBy(x=>x.CreateDate).ToList();
		}

		public List<Blog> Search(string aranankelime)
        {
            return blogRepository.GetEx(x=>x.BlogTitle.ToUpper().Contains(aranankelime.ToUpper())).ToList();
        }

        public List<Blog> SearchTag(string aranankelime)
        {
            return blogRepository.GetEx(x=>x.Tag==aranankelime).ToList();
        }

        public void Update(Blog entity)
        {
            entity.ModifiedDate= DateTime.Now;
            blogRepository.Update(entity);

        }

        
    }
}
