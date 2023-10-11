using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuizDbContext _dbContext;

        public QuestionsController(QuizDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> Get()
        {
            var random5Qns = await _dbContext.Questions.Select(x => new
            {
                QnId=x.QnId,
                QnInWords = x.QmInWords,
                ImageName = x.ImageName,
                Options= new string[] {x.Option1,x.Option2, x.Option3, x.Option4},
            }).OrderBy(y=>Guid.NewGuid()).Take(5).ToListAsync();
            return Ok(random5Qns);
        }
        //POST: api/Question/GetAnswers
        [HttpPost]
        [Route("GetAnswers")]
        public async Task<ActionResult<Question>> RetriveAnswers(int[] qnIds)
        {
           
            var answers =await _dbContext.Questions.Where(y => qnIds.Contains(y.QnId))
                .Select(x => new {
                    QnId = x.QnId,
                    QnInWords = x.QmInWords,
                    ImageName = x.ImageName,
                    Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 },
                    Answear= x.Answear

                }).ToListAsync();
            return Ok(answers);
        }

        
    }
}
