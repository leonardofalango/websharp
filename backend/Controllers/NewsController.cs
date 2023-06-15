using backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace backend.Controllers;

[ApiController]
[Route("News")]
[EnableCors("MainPolicy")]
public class NewsController : ControllerBase
{
    private WebSharpContext entity;
    public NewsController(WebSharpContext context)
        => this.entity = context;

    [HttpGet()]
    public IEnumerable<News> Get()
    {
        List<News> newerNews = new List<News>();
        
        var entities = entity.News.OrderBy(
            e => e.NewsDate
        );

        var result = entities.Take(5);
        return result;
    }

    [HttpGet("{newsId}")]
    public CompleteNews? Get(int newsId)
        => completeNews(entity.News.FirstOrDefault(e => e.Id == newsId)!);
    

    private CompleteNews completeNews(News news)
    {
        var query =
            from n in entity.News
                join c in entity.Cities
                    on n.IdCity equals c.Id
                join s in entity.States
                    on c.IdState equals s.Id
                join country in entity.Countries
                    on s.IdCountry equals country.Id
            select new CompleteNews
            {
                Id = n.Id,
                Title = n.Title,
                Thumb = n.Thumbnail,
                City = c.CityName,
                State = s.StateName,
                Country = country.CountryName,
                Date = n.NewsDate,
                Topics = new string[]{"1", "2", "3"}
            };
        return query.FirstOrDefault(e => e.Id == news.Id)!;
    }

    public class CompleteNews
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Thumb { get; set; }
        public string? City  { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public DateTime? Date { get; set; }
        public string[]? Topics { get; set; }
    }
    
}
