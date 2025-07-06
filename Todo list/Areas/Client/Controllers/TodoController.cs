using Microsoft.AspNetCore.Mvc;
using Todo_list.DataAccess.Repository.IRepository;
using Todo_list.Models;
using Todo_list.Models.ViewModels;

namespace Todo_list.Areas.Client.Controllers
{
    [Area("Client")]
    public class TodoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TodoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            TodoVM todos = new TodoVM()
            {
                TodoList = _unitOfWork.Todo.GetAll().ToList(),
                NewTodo = new Todo()
            };

            return View(todos);
        }
        [HttpPost]
        public IActionResult Index(TodoVM obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.Todo.Add(obj.NewTodo);
                _unitOfWork.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        #region API CALLS
        [HttpPatch]
        public IActionResult Update([FromBody] Todo todo)
        {
            if (ModelState.IsValid)
            {
                var todoFromDb = _unitOfWork.Todo.Get(u => u.Id == todo.Id);
                if (todoFromDb != null)
                {
                    try
                    {
                        todoFromDb.Title= todo.Title;
                        //todoFromDb.IsCompleted = todo.IsCompleted;
                        _unitOfWork.Todo.Update(todoFromDb);
                        _unitOfWork.Save();
                        return Json(new { data = "update" });
                    }
                    catch (Exception ex)
                    {
                        return Json(new { data = "error", message = ex.Message });
                    }
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var todoFromDb = _unitOfWork.Todo.Get(u => u.Id == id);
            if (todoFromDb != null)
            {
                try
                {
                    _unitOfWork.Todo.Remove(todoFromDb);
                    _unitOfWork.Save();
                    return Json(new { data = "delete" });
                }
                catch (Exception ex)
                {
                    return Json(new { data = "error", message = ex.Message });
                }

            }
            return NotFound();
        }
        #endregion
    }
}
