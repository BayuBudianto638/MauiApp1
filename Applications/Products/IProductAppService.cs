using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Applications.Products
{
    internal interface IProductAppService
    {
        Task<(bool, string)> Save(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(int Id);
        Task<List<Product>> GetAll();
    }
}
