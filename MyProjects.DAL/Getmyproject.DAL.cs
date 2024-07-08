using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProjects.DAL;
using Myprojects.DTO;
using System.Data.SqlClient;



namespace MyProjects.DAL
{
  
    public partial class MyprojectsDAL
    {
        DataTable _dteSmartApps;
        class Getmyproject
        {
        }
        public DataTable SMSLogin(UserLoginInfo objSMSLogin)
        {
            _dteSmartApps = new DataTable();
            try
            {
                using (SqlCommand _SqlCmd = new SqlCommand("Login_SMSLoginDetails", MyprojectsDAL.GetConnection))
                {
                    _SqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    _SqlCmd.Parameters.Add("@LoginName", SqlDbType.NVarChar, 50).Value = objSMSLogin.Username;
                    _SqlCmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = objSMSLogin.Password;

                    using (SqlDataAdapter _SqlDAdp = new SqlDataAdapter(_SqlCmd))
                    {
                        _SqlDAdp.Fill(_dteSmartApps);
                    }
                    _SqlCmd.Dispose();
                }
                return _dteSmartApps;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               MyprojectsDAL.CloseConnection();
            }
        }
        public Admindashboard Getadmindata()
        {
            Admindashboard objadmindashboard = new Admindashboard();
            DataSet DSadmindashboard = new DataSet();
            try
            {
                using(SqlCommand sqcmd=new SqlCommand("Get_AdminDashboard", GetConnection))
                {
                    sqcmd.CommandType = CommandType.StoredProcedure;
                    using(SqlDataAdapter DA=new SqlDataAdapter(sqcmd))
                    {
                        DA.Fill(DSadmindashboard);
                    }
                    if(DSadmindashboard.Tables[0].Rows.Count>0)
                    {
                        DataRow DTadmindash = DSadmindashboard.Tables[0].Rows[0];
                        objadmindashboard.Noofcustomer = Convert.ToInt32(DTadmindash["NoofCustomers"]);
                        objadmindashboard.NoofOrders = Convert.ToInt32(DTadmindash["NoofOrders"]);
                        objadmindashboard.NoOfProducts = Convert.ToInt32(DTadmindash["NoOfProducts"]);
                        objadmindashboard.TotalSales = Convert.ToInt32(DTadmindash["TotalSales"]);
                        
                    }
                    DSadmindashboard.Dispose();
                    sqcmd.Dispose();

                }
                return objadmindashboard;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public List<Products> Getproductslst()
        {
            List<Products> objproducts = new List<Products>();
            DataTable dtproducts = new DataTable();
            try {
                using (SqlCommand sqlcmd = new SqlCommand("Getallproducts", GetConnection))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter daproducts = new SqlDataAdapter(sqlcmd))
                    {
                        daproducts.Fill(dtproducts);
                    }
                    foreach (DataRow dr in dtproducts.Rows)
                    {

                        Products prods = new Products
                        {
                            Productid = Convert.ToInt32(dr["ProductID"]),
                            ProductName = Convert.ToString(dr["ProductName"]),
                            Price = Convert.ToDecimal(dr["Price"]),
                            CategoryID = Convert.ToInt32(dr["CategoryID"]),
                            StockQuantity = Convert.ToInt32(dr["StockQuantity"])


                        };
                        objproducts.Add(prods);

                    }
                    return objproducts;
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
