using bdtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdtest.Functions
{
    public class Products
    {
        private ProductContext _base;
        public Products()
        {
            ProductContext dataBase = new ProductContext();
            _base = dataBase;
        } 

        public string[] GetAllKind()
        {
            string allKind = "";
            foreach(var product in _base.products.ToList())
            {
                allKind += product.Kind + ",";
            }
            string[] kinds = allKind.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            kinds = kinds.Distinct().ToArray();
            return kinds;
        }
        public List<string> GetKomplexKind(char day, bool extra = false)
        {
            List<String> list = new List<String>();
            foreach (var product in _base.products.ToList())
            {
                if (product.Kind == "Салаты и закуски" && !extra)
                    return list;
                if (product.Kind == "Салаты и закуски" && extra)
                    return list;
                if (product.Komplex.Contains(day) && !extra)
                {
                    list.Add(product.Kind);
                }
            }
            list = new List<string>(list.Distinct());
            return list;
        }
        public List<Product> GetProductOnDayAndKind(char day, string kind)
        {
            List<Product> list = new List<Product>();
            foreach (var product in _base.products.ToList())
            {
                if(product.Day.Contains(day) && product.Kind.Contains(kind))
                {
                    list.Add(product);
                }
            }
            return list;
        }
        public List<Product> GetKomplexOnDayAndKind(char day, string kind)
        {
            List<Product> list = new List<Product>();
            foreach (var product in _base.products.ToList())
            {
                if (product.Komplex.Contains(day) && product.Kind.Contains(kind))
                {
                    list.Add(product);
                }
            }
            return list;
        }
    }
}
