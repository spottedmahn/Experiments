using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SO_51816947_ActionResult_Interfaces.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IList<string>> Get()
        {
            //DOESN'T COMPILE:
            //Error CS0029  Cannot implicitly convert type 'System.Collections.Generic.IList<string>' to 'Microsoft.AspNetCore.Mvc.ActionResult<System.Collections.Generic.IList<string>>'
            //the cast here is for demo purposes.
            //the problem will usually arise from a dependency that returns
            //an interface.
            //var result = new List<string> { "value1", "value2" } as IList<string>;
            //return result;

            return new List<string> { "value1", "value2" };
        }
    }
}