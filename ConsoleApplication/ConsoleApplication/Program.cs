using System;
using System.Collections;
using System.Text;
using ConsoleApplication.Services;
using ConsoleApplication.Models;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanrresourcemanager = new HumanResourceManager();
            baseMethod(humanrresourcemanager);
        }
        #region baseMethod
        static void baseMethod(HumanResourceManager humanResourceManager)
        {
            do
            {
                Console.WriteLine("1-  Departmentlerle elaqeli isler uchun 1 duymesini secin");
                Console.WriteLine("2-  Ischiler uzerindeki emaliyyatlar uchun 2 duymesinin secin");

                string choose = Console.ReadLine();
                int chooseNum;

                int.TryParse(choose, out chooseNum);

                switch (chooseNum)
                {
                    case 1:
                        DepartmentOperation(humanResourceManager);
                        break;

                    case 2:
                        EmployeeOperation(humanResourceManager);
                        break;

                    default:
                        Console.Clear();
                        break;
                }

            } while (true);
        }
        #endregion

        #region DepartmentOperation
        static void DepartmentOperation(HumanResourceManager humanResourceManager)
        {
            do
            {
                Console.WriteLine("1 - Departameantlerin siyahisini gostermek");
                Console.WriteLine("2 - Departamenet yaratmaq");
                Console.WriteLine("3 - Departmanetde deyisiklik etmek");
                Console.WriteLine("4 - Proses menusuna qayitmaq");


                string choose = Console.ReadLine();
                int chooseNum;

                int.TryParse(choose, out chooseNum);


                switch (chooseNum)
                {
                    case 1:
                        getDepartmentInfo(humanResourceManager);
                        break;

                    case 2:
                                      
                        createDepartment(humanResourceManager);
                        break;

                    case 3:
                        editDepartment(humanResourceManager);
                        break;
                    case 4:
                        baseMethod(humanResourceManager);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (true);
        }
        #endregion

        #region EmployeeOperation
        static void EmployeeOperation(HumanResourceManager humanResourceManager)
        {
            do
            {
                Console.WriteLine("1 - Iscilerin siyahisini gostermek");
                Console.WriteLine("2 - Departamentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("3 - Isci elave etmek");
                Console.WriteLine("4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("5 - Departamentden isci silinmesi");
                Console.WriteLine("6 - Proses menusuna qayitmaq");


                string choose = Console.ReadLine();
                int chooseNum;

                int.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        getEmployees(humanResourceManager);
                        break;

                    case 2:
                        getEmployeesInDepartment(humanResourceManager);
                        break;

                    case 3:
                        addEmployee(humanResourceManager);
                        break;
                    case 4:
                        editEmployee(humanResourceManager);
                        break;
                    case 5:
                        removeEmployee();
                        break;

                    case 6:
                        baseMethod(humanResourceManager);

                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (true);
        }
        #endregion

        #region getDepartmentInfo
        static void getDepartmentInfo(HumanResourceManager humanResourceManager)
        {
            humanResourceManager.GetDepartments();

            //Employee employee = new Employee();
            //Department department = new Department();

            //for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            //{
            //    Console.WriteLine($"{humanResourceManager.Departments[i].Name} {humanResourceManager.Departments[i]} {humanResourceManager.Departments[i].CalcSalaryAverage()}");
            //}
            //Console.WriteLine(humanResourceManager.GetDepartments());
            
        }
        #endregion

        #region createDepartment
        static void createDepartment(HumanResourceManager humanResourceManager)
        {
            Department department1 = new Department();
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Departmentin adinin girin!!!");
                string DepartName = Console.ReadLine();
                Console.WriteLine("isci limitini girin");

                string empLimit = Console.ReadLine();
                int workerLimit;

                while (!int.TryParse(empLimit, out workerLimit))
                {
                    Console.WriteLine("isci limitini girin");
                    empLimit = Console.ReadLine();
                    int.TryParse(empLimit, out workerLimit);
                }
                Console.WriteLine("Maas limitini daxil edin");

                string salaryLimit = Console.ReadLine();
                int salaryCount;

                while (!int.TryParse(salaryLimit, out salaryCount))
                {
                    Console.WriteLine("isci limitini girin");
                    salaryLimit = Console.ReadLine();
                    int.TryParse(salaryLimit, out salaryCount);
                }
                department1.Name = DepartName;
                department1.SalaryLimit = salaryCount;
                department1.WorkerLimit = workerLimit;


                humanResourceManager.AddDepartment(department1);
                check = true;
            }


        }
        #endregion

        #region editDepartment
        static void editDepartment(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Axradiginiz departmentin adini girin!!!");
            string name = Console.ReadLine();

            Department department = humanResourceManager.Departments.Find(h => h.Name.ToLower() == name.ToLower());
            if (department == null)
            {
                Console.WriteLine("daxil etdiyiniz department yoxdur!!!");
                return;
            }

            Console.WriteLine($"Departmentin adi: {department.Name} Deparmentin maas limiti: {department.SalaryLimit} Departmentin isci limiti: {department.WorkerLimit} ");
            Console.WriteLine("Departmentin yeni adi:");
            string newName = Console.ReadLine();
            Console.WriteLine("Departmentin maas limitini girin:");
            string salaryLimit = Console.ReadLine();
            int salInt;
            while (!int.TryParse(salaryLimit, out salInt))
            {
                Console.WriteLine("Departmentin maas limitini girin:");
                salaryLimit = Console.ReadLine();
                int.TryParse(salaryLimit, out salInt);
            }
            Console.WriteLine("Departmentin isci limitini girin");
            string empLimit = Console.ReadLine();
            int eLimit;
            while (!int.TryParse(empLimit, out eLimit))
            {
                Console.WriteLine("Departmentin isci limitini girin");
                empLimit = Console.ReadLine();
                int.TryParse(empLimit, out eLimit);
            }

            department.Name = newName;
            department.SalaryLimit = salInt;
            department.WorkerLimit = eLimit;

            Console.WriteLine("Department uzerindeki deyisikler ugurla edildi");

           
        }
        #endregion




        #region getEmployees
        static void getEmployees(HumanResourceManager humanResourceManager)
        {
            for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            {
                Department departmentEmployees = humanResourceManager.Departments[i];
                for (int a = 0; i < departmentEmployees.Employees.Count; a++)
                {
                    Console.WriteLine($"{departmentEmployees.Employees[i].NO} {departmentEmployees.Employees[i].FullName} {departmentEmployees.Employees[i].DepartmentName} {departmentEmployees.Employees[i].Salary}");
                }
            }
        }
        #endregion

        #region getEmployeesInDepartment
        static void getEmployeesInDepartment(HumanResourceManager humanResourceManager)
        {
        
            Console.WriteLine("departmen adini daxil edin!!!");
            string depName = Console.ReadLine();

            Department dep = humanResourceManager.Departments.Find(hd => hd.Name.ToLower() == depName.ToLower());

            if (dep != null)
            {

                for (int i = 0; i < dep.Employees.Count; i++)
                {
                    Console.WriteLine("asdasd");
                    Console.WriteLine($"{dep.Employees[i].NO} {dep.Employees[i].FullName} {dep.Employees[i].Position} {dep.Employees[i].Salary}");
                }
            }
         
        }
        #endregion

        #region addEmployee
        static void addEmployee(HumanResourceManager humanResourceManager)
        {
            Employee emp1 = new Employee();

            Console.WriteLine("Fullname-i girin!!!");
            string fullname = Console.ReadLine();

            Console.WriteLine("Isci tutdugunuz vezifeni girin!!");
            string position = Console.ReadLine();

            Console.WriteLine("maasi girin!!!");
            string salary = Console.ReadLine();
            int salaryInt;
            while (!int.TryParse(salary,out salaryInt))
            {
                Console.WriteLine("maasi girin!!!");
                salary = Console.ReadLine();
                int.TryParse(salary, out salaryInt);
            }

            Console.WriteLine("Departmanin adini girin!!!");
            string DepartmanName = Console.ReadLine();

            emp1.FullName = fullname;
            emp1.Salary = salaryInt;
            emp1.Position = position;

            humanResourceManager.AddEmployee(emp1, DepartmanName);

            //humanResourceManager.Departments;
        }
        #endregion

        #region editEmployee
        static void editEmployee(HumanResourceManager humanResourceManager)
        {

            Console.WriteLine("deyisiklik etmek istediyiniz iscinin nomresini daxil edin!!!");
            string employyeNo = Console.ReadLine();
            int empNo;

            while (!int.TryParse(employyeNo,out empNo))
            {
                Console.WriteLine("deyisiklik etmek istediyiniz iscinin nomresini daxil edin!!!");
                employyeNo = Console.ReadLine();
                int.TryParse(employyeNo, out empNo);
            }

            //foreach (Employee item in humanResourceManager.Departments)
            //{
            //    if ()
            //    {

            //    }
            //}

        }
        #endregion

        #region removeEmployee
        static void removeEmployee()
        {

        }
        #endregion
    }
}
