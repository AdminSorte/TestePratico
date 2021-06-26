using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Application.Repository;
using Todo.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Todo.Infrastructure.Repository
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly string _connectionString;

        public TodoTaskRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<TodoTask> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<TodoTask>> GetAllAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> CreateAsync(TodoTask data)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(TodoTask data)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}