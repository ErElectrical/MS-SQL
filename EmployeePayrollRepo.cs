using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Employee_Payroll
{
    public class EmployeePayrollRepo
    {
        public static string ConnectionString = @"Server=DESKTOP-2G853OJ;Initial Catalog=Employee_Pay;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);
        public void GetAllData()
        {
            try
            {
                EmployeePayrollModel model = new EmployeePayrollModel();
                using (this.connection)
                {
                    string Query = @"select Startdate,Emp_PhoneNumber,Emp_Address,Dept_Name,state_belong,Country,BasicPay,Deducations,TaxPay,IncomeTax,NetPay,gender,Emp_Name
                                    from Employee_Pay;";

                    //define the Sqlcommand object

                    SqlCommand cmd = new SqlCommand(Query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            EmployeePayrollModel.EmployeeId = dr.GetInt32(0);
                            EmployeePayrollModel.stratdate = dr.GetDateTime(1);
                            EmployeePayrollModel.Phonenumber = dr.GetString(2);
                            EmployeePayrollModel.Address = dr.GetString(3);
                            EmployeePayrollModel.Department = dr.GetString(4);
                            EmployeePayrollModel.state = dr.GetString(5);
                            EmployeePayrollModel.Country = dr.GetString(6);
                            EmployeePayrollModel.basicPay = dr.GetDouble(7);
                            EmployeePayrollModel.Deducations = dr.GetDouble(8);
       
                            EmployeePayrollModel.TaxPay = dr.GetDouble(9);
                            EmployeePayrollModel.Tax = dr.GetDouble(10);

                            EmployeePayrollModel.NetPay = dr.GetDouble(11);

                            EmployeePayrollModel.gender = dr.GetString(12);
                            EmployeePayrollModel.EmployeeName = dr.GetString(13);

                            Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}", EmployeePayrollModel.EmployeeId, EmployeePayrollModel.EmployeeName, EmployeePayrollModel.stratdate, EmployeePayrollModel.Phonenumber, EmployeePayrollModel.NetPay, EmployeePayrollModel.state, EmployeePayrollModel.TaxPay);
                            Console.WriteLine("\n");















                        }
                    }
                    else
                    {
                        Console.WriteLine("data not found ");
                    }
                    dr.Close();
                    this.connection.Close();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                
                this.connection.Close();
            }
        }
    }
}
