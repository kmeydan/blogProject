using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using Straßenkarte.Abstract.Repository;
using Straßenkarte.Abstract.Service;
using Straßenkarte.Enitites;
using Straßenkarte.Repository;

namespace Straßenkarte.Services
{
	public class TodoService:ITodoService
	{
		private readonly ITodoRepository todoRepository;

		public TodoService(ITodoRepository Todo)
		{
			this.todoRepository = Todo;
		}

		public List<Todo> GetAll()
		{

			return todoRepository.GetAll().ToList();

		}

		public Todo GetById(int id)
		{
			return todoRepository.GetById(id);
		}

		public void Create(Todo todo)
		{
			todo.CreateDateTime=DateTime.Now;
			todoRepository.Add(todo);
		}

		public void Delete(Todo todo)
		{
			todoRepository.Delete(todo);
		}

		public void Update(Todo todo)
		{
			todoRepository.Update(todo);
		}
	}

	
}
