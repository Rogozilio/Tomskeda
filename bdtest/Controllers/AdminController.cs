using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using bdtest.Functions;
using bdtest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace bdtest.Controllers
{
    public class AdminController : Controller
    {
        IWebHostEnvironment _appEnvironment;

        ProductContext _dataBase = new ProductContext();
        public AdminController(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            Product products = new Product();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, string[] day, string[] komplex, IFormFile image, string path,
                                                    string Kkal, string Belki, string Jiry, string Uglevod, string action)
        {
            product.Day = "";
            product.Komplex = "";  
            foreach(var iday in day)
            {
                product.Day += iday + " ";
            }
            foreach (var ikomplex in komplex)
            {
                product.Komplex += ikomplex + " ";
            }
            product.Info = "100г: Ккал " + Kkal
                            + "  Б "+ Belki
                           + "  Ж "+ Jiry
                          + "  У "+ Uglevod;
            if(action == "Добавить")
            { 
                product.Image = "/pict/eda/" + image.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + product.Image, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                _dataBase.Add(product);
                _dataBase.SaveChanges();
            }
            if(action == "Изменить")
            {
                if (image != null)
                {
                    product.Image = "/pict/eda/" + image.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + product.Image, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                }
                else
                {
                    product.Image = "/pict/eda/" + path;
                }
                _dataBase.Update(product);
                _dataBase.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
