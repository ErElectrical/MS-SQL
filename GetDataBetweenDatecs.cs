using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Employee_Payroll
{
    public class GetDataBetweenDatecs
    {
        public static string ConnectionString = @"DataServer=DESKTOP-2G853OJ;Initial Catalog=Payroll_Services;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionString);

        public void GetDataDates()
        {
            try
            {
                EmployeePayrollModel model = new EmployeePayrollModel();
                using (this.connection)
                {
                    string query = @"select * from Employee_Pay where startdate between cast('2015-08-30' as date) and getdate();";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            model.EmployeeId = dr.GetInt32(0);
                            model.stratdate = dr.GetDateTime(1);
                            model.Phonenumber = dr.GetString(2);
                            model.Address = dr.GetString(3);
                            model.Department = dr.GetString(4);
                            model.state = dr.GetString(5);
                            model.Country = dr.GetString(6);
                            model.basicPay = dr.GetDouble(7);
                            model.Deducations = dr.GetDouble(8);

                            model.Deducations = dr.GetDouble(8);

                            model.TaxPay = dr.GetDouble(9);
                            model.Tax = dr.GetDouble(10);

                            model.NetPay = dr.GetDouble(11);

                            model.gender = dr.GetString(12);
                            model.EmployeeName = dr.GetString(13);

                            Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}", model.EmployeeId, model.EmployeeName, model.stratdate, model.Phonenumber, model.NetPay, model.state, model.TaxPay);
                            Console.WriteLine("\n");

                        }

                    }
                    else
                    {
                        Console.WriteLine("No result found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
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
