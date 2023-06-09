﻿using System.ComponentModel.DataAnnotations.Schema;

namespace GlxyWeb.Models
{
    public class AlarmModel
    {
        public string Alarm_name { get; set; }
        public string Repeat { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }
        public string Message { get; set; }
        public bool Active { get; set; }
    }
}
