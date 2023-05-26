using System.Security.Claims;

namespace GlxyWeb.Models
{
    public class DataTableResponse
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<AlarmModel> data { get; set; }
    }
}
