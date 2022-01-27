using System;

namespace Employee_Payroll
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ADO.Net Tutorial");
            EmployeePayrollRepo emp = new EmployeePayrollRepo();
            emp.GetAllData();
        }
    }
}
