using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController:ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string>lst= new List<string>();
            lst.Add("hola controller  con entity");
            return lst;
        }

    }
}