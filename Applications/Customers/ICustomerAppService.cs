using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Applications.Customers
{
    internal interface ICustomerAppService
    {
        Task<(bool, string)> Save(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Delete(int Id);
        Task<List<Customer>> GetAll();
    }
}
