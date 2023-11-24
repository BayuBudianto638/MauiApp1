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
        (bool, string) Save(Customer customer);
        bool Update(Customer customer);
        bool Delete(int Id);
    }
}
