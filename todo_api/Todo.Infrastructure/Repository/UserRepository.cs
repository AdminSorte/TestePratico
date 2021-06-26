using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Todo.Application.Repository;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<User> FindById(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.QuerySingleAsync<User>("SP_FIND_USER_BY_ID", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<User> FindByEmail(string email)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Email", email, DbType.String, ParameterDirection.Input, 100);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.QuerySingleAsync<User>("SP_FIND_USER_BY_EMAIL", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<int> CreateAsync(User data)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", data.Name, DbType.String, ParameterDirection.Input, 60);
            parameters.Add("@LastName", data.LastName, DbType.String, ParameterDirection.Input, 60);
            parameters.Add("@Email", data.Email, DbType.String, ParameterDirection.Input, 100);
            parameters.Add("@Password", data.Password, DbType.String, ParameterDirection.Input, int.MaxValue);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.QuerySingleAsync<int>("SP_CREATE_USER", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<bool> UpdateAsync(User data)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", data.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Name", data.Name, DbType.String, ParameterDirection.Input, 60);
            parameters.Add("@LastName", data.LastName, DbType.String, ParameterDirection.Input, 60);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.ExecuteAsync("SP_UPDATE_USER", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> ChangePasswordAsync(User data)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", data.Id, DbType.Int32, ParameterDirection.Input);
            parameters.Add("@Password", data.Password, DbType.String, ParameterDirection.Input, int.MaxValue);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.ExecuteAsync("SP_CHANGE_PASSWORD", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            using (var connection = new SqlConnection(_connectionString)) {
                var result = await connection.ExecuteAsync("SP_REMOVE_USER", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
    }
}