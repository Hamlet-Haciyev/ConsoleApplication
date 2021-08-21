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
        // Iscileri elave etmek uchun bir add metodu yaradiriq. Bu bizden employee objecti ve hansi departname e elave edecemizi isteyir. 
        public void AddEmployee(Employee employee,string depName)
        {
            Employee emp = new Employee();

            emp.FullName = employee.FullName;
            emp.Salary = employee.Salary;
            emp.Position = employee.Position;
            emp.DepartmentName = employee.DepartmentName;

            foreach (Department item in _departments)
            {
                if (item.Name.ToLower()==depName.ToLower())
                {
                    if (item.WorkerLimit > item.Employees.Count)
                    {

                        item.Employees.Add(emp);
                        Console.WriteLine("isci sirkete ugurla elave edildi!!!");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Name} departmentinde isci elave etmek uchun bos yer yoxdur!!!");
                    }
                }
            }
    
        }

        public void EditDepartaments(string oldName,Department department)
        {

            foreach (Department dep in _departments)
            {
                if (dep.Name.ToLower()==oldName.ToLower())
                {
                    dep.Name = department.Name;
                    
                   

                }
                else
                {
                    Console.WriteLine("axtardiginiz adli department yoxdu");
                }
            }

        }

        public void EditEmployee(string num, string fullname, int salary, string position,Employee employee)
        {
            Employee editedEmpoyee = new Employee();

            foreach (Department item in _departments)
            {

                for (int i = 0; i < item.Employees.Count; i++)
                {
                    if (item.Employees[i].NO == num)
                    {

                        Console.WriteLine($"{item.Employees[i].FullName} {item.Employees[i].Salary} {item.Employees[i].Position}");

                        editedEmpoyee.Salary = employee.Salary;
                        editedEmpoyee.Position = employee.Position;
                    }
                    else
                    {
                        Console.WriteLine("axtardiginiz isci yoxdur!!!");
                        return;
                    }
                }

            }
        }

        public List<Department> GetDepartments()
        {
            
            return Departments;
        }

        public void RemoveEmployee(string num, string departmentName)
        {

            foreach (Department item in _departments)
            {
                if (item.Name.ToLower()==departmentName.ToLower())
                {
                    for (int i = 0; i < item.Employees.Count; i++)
                    {
                        if (item.Employees[i].NO==num)
                        {
                            item.Employees.Remove(item.Employees[i]);
                            Console.WriteLine("isci departmenden ugurla silindi");
                        }
                        else
                        {
                            Console.WriteLine("axtardiginiz nomreli isci yoxdur!!!");
                        }
                    }
                }
                else { 
                    Console.WriteLine("axtardiginiz adli department yoxdur!!!");
                }
            }
        }
    }
}
