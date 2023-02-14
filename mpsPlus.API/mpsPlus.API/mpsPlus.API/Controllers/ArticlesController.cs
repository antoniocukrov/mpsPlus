using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mpsPlus.API.Data;
using mpsPlus.API.Models;

namespace mpsPlus.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly mpsPlusDbContext _mpsPlusDbContext;
        public ArticlesController(mpsPlusDbContext mpsPlusDbContext)
        {
            _mpsPlusDbContext = mpsPlusDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _mpsPlusDbContext.Articles.ToListAsync();

            return Ok(articles);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody] Article articleRequest)
        {
            articleRequest.Id = Guid.NewGuid();
            await _mpsPlusDbContext.Articles.AddAsync(articleRequest);
            await _mpsPlusDbContext.SaveChangesAsync();

            return Ok(articleRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetArticle([FromRoute] Guid id)
        {
            var article = await _mpsPlusDbContext.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateArticle([FromRoute] Guid id, Article updateArticleRequest)
        {
            var article = await _mpsPlusDbContext.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            article.Name = updateArticleRequest.Name;
            article.Price = updateArticleRequest.Price;
            article.Quantity = updateArticleRequest.Quantity;
            article.Eancode = updateArticleRequest.Eancode;

            

            await _mpsPlusDbContext.SaveChangesAsync();

            return Ok(article);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteArticle([FromRoute] Guid id)
        {
            var article = await _mpsPlusDbContext.Articles.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            _mpsPlusDbContext.Articles.Remove(article);
            await _mpsPlusDbContext.SaveChangesAsync();

            return Ok(article);
        }
    }
}
