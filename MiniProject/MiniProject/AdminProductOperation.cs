using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject
{
    class AdminProductOperation
    {
        internal static void getProductAdmin()
        {
            using (var context = new InventoryContext())
            {
                var header = String.Format("--------------------------------------------------------------------------------\n" +
                    "\t\t\tProduct List\n" +
                    "--------------------------------------------------------------------------------\n" +
                    "{0,4}{1,15}{2,15}{3,10}{4,15}\n--------------------------------------------------------------------------------",
                    "ID", "Product Name", "Price", "Quantity", "CategoryID");
                Console.WriteLine(header);
                foreach (var item in context.Products.ToList())
                {
                    var output = String.Format("{0,4}{1,15}{2,15}{3,10}{4,15}", item.ProductID, item.ProductName, item.Price, item.Quantity, item.CategoryID);
                    Console.WriteLine(output);
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }
        }

        internal static void deleteProductAdmin()
        {
            int exit = 0;
            do
            {
                AdminProductOperation.getProductAdmin();
                int temp;
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Enter Product ID to update Product : ");
                    temp = Convert.ToInt32(Console.ReadLine());
                    var data = context.Products.First(a => a.ProductID == temp);
                    if (temp == data.ProductID)
                    {
                        context.Remove(context.Products.Single(a => a.ProductID == temp));
                        context.SaveChanges();
                        Console.WriteLine("\nProduct deleted Successfully!");
                        exit = -1;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct ID");
                    }
                }
            }
            while (exit >= 0);
        }

        internal static void updateProductMenuAdmin()
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
                        updateProductNameAdmin();
                        AdminUserOperations.previousMenu();
                        exit = -1;
                        break;
                    case 2:
                        updatePriceAdmin();
                        AdminUserOperations.previousMenu();
                        exit = -1;
                        break;
                    case 3:
                        updateQuantityAdmin();
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
        static decimal Price;
        static int Quantity;
        static int Exit = 0;
        internal static void addProductAdmin()
        {
            string ProductName;

            int CategoryID;
            do
            {
                Console.Write("Enter product name = ");
                ProductName = Console.ReadLine();
            }
            while (!Validation.ValidateNull(ProductName));
            do {
                try
                {
                    Console.Write("Enter price = ");
                    Price = Convert.ToDecimal(Console.ReadLine());
                }
                catch(Exception e)
                {
                    Console.WriteLine("Price cannot be empty or in Invalid format",e);
                    continue;
                }
                Exit = -1;
            }
            while (Exit >=0);
            do
            {
                try
                {
                    Console.Write("Enter quantity = ");
                    Quantity = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Quantity cannot be empty or in Invalid format", e);
                    continue;
                }
                Exit = -1;
            }
            while (Exit >= 0);
            
            AdminUserOperations.getCategories();
            do
            {
                Console.Write("Enter CategoryID = ");
                CategoryID = Convert.ToInt32(Console.ReadLine());
            } while (CategoryID <= 0 && CategoryID > 4);
            using (var context = new InventoryContext())
            {
                Product prodct = new Product();
                prodct.ProductName = ProductName.ToString();
                prodct.Price = Price;
                prodct.Quantity = Quantity;
                prodct.CategoryID = CategoryID;
                prodct.UserID = Authentication.catchUserID;
                context.Add(prodct);
                context.SaveChanges();
                Console.WriteLine("\nProduct Added Successfully!");
            }

        }

        static void updateProductNameAdmin()
        {
            int exit = 0;
            do
            {
                AdminProductOperation.getProductAdmin();
                int temp;
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Enter Product ID to update Product : ");
                    temp = Convert.ToInt32(Console.ReadLine());

                    var data = context.Products.First(a => a.ProductID == temp);
                    if (temp == data.ProductID)
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
                        Console.WriteLine("Enter correct ID");
                    }
                }


            }
            while (exit >= 0);
        }

        static void updatePriceAdmin()
        {
            int exit = 0;
            do
            {
                AdminProductOperation.getProductAdmin();
                int temp;
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Enter Product ID to update Product : ");
                    temp = Convert.ToInt32(Console.ReadLine());

                    var data = context.Products.First(a => a.ProductID == temp);
                    if (temp == data.ProductID)
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
                        Console.WriteLine("Enter correct ID");
                    }
                }


            }
            while (exit >= 0);
        }
        static void updateQuantityAdmin()
        {
            int exit = 0;
            do
            {
                AdminProductOperation.getProductAdmin();
                int temp;
                using (var context = new InventoryContext())
                {
                    Console.WriteLine("Enter Product ID to update Product : ");
                    temp = Convert.ToInt32(Console.ReadLine());

                    var data = context.Products.First(a => a.ProductID == temp);
                    if (temp == data.ProductID)
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
                        Console.WriteLine("Enter correct ID");
                    }
                }


            }
            while (exit >= 0);
        }

    }
}