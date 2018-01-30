using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Data;
using TaskManager.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    public class TaskManagerController : Controller
    {
        private readonly ToDoDbContext _context;
        public TaskManagerController(ToDoDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskManager
        [HttpGet]
        public IEnumerable<ToDo> Get() => _context.ToDos;

        // GET: api/TaskManager/{id}
        [HttpGet("{id:int}")]
        public ToDo Get(int id) => _context.ToDos.FirstOrDefault(t => t.ID == id);

        // POST: api/TaskManager/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ToDo todo)
        {
            await _context.AddAsync(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction("Get", todo);
        }

        // PUT: api/TaskManager/{id}
        [HttpPut("{id:int}")]
        public async Task<HttpResponseMessage> Put(int id, [FromBody]ToDo todo)
        {
            var result = _context.ToDos.FirstOrDefault(t => t.ID == id);
            if (result != null)
            {
                result.Description = todo.Description;
                result.Done = todo.Done;
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        // DELETE: api/TaskManager/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _context.ToDos.FirstOrDefault(t => t.ID == id);
            if (result != null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
