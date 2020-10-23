using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UserApiModels;

namespace UserApiWeb
{
    public class UserRepository : IUserRepository
    {
        string _connectionString = null;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<User> GetUsers()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users").ToList();
            }
        }

        public User Get(string iin)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE IIN = @IIN", new { IIN = iin }).FirstOrDefault();
            }
        }

        public void Create(User user)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Users (IIN, FirstName, LastName, BirthDate) VALUES(@IIN, @FirstName, @LastName, @BirthDate)";
                db.Execute(sqlQuery, user);

                // если мы хотим получить id добавленного пользователя
                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }
        }

        public void Update(User user)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName WHERE IIN = @IIN";
                db.Execute(sqlQuery, user);
            }
        }

        public void Delete(string iin)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Users WHERE IIN = @IIN";
                db.Execute(sqlQuery, new { iin });
            }
        }
    }
}
