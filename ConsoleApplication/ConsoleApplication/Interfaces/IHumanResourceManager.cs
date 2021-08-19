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

        public void EditDepartaments(string oldName,string newName);


        public void AddEmployee(Employee employee,string departmentName);

        public void RemoveEmployee(int num,string departmentName);
        public void EditEmployee(int num,string fullname,int salary,string position);
    }
}
