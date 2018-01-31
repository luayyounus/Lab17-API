using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskManager.Controllers;
using TaskManager.Data;
using TaskManager.Models;
using Xunit;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using TaskManager;

namespace XUnitTestTaskManager
{
    public class UnitTest1
    {
        [Fact]
        public void TestGettingAllTodosInDb()
        {
            ToDoDbContext _context;
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (_context = new ToDoDbContext(options))
            {
                List<ToDo> testTodos = GetTodosObjects();

                // Adding two objects into the context to check if both are stored in database
                foreach (ToDo x in testTodos) _context.ToDos.AddAsync(x);
                _context.SaveChangesAsync();

                // Arrange
                TaskManagerController taskManagerController = new TaskManagerController(_context);

                // Act
                IEnumerable<ToDo> result = taskManagerController.Get();
                List<ToDo> resultList = result.ToList();

                // Assert
                Assert.Equal(testTodos.Count, resultList.Count);
            }
        }

        [Fact]
        public async void TestPostTodoToDb()
        {
            ToDoDbContext _context;
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            TestServer _server;
            HttpClient _client;
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();

            using (_context = new ToDoDbContext(options))
            {
                List<ToDo> testTodos = GetTodosObjects();

                // Arrange
                TaskManagerController taskManagerController = new TaskManagerController(_context);

                // Act
                var result = taskManagerController.Post(testTodos[0]);
                //var response = await _client.PostAsync("", HttpResponseMessage(StatusCodeResult))

                // Assert
                Assert.NotNull(result);

            }
        }

        private List<ToDo> GetTodosObjects()
        {
            return new List<ToDo>
            {
                new ToDo
                {
                    ID = 1,
                    Description = "Go to work!",
                    Done = true
                },
                new ToDo
                {
                    ID = 2,
                    Description = "Eat lunch!",
                    Done = false
                }
            };
        }
    }
}
