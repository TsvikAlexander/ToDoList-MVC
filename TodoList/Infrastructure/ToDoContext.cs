using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Infrastructure
{
    public class ToDoContext : DbContext
    {
        public DbSet<TodoListItem> TodoListItems { get; set; }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoListItem>().HasData(
                new TodoListItem[]
                {
                new TodoListItem { Id=1, Title="Attend courses", AddDate=DateTime.Now, IsDone=false},
                new TodoListItem { Id=2, Title="Go to the store", AddDate=DateTime.Now, IsDone=false},
                new TodoListItem { Id=3, Title="Clean the house", AddDate=DateTime.Now, IsDone=true},
                new TodoListItem { Id=4, Title="Learn programming", AddDate=DateTime.Now, IsDone=true}
                });
        }
    }
}
