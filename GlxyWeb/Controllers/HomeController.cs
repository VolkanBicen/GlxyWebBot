using GlxyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GlxyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<AlarmModel> _result;

        public HomeController()
        {
            _result = new Helper.Data().GetData();
        }

        public IActionResult Index()
        {
            return View(_result.OrderBy(x => x.Hour).OrderBy(x => x.Repeat).OrderBy(x => x.Active).ToList());
        }

        [HttpPost]
        public IActionResult Update(string alarm_name, bool status)
        {
            var data = _result.Find(p => p.Alarm_name == alarm_name);
            new Helper.Data().DeleteData(data, status);
            return Content("Success");
        }

        public IActionResult CreateAlarm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAlarm(AlarmModel model)
        {
            model.Repeat = DateTime.Parse(model.Repeat).ToString("dd.MM.yyyy");
            model.Active = true;
            new Helper.Data().InsertData(model);
            return View();
        }

    }
}