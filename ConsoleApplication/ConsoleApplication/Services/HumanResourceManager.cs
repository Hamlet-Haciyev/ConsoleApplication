using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApplication.Interfaces;
using ConsoleApplication.Models;

namespace ConsoleApplication.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private List<Department> _departments;

        public List<Department> Departments
        {
            get
            {
                return _departments;
            }
        }
        private List<Employee> _employees;

        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
        }
        public HumanResourceManager()
        {
            _departments = new List<Department>();
        }
        public void AddDepartment(Department department)
        {       
                _departments.Add(department);
        }
        // Iscileri elave etmek uchun bir add metodu yaradiriq. Bu bizden employee objecti ve hansi departname e elave edecemizi isteyir. 
        public void AddEmployee(Employee employee, string departmentName)
        {
            Employee emp = new Employee();
            emp.FullName = employee.FullName;
            emp.Salary = employee.Salary;
            emp.Position = employee.Position;

            foreach (Department item in Departments)
            {
                if (item.Name.ToLower()==departmentName.ToLower())
                {
                    item.Employees.Add(emp);
                }
            }


            //foreach (Department item in Departments)
            //{
            //    if (item.Name.ToLower()==departmentName.ToLower())
            //    {
                   
            //        if (item.Employees.Count < item.WorkerLimit)
            //        {
            //            item.Employees.Add(employee);
            //        }
            //    }
               
            //}
           
        }

        public void EditDepartaments(string oldName, string newName)
        {
        }

        public void EditEmployee(int num, string fullname, int salary, string position)
        {
        }

        public List<Department> GetDepartments()
        {
            return Departments;
            Console.WriteLine("asdasd");
        }

        public void RemoveEmployee(int num, string departmentName)
        {
        }
    }
}
