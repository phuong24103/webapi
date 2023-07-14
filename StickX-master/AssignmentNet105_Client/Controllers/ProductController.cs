using AssignmentNet105_Client.Services;
using AssignmentNet105_Shared.Data;
using AssignmentNet105_Shared.Models;
using AssignmentNet105_Shared.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Http;
using System.Security.Principal;
using System.Text;

namespace AssignmentNet105_Client.Controllers
{
    public class ProductController : Controller
    {
        TServices _services = new TServices();
        public async Task<IActionResult> Index()
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
                if (user.RoleId == Guid.Parse("9d76eb12-8c3c-4dcf-a389-4a807ecf0a31"))
                {
                    return View(await _services.GetAll<ProductView>("https://localhost:7197/api/product"));
                }
            }
            var product = await _services.GetAll<ProductView>("https://localhost:7197/api/product");
            var p = product.GroupBy(p => new { p.Name, p.ColorID }).Select(g => g.First()).ToList();
            return View(p);
        }
        public async Task<IActionResult> Search(string search)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            return View("Index", await _services.GetAll<ProductView>($"https://localhost:7197/api/product/{search}"));
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            var result = await _services.GetAllById<Product>($"https://localhost:7197/api/product/{id}");
            var name = await _services.GetAll<ProductView>($"https://localhost:7197/api/product/{result.Name}");
            List<Color> color = new List<Color>();
            List<Size> size = new List<Size>();
            foreach (var item in name)
            {
                bool a = false;
                foreach (var items in color)
                {
                    if (items.Id == item.ColorID)
                    {
                        a = true;
                        break;
                    }
                }
                if (!a)
                    color.Add(item.Color);
                /*// select sort
                for (int i = 0; i < color.Count - 1; i++)
                {
                    for (int j = i + 1; j < color.Count; j++)
                    {
                        if (Convert.ToUInt32(color[i].Name) < Convert.ToUInt32(color[j].Name))
                        {
                            Color c = color[i];
                            color[i] = color[j];
                            color[j] = c;
                        }
                    }
                }*/
                bool b = false;
                foreach (var items in size)
                {
                    if (items.Id == item.SizeID)
                    {
                        b = true;
                        break;
                    }
                }
                if (!b)
                    size.Add(item.Size);
            }
            ViewData["colors"] = color;
            ViewData["sizes"] = size;
            return View(result);
        }
        public async Task<IActionResult> Create()//Mở form
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            var allColor = await _services.GetAll<Color>("https://localhost:7197/api/color");
            List<Color> color = new List<Color>();
            foreach (var item in allColor)
            {
                color.Add(item);
            }
            ViewData["color"] = color;
            var allSize = await _services.GetAll<Size>("https://localhost:7197/api/size");
            List<Size> size = new List<Size>();
            foreach (var item in allSize)
            {
                size.Add(item);
            }
            ViewData["size"] = size;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product, IFormFile imageFile)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            product.Status = 0;
            product.Likes = 0;
            if (imageFile != null && imageFile.Length > 0)//Kiểm tra đường dẫn phù hợp
            {
                //thực hiện sao chép ảnh đó vào wwwroot
                //Tạo đường dẫn tới thư mục sao chép (nằm trong root)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);//abc/wwwroot/Images/xxx.png
                var stream = new FileStream(path, FileMode.OpenOrCreate);//Tạo 1 filestream để tạo mới
                await imageFile.CopyToAsync(stream);//copy ảnh vừa được chọn vào đúng cái stream đó
                                                    //gán lại giá trị link ảnh (lúc này đã nằm trong root cho thuộc tính ImageUrl)
                product.ImageUrl = imageFile.FileName;
            }
            await _services.CreateAll("https://localhost:7197/api/product", product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)//Mở form
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            var allColor = await _services.GetAll<Color>("https://localhost:7197/api/color");
            List<Color> color = new List<Color>();
            foreach (var item in allColor)
            {
                color.Add(item);
            }
            ViewData["color"] = color;
            var allSize = await _services.GetAll<Size>("https://localhost:7197/api/size");
            List<Size> size = new List<Size>();
            foreach (var item in allSize)
            {
                size.Add(item);
            }
            ViewData["size"] = size;
            var product = await _services.GetAllById<ProductView>($"https://localhost:7197/api/product/{id}");
            return View(product);
        }
        public async Task<IActionResult> Edit(ProductView product, IFormFile imageFile)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            if (imageFile != null && imageFile.Length > 0)//Kiểm tra đường dẫn phù hợp
            {
                //thực hiện sao chép ảnh đó vào wwwroot
                //Tạo đường dẫn tới thư mục sao chép (nằm trong root)
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", imageFile.FileName);//abc/wwwroot/Images/xxx.png
                var stream = new FileStream(path, FileMode.OpenOrCreate);//Tạo 1 filestream để tạo mới
                await imageFile.CopyToAsync(stream);//copy ảnh vừa được chọn vào đúng cái stream đó
                                                    //gán lại giá trị link ảnh (lúc này đã nằm trong root cho thuộc tính ImageUrl)
                product.ImageUrl = imageFile.FileName;
            }
            await _services.EditAll($"https://localhost:7197/api/product/{product.Id}", product);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            await _services.DeleteAll<Product>($"https://localhost:7197/api/product/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Like(Guid id)
        {
            var user = SessionServices.GetAccountFromSession(HttpContext.Session, "User");
            if (user.Status != 404)
            {
                ViewBag.RoleId = user.RoleId;
            }
            HttpClient httpClient = new HttpClient(); // tạo ra để callApi
            var request = new HttpRequestMessage(HttpMethod.Options, $"https://localhost:7197/api/favoriteProducts/{user.Id}/{id}");
            await httpClient.SendAsync(request);
            return RedirectToAction("Index", "FavoriteProducts");
        }
    }
}
