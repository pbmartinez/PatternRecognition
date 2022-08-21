using Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/patterns")]
    [ApiController]
    public class PatternRecognitionController : ControllerBase
    {
        
        [HttpGet("recognize-sentiment")]
        public ActionResult<SentimentAnalysis.ModelInput> GetSentiment([FromQuery]SentimentAnalysis.ModelInput input)
        {
            return Ok(SentimentAnalysis.Predict(input));
        }
        [HttpGet("recognize-image")]
        public ActionResult<SentimentAnalysis.ModelInput> GetPicture([FromQuery] RecognizeNaturalImages.ModelInput input)
        {
            return Ok(RecognizeNaturalImages.Predict(input));
        }
    }
}
