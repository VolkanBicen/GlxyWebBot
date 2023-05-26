namespace GlxyWeb.Models
{
    public class DataTableRequest
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public string search { get; set; }
        // Diğer gerekli parametreleri buraya ekleyebilirsiniz
    }
}
