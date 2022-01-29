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
        public static string ConnectionString = @"DataServer=DESKTOP-2G853OJ;Initial Catalog=Payroll_Services;Integrated Security=True";
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
                        Console.WriteLine("data not found ");
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

        public void  AddEmployee(EmployeePayrollModel emp)
        {
            try
            {
                /* this approach is through procedure of sql
                 * with the help of proceure we can reuse the instructions again and again
                
                using(this.connection)
                {
                    SqlCommand cmd = new SqlCommand(SPhelpInserting, this.connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(@EmployeeName, EmployeePayrollModel.EmployeeName);
                    cmd.Parameters.AddWithValue(@Phonenumber, EmployeePayrollModel.Phonenumber);
                    cmd.Parameters.AddWithValue(@Startdate, EmployeePayrollModel.stratdate);

                    cmd.Parameters.AddWithValue(@Emp_Address, EmployeePayrollModel.Address);

                    cmd.Parameters.AddWithValue(@Dept_Name, EmployeePayrollModel.Department);

                    cmd.Parameters.AddWithValue(@state_belong, EmployeePayrollModel.state);

                    cmd.Parameters.AddWithValue(@Country, EmployeePayrollModel.Country);

                    cmd.Parameters.AddWithValue(@BasicPay, EmployeePayrollModel.basicPay);

                    cmd.Parameters.AddWithValue(@Deducations, EmployeePayrollModel.Deducations);

                    cmd.Parameters.AddWithValue(@TaxPay, EmployeePayrollModel.TaxPay);

                    cmd.Parameters.AddWithValue(@IncomeTax, EmployeePayrollModel.Tax);

                    cmd.Parameters.AddWithValue(@NetPay, EmployeePayrollModel.NetPay);

                    cmd.Parameters.AddWithValue(@gender, EmployeePayrollModel.gender);
                */


                using (this.connection)
                {
                    string query = @"insert into Employee_Pay(Startdate,Emp_PhoneNumber,Emp_Address,Dept_Name,state_belong,Country,BasicPay,Deducations,TaxPay,IncomeTax,NetPay,gender,Emp_Name" +
                                    "values(emp.stratdate,emp.Phonenumber,emp.Address,emp.Department,emp.state,emp.Country,emp.basicPay,emp.Deducations,emp.TaxPay,emp.Tax,emp.gender,emp.EmployeeName)";

                    this.connection.Open();
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Close();
                    int numberofinsertion = cmd.ExecuteNonQuery();

                    if (numberofinsertion > 0)
                    {
                        Console.WriteLine("insertion occur");
                    }

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

        public void Uccases()
        {
            try
            {
                using(this.connection)
                {
                    Sqlcommand cmd = new Sqlcommand("UccasesHelp", this.connection);
                    cmd.commandtype = System.Data.CommandType.StoredProcedure;
                    this.connection.Open();
                    SqlDataReader record = cmd.ExecuteReader();
                    if(record.HasRows)
                    {
                        Console.WriteLine("\n 1. sum of salary male and female " +
                            "\n 2. max of salary male or female " +
                            "\n 3. min of slary male and female" +
                            "\n 4. count of male and female");
                        while(record.Read())
                        {
                            Console.WriteLine(record);
                            Console.WriteLine();
                        }
                    }


                }
            }
        }
    }
}
