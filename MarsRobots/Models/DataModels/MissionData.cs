namespace MarsRobots.Models
{
    using System.Collections.Generic;
    using MarsRobots.Models.PlanetModels;

    public class MissionData
    {
        public Grid Grid { get; set; } = new();

        public IList<Robot> RobotList { get; set; } = new List<Robot>();
    }
}
