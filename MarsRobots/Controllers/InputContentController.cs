namespace MarsRobots.Controllers
{
    using MarsRobots.Models;
    using MarsRobots.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class InputContentController : ControllerBase
    {
        private readonly IDataReaderService DataReaderService;

        public InputContentController(IDataReaderService dataReaderService)
        {
            this.DataReaderService = dataReaderService;
        }

        [HttpGet]
        public MissionData GetInputContent()
        {
            return DataReaderService.ReadInputFile();
        }
    }
}
