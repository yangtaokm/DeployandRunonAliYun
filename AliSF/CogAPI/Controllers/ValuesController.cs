using Microsoft.ProjectOxford.Face;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using System;
using System.Diagnostics;

namespace CogAPI.Controllers
{
    public class ValuesController : ApiController
    {
  
        // POST api/values 
        public async Task<string> Get(string imgUrl)
        {
            
            VisionServiceClient visionclient = new VisionServiceClient("CognitiveServiceVisionKey");
            AnalysisResult result = null;
            try
            {
               result = await visionclient.DescribeAsync(imgUrl);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
           return result.Description.Captions[0].Text;
        }

    }
}
