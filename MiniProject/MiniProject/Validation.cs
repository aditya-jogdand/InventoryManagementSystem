using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniProject
{
    public static class Validation
    {
        internal static bool ValidateNull(string input)
        {
            if (input == "" || input == null)
            {
                Console.WriteLine("Field cannot be blank");
                return false;
            }
            return true;
        }

        internal static bool UserExists(string input)
        {
            using (var context = new InventoryContext())
            {
                foreach (var item in context.Users.ToList())
                {
                    if (String.Equals(input, item.Username))
                    {
                        Console.WriteLine("User Already Exists!");
                        return false;
                    }
                }
                return true;
            }
        }

        internal static bool ValidatePassword(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{6,12}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (!hasNumber.IsMatch(input)|| !hasUpperChar.IsMatch(input)|| !hasLowerChar.IsMatch(input)|| !hasMiniMaxChars.IsMatch(input)|| !hasSymbols.IsMatch(input))
            {
                Console.WriteLine("Password should contain 6-10 Characters with atleast 1 Upper Case, 1 Lower Case, 1 Symbol and 1 Number");
                return false;
            }
            return true;
        }
    }
}
