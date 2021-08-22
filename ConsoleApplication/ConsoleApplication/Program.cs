using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApplication.Services;
using ConsoleApplication.Models;
namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // HumanResourcesManager classini initialize ederek bir object yaradiriq ve butun islerimizi bu object uzerinde goruruk.
            HumanResourceManager humanrresourcemanager = new HumanResourceManager();
            baseMethod(humanrresourcemanager);
        }
        // Bizim esas metodumuzdur hansi ki department ve ya isciler uzerindeki emeliyyatlara getmeyimiz uchun bu metod islemelidir.
        #region baseMethod
        static void baseMethod(HumanResourceManager humanResourceManager)
        {
            do
            {
                Console.WriteLine("1-  Departamentlerle elaqeli isler uchun 1 duymesini secin");
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
        // Department uzerindeki emeliyyatlar uchun bu metodu isledirik.
        #region DepartmentOperation
        static void DepartmentOperation(HumanResourceManager humanResourceManager)
        {
            do
            {
                Console.WriteLine("1 - Departamentlerin siyahisini gostermek");
                Console.WriteLine("2 - Departament yaratmaq");
                Console.WriteLine("3 - Departamentde deyisiklik etmek");
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
        // Ischiler uzerinde emelliyatlar etmke uchun ise EmployyeOperation metodundan istifade etmeliyik.
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
                        removeEmployee(humanResourceManager);
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


        // Bu metod bizim departamentimizin adinin , orda nece ischinin calisigini ve onlarin ortalama maasini gosterir.
        #region getDepartmentInfo
        static void getDepartmentInfo(HumanResourceManager humanResourceManager)
        {


            foreach (Department item in humanResourceManager.Departments)
            {

                if (item.Employees.Count > 0)
                {
                    Console.WriteLine($"Departamentin adi: {item.Name} Departamentdeki isci sayisi: {item.Employees.Count} Departamentideki iscilerin ortalama maasi: {item.CalcSalaryAverage()}");

                }
                else
                {
                    Console.WriteLine($"Departamentin adi: {item.Name} Departamentdeki isci sayisi: 0 -di ve buna gore deye ortalam emek haqqi da 0 olur.");
                }
            }

        }
        #endregion
        // CreateDepartment metodu bize department yaratmaq uchun lazimdi. Bu metodla departmenti yaradib sonra ora isci elave ede iscini update ede ve sile bilerik.
        #region createDepartment
        static void createDepartment(HumanResourceManager humanResourceManager)
        {
            Department department1 = new Department();
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Departmentin adinin girin!!!");
                string DepartName = Console.ReadLine();
                Console.WriteLine("Isci limitini girin");

                string empLimit = Console.ReadLine();
                int empCount;

                while (!int.TryParse(empLimit, out empCount))
                {
                    Console.WriteLine("Isci limitini girin");
                    empLimit = Console.ReadLine();
                    int.TryParse(empLimit, out empCount);
                }
                Console.WriteLine("Maas limitini daxil edin");

                string salaryLimit = Console.ReadLine();
                int salaryCount;

                while (!int.TryParse(salaryLimit, out salaryCount))
                {
                    Console.WriteLine("Maas limitini daxil edin");
                    salaryLimit = Console.ReadLine();
                    int.TryParse(salaryLimit, out salaryCount);
                }
                department1.Name = DepartName.Trim();
                department1.SalaryLimit = salaryCount;
                department1.WorkerLimit = empCount;


                humanResourceManager.AddDepartment(department1);
                
                check = true;
            }


        }
        #endregion
        // Edit departament metodu departament uzerinde deyisikler aparmaq uchun lazimdi. Bu metod sayesinde departamente yeni ad , isci limiti ve yeni maas limiti qoya bilerik. 
        #region editDepartment
        static void editDepartment(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Axradiginiz departmentin adini girin!!!");
            string name = Console.ReadLine();

            Department department = humanResourceManager.Departments.Find(h => h.Name.ToLower() == name.ToLower());
            if (department == null)
            {
                Console.WriteLine("Daxil etdiyiniz adda department yoxdur!!!");
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
        
        }
        #endregion


        // GetEmployees metodu bize butun departamentlerde olan ischilerin siyahisinin getirir.
        #region getEmployees
        static void getEmployees(HumanResourceManager humanResourceManager)
        {
            for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            {
                Department departmentEmployees = humanResourceManager.Departments[i];
                for (int a = 0; a < departmentEmployees.Employees.Count; a++)
                {
                    Console.WriteLine($"Iscinin nomresi: {departmentEmployees.Employees[a].NO} Iscinin ad ve soyadi: {departmentEmployees.Employees[a].FullName} Departmanin adi: {departmentEmployees.Employees[a].DepartmentName} Iscinin maasi: {departmentEmployees.Employees[a].Salary}");
                }
            }
        }
        #endregion
        // GetEmplyeesInDepartment metodu bizden hansi departamendeki ischilerin siyasini gormek istediyimizi sorusur. Biz hansini istediyimizi bildirdikde hemin departamentdeki butun ischilerin siyahisini getirir.
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
                    Console.WriteLine($"Departamentdeki iscinin nomresi: {dep.Employees[i].NO} Iscinin ad ve soyadi: {dep.Employees[i].FullName} Iscinin tutdugu vezife: {dep.Employees[i].Position} Iscinin aldigi maas: {dep.Employees[i].Salary}");
                }
            }
            else
            {
                Console.WriteLine("Axtardiginiz adda department yoxdur");
            }
         
        }
        #endregion
        // addEmployee metodu sayesinde bizden hansi departamente ischi elave etmek istedimizi sorusur ve biz onu girdikden sonra ischinin hemin departamentde elave edir.
        #region addEmployee
        static void addEmployee(HumanResourceManager humanResourceManager)
        {


            Console.WriteLine("Fullname-i girin!!!");
            string fullname = Console.ReadLine();

            Console.WriteLine("Iscinin tutdugu vezifeni girin!!");
            string position = Console.ReadLine();

            Console.WriteLine("Maasi girin!!!");
            string salary = Console.ReadLine();
            int salaryInt;
            while (!int.TryParse(salary,out salaryInt))
            {
                Console.WriteLine("Maasi girin!!!");
                salary = Console.ReadLine();
                int.TryParse(salary, out salaryInt);
            }

            Console.WriteLine("Departmanin adini girin!!!");
            string DepartmanName = Console.ReadLine();
            Employee emp = new Employee(DepartmanName);

            emp.FullName = fullname.Trim();
            emp.Salary = salaryInt;
            emp.Position = position.Trim();
            
            

            humanResourceManager.AddEmployee(emp,DepartmanName);
        }
        #endregion
        // editEmployee metodu bizden ischinin nomresini girmeyimizi isteyir ve hemin normeli ischi varsa hemin ischi uzeride deyisiklik etmeyimize imkan verir.
        #region editEmployee
        static void editEmployee(HumanResourceManager humanResourceManager)
        {

            Console.WriteLine("Deyisiklik etmek istediyiniz iscinin nomresini daxil edin!!!");
            string employyeNo = Console.ReadLine();

            bool check = false;
            string nowName = " ";
            int nowSalary=0;
            string nowPosition = " ";

            int depIndex = 0;
            int empIndex = 0;
            for (int i = 0; i < humanResourceManager.Departments.Count; i++)
            {
                for (int a = 0; a < humanResourceManager.Departments[i].Employees.Count; a++)
                {

                    if (employyeNo.ToUpper() == humanResourceManager.Departments[i].Employees[a].NO)
                    {
                        check = true;
                        if (check)
                        {
                            nowName = humanResourceManager.Departments[i].Employees[a].FullName;
                            nowSalary = humanResourceManager.Departments[i].Employees[a].Salary;
                            nowPosition = humanResourceManager.Departments[i].Employees[a].Position;
                            depIndex = i;
                            empIndex = a;
                        }
                        break;
                    }         
                 
                }
            }

            if (check)
            {
                Console.WriteLine($"{nowName} {nowSalary} {nowPosition}");
                Console.WriteLine("yeni maasi girin!!!");
                string salary = Console.ReadLine();
                int SalaryInt;

                while (!int.TryParse(salary,out SalaryInt))
                {
                    Console.WriteLine("yeni maasi girin!!!");
                    salary = Console.ReadLine();
                    int.TryParse(salary, out SalaryInt);
                }
                Console.WriteLine("yeni vezifeni girin");
                string newPosition = Console.ReadLine();

                humanResourceManager.Departments[depIndex].Employees[empIndex].Position = newPosition;
                humanResourceManager.Departments[depIndex].Employees[empIndex].Salary = SalaryInt;
            }
            else
            {
                baseMethod(humanResourceManager);
            }

        }
        #endregion
        // removeEmployee metodu bizden ilk once hansi departmandan ischi silmek  isteyimizi sorusur. Biz daxil edirik eger hemin department varsa bizden ischinin nomresinin sorusur onuda daxil etdikten sonra hemin nomreli ischi varsa onu silir.
        #region removeEmployee
        static void removeEmployee(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Silmek istediyiviz iscinin islediyi departmanin adini girin!!!");
            string depName = Console.ReadLine();

            Department department = humanResourceManager.Departments.Find(d => d.Name == depName);

            Console.WriteLine("Silmek istediyiviz iscinin nomresinin girin");
            string no = Console.ReadLine();

            if (department!=null)
            {
                for (int i = 0; i < department.Employees.Count; i++)
                {
                    if (department.Employees[i].NO==no.ToUpper())
                    {
                        department.Employees.Remove(department.Employees[i]);
                        return;
                    }
                }
            }

        }
        #endregion
    }
}
