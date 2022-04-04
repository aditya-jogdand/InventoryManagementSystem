using MiniProject.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace MiniProject

{
    enum Roles { Admin = 1, User = 2 }
    enum userCRUD { Exit, AddProduct, GetProduct, UpdateProduct, DeleteProduct }
    enum adminCRUD { Exit, AddUser, ShowUsers, UpdateUser, DeleteUser, AddProduct, ShowProduct, UpdateProduct, DeleteProduct }
    class Program
    {

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            int exitApplication;
            Console.WriteLine("Welcome to Inventory Management System ");
            do
            {
                if (Authentication.LoginValidation())
                {
                    if (Authentication.checkAdmin())
                    {
                        //Admin Menu
                        int adminOperation = 0;
                        do
                        {
                            AdminMenu.AdminOperationsMenu();
                            string tempValue = Console.ReadLine();
                            int choice = int.Parse(tempValue);
                            switch (choice)
                            {
                                case 0:
                                    adminOperation = -1;
                                    break;

                                case 1:
                                    AdminUserOperations.addUser();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 2:
                                    AdminUserOperations.getUsers();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 3:
                                    AdminUserOperations.updateUser();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 4:
                                    AdminUserOperations.deleteUser();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 5:
                                    AdminProductOperation.addProductAdmin();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 6:
                                    AdminProductOperation.getProductAdmin();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 7:
                                    AdminProductOperation.updateProductMenuAdmin();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 8:
                                    AdminProductOperation.deleteProductAdmin();
                                    AdminUserOperations.previousMenu();
                                    break;

                                default:
                                    Console.WriteLine("Enter correct input");
                                    AdminUserOperations.previousMenu();
                                    break;
                            }
                        }
                        while (adminOperation >= 0);
                        adminOperation = -1;
                        //exitApplication = -1;
                    }

                    //User Code Here
                    else
                    {
                        int userOperation = 0;
                        do
                        {
                            UserMenu.UserOperationsMenu();
                            int choice = Convert.ToInt32(Console.ReadLine());
                            switch (choice)
                            {
                                case 0:
                                    userOperation = -1;
                                    break;

                                case 1:
                                    UserProductOperations.addProduct();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 2:
                                    UserProductOperations.getProduct();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 3:
                                    UserProductOperations.updateProduct();
                                    AdminUserOperations.previousMenu();
                                    break;

                                case 4:
                                    UserProductOperations.deleteProduct();
                                    AdminUserOperations.previousMenu();
                                    break;

                                default:
                                    Console.WriteLine("Enter correct input");
                                    AdminUserOperations.previousMenu();
                                    break;
                            }
                        }
                        while (userOperation >= 0);
                        userOperation = -1;
                        //exitApplication = -1;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid credentials");
                }
                Console.WriteLine("Do you want to Continue ?\n 0.Exit\n 1.Login");
                exitApplication = Convert.ToInt32(Console.ReadLine());
            }
            while (exitApplication != 0);


        }





    }









}


