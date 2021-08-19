using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Models
{
    class Department
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length > 2)
                {
                    _name = value;
                }
                else
                {
                    Console.WriteLine("Departmentin adi 2 herfden az ola bilmez!!!");
                }
            }
        }

        public List<Employee> Employees;

        public Department()
        {
            Employees = new List<Employee>();
        }

        private int _workerLimit;
        public int WorkerLimit
        {
            get
            {
                return _workerLimit;
            }
            set
            {
                if (value > 1)
                {
                    _workerLimit = value;
                }
                else
                {
                    Console.WriteLine("isci sayi minumum 1 ola biler!!!");
                }
            }
        }

        private int _salaryLimit;

        public int SalaryLimit
        {
            get
            {
                return _salaryLimit;
            }
            set
            {
                if (value > 250)
                {
                    _salaryLimit = value;
                }
                else
                {
                    Console.WriteLine("mebleg minumum 250 ola biler!!!");
                }
            }
        }




        public int CalcSalaryAverage()
        {
            int salaryAverage = 0;

            foreach (Employee emp in Employees)
            {
                salaryAverage += emp.Salary;
            }

            salaryAverage /= 2;

            return salaryAverage;
        }
        public override string ToString()
        {
            return $"{Name} {WorkerLimit} {SalaryLimit} {Employees}";
        }

    }

}
