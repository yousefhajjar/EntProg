using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //are going to handle the incoming requests and outgoing responses
    public class ItemsController : Controller
    {
        private ItemsServices itemsService;
        private IWebHostEnvironment host;
        public ItemsController(ItemsServices _itemsService, IWebHostEnvironment _host) 
        {
            itemsService = _itemsService;
            host = _host;
        }

        //a method to open the page, then th user starts typing
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //a method to handle the submission of the form
        [HttpPost]
        public IActionResult Create(CreateItemViewModel data, IFormFile file)
        {
            try
            {
                if(file != null) 
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string absolutePath = host.WebRootPath;

                    using (FileStream fsOut = new(absolutePath + "\\Images\\" + fileName, FileMode.CreateNew))
                    {
                        file.CopyTo(fsOut);
                    }

                    data.PhotoPath = "/Images/" + fileName;
                }

                itemsService.AddItem(data); //to test
                ViewBag.Message = "Item successfully created!";
            }
            catch (Exception ex) 
            {
                ViewBag.Error = "Item wasn't inserted. Please verify inputs!";
            }
            
            return View();
        }

        public IActionResult List() 
        {
            var list = itemsService.GetItems();
            return View(list);
        }

        public IActionResult Details(int id) 
        {
            var myItem = itemsService.GetItem(id);
            return View(myItem);
        }

    }
}
