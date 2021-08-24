using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Models
{
    class Employee
    {
        // Departmentdeki ischilerin her birinin oz nomresi olur ve biz bunu stativ qeyd ederek constructor icerinde davamli olaraq artiririqki her ischi elave olunanda onun ozune xas nomresi olsun.
        private static int _empOrder = 1000;
        
        public string DepartmentName;
       
       
        // Ishcilerin nomrelerini tutacgimiz field encapsulation edirik xariden mudaxile olmasin deye.
        private string _no;

        public string NO
        {
            get
            {
                return _no;
            }
            set
            {
                _no = value;
            }
        }
        // Bosh bir contructor yaradiriq.Cunki bundan intialize elib ischini departament listine elave edeceyik
        public Employee()
        {

        }
        // Ikinici bir contructor yaradiriq ve bu bir parametr alir departament deyeri alirki onuda Departamenin adina menimsedirik. Sonra ischiler elave olunduqa nomrelirini artirmaq uchun empOrder bir vahid qaldirib NO propertysine menimsedirik.
        public Employee(string departament) : this()
        {
            DepartmentName = departament;

            _empOrder++;
            
            NO = departament.Substring(0, 2).ToUpper() + _empOrder;

        }
        //  Her bir ischimizin ad ve soyadini tutacaq bir field.
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
                try
                {
                    if (checkName(value))
                    {
                        _position = value;
                    }
                    else
                    {
                        _empOrder--;
                        Console.WriteLine("Iscinin vezifesi mimumum 2 herfden ibaret olmalidir!!!");
                    }
                }
                catch (Exception )
                {
                   
                }
            }
        }
        // Bu metod ishcimizin vezifesini daxil ederken yoxlanish aparir eger 2 simvoldan az ve  2 herfden az bir deyer giririkse bir error mesaji verir.
        private bool checkName(string name)
        {
            int letterCount = 0;
            bool check = true;
            

            for (int i = 0; i < name.Length; i++)
            {
                if (Char.IsLetter(name[i]))
                {
                    letterCount++;
                }
            }

            if (letterCount < 2)
            {
                check = false;
            }

            return check;

        }

        // Her bir ishcimiz maas alir ve bu maasi saxlayacagimiz bir field bunuda encapsulation edirik.
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
