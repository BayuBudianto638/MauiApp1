using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Applications.Customers
{
    public interface ICustomerAppService
    {
        Task<(bool, string)> Save(CustomerModel customer);
        Task<bool> Update(CustomerModel customer);
        Task<bool> Delete(int Id);
        Task<List<CustomerModel>> GetAll();
    }
}
