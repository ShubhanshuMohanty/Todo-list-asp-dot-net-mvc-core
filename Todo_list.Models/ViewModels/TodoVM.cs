using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_list.Models.ViewModels
{
    public class TodoVM
    {
        public List<Todo> TodoList { get; set; } = new List<Todo>();
        public Todo NewTodo { get; set; } = new Todo();
    }
}
