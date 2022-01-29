using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Employee_Payroll
{
    public class AddEmployeeTransaction
    {
        //It is a single unit of work.
        //If a transaction is successful, all of the data modifications made during the transaction
        //are committed and become a permanent part of the database.
        //If a transaction encounters errors or gets rolled back, then all of the data modifications are erased.

        public static string ConnectionString = @"DataServer=DESKTOP-2G853OJ;Initial Catalog=Employee_Payroll_Normalisation;Integrated Security=True";
        SqlConnection connection = new SqlConnection("ConnectionString");

        public void Transaction(EmployeePayrollModel model)
        {
            try
            {


                SqlTransaction trans;
                using (this.connection)
                {
                    trans = this.connection.BeginTransaction();

                    string query1 = @"insert into Company(startdate,Emp_Name,gender)" +
                                      "values(model.stratdate,model.EmployeeName,model.gender)";
                    SqlCommand cmd1 = new SqlCommand(query1, this.connection);
                    string query2 = @"insert into Payroll(Basic_Pay,Tax_Pay,Deductions,Income_Tax,Net_Pay) " +
                                      "values(model.basicPay,model.TaxPay,model.Deducations,model.Tax,model.NetPay)";
                    SqlCommand cmd2 = new SqlCommand(query2, this.connection);

                    SqlDataReader record1 = cmd1.ExecuteNonQuery();
                    SqlDataReader record2 = cmd2.ExecuteNonQuery();
                    if(record1 == record2)
                    {
                        Console.WriteLine("Entered successfully");
                    }
                    else
                    {
                        Console.WriteLine("Not successFully");
                    }

                    record1.Close();
                    record2.Close();
                    this.connection.Close();
                    trans.Commit();


                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.connection.rollback();
            }
            finally
            {
                if(connection != null)
                {
                    this.connection.Close();

                }
                
                
            }
        }


    }
}
