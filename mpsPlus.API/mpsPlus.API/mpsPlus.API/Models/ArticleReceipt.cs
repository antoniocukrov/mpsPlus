namespace mpsPlus.API.Models
{
    public class ArticleReceipt
    {
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

        public Guid ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
    }
}
