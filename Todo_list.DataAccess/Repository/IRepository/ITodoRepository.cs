using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_list.Models;

namespace Todo_list.DataAccess.Repository.IRepository
{
    public interface ITodoRepository : IRepository<Todo>
    {
        void Update(Todo obj);
    }
}
