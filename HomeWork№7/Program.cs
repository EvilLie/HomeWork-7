using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    internal class Program
    {
        public static void Text(string s)
        {
            Console.WriteLine(s);
        }
        public static Employee InitEmployee(int ID)
        {
            Employee employee = new Employee();
            employee.ID = ID;
            employee.DateOfCreating = DateTime.Now;
            Text("Please enter full name of emloyee: ");
            employee.FullName = $"{Console.ReadLine()}#";
            Text("Please enter age of new employee: ");
            employee.Age = Convert.ToInt32($"{Console.ReadLine()}#");
            Text("Please enter height of new employee: ");
            employee.Height = Convert.ToInt32($"{Console.ReadLine()}#");
            Text("Enter date of birth: DD.MM.YYYY");
            employee.DateOfBirth = Convert.ToDateTime("{Console.ReadLine()}#");
            Text("Enter place of birth");
            employee.PlaceOfBirth = $"{Console.ReadLine()}#";
            return employee;
        }
        public static string Employee(Employee employee)
        {
            string s = $"{employee.ID}#" + $"{employee.DateOfCreating}#" + employee.FullName + employee.Age + employee.Height + employee.DateOfBirth + employee.PlaceOfBirth; 
            return s;
        }
        public static void WriteToFile(string fileName, string s)
        {
            File.AppendAllText(fileName, s);
        }     
        static void Main(string[] args)
        {
            int ID = 1;
        }
    }
}
