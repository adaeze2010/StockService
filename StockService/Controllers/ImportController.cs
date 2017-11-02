using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockService.Model;
using Microsoft.Extensions.Logging;
using StockService.Importer;

namespace StockService.Controllers
{
    [Produces("application/json")]
    [Route("api/Import")]
    public class ImportController : Controller
    {
        private readonly ILogger _logger;
        private readonly ImportDispatcher _importDispatcher;

        public ImportController(ImportDispatcher importDispatcher, ILogger<ImportController> logger)
        {
            _importDispatcher = importDispatcher;
            _logger = logger;
        }

        // POST: api/Import
        [HttpPost]
        public void Post([FromBody]ImportDto importDto)
        {
            _logger.LogInformation("Received payload with content {0}", importDto.Payload);
            _importDispatcher.Dispatch(importDto);
        }
    }
}
