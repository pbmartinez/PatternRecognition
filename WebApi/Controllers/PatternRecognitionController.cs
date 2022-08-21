using Core;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/patterns")]
    [ApiController]
    public class PatternRecognitionController : ControllerBase
    {
        
        [HttpGet("recognize-sentiment")]
        public ActionResult<SentimentAnalysis.ModelOutput> GetSentiment([FromQuery]SentimentAnalysis.ModelInput input)
        {
            return Ok(SentimentAnalysis.Predict(input));
        }

        [HttpGet("recognize-image")]
        public IActionResult GetPicture(string imageInBase64)
        {
            byte[] arrayOfBytes = Convert.FromBase64String(imageInBase64);
            /*
             
        Console.WriteLine("Byte Array is: " + String.Join(" ", bytes));
 
        string str = Convert.ToBase64String(bytes);
        Console.WriteLine("The String is: " + str);*/
            RecognizeNaturalImages.ModelInput input = new RecognizeNaturalImages.ModelInput()
            {
                ImageSource = arrayOfBytes
            };
            return Ok(RecognizeNaturalImages.Predict(input));
        }

        private void UploadFiles(InputFileChangeEventArgs e)
        {
            var picture = e.GetMultipleFiles().FirstOrDefault();
            var arrayOfBytes = new byte[picture.Size];
            using (var ms = picture.OpenReadStream())
            {
                var bytesRead = ms.Read(arrayOfBytes,0, arrayOfBytes.Length);
            }
            string str = Convert.ToBase64String(arrayOfBytes);

        }
    }
}
