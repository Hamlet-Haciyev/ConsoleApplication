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
                        DepartmentOperation(humanrresourcemanager);
                        break;

                    case 2:
                        EmployeeOperation(humanrresourcemanager);
                        break;

                    default:
                        Console.Clear();
                        break;
                }
            } while (true);
        }
        #region DepartmentOperation
        static void DepartmentOperation(HumanResourceManager humanResourceManager)
        {
            do
            {
                Console.WriteLine("1 - Departameantlerin siyahisini gostermek");
                Console.WriteLine("2 - Departamenet yaratmaq");
                Console.WriteLine("3 - Departmanetde deyisiklik etmek");

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
                        editDepartment();
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            } while (true);
        }
        #endregion

        #region MyRegion
        static void EmployeeOperation(HumanResourceManager humanResourceManager)
        {
            do
            {
                Console.WriteLine("1 - Iscilerin siyahisini gostermek");
                Console.WriteLine("2 - Departamentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("3 - Isci elave etmek");
                Console.WriteLine("4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("5 - Departamentden isci silinmesi");


                string choose = Console.ReadLine();
                int chooseNum;

                int.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        getEmployees();
                        break;

                    case 2:
                        getEmployeesInDepartment();
                        break;

                    case 3:
                        addEmployee();
                        break;
                    case 4:
                        editEmployee();
                        break;
                    case 5:
                        removeEmployee();
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
            for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            {
                Console.WriteLine(humanResourceManager.Departments[i]);
            }
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
                check = true;
            }


        }
        #endregion

        #region editDepartment
        static void editDepartment()
        {

        }
        #endregion

        #region getEmployees
        static void getEmployees()
        {

        }
        #endregion

        #region getEmployeesInDepartment
        static void getEmployeesInDepartment()
        {

        }
        #endregion

        #region addEmployee
        static void addEmployee()
        {

        }
        #endregion

        #region editEmployee
        static void editEmployee()
        {

        }
        #endregion

        #region removeEmployee
        static void removeEmployee()
        {

        }
        #endregion
    }
}
