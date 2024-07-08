using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myprojects.DTO
{
    public interface IMyprojectcls
    {
       
    }
    public interface IUserLoginInfo
    {
        string Username { get; set; }
        string Password { get; set; }
        int RoleID { get; set; }
        string Email { get; set; }
    }
    public interface IAdminDashboard
    {
        int Noofcustomer { get; set; }
        int TotalSales { get; set; }
        int NoofOrders { get; set; }
        int NoOfProducts { get; set; }
    }
    public interface IProducts
    {
        int Productid { get; set; }
        string ProductName { get; set; }
        int CategoryID { get; set; }
        decimal Price { get; set; }
        int StockQuantity { get; set; }
    }
}
