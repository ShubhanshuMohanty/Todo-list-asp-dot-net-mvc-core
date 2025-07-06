using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_list.DataAccess.Data;
using Todo_list.DataAccess.Repository.IRepository;
using Todo_list.Models;

namespace Todo_list.DataAccess.Repository
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        private readonly ApplicationDbContext _db;
        public TodoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Todo obj)
        {
            _db.Todos.Update(obj);
        }
    }
}
