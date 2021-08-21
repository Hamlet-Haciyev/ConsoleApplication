using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApplication.Models;
namespace ConsoleApplication.Interfaces
{
    interface IHumanResourceManager
    {
        public List<Department> Departments { get; }

        public void AddDepartment(Department department);

        public List<Department> GetDepartments();

        public void EditDepartaments(string oldName, Department department);


        public void AddEmployee(Employee employee,string depName);

        public void RemoveEmployee(string num,string departmentName);
        public void EditEmployee(string num, string fullname, int salary, string position, Employee employee);
    }
}
