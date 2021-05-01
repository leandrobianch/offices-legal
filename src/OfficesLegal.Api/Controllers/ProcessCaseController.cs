using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficesLegal.Application.ProcessCases;
using OfficesLegal.Application.ViewModels.CouncilProcessCases;
using System.Threading.Tasks;

namespace OfficesLegal.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProcessCaseController : ControllerBase
    {
        private readonly ILogger<ProcessCaseController> _logger;
        private readonly IProcessCaseService _processCaseService;

        public ProcessCaseController(
            ILogger<ProcessCaseController> logger,
            IProcessCaseService processCaseService)
        {
            _logger = logger;
            _processCaseService = processCaseService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //[SwaggerResponse(statusCode: 201, description: "New Process Legal Case ", Type = typeof(CreatedCommitteeViewModelOutput))]
        //[SwaggerResponse(statusCode: 400, description: "Business validation", Type = typeof(ResultErrorViewModelOutput))]
        //[SwaggerResponse(statusCode: 404, description: "Resource not found", Type = typeof(ResultErrorViewModelOutput))]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(ProcessCasesViewModelInput processCaseViewModelInput)
        {
            return Created("", await _processCaseService.New(processCaseViewModelInput));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="processCaseViewModelInput"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, ProcessCasesViewModelInput processCaseViewModelInput)
        {
            return Accepted(await _processCaseService.Update(id, processCaseViewModelInput));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _processCaseService.Delete(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caseNumber"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{caseNumber}")]
        public async Task<IActionResult> Get(string caseNumber)
        {
            return Ok(await _processCaseService.GetByCaseNumber(caseNumber));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _processCaseService.GetAll());
        }
    }
}
