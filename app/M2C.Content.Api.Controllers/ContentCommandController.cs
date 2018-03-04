using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M2C.Content.Model;
using M2C.Content.Search;
using M2C.Core.Abstractions;
using M2C.Search.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace M2C.Content.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/content")]
    public class ContentCommandController : Controller
    {

        public IDataService<ContentItem> DataService { get; set; }
        public ContentCommandController(IDataService<ContentItem> dataService)
        {
            DataService = dataService ?? throw new NotImplementedException(nameof(dataService));

        }

        [HttpDelete("/{id}")]
        public IActionResult Delete(string id)
        {

            return Json(new { Message = id });
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContentItem inputModel)
        {

            return Json(new { Message = "post error" });
        }

        [HttpPut]
        public IActionResult Put([FromBody] ContentItem inputModel)
        {
            return Json(new { Message = "put error" });
        }


    }
}
