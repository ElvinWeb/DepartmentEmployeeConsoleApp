using AppClasses.Enums;
using AppClasses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppClasses.Classes
{
    public class Department
    {
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public int EmployeeLimit { get; set; }

        private Employee[] Employees = Array.Empty<Employee>();
        static Department()
        {
            _id = 0;
        }
        public Department(string name, int employeeLimit)
        {
            _id++;
            Id = _id;
            this.Name = name;
            this.EmployeeLimit = employeeLimit;
        }

        public Employee this[int index]
        {
            get => Employees[index];
            set => Employees[index] = value;
        }

        public void AddEmployee(Employee employee)
        {
            if (Employees.Length >= EmployeeLimit)
            {
                throw new CapacityLimitException("Limiti kecdi!!!");
            }
            AddEmployee(ref Employees, employee);
        }
        public void AddEmployee(ref Employee[] array, Employee employee)
        {
            Array.Resize(ref array, array.Length + 1);
            array[^1] = employee;
        }
        public void GetAllEmployee()
        {
            foreach (Employee emp in Employees)
            {
                emp.ShowInfo();
            }
        }
        public Employee[] RemoveEmployee(int id)
        {
            Employee[] newEmpolyeeArr = new Employee[Employees.Length - 1];
            
            foreach (Employee emp in Employees)
            {
                if (emp.Id == id)
                {
                    continue;
                }

                Array.Resize(ref newEmpolyeeArr, newEmpolyeeArr.Length);
                newEmpolyeeArr[^1] = emp;

            }
            Employees = newEmpolyeeArr;

            return newEmpolyeeArr;
        }

        public Employee GetEmployee(int id)
        {
            foreach (Employee emp in Employees)
            {
                if (emp.Id == id)
                {
                    return emp;
                }
            }

            return null;
        }

        public Employee[] GetEmployeesBySalary(double minSalary, double maxSalary)
        {
            Employee[] newEmpolyeeArr = Array.Empty<Employee>();
            foreach (Employee emp in Employees)
            {
                if (minSalary <= emp.Salary && maxSalary >= emp.Salary)
                {
                    AddEmployee(ref newEmpolyeeArr, emp);
                }

            }

            return newEmpolyeeArr;
        }

        public Employee[] GetEmployeesByDeparmentName(string departmentName)
        {
            Employee[] newEmpolyeeArr = Array.Empty<Employee>();

            foreach (Employee emp in Employees)
            {
                if (departmentName == emp.DepartmentName)
                {
                    AddEmployee(ref newEmpolyeeArr, emp);
                }

            }

            return newEmpolyeeArr;
        }

        public Employee[] GetEmployeesByPosition(Positions position)
        {
            Employee[] newEmpolyeeArr = Array.Empty<Employee>();
            foreach (Employee emp in Employees)
            {
                if (emp.Position == position.ToString())
                {
                    AddEmployee(ref newEmpolyeeArr, emp);
                }

            }
            return newEmpolyeeArr;
        }

    }
}
