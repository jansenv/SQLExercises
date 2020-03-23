using DepartmentsEmployeesConsole.Data;
using DepartmentsEmployeesConsole.Models;
using System;

namespace DepartmentsEmployeesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new EmployeeRepository();
            var employees = repo.GetAllEmployees();

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} is in {employee.Department.DeptName}");
            }

            Console.WriteLine("Let's get an employee with the ID 2");

            var employeeWithId2 = repo.GetEmployeeById(2);

            Console.WriteLine($"Employee with Id 2 is {employeeWithId2.FirstName} {employeeWithId2.LastName}");

            var deptRepo = new DepartmentRepository();
            var departments = deptRepo.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Id} {department.DeptName}");
            }

            Console.WriteLine("Let's get a department with the ID 2");

            var deptWithId2 = deptRepo.GetDepartmentById(2);

            Console.WriteLine($"Department with Id 2 {deptWithId2.DeptName}");

            Department legalDept = new Department
            {
                DeptName = "Legal"
            };

            deptRepo.AddDepartment(legalDept);

            Console.WriteLine("-------------------------------"); 
            Console.WriteLine("Added the new Legal Department!");
        }
    }
}
