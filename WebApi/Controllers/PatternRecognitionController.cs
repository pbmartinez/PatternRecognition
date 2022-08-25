using Core;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.ML;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/patterns")]
    [ApiController]
    public class PatternRecognitionController : ControllerBase
    {
        PredictionEnginePool<RecognizeNaturalImages.ModelInput, RecognizeNaturalImages.ModelOutput> predictionEnginePool;

        public PatternRecognitionController(PredictionEnginePool<RecognizeNaturalImages.ModelInput, RecognizeNaturalImages.ModelOutput> predictionEnginePool)
        {
            this.predictionEnginePool = predictionEnginePool ?? throw new ArgumentNullException(nameof(predictionEnginePool));
        }

        [HttpGet("recognize-sentiment")]
        public ActionResult<SentimentAnalysis.ModelOutput> GetSentiment([FromQuery]SentimentAnalysis.ModelInput input)
        {
            return Ok(SentimentAnalysis.Predict(input));
        }

        [HttpPost("recognize-image")]
        public IActionResult GetPicture([FromBody]string imageInBase64)
        {
            byte[] arrayOfBytes = Convert.FromBase64String(imageInBase64);
            
            var input = new RecognizeNaturalImages.ModelInput()
            {
                ImageSource = arrayOfBytes
            };
            var output = predictionEnginePool.Predict(input);
            return Ok(output);
        }
        [HttpPost("recognize-image-bytes")]
        public IActionResult GetPicture([FromBody]byte[] arrayOfBytes)
        {
            var input = new RecognizeNaturalImages.ModelInput()
            {
                ImageSource = arrayOfBytes
            };
            var output = predictionEnginePool.Predict(input);
            return Ok(output);
        }
    }
}
