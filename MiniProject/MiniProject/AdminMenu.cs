using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject
{
    class AdminMenu
    {
        internal static void AdminOperationsMenu()
        {
            using (var context = new InventoryContext())
            {
                var header = String.Format("--------------------------------------------------------------------------------\n" +
                    "\t\t\tAdmin Menu\n" +
                    "--------------------------------------------------------------------------------\n" +
                    "{0,-3}{1,-10}\n--------------------------------------------------------------------------------",
                    "ID", "Operations");
                Console.WriteLine(header);
                foreach (var name in Enum.GetNames(typeof(adminCRUD)))
                {

                    int index = (int)Enum.Parse(typeof(adminCRUD), name);
                    var output = String.Format("{0,-3}{1,-10}", index, name);
                    Console.WriteLine(output);
                }
                Console.WriteLine("--------------------------------------------------------------------------------");
            }


        }
    }
}
