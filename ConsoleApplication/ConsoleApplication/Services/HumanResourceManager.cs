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
        public HumanResourceManager()
        {
            _departments = new List<Department>();
        }
        public void AddDepartment(Department department)
        {

            _departments.Add(department);

        }

        public void AddEmployee(Employee employee, string departmentName)
        {


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
        }

        public void RemoveEmployee(int num, string departmentName)
        {
        }
    }
}
