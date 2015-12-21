using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TodoMVCRC1.Models;
using Microsoft.Extensions.Logging;

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
        public IActionResult Edit(int id)
        {
            var item = _todoRepo.GetById(id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(ToDoViewModel item)
        {
         
          if(ModelState.IsValid && item.ID.HasValue)
            {
                var matchItem = _todoRepo.GetById(item.ID.Value);
                matchItem.Title = item.Title;
                matchItem.Description = item.Description;
                matchItem.IsComplete = item.IsComplete;
                _todoRepo.Update(matchItem);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(int id,  [FromForm]bool isComplete, string type)
        {
           
            var destView = "index";
            var matchItem = _todoRepo.GetById(id);
            matchItem.IsComplete = !isComplete;
            _todoRepo.Update(matchItem);

            if(!string.IsNullOrEmpty(type))
            {
                destView = type;
            }
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
        public IActionResult Delete( int id)
        {
           _todoRepo.DeleteById(id);
            var items = _todoRepo.GetAll();
            return RedirectToAction("index");
           
        }
    }
}
