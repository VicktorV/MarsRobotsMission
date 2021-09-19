namespace MarsRobots.Services.Contracts
{
    using MarsRobots.Models;

    public interface IDataReaderService
    {
        public MissionData ReadInputFile();
    }
}
