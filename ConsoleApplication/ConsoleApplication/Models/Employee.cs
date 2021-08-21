using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Models
{
    class Employee
    {

        private static int _empOrder = 1000;

        public string DepartmentName;

        public string NO;
        public Employee()
        {
            

        }
        public Employee(string dep) : this()
        {
            DepartmentName = dep;

            _empOrder++;

            NO = DepartmentName.Substring(0, 2).ToUpper() + _empOrder;

        }

        public string FullName;

        private string _position;

        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (checkName(value))
                {
                    _position = value;
                }
                else {
                    Console.WriteLine("iscinin vezifesi mimumum 2 herfden ibaret olmalidir!!!");
                }
            }
        }

        private bool checkName(string name)
        {
            if (name.Length < 2)
            {
                return false;
            }

            foreach (char item in name)
            {
                if (!Char.IsLetter(item))
                {
                    return false;
                }
            }

            return true;

        }


        private int _salary;
        public int Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value > 250)
                {
                    _salary = value;
                }
                else
                {
                    Console.WriteLine("Iscinin maasi 250 den az ola bilmez!!!");
                }
            }
        }


    }
}
