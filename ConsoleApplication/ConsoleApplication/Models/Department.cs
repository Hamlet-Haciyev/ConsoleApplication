using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Models
{
    class Department
    {
        // Departmanin adi encapsulation edirikki classin xaricinden isledile bilmesin
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
              
                    if (checkName(value))
                    {
                        _name = value;
                    }
                                
            }
        }
        // Departmanin adinda uzunlugunun 2 den cox oldugunu ve 2 den cox herf oldugunu yoxlamaq uchun metod.
        private bool checkName(string name)
        {
            int letterCount = 0;
            if (name.Length < 2)
            {
                return false;
            }

            for (int i = 0; i < name.Length; i++)
            {               
                if (Char.IsLetter(name[i]))
                {
                    letterCount++;
                }
            }
            if (letterCount < 2)
            {                
                return false;
            }

            return true;

        }
        // Her bir departmain oz isci listi olurki hemin liste departmentde isleyen butun isciler saxlanilir ve bunun encapsulation edirikki kenardan mudaxile olmasin.
        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
            }
        }
        // Employees listini initialize edirik.
        public Department()
        {
            _employees = new List<Employee>();
        }

        // Departmentde en cox ne qeder ishcinin isleye bilceyini bildirimek uchun bir field , bunuda encapsulation edirik xaricden mudaxile olmasin deye.
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
        // Departmentde isleyecek iscilerin en az ala bilecek maasi elimizde saxlamaq uchun lazim olan bir field bunuda  encapsulation edirik.
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
                    Console.WriteLine("Departmentdeki mebleg minumum 250 ola biler!!!");
                }
            }
        }

    

        // Departmentdeki ishcilerin ortalama maaslarini hesablayacaq metod.
        public int CalcSalaryAverage()
        {
            int salaryAverage = 0;

            foreach (Employee emp in Employees)
            {
                salaryAverage += emp.Salary;
            }

            salaryAverage /= Employees.Count; 

            return salaryAverage;
        }
        public override string ToString()
        {
            return $"{Name} {Employees.Count} {CalcSalaryAverage()}";
        }

        // Bu metod departmentdeki butun ischilerin maaslarini toplaraq geriye qaytarir.
        public int Sum()
        {
            int result = 0;
            for (int i = 0; i < _employees.Count; i++)
            {
                result += _employees[i].Salary;
            }
            return result;
        }

    }

}
