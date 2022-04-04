using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject
{
    enum Categories { Iphone = 1, Ipad = 2, IWatch = 3, MacBook = 4 }
    public static class AdminUserOperations
    {
        internal static void addRole()
        {
            string UserRole;
            Console.Write("Enter User Role = ");
            UserRole = Console.ReadLine();
            using (var context = new InventoryContext())
            {
                Role r = new Role();
                r.RoleName = UserRole.ToString();
                context.Add(r);
                context.SaveChanges();
            }
        }

        internal static void addCategory()
        {
            string Category;
            Console.WriteLine("Add Category Menu");
            Console.Write("Enter Category Name = ");
            Category = Console.ReadLine();
            using (var context = new InventoryContext())
            {
                Category r = new Category();
                r.CategoryName = Category.ToString();
                context.Add(r);
                context.SaveChanges();
            }
        }


        internal static void addUser()
        {
            int addUserFlag = 0;
            do
            {
                string Username, Password;
                int Role, Category;
                Console.WriteLine("Add User Menu");
                do
                {
                    Console.Write("Enter Username = ");
                    Username = Console.ReadLine();
                }
                while (!Validation.ValidateNull(Username) || !Validation.UserExists(Username));
                do
                {
                    Console.Write("Enter Password = ");
                    Password = Console.ReadLine();
                }
                while (!Validation.ValidateNull(Password) || !Validation.ValidatePassword(Password));
                Console.WriteLine("Enter User Role");

                foreach (var name in Enum.GetNames(typeof(Roles)))
                {
                    int index = (int)Enum.Parse(typeof(Roles), name);
                    Console.WriteLine(index + "." + name);
                }
                String read;
                do
                {
                    Console.Write("Enter Response = ");
                    read = Console.ReadLine();
                }
                while (!Validation.ValidateNull(read));
                Role = int.Parse(read);

                switch (Role)
                {
                    case (int)Roles.Admin:

                        using (var context = new InventoryContext())
                        {
                            User usr = new User();
                            usr.Username = Username;
                            usr.Password = Password;
                            usr.RoleID = Role;
                            context.Add(usr);
                            context.SaveChanges();
                            Console.WriteLine("User Added Successfully!");
                            addUserFlag = -1;
                        }
                        break;

                    case (int)Roles.User:

                        Console.WriteLine("Enter Category to be assigned to user");
                        foreach (var name in Enum.GetNames(typeof(Categories)))
                        {
                            int index = (int)Enum.Parse(typeof(Categories), name);
                            Console.WriteLine(index + "." + name);
                        }

                        Console.Write("Enter Respones = ");
                        Category = int.Parse(Console.ReadLine());

                        using (var context = new InventoryContext())
                        {
                            User usr = new User();
                            usr.Username = Username;
                            usr.Password = Password;
                            usr.RoleID = Role;
                            usr.CategoryID = Category;
                            context.Add(usr);
                            context.SaveChanges();
                            Console.WriteLine("User Added Successfully!");
                            addUserFlag = -1;
                        }
                        break;

                    default:
                        Console.WriteLine("Enter Correct value");
                        break;
                }
            }
            while (addUserFlag >= 0);
        }

        //Update User details
        internal static void updateUser()
        {
            int addUserFlag = 0;
            do
            {
                string Username, Password;
                int Role, Category, id;
                Console.WriteLine("Update User Menu");
                getUsers();
                Console.WriteLine("Enter User ID");
                string tempID = Console.ReadLine();
                id = int.Parse(tempID);
                Console.Write("Enter Username = ");
                Username = Console.ReadLine();
                Console.Write("Enter Password = ");
                Password = Console.ReadLine();

                Console.WriteLine("Enter User Role");
                foreach (var name in Enum.GetNames(typeof(Roles)))
                {
                    int index = (int)Enum.Parse(typeof(Roles), name);
                    Console.WriteLine(index + "." + name);
                }
                Console.Write("Enter Response = ");
                String readLine = Console.ReadLine();
                Role = int.Parse(readLine);
                switch (Role)
                {
                    case (int)Roles.Admin:
                        using (var add = new InventoryContext())
                        {
                            User r = new User();
                            r.Username = Username;
                            r.Password = Password;
                            r.RoleID = Role;
                            r.UserID = id;
                            add.Update(r);
                            add.SaveChanges();
                            Console.WriteLine("User Updated Successfully!");
                            addUserFlag = -1;
                        }
                        break;


                    case (int)Roles.User:

                        Console.WriteLine("Enter Category to be assigned to user");
                        foreach (var name in Enum.GetNames(typeof(Categories)))
                        {
                            int index = (int)Enum.Parse(typeof(Categories), name);
                            Console.WriteLine(index + "." + name);
                        }
                        Console.Write("Enter Respones = ");
                        Category = int.Parse(Console.ReadLine());
                        using (var add = new InventoryContext())
                        {
                            User r = new User();
                            r.Username = Username;
                            r.Password = Password;
                            r.RoleID = Role;
                            r.CategoryID = Category;
                            r.UserID = id;
                            add.Update(r);
                            add.SaveChanges();
                            Console.WriteLine("User Updated Successfully!");
                            addUserFlag = -1;
                        }
                        break;

                    default:
                        Console.WriteLine("Enter Correct value");
                        break;
                }
            }
            while (addUserFlag >= 0);
        }

        //Delete User
        internal static void deleteUser()
        {
            int exit = 0;

            do
            {
                int id;

                var data = new User();
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Delete User Menu");
                    getUsers();
                    Console.WriteLine("Enter User ID to Delete User");
                    id = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        data = context.Users.First(a => a.UserID == id);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ID Not Found");
                        continue;
                    }
                    context.Remove(context.Users.Single(a => a.UserID == id));
                    context.SaveChanges();
                    Console.WriteLine("\nProduct deleted Successfully!");
                    exit = -1;
                }

            } while (exit >= 0);
        }


        //Fetch All Users from database
        internal static void getUsers()
        {
            using (var context = new InventoryContext())
            {
                var header = String.Format("--------------------------------------------------------------------------------\n" +
                    "\t\t\tUsers List\n" +
                    "--------------------------------------------------------------------------------\n" +
                    "{0,4}{1,15}{2,15}{3,10}{4,15}\n--------------------------------------------------------------------------------",
                    "ID", "Username", "Password", "RoleID", "CategoryID");
                Console.WriteLine(header);
                foreach (var item in context.Users.ToList())
                {
                    var output = String.Format("{0,4}{1,15}{2,15}{3,10}{4,15}", item.UserID, item.Username, item.Password, item.RoleID, item.CategoryID);
                    Console.WriteLine(output);
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }

        //Show All Categories - ENUM indexing pending
        internal static void getCategories()
        {
            foreach (var name in Enum.GetNames(typeof(Categories)))
            {
                int index = (int)Enum.Parse(typeof(Categories), name);
                Console.WriteLine(index + "." + name);
            }

        }

        internal static void previousMenu()
        {
            Console.WriteLine("Enter any key to go back to Main Menu");
            Console.ReadLine();
        }




    }
}

