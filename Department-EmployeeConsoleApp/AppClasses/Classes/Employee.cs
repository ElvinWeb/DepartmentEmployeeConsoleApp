using AppClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppClasses.Classes
{
    public class Employee : IPerson
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Age { get; set; }
        public double Salary { get; set; }

        static Employee()
        {
            _id = 0;
        }
        public Employee(string name, string position, double age, double salary)
        {
            _id++;
            Id = _id;
            this.Name = name;
            this.Position = position;
            this.Age = age;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return GetInfo();
        }

        public void ShowInfo()
        {
            Console.WriteLine(GetInfo());
        }

        public string GetInfo()
        {
            return $"Id: {this.Id}, Adi: {this.Name}, Yasi: {this.Age}, Vezifesi: {this.Position}, Maasi: {this.Salary}";
        }
    }
}
