using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Models
{
    class Employee
    {
        private static int _empOrder;

        public Employee()
        {
            _empOrder++;
            NO = DepartmentName.Substring(0, 2).ToUpper() + _empOrder;
        }
        public string NO;

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
                if (value.Length > 2)
                {
                    _position = value;
                }
                else {
                    Console.WriteLine("iscinin vezifesi mimumum 2 herfden ibaret olmalidir!!!");
                }
            }
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

        public string DepartmentName;

    }
}
