namespace SaintSender.Core.Models
{
    public class EmailConfiguration
    {
        public string SMTPFrom { get; set; }
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }
        public string SMTPLogin { get; set; }
        public string SMTPPassword { get; set; }
    }
}
