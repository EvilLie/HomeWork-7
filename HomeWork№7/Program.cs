﻿using System;
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
        public static int FindID(string[] employees)
        {
            if(employees.Length!=0)
            {
                int lastIndex = employees.Length;
                int firstSplit = employees[lastIndex - 1].IndexOf("#", 0);
                return Convert.ToInt32(employees[lastIndex - 1].Substring(0, firstSplit));
            }
            else
            {
                Text("Database is empty");
                return new int();
            }           
        }
        public static int UserID()
        {
            Text("Enter ID of record you need");
            int userID = Convert.ToInt32(Console.ReadLine());
            return userID;
        }
        public static Employee InitEmployee(int ID)
        {
            int i = 0, j = 0, h = 0;
            Employee employee = new Employee();
            employee.ID = ID;
            employee.DateOfCreating = DateTime.Now;
            Text("Please enter full name of emloyee: ");
            employee.FullName = $"{Console.ReadLine()}";
            Text("Please enter age of new employee: ");
            while (j == 0)
            {
                if (int.TryParse(Console.ReadLine(), out int age))
                {
                    employee.Age = age;
                    j++;
                }
                else
                {
                    Text("Wrong format of age, try again");
                }
            }
            Text("Please enter height of new employee: ");
            while (h == 0)
            {
                if (int.TryParse(Console.ReadLine(), out int height))
                {
                    employee.Height = height;
                    h++;
                }
                else
                {
                    Text("Wrong format of height, try again");
                }
            }
            Text("Enter date of birth: DD.MM.YYYY");
            while (i == 0)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                {
                    employee.DateOfBirth = dateOfBirth;
                    i++;
                }
                else
                {
                    Text("Wrong format of datetime, try again");
                }
            }

            Text("Enter place of birth");
            employee.PlaceOfBirth = $"{Console.ReadLine()}";
            return employee;
        }
        public static string ConvertEmployee(Employee employee)
        {
            string s = $"{employee.ID}#{employee.DateOfCreating}#{employee.FullName}#{employee.Age}#{employee.Height}#{employee.DateOfBirth}#{employee.PlaceOfBirth}#";
            return s;
        }
        public static List<string> FillArray(List<string> employees, string[] employeesStr)
        {
            foreach(string employee in employeesStr)
            {
                employees.Add(employee);
            }
            return employees;
        }
        public static List<string> AddEmployee(List<string> employees, Employee employee)
        {
            employees.Add(ConvertEmployee(employee));
            return employees;
        }
        public static List<string> DeleteEmployee(List<string> employees, int ID)
        {
            employees.RemoveAt(ID - 1);
            return employees;
        }
        public static List<string> ChangeRecord(List<string> employees, int ID)
        {
            DeleteEmployee(employees, ID);
            AddEmployee(employees, InitEmployee(ID));
            return employees;
        }
        public static void WriteArrayToFile(string fileName, List<string> employees)
        {
            File.AppendAllLines(fileName, (IEnumerable<string>)employees);
        }
        public static void RecreateFile(string fileName, List<string> employees)
        {
            File.Delete(fileName);
            WriteArrayToFile(fileName, employees);
        }
        public static void ReadEmployee(List<string> employees, int ID)
        {
            try
            {
                Text(employees[ID - 1]);
            }
            catch
            {
                Text("There is no record with ID like that");
            }
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
        static void Main(string[] args)
        {

            string fileName = "database.txt";
            List<string> employees = new List<string>();
            FillArray(employees, ReadArrayFromFile(fileName));
            int ID = FindID(ReadArrayFromFile(fileName)) + 1;
            while (true)
            {
                int i = 0;
                Text("To add new employee type ADD, to delete type DEL, to change record type CHG,\n to read record type REC and to exit type EXIT");
                switch (UserChoice())
                {
                    case "ADD":
                        {
                            AddEmployee(employees, InitEmployee(ID));
                            ID++;
                            RecreateFile(fileName, employees);
                            continue;
                        }
                    case "DEL":
                        {
                            DeleteEmployee(employees, UserID());
                            RecreateFile(fileName, employees);
                            continue;
                        }
                    case "CHG":
                        {
                            ChangeRecord(employees, UserID());
                            RecreateFile(fileName, employees);
                            continue;
                        }
                    case "REC":
                        {
                            ReadArrayFromFile(fileName);
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
                if (i == 1)
                {
                    break;
                }
            }
        }
    }
}