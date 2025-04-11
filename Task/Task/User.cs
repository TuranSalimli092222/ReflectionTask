using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class User
    {
        private int id;
        private string name;
        private string surname;
        private static int age;

        public void GetFullName()
        {
            Console.WriteLine($"{name} {surname}");
        }

        public static void ChangeAge(int newAge)
        {
            age = newAge;
        }
    }


}
