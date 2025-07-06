using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_list.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Todo Title")]
        public string Title { get; set; }

        public bool IsCompleted { get; set; }=false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
