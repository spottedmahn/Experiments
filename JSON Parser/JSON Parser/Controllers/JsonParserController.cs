using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JSONParser.Controllers
{
    [Route("api/json-parser")]
    public class JsonParserController : Controller
    {
        [Route("sample-data")]
        public object ParseSampleData()
        {
            var mlEscapedJson = "{\"message\":\"Error: Model Validation Failed Failures:{\\\"valid\\\":false,\\\"errors\\\":[{\\\"keyword\\\":\\\"enum\\\",\\\"dataPath\\\":\\\".accountType\\\",\\\"schemaPath\\\":\\\"#/properties/accountType/enum\\\",\\\"params\\\":{\\\"allowedValues\\\":[\\\"Admin\\\",\\\"Associate\\\",\\\"HRAdmin\\\"]},\\\"message\\\":\\\"should be equal to one of the allowed values\\\"}]} - {\\\"id\\\":\\\"961369bc-6ab6-4728-8089-45b8019ce9b1\\\",\\\"organizationId\\\":\\\"82418114-2170-4a78-80f8-0db5f6f85403\\\",\\\"accountType\\\":\\\"HrAdmin\\\",\\\"isActive\\\":true,\\\"firstName\\\":\\\"Postman\\\",\\\"lastName\\\":\\\"Tests\\\",\\\"emailAddress\\\":\\\"user@example.com\\\",\\\"registration1Question\\\":\\\"string\\\",\\\"registration1Answer\\\":\\\"string\\\",\\\"registration2Question\\\":\\\"string\\\",\\\"registration2Answer\\\":\\\"string\\\",\\\"registration3Question\\\":\\\"string\\\",\\\"registration3Answer\\\":\\\"string\\\",\\\"entity\\\":\\\"User\\\"}\",\"stack\":\"Error: Model Validation Failed Failures:{\\\"valid\\\":false,\\\"errors\\\":[{\\\"keyword\\\":\\\"enum\\\",\\\"dataPath\\\":\\\".accountType\\\",\\\"schemaPath\\\":\\\"#/properties/accountType/enum\\\",\\\"params\\\":{\\\"allowedValues\\\":[\\\"Admin\\\",\\\"Associate\\\",\\\"HRAdmin\\\"]},\\\"message\\\":\\\"should be equal to one of the allowed values\\\"}]} - {\\\"id\\\":\\\"961369bc-6ab6-4728-8089-45b8019ce9b1\\\",\\\"organizationId\\\":\\\"82418114-2170-4a78-80f8-0db5f6f85403\\\",\\\"accountType\\\":\\\"HrAdmin\\\",\\\"isActive\\\":true,\\\"firstName\\\":\\\"Postman\\\",\\\"lastName\\\":\\\"Tests\\\",\\\"emailAddress\\\":\\\"user@example.com\\\",\\\"registration1Question\\\":\\\"string\\\",\\\"registration1Answer\\\":\\\"string\\\",\\\"registration2Question\\\":\\\"string\\\",\\\"registration2Answer\\\":\\\"string\\\",\\\"registration3Question\\\":\\\"string\\\",\\\"registration3Answer\\\":\\\"string\\\",\\\"entity\\\":\\\"User\\\"}\\n    at UserModel.save (/ext/model/BaseModel.sjs:698:13)\\n    at asArray.forEach.e (/ext/model/BaseModel.sjs:420:11)\\n    at Array.forEach (native)\\n    at Function.load (/ext/model/BaseModel.sjs:417:19)\\n    at PUT (/marklogic.rest.resource/user/assets/resource.sjs:8:21)\\n    at Object.e [as PUT] (/ext/BaseAPI.sjs:11:36)\\n    at xdmp.invokeFunction (/dispatcher/dispatcher.sjs:64:71)\\n    at /dispatcher/dispatcher.sjs:63:20\"}";
            //var token = JToken.Parse(mlEscapedJson);
            //var json = JObject.Parse((string)token);
            var json = JsonConvert.DeserializeObject(mlEscapedJson);
            return json;
        }
    }
}
