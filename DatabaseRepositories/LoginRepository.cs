using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace SailingBackend.DatabaseRepositories
{
    public static class LoginRepository
    {
        public static ApplicationClasses.LoggedInUser GetLoginInformation(string email, string password)
        {
            ApplicationClasses.LoggedInUser loggedInUser = new ApplicationClasses.LoggedInUser { };
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
                    loggedInUser = connection.QueryFirst<ApplicationClasses.LoggedInUser>(
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
                            sql: "INSERT INTO Users (Email, FullName, Password, IsAdmin) VALUES (@EMAIL, @FULLNAME, @PASSWORD, False)",
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

        public static bool IsEmailFree(string email)
        {
            bool IsEmailUsed = false;
            using var connection = DatabaseConnectionRepository.Connect();
            try 
            {
                IsEmailUsed = connection.ExecuteScalar<bool>
                (
                    sql: "SELECT COUNT(1) FROM Users WHERE Email=@EMAIL",
                    param: new
                    {
                        @EMAIL = email
                    }
                );
            } 
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            return !IsEmailUsed;
        }

        public static bool UserIsAdmin(string email)
        {
            bool IsAdmin = false;
            using var connection = DatabaseConnectionRepository.Connect();
            try
            {
                IsAdmin = connection.ExecuteScalar<bool>
                (
                    sql: "SELECT COUNT(1) FROM Users WHERE Email=@EMAIL AND IsAdmin = 1",
                    param: new
                    {
                        @EMAIL = email
                    }
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
