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
        [HttpPost]
        public IActionResult Update(int id,  [FromForm]string isComplete)
        {
            bool complete = string.IsNullOrEmpty(isComplete) ? false : (isComplete.Equals("on", StringComparison.OrdinalIgnoreCase) ? true : false);
            ToDoItem item = new ToDoItem { ID = id,   IsComplete=complete };
            _todoRepo.Update(item);
            return RedirectToAction("index");
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
