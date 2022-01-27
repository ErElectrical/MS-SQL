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

            temp.EmployeeName = "moke";
            temp.Country = "india";
            temp.state = "maharastra";
            temp.stratdate = DateTime.Today;
            temp.Department = "engg";
            temp.gender = "male";
            temp.Address = "Junu okhkla";
            temp.Tax = 129;
            temp.basicPay = 12000;
            temp.TaxPay = 100;
            temp.NetPay = 11500;
            temp.Deducations = 150;
            temp.Phonenumber = "356642235";

           // emp.AddEmployee( temp);

            GetDataBetweenDatecs inst = new GetDataBetweenDatecs();
            inst.GetDataDates();

        }
    }
}
