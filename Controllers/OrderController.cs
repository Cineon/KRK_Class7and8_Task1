using KRK_Class7_Task1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KRK_Class7_Task1.Controllers
{
    public class OrderController : Controller
    {

        private readonly MyDbContext _dbContext;
        public OrderController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Orders.Include(o => o.Client).ToListAsync());
        }
    }
}
