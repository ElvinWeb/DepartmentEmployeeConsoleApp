using AppClasses.Classes;
using AppClasses.Enums;
using AppClasses.Exceptions;
using System;

namespace Department_EmployeeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department Department = new Department("IT", 5);
            Department Department1 = new Department("Marketing", 2);


            string option;
            do
            {
                Console.WriteLine("Emeliyyati secin: ");
                Console.WriteLine($"1. İşci elave et" +
                    "\n2. İsci axtar " +
                    "\n3. Butun iscilere bax" +
                    "\n4. Maaş aralıgına gore iscileri axtarıs et" +
                    "\n5. Departamente gore iscileri axtarıs et" +
                    "\n6. Positiona gore isciləri axtarıs et" +
                    "\n7. İscini qov" +
                    "\n0. Programi dayandir");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        try
                        {
                            Department.AddEmployee(CreateEmployee());
                            Console.WriteLine("Elave edildi");
                        }
                        catch (CapacityLimitException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        Console.WriteLine("<==========================>");
                        break;
                    case "2":

                        int id;
                        string idStr;
                        bool parseId;
                        do
                        {
                            Console.Write("axtaris ucun isci ID daxil edin: ");
                            idStr = Console.ReadLine();
                            parseId = int.TryParse(idStr, out id);
                            if (!parseId)
                            {
                                Console.WriteLine("Iscinin ID deyerini duzgun daxil edin");
                            }

                        } while (!parseId);

                        Department.GetEmployee(id).ShowInfo();
                        break;
                    case "3":
                        Department.GetAllEmployee();
                        break;
                    case "4":
                        string maxSalary;
                        string minSalary;
                        double max;
                        double min = 0;
                        bool parse1;
                        bool parse2;
                        Console.Write("axtaris ucun maasi araligi daxil edin");
                        do
                        {
                            Console.Write("\nminimum deyer daxil edin: ");
                            minSalary = Console.ReadLine();
                            Console.Write("\nmaximum deyer daxil edin: ");
                            maxSalary = Console.ReadLine();

                            parse1 = double.TryParse(maxSalary, out max);
                            parse2 = double.TryParse(minSalary, out min);

                            if (!parse1 && !parse2)
                            {
                                Console.Write("max ve min deyerleri duzgun daxil edin");
                            }

                        } while (!parse1 && !parse2);
                        Employee[] employeesBySalary = Department.GetEmployeesBySalary(min, max);
                        foreach (Employee emp in employeesBySalary)
                        {
                            emp.ShowInfo();
                        }
                        break;
                    case "5":
                        Console.Write("Axtaris ucun department adi daxil edin: ");
                        string departmentName = Console.ReadLine();

                        Employee[] employeesByDepartment = Department.GetEmployeesByDeparmentName(departmentName.Trim());
                        foreach (Employee employee in employeesByDepartment)
                        {
                            employee.ShowInfo();
                        }
                        break;
                    case "6":
                        Console.WriteLine("Isci Vezifesini daxile edin: ");
                        Console.WriteLine("1 - Boss, 2 - Engineer, 3 - HR");
                        Positions position = Positions.Engineer; //default deyerdi
                        string positionChoice = Console.ReadLine();

                        switch (positionChoice)
                        {
                            case "1":
                                position = Positions.Boss;
                                break;
                            case "2":
                                position = Positions.Engineer;
                                break;
                            case "3":
                                position = Positions.HR;
                                break;
                            default:
                                break;
                        }

                        Employee[] employeesByPositions = Department.GetEmployeesByPosition(position);
                        foreach (Employee employee in employeesByPositions)
                        {
                            employee.ShowInfo();
                        }
                        break;
                    case "7":
                        int removeId;
                        string removeIdStr;
                        bool parseRemoveId;
                        do
                        {
                            Console.Write("axtaris ucun isci ID daxil edin: ");
                            removeIdStr = Console.ReadLine();
                            parseRemoveId = int.TryParse(removeIdStr, out removeId);
                            if (!parseRemoveId)
                            {
                                Console.WriteLine("Iscinin ID deyerini duzgun daxil edin");
                            }

                        } while (!parseRemoveId);

                        Department.RemoveEmployee(removeId);
                        Console.WriteLine("Isci silindi");
                        break;
                    default:
                        break;
                }
            } while (option != "0");
        }
        public static Employee CreateEmployee()
        {

            Console.Write("Isci adini daxil edin: ");
            string Name = Console.ReadLine();

            double age;
            string ageStr;
            bool parseAge;
            do
            {
                Console.Write("Isci Yasini daxil edin: ");
                ageStr = Console.ReadLine();
                parseAge = double.TryParse(ageStr, out age);
                if (!parseAge)
                {
                    Console.WriteLine("Iscinin Yasini duzgun daxil edin");
                }

            } while (!parseAge);

            double salary;
            string salaryStr;
            bool parseSalary;
            do
            {
                Console.Write("Iscinin massini daxil edin: ");
                salaryStr = Console.ReadLine();
                parseSalary = double.TryParse(salaryStr, out salary);
                if (!parseSalary)
                {
                    Console.WriteLine("Iscinin massini duzgun daxil edin");
                }

            } while (!parseSalary);

            Console.WriteLine("Isci Vezifesini daxile edin: ");
            Console.WriteLine("1 - Boss, 2 - Engineer, 3 - HR");
            Positions position = Positions.Engineer; //default deyerdi
            string positionChoice = Console.ReadLine();

            switch (positionChoice)
            {
                case "1":
                    position = Positions.Boss;
                    break;
                case "2":
                    position = Positions.Engineer;
                    break;
                case "3":
                    position = Positions.HR;
                    break;
                default:
                    break;
            }

            Employee Employee = new Employee(Name.Trim(), position.ToString(), age, salary);

            return Employee;

        }
    }
}