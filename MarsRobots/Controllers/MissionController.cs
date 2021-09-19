namespace MarsRobots.Controllers
{
    using MarsRobots.Models;
    using MarsRobots.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class MissionController : ControllerBase
    {
        private readonly IDataReaderService DataReaderService;
        private readonly IDataWriterService DataWriterService;
        private readonly IMissionService MissionService;

        public MissionController(IDataReaderService dataReaderService, IDataWriterService dataWriterService, IMissionService missionService)
        {
            this.DataReaderService = dataReaderService;
            this.DataWriterService = dataWriterService;
            this.MissionService = missionService;
        }

        [HttpGet]
        public void StartMission()
        {
            MissionData missionData = DataReaderService.ReadInputFile();
            MissionService.Start(missionData);
            DataWriterService.WriteOutputFile(missionData);
        }
    }
}
