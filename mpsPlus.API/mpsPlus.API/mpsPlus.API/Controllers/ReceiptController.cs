using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mpsPlus.API.Data;
using mpsPlus.API.Models;

namespace mpsPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptsController : Controller
    {
        private readonly mpsPlusDbContext _mpsPlusDbContext;
        public ReceiptsController(mpsPlusDbContext mpsPlusDbContext)
        {
            _mpsPlusDbContext = mpsPlusDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllReceipts()
        {
            var receipts = await _mpsPlusDbContext.Receipts.ToListAsync();

            return Ok(receipts);
        }

        [HttpPost]
        public async Task<IActionResult> AddReceipt([FromBody] Receipt ReceiptRequest)
        {
            
            await _mpsPlusDbContext.Receipts.AddAsync(ReceiptRequest);
            await _mpsPlusDbContext.SaveChangesAsync();

            return Ok(ReceiptRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetReceipt([FromRoute] Guid id)
        {
            var Receipt = await _mpsPlusDbContext.Receipts.FirstOrDefaultAsync(x => x.Id == id);

            if (Receipt == null)
            {
                return NotFound();
            }
            return Ok(Receipt);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateReceipt([FromRoute] Guid id, Receipt updateReceiptRequest)
        {
            var receipt = await _mpsPlusDbContext.Receipts.FindAsync(id);

            if (receipt == null)
            {
                return NotFound();
            }

            receipt.Name = updateReceiptRequest.Name;
            receipt.ReceiptNumber = updateReceiptRequest.ReceiptNumber;
            receipt.Employee = updateReceiptRequest.Employee;
            

            await _mpsPlusDbContext.SaveChangesAsync();

            return Ok(receipt);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteReceipt([FromRoute] Guid id)
        {
            var receipt = await _mpsPlusDbContext.Receipts.FindAsync(id);

            if (receipt == null)
            {
                return NotFound();
            }

            _mpsPlusDbContext.Receipts.Remove(receipt);
            await _mpsPlusDbContext.SaveChangesAsync();

            return Ok(receipt);
        }
    }
}
