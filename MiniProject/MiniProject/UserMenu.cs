using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject
{
    class UserMenu
    {
        internal static void UserOperationsMenu()
        {
            using (var add = new InventoryContext())
            {
                var header = String.Format("--------------------------------------------------------------------------------\n" +
                    "\t\t\tUser Menu\n" +
                    "--------------------------------------------------------------------------------\n" +
                    "{0,-3}{1,-10}\n--------------------------------------------------------------------------------",
                    "ID","Operations");
                Console.WriteLine(header);
                foreach (var name in Enum.GetNames(typeof(userCRUD)))
                {
                    int index = (int)Enum.Parse(typeof(userCRUD), name);
                    var output = String.Format("{0,-3}{1,-10}", index, name);
                    Console.WriteLine(output);
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }


        }
    }
}