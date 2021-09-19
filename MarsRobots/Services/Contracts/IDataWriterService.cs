namespace MarsRobots.Services.Contracts
{
    using MarsRobots.Models;
    public interface IDataWriterService
    {
        public void WriteOutputFile(MissionData missionData);
    }
}
