using System.ComponentModel.DataAnnotations;

namespace mpsPlus.API.Models
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long ReceiptNumber { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public ICollection<ArticleReceipt> ArticleReceipts { get; set; }


    }
}
