using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    internal class SalesDetailModel
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}
