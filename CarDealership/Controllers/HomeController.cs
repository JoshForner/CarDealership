using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarDealership.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        private readonly DAL dAL = new DAL();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy(string CarMake, string CarModel, string CarColor, int? CarYear)
        {
            List<Cars> list = await dAL.GetCars();
            List<Cars> clist = list.Where(x => (CarColor == null || x.CarColor.ToLower() == CarColor.ToLower()) && (CarMake == null || x.CarMake.ToLower() == CarMake.ToLower()) &&
            (CarModel == null || x.CarModel.ToLower() == CarModel.ToLower()) && (CarYear == null || x.CarYear.Year == CarYear)).ToList();


            return View(clist);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
