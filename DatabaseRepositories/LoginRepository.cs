using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SailingBackend.ApplicationClasses;

namespace SailingBackend.DatabaseRepositories
{
    /// <summary>
    /// Contains database logic for authentication
    /// </summary>
    public static class LoginRepository
    {
        /// <summary>
        /// get user's full name
        /// </summary>
        /// <param name="id"> int userid </param>
        /// <returns> string name </returns>
        public static string GetUserFullName(int id)
        {
            using var connection = DatabaseConnectionRepository.Connect();
            string name = null;
            try
            {
                name = connection.ExecuteScalar<string>(
                sql: "SELECT FullName FROM Users WHERE UserID=@ID",
                param: new
                {
                    @ID = id
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return name;
        }

        /// <summary>
        /// get user's id from email
        /// </summary>
        /// <param name="email"> string email </param>
        /// <returns> int id </returns>
        public static int GetUserId(string email)
        {
            int userId = -1;
            using var connection = DatabaseConnectionRepository.Connect();
            try
            {
                userId = connection.QueryFirst<int>(
                sql: "SELECT UserID FROM Users WHERE Email=@EMAIL",
                param: new { @EMAIL = email }
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return userId;
        }

        /// <summary>
        /// Get user login details
        /// </summary>
        /// <param name="email"> string email </param>
        /// <param name="password"> string password </param>
        /// <returns> Object of type LoggedInUser </returns>
        public static LoggedInUser GetLoginInformation(string email, string password)
        {
            LoggedInUser loggedInUser = new LoggedInUser { };
            using var connection = DatabaseConnectionRepository.Connect();
            try 
            {
                if (connection.ExecuteScalar<bool>(
                    sql: "SELECT COUNT(1) FROM Users WHERE Email=@EMAIL AND Password=@PASSWORD", 
                    param: new 
                    {
                        @EMAIL = email,
                        @PASSWORD = password
                    })
                )
                {
                    loggedInUser = connection.QueryFirst<LoggedInUser>(
                    sql: "SELECT * FROM Users WHERE Email=@EMAIL AND Password=@PASSWORD",
                    param: new
                    {
                        @EMAIL = email,
                        @PASSWORD = password
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return loggedInUser;
        }

        /// <summary>
        /// Register 
        /// </summary>
        /// <param name="email"> string email </param>
        /// <param name="fullname"> string fullname </param>
        /// <param name="password"> string password </param>
        /// <returns>
        /// bool that reflects success
        /// </returns>
        public static bool IsValidRegistration(string email, string fullname, string password)
        {
            bool IsValidRegistration = false;
            using var connection = DatabaseConnectionRepository.Connect();
            try
            {
                if (IsEmailFree(email))
                {
                    connection.ExecuteScalar<bool>
                        (
                            sql: @"
                            INSERT INTO Users 
                            (
                                Email, 
                                FullName, 
                                Password, 
                                IsAdmin
                            ) 
                            VALUES 
                            (
                                @EMAIL, 
                                @FULLNAME, 
                                @PASSWORD, 
                                False
                            )
                            ",
                            param: new
                            {
                                @EMAIL = email,
                                @FULLNAME = fullname,
                                @PASSWORD = password
                            }
                        );
                    IsValidRegistration = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return IsValidRegistration;
        }

        /// <summary>
        /// Check if email is free
        /// </summary>
        /// <param name="email"> string email </param>
        /// <returns> boolean </returns>
        public static bool IsEmailFree(string email)
        {
            bool IsEmailUsed = false;
            using var connection = DatabaseConnectionRepository.Connect();
            try 
            {
                IsEmailUsed = connection.ExecuteScalar<bool>
                (
                    sql: "SELECT COUNT(1) FROM Users WHERE Email=@EMAIL",
                    param: new { @EMAIL = email }
                );
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return !IsEmailUsed;
        }

        /// <summary>
        /// check if user is admin
        /// </summary>
        /// <param name="email"> string email </param>
        /// <returns> boolean </returns>
        public static bool UserIsAdmin(string email)
        {
            bool IsAdmin = false;
            using var connection = DatabaseConnectionRepository.Connect();
            try
            {
                IsAdmin = connection.ExecuteScalar<bool>
                (
                    sql: "SELECT COUNT(1) FROM Users WHERE Email=@EMAIL AND IsAdmin = 1",
                    param: new { @EMAIL = email }
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return IsAdmin;
        }

    }
}
