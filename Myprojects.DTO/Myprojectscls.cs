using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myprojects.DTO
{
    public class Myprojectscls : IMyprojectcls
    {
      
    }
    public class UserLoginInfo:IUserLoginInfo
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
    }
    public class Admindashboard:IAdminDashboard { 
        public int Noofcustomer {get;set; }
        public int TotalSales {  get;set;}
        public int NoofOrders { get; set; }
        public int NoOfProducts { get; set; }
    }
    public class Products: IProducts
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

}
