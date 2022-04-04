using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject
{
    class UserProductOperations
    {
        internal static void addProduct()
        {
            string ProductName;
            decimal Price;
            int Quantity;
            Console.Write("Enter product name = ");
            ProductName = Console.ReadLine();
            Console.Write("Enter price = ");
            Price = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter quantity = ");
            Quantity = Convert.ToInt32(Console.ReadLine());
            using (var context = new InventoryContext())
            {
                Product p = new Product();
                p.ProductName = ProductName.ToString();
                p.Price = Price;
                p.Quantity = Quantity;
                p.CategoryID = Authentication.catchCategoryID;
                p.UserID = Authentication.catchUserID;
                context.Add(p);
                context.SaveChanges();
                Console.WriteLine("\nProduct Added Successfully!");
            }
        }

        internal static void getProduct()
        {
            using (var context = new InventoryContext())
            {
                var header = String.Format("--------------------------------------------------------------------------------\n" +
                    "\t\t\tProduct List\n" +
                    "--------------------------------------------------------------------------------\n" +
                    "{0,4}{1,15}{2,15}{3,10}{4,15}\n--------------------------------------------------------------------------------",
                    "ID", "Username", "Price", "Quantity", "CategoryID");
                Console.WriteLine(header);
                var data = context.Products.Where(a => a.CategoryID == Authentication.catchCategoryID);
                foreach (var item in data.ToList())
                {
                    var output = String.Format("{0,4}{1,15}{2,15}{3,10}{4,15}", item.ProductID, item.ProductName, item.Price, item.Quantity, item.CategoryID);
                    Console.WriteLine(output);
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }

        internal static void deleteProduct()
        {
            int exit = 0;
            do
            {
                UserProductOperations.getProduct();
                int id;
                var data = new Product();
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Enter Product ID to Delete Product : ");
                    id = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        data = context.Products.First(a => a.ProductID == id);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("ID Not Found");
                        continue;
                    }
                    if (Authentication.catchCategoryID == data.CategoryID)
                    {
                        context.Remove(context.Products.Single(a => a.ProductID == id));
                        context.SaveChanges();
                        Console.WriteLine("\nProduct deleted Successfully!");
                        exit = -1;
                    }
                    else
                    {
                        Console.WriteLine("You are not allowed to change another category details");
                    }
                }
            }
            while (exit >= 0);
        }
        internal static void updateProduct()
        {
            int exit = 0;
            do
            {
                Console.WriteLine("Choose the Operation : ");
                Console.WriteLine("1. Update Product Name\n2. Update Product Price\n3. Update Product Quantity.");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        updateProductName();
                        AdminUserOperations.previousMenu();
                        exit = -1;
                        break;
                    case 2:
                        updatePrice();
                        AdminUserOperations.previousMenu();
                        exit = -1;
                        break;
                    case 3:
                        updateQuantity();
                        AdminUserOperations.previousMenu();
                        exit = -1;
                        break;
                    default:
                        Console.WriteLine("Enter correct input");
                        break;
                }
            }
            while (exit >= 0);
        }


        static void updateProductName()
        {
            int exit = 0;
            do
            {
                UserProductOperations.getProduct();
                int temp;
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Enter Product ID to update Product : ");
                    temp = Convert.ToInt32(Console.ReadLine());

                    var data = context.Products.First(a => a.ProductID == temp);
                    if (Authentication.catchCategoryID == data.CategoryID)
                    {
                        Console.WriteLine("Enter Product Name :");
                        string productName = Console.ReadLine();
                        data.ProductName = productName;
                        context.SaveChanges();
                        Console.WriteLine("\nProduct Name updated Successfully!");
                        exit = -1;
                    }
                    else
                    {
                        Console.WriteLine("You are not allowed to change another category details");
                    }
                }
            }
            while (exit >= 0);
        }
        static void updatePrice()
        {
            int exit = 0;
            do
            {
                UserProductOperations.getProduct();
                int temp;
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Enter Product ID to update Product : ");
                    temp = Convert.ToInt32(Console.ReadLine());

                    var data = context.Products.First(a => a.ProductID == temp);
                    if (Authentication.catchCategoryID == data.CategoryID)
                    {
                        Console.WriteLine("Enter Product Price :");
                        int productPrice = Convert.ToInt32(Console.ReadLine());
                        data.Price = productPrice;
                        context.SaveChanges();
                        Console.WriteLine("\nProduct Price updated Successfully!");
                        exit = -1;
                    }
                    else
                    {
                        Console.WriteLine("You are not allowed to change another category details");
                    }
                }
            }
            while (exit >= 0);
        }
        static void updateQuantity()
        {
            int exit = 0;
            do
            {
                UserProductOperations.getProduct();
                int temp;
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Enter Product ID to update Product : ");
                    temp = Convert.ToInt32(Console.ReadLine());

                    var data = context.Products.First(a => a.ProductID == temp);
                    if (Authentication.catchCategoryID == data.CategoryID)
                    {
                        Console.WriteLine("Enter Product Quantity :");
                        int productQuantity = Convert.ToInt32(Console.ReadLine());
                        data.Quantity = productQuantity;
                        context.SaveChanges();
                        Console.WriteLine("\nProduct Quantity updated Successfully!");
                        exit = -1;
                    }
                    else
                    {
                        Console.WriteLine("You are not allowed to change another category details");
                    }
                }
            }
            while (exit >= 0);
        }
    }
}