using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork_7
{
    internal class Program
    {
        public static void Text(string s)
        {
            Console.WriteLine(s);
        }
        public static string UserChoice()
        {
            string userChoise = Console.ReadLine().Trim().ToUpper();
            return userChoise;
        }
        public static int UserID()
        {
            int userID = Convert.ToInt32($"{Console.ReadLine()})");
            return userID;
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
        public static List<Employee> AddEmployee(List<Employee> employees,Employee employee)
        {
            employees.Add(employee);
            return employees;
        }
        public static List<Employee> DeleteEmployee(List<Employee> employees,int ID)
        {
            employees.RemoveAt(ID - 1);            
            return employees;
        }
        public static List<Employee> ChangeRecord(List<Employee> employees,int ID)
        {
            DeleteEmployee(employees, ID);
            AddEmployee(employees, InitEmployee(ID));
            return employees;
        }
        public static void WriteArrayToFile(string fileName, List<Employee> employees)
        {
            File.AppendAllLines(fileName, (IEnumerable<string>)employees);
        }
        public static void ReadEmployee(List<Employee> employees, int ID)
        {
            Console.WriteLine(employees[ID - 1]);
        }
        public static string[] ReadArrayFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                return File.ReadAllLines(fileName);
            }
            else
            {
                return new string[0];
            }
        }
        public static void ReverseReadFromFile(string fileName, List<Employee> employees)
        {
            employees.Reverse();
            WriteArrayToFile(fileName, employees);
            ReadArrayFromFile(fileName);
        }
        static void Main(string[] args)
        {
            int ID = 1;
            string fileName = "database.txt";
            List<Employee> employees = new List<Employee>();
            while(true)
            {
                int i = 0;
                Text("To add new employee type ADD, to delete type DEL, to change record type CHG, to read database type READ,to read record type REC");
                switch(UserChoice())
                {
                    case "ADD":
                        {
                            AddEmployee(employees, InitEmployee(ID));
                            ID++;
                            continue;
                        }
                    case "DEL":
                        {
                            DeleteEmployee(employees, UserID());
                            continue;
                        }
                    case "CHG":
                        {
                            ChangeRecord(employees, UserID());
                            continue;
                        }
                    case "READ":
                        {
                            ReadArrayFromFile(fileName);
                            continue;
                        }
                    case "REC":
                        {
                            ReadEmployee(employees, UserID());
                            continue;
                        }
                    case "EXIT":
                        {
                            Text("Program executed by user");
                            i = 1;
                            break;
                        }
                }
                if(i == 1)
                {
                    break;
                }
            }
        }
    }
}
