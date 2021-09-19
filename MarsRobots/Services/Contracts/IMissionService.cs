namespace MarsRobots.Services.Contracts
{
    using MarsRobots.Models;

    public interface IMissionService
    {
        public MissionData DeployRobots(MissionData inputData);

    }
}
