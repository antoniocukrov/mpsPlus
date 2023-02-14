using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace mpsPlus.API.Models
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public long Quantity  { get; set; }
        public long Eancode { get; set; }
        public ICollection<ArticleReceipt> ArticleReceipts { get; set; }
    }
}
