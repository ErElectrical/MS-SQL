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

            EmployeePayrollModel temp = new EmployeePayrollModel();

            EmployeePayrollModel.EmployeeName = "moke";
            EmployeePayrollModel.Country = "india";
            EmployeePayrollModel.state = "maharastra";
            EmployeePayrollModel.stratdate = DateTime.Today;
            EmployeePayrollModel.Department = "engg";
            EmployeePayrollModel.gender = "male";
            EmployeePayrollModel.Address = "Junu okhkla";
            EmployeePayrollModel.Tax = 129;
            EmployeePayrollModel.basicPay = 12000;
            EmployeePayrollModel.TaxPay = 100;
            EmployeePayrollModel.NetPay = 11500;
            EmployeePayrollModel.Deducations = 150;
            EmployeePayrollModel.Phonenumber = "356642235";

            emp.AddEmployee( temp);

        }
    }
}
