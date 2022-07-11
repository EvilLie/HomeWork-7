using System;

namespace HomeWork_7
{
    public struct Employee
    {
        /// <summary>
        /// Employees number in catalog
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Date when record was created
        /// </summary>
        public DateTime DateOfCreating { get; set; }
        /// <summary>
        /// Full name of employee
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Age of employee
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Height of employee
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Employees date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Place of dirth of employee
        /// </summary>
        public string PlaceOfBirth { get; set; }
    }
}