using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApplication.Interfaces;
using ConsoleApplication.Models;

namespace ConsoleApplication.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        //Encapsulation edirik cunki classin xaricden bir basa bizim listimize mudaxile edilmesi tehlukelidir.
        private List<Department> _departments;

        public List<Department> Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                Departments = _departments;
            }
        }

        // Department listini constructor icinde initialize edirik.
        public HumanResourceManager()
        {
            _departments = new List<Department>();
        }
        //Department listine yaradilmis bir departament objectini atiriq. Bu objectin daxili melumatlarini istifadeci console pencersinden girir.
        #region AddDepartment
        public void AddDepartment(Department department)
        {

            if (department.SalaryLimit > 250)
            {
                try
                {
                    if (department.Name.Length >= 2)
                    {
                        _departments.Add(department);

                    }

                }
                catch (Exception)
                {

                    Console.WriteLine("Departament departament listine elave olunmadi cunki departamentin adi 2 herfden az ola bilmez");
                }


            }
        }
        #endregion
        // Iscileri elave etmek uchun bir add metodu yaradiriq. Bu bizden employee objecti ve hansi departname e elave edecemizi isteyir. 
        #region AddEmployee
        public void AddEmployee(Employee employee, string depName)
        {
            Employee emp = new Employee();

            emp.FullName = employee.FullName;
            emp.Salary = employee.Salary;
            emp.Position = employee.Position;
            emp.DepartmentName = employee.DepartmentName;
            emp.NO = employee.NO;

            // Ischilerin maaslarinni toplamaq uchun bir degisken
            int result = 0;
            
            

            foreach (Department item in _departments)
            {
                for (int i = 0; i < item.Employees.Count; i++)
                {
                    result += item.Sum()+ emp.Salary;
                }
                if (item.Name.ToLower() == depName.ToLower())
                {
                    // Sirketin umumi maas limiti ile ischilerin umumi maaslarini muqayise edirik.
                    if (item.SalaryLimit >= result)
                    {

                        if (item.WorkerLimit > item.Employees.Count)
                        {
                            if (emp.Salary > 250)
                            {
                                try
                                {
                                    if (employee.Position.Length >= 2)
                                    {
                                        item.Employees.Add(emp);
                                        Console.WriteLine("isci sirkete ugurla elave edildi!!!");

                                    }
                                    
                                }
                                catch (Exception)
                                {


                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine($"{item.Name} departmentinde isci elave etmek uchun bos yer yoxdur!!!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Departmente ischi elave olunmadi.Cunki departmentin mebleg maasi limitini kecir!!!");
                    }
                }

            }

        }
        #endregion
        //Istifadeci bir ad girir hemin adda departament varsa yeni ad girmeyimizi isteyir ve o ad evvelkiile evez olunur.
        #region EditDepartaments
        public void EditDepartaments(string oldName, Department department)
        {

            foreach (Department dep in _departments)
            {
                if (dep.Name.ToLower() == oldName.ToLower())
                {
                    dep.Name = department.Name;
                }
                else
                {
                    Console.WriteLine("Axtardiginiz adli department yoxdu");
                }
            }

        }
        #endregion
        //Iscinin nomresini goturur ve o nomreli iscinin departmentde olub olmadigna baxir eger varsa onun uzerinde deyisikler etmesine icaze verir.Eger yoxdusa proses menusuna qayidir.
        #region EditEmployee
        public void EditEmployee(string num, string fullname, int salary, string position, Employee employee)
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
                        Console.WriteLine("Axtardiginiz isci yoxdur!!!");
                        return;
                    }
                }

            }
        }
        #endregion
        //Departament listimize geriye donderir.
        #region GetDepartments
        public List<Department> GetDepartments()
        {
            return Departments;
        }
        #endregion
        //Departtamentin adini istifadeci girdikten sonra hemin adda departament olub olmadigina baxilir eger varsa sonra istifadeciden iscinin nomresi istenilir o da uygun gelirse iscimiz silinir.
        #region RemoveEmployee
        public void RemoveEmployee(string num, string departmentName)
        {

            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    for (int i = 0; i < item.Employees.Count; i++)
                    {
                        if (item.Employees[i].NO == num.ToUpper())
                        {
                            item.Employees.Remove(item.Employees[i]);
                        }
                        else
                        {
                            Console.WriteLine("Axtardiginiz nomreli isci yoxdur!!!");
                        }
                    }
                }
                
            }
        }
        #endregion
    }
}
