using EcommerceApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp.Controllers
{
    public class UserIdentityController : Controller
    {
        private readonly AppDbContext _dbContext;
        public UserIdentityController(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //public JsonResult Division()
        //{
        //    var divisions = _dbContext.Divisions.ToList();
        //    return new JsonResult(divisions);
        //}
        public JsonResult Zila(int id)
        {
            var zila = _dbContext.Zilas.Where(x => x.Id == id).ToList();
            return new JsonResult(zila);
        }
        public JsonResult thana(int id)
        {
            var thana = _dbContext.Thanas.Where(x => x.Id == id).ToList();
            return new JsonResult(thana);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
