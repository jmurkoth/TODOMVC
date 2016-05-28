using Microsoft.Extensions.Logging;
using System;
using ToDo.Core.Repos;
using ToDo.Core.Models;
using TodoMVCRC1.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoMVCRC1.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private IToDoRepository _todoRepo;
        private ILogger<HomeController> _logger;
        public HomeController(IToDoRepository todoRepo, ILogger<HomeController> logger)
        {
            _todoRepo = todoRepo;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Getting the Items-Info");
            _logger.LogDebug("Getting the Items-Debug");
           var items= _todoRepo.GetAll();
            HomeViewModel hvm = new HomeViewModel { NewToDoITem = new ToDoItem { }, ToDoItems = items };
            return View(hvm);
        }
        public IActionResult Completed()
        {
            var items = _todoRepo.GetCompleted();
            return View(items);
        }
        public IActionResult Active()
        {
            var items = _todoRepo.GetActive();
            return View(items);
        }
        public IActionResult Edit(Guid id)
        {
            var item = _todoRepo.GetById(id);
            var todovm = new ToDoViewModel { Description = item.Description, ID = item.Id, IsComplete = item.IsComplete, Title = item.Title };
            var vm = new EditViewModel { Item = todovm, Referrer = Request.Headers["referer"] };
            return View(vm);
        }
        [HttpPost]
        public IActionResult Edit(EditViewModel vmitem)
        {
         
          if(ModelState.IsValid && vmitem.Item.ID.HasValue)
            {
                var matchItem = _todoRepo.GetById(vmitem.Item.ID.Value);
                matchItem.Title = vmitem.Item.Title;
                matchItem.Description = vmitem.Item.Description;
                matchItem.IsComplete = vmitem.Item.IsComplete;
                matchItem.UpdatedDate = DateTime.Now;
                matchItem.UpdatedBy = "jm-upd";
                _todoRepo.Update(matchItem);
            }
          if( string.IsNullOrEmpty(vmitem.Referrer))
            {
                return RedirectToAction("index");
            }
          else
            {
                return Redirect(vmitem.Referrer);
            }
           
        }

        [HttpPost]
        public IActionResult Update(Guid id,  [FromForm]bool isComplete, string type)
        {
            var destView = string.IsNullOrEmpty(type) ? "index" : type;
            var matchItem = _todoRepo.GetById(id);
            matchItem.IsComplete = !isComplete;
            matchItem.UpdatedDate = DateTime.Now;
            matchItem.UpdatedBy = "jm-upd";
            _todoRepo.Update(matchItem);
            return RedirectToAction(destView);
        }

        [HttpPost]
        public IActionResult Add(HomeViewModel item)
        {
            item.NewToDoITem.CreatedDate = DateTime.Now;
            item.NewToDoITem.CreatedBy = "jmurkoth";
            _todoRepo.Add(item.NewToDoITem);
              return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Delete( Guid id , string type)
        {
            var destView = string.IsNullOrEmpty(type) ? "index": type;
           _todoRepo.DeleteById(id);
           return RedirectToAction(destView);
        }
    }
}
