using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace EgyptBYU.Controllers
{
    [ApiController]
    [Route("/prediction")]
    public class InferenceController : ControllerBase
    {
        private InferenceSession _session;

        public InferenceController(InferenceSession session)
        {
            _session = session;
        }

        [HttpPost]
        public ActionResult Prediction(Mummy_Data data)
        {
            var result = _session.Run(new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
            });
            Tensor<string> modelResult = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = modelResult.First() };
            result.Dispose();
            return Ok(prediction);
        }

    }
}