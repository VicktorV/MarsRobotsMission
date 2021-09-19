namespace MarsRobots.Services
{
    using MarsRobots.Common;
    using MarsRobots.Models;
    using MarsRobots.Services.Contracts;

    public class MissionService : IMissionService
    {
        //private readonly IUnitMovementService UnitMovementService;

        public MissionService(/*IUnitMovementService unitMovementService*/)
        {
            //this.UnitMovementService = unitMovementService;
        }

        public MissionData DeployRobots(MissionData missionData)
        {


            return new MissionData();
        }
    }

}
