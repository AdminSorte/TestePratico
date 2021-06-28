using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Application.Repository;
using Todo.Domain.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Todo.Infrastructure.Repository
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly string _connectionString;

        public TodoTaskRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<TodoTask> GetById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.QuerySingleAsync<TodoTask>("SP_FIND_TODO_TASK_BY_ID", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<List<TodoTask>> GetAllAsync(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.QueryAsync<TodoTask>("SP_FIND_TODO_TASK_BY_USER", parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<int> CreateAsync(TodoTask data)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Title", data.Title, DbType.String, ParameterDirection.Input, 30);
            parameters.Add("@Description", data.Description, DbType.String, ParameterDirection.Input, 200);
            parameters.Add("@DateTodo", data.DateTodo, DbType.DateTime, ParameterDirection.Input);
            parameters.Add("@UserId", data.UserId, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.QuerySingleAsync<int>("SP_CREATE_TODO_TASK", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> UpdateAsync(TodoTask data)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", data.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Title", data.Title, DbType.String, ParameterDirection.Input, 30);
            parameters.Add("@Description", data.Description, DbType.String, ParameterDirection.Input, 200);
            parameters.Add("@DateTodo", data.DateTodo, DbType.DateTime, ParameterDirection.Input);
            
            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.ExecuteAsync("SP_UPDATE_TODO_TASK", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);
            
            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.ExecuteAsync("SP_REMOVE_TODO_TASK", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}