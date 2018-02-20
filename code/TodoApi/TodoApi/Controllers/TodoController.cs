using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using System.Linq;

/*
# Add a controller
In Solution Explorer, right-click the Controllers folder. Select Add > New Item.
In the Add New Item dialog, select the Web API Controller Class template. 
Name the class TodoController


This code:

* Defines an empty controller class. In the next sections, methods are added to implement the API.
* The constructor uses Dependency Injection to inject the database context (TodoContext) into the controller. 
* The database context is used in each of the CRUD methods in the controller.
* The constructor adds an item to the in-memory database if one doesn't exist
*/

namespace TodoApi.Controllers
{
    
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;


        //Constructor
        public TodoController(TodoContext context)
        {
            _context = context;

            if(_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        //Get all todo items
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return _context.TodoItems.ToList();
        }

        //Get the todo item by id
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);

            if(item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //Create a new todo item
        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if(item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
