using System;
using System.Collections.Generic;
using System.Text;
using Tomskeda.Core.Entities;

namespace Tomskeda.Services.Interfaces
{
    public interface IProductService
    {
        List<String> GetKind(int day);
        List<string> GetKomplexKind(int day, bool isExtra = false);
        IEnumerable<Product> GetProductOnDayAndKind(int day, string kind);
        IEnumerable<Product> GetKomplexOnDayAndKind(int day, string kind);
        IEnumerable<Product> GetAllProducts();
        string[] GetProductOnId(string cookieId, string cookieCount);
        int GetPriceProducts(string cookieId, string cookieCount, bool isDelivery = true);
    }
}
