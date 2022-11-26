using BusinessLogic.Services;
using BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    //are going to handle the incoming requests and outgoing responses
    public class ItemsController : Controller
    {
        private ItemsServices itemsService;
        public ItemsController(ItemsServices _itemsService) 
        {
            itemsService = _itemsService;
        }
        //a method to open the page, then th user starts typing
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //a method to handle the submission of the form
        [HttpPost]
        public IActionResult Create(CreateItemViewModel data)
        {
            try
            {
                itemsService.AddItem(data); //to test
                ViewBag.Message = "Item successfully created!";
            }
            catch (Exception ex) 
            {
                ViewBag.Error = "Item wasn't inserted. Please verify inputs!";
            }
            
            return View();
        }


    }
}
