using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Applications.Sales
{
    internal interface ISalesAppService
    {
        Task<(bool, string)> Save(SalesHeader salesHeader);
        Task<bool> Update(SalesHeader salesHeader);
        Task<bool> Delete(int Id);
        Task<List<SalesHeader>> GetAll();
    }
}
