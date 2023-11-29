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
        Task<(bool, string)> Save(ProductModel product);
        Task<bool> Update(ProductModel product);
        Task<bool> Delete(int Id);
        Task<List<ProductModel>> GetAll();
    }
}
