using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll
{

    // why dataModel class is required in such kind of opreations
    // with the help of data model class we are able to do modeling of data into class Object
    // after that we can easily bind it to database or use it in our Program
    // for any kind of manipulations
    public class EmployeePayrollModel
    {
        public static int EmployeeId { get; set; } 
        public static  string EmployeeName { get; set; }
        public static string Phonenumber { get; set; }
        public static string Address { get; set; }

        public static  string Department { get; set; }

        public static  string gender { get; set; }

        public static  double basicPay { get; set; }

        public static  double Deducations { get; set; }

        public  static double TaxPay { get; set; }

        public static  double Tax { get; set; }

        public static  double NetPay { get; set; }

        public  static DateTime stratdate { get; set; }

        public static  string state { get; set; }

        public  static string Country { get; set; }
    }
}
