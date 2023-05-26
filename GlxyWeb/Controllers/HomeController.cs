using GlxyWeb.Helper;
using GlxyWeb.Models;
using Microsoft.AspNetCore.Mvc;


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
            var findAlarmName = _result.Any(x => x.Alarm_name.ToLower() == model.Alarm_name.ToLower());
            if (findAlarmName)
            {
                ViewBag.Message = "A record with a similar name was found. Rename this record";
                return View();
            }
            model.Repeat = DateTime.Parse(model.Repeat).ToString("dd.MM.yyyy");
            model.Active = true;

            new Helper.Data().InsertData(model);
        
            return View();
        }

        public IActionResult Edit()
        {
            var data = new Helper.Data().GetData().Find(p => p.Alarm_name == "Maintenance");
            //data.Repeat = DateTime.Parse(data.Repeat).ToString("yyyy-MM-dd");
            return View(data);

        }
        [HttpPost]
        public IActionResult Edit(AlarmModel model)
        {
            model.Active = true;
            model.Repeat = DateTime.Parse(model.Repeat).ToString("dd.MM.yyyy");
            model.Message= model.Message.Trim();
            new Helper.Data().EditData(model);
            return RedirectToAction("Index");
        }


    }

}
