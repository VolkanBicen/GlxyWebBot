﻿using GlxyWeb.Helper;
using GlxyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
            return View(_result.Where(x=>x.Active == true).OrderBy(x => x.Hour).OrderBy(x => x.Repeat).ToList());
        }
        public IActionResult ListDisable()
        {
            return View(_result.Where(x => x.Active == false).OrderBy(x => x.Hour).OrderBy(x => x.Repeat).ToList());
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

            model.Message.Trim();
            model.Active = true;

            new Data().InsertData(model);
            return View();
        }

        [HttpPost]
        public IActionResult Update(string alarm_name, bool status)
        {
            var data = _result.Find(p => p.Alarm_name == alarm_name);
            new Helper.Data().DeleteData(data, status);
            return Content("Success");
        }

        public IActionResult Edit(string alarm_name)
        {
            var data = new Data().GetData().Find(p => p.Alarm_name == alarm_name);
        
            return View(data);

        }
        [HttpPost]
        public IActionResult Edit(AlarmModel model)
        {
            model.Active = true;
            model.Message.Trim();
            
            model.Message = model.Message.Trim();
            new Helper.Data().EditData(model);
            return RedirectToAction("Index");
        }


    }

}
