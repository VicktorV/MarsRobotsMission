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
        private readonly IMissionService MissionService;

        public MissionController(IDataReaderService dataReaderService, IMissionService missionService)
        {
            this.DataReaderService = dataReaderService;
            this.MissionService = missionService;
        }

        [HttpGet]
        public MissionData StartMission()
        {
            MissionData missiontData = DataReaderService.ReadInputFile();
            return MissionService.DeployRobots(missiontData);
        }
    }
}
