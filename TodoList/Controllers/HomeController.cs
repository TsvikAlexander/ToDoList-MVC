using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoContext context;

        public HomeController(ToDoContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.TodoListItems.OrderBy(s => s.IsDone).ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoListItem item)
        {
            if (!String.IsNullOrEmpty(item.Title))
            {
                item.AddDate = DateTime.Now;
                context.TodoListItems.Update(item);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return NotFound();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                TodoListItem item = await context.TodoListItems.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                {
                    context.TodoListItems.Remove(item);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoListItem item)
        {
            if (!String.IsNullOrEmpty(item.Title))
            {
                item.AddDate = DateTime.Now;
                context.TodoListItems.Add(item);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View("Index", await context.TodoListItems.OrderBy(s => s.IsDone).ToListAsync());
        }

        public async Task<IActionResult> ToggleIsDone(int? id)
        {
            if (id != null)
            {
                TodoListItem item = await context.TodoListItems.FirstOrDefaultAsync(p => p.Id == id);
                if (item != null)
                {
                    item.IsDone = !item.IsDone;
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
