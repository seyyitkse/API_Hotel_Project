using System.ComponentModel.DataAnnotations;

namespace HotelProject.EntityLayer.Concrete
{
    public class SendMessage
    {
        [Key]
        public int SendMessageId { get; set; }
        public string SenderName { get; set; }
        public string SenderMail{ get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
