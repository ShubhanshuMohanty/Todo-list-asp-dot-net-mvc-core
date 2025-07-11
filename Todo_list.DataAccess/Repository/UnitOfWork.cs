﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_list.DataAccess.Data;
using Todo_list.DataAccess.Repository.IRepository;

namespace Todo_list.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ITodoRepository Todo { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Todo = new TodoRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
