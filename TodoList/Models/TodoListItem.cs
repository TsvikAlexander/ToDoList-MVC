using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class TodoListItem
    {
        public int Id { get; set; }

        public DateTime AddDate { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsDone { get; set; }
    }
}
