using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject
{
    public static class Authentication
    {
        public static int roleCheck;
        public static int catchUserID;
        public static int catchCategoryID;
        //Login Validation Code
        internal static bool LoginValidation()
        {
            string Username, Password;
            Console.WriteLine("Please Enter your credentials to login");
            Console.Write("Enter Username = ");
            Username = Console.ReadLine();
            Console.Write("Enter Password = ");
            Password = Console.ReadLine();

            using (var context = new InventoryContext())
            {
                foreach (var item in context.Users.ToList())
                {
                    if (String.Equals(Username, item.Username) && String.Equals(Password, item.Password))
                    {
                        roleCheck = item.RoleID;
                        catchUserID = (int)item.UserID;
                        if (roleCheck == 1)
                        {
                            catchCategoryID = 0;
                        }
                        else
                        {
                            catchCategoryID = (int)item.CategoryID;
                        }
                        Console.WriteLine("Login Successful as " + item.Username);
                        return true;
                    }

                }

            }
            return false;
        }
        //Check if admin condition
        internal static bool checkAdmin()
        {
            using (var context = new InventoryContext())
            {
                if (roleCheck == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}