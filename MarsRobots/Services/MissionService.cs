namespace MarsRobots.Services
{
    using System.Linq;
    using MarsRobots.Common;
    using MarsRobots.Models;
    using MarsRobots.Models.PlanetModels;
    using MarsRobots.Services.Contracts;

    public class MissionService : IMissionService
    {
        public void Start(MissionData missionData)
        {
            foreach (Robot robot in missionData.RobotList.Where(x => x.Status))
            {
                foreach (Instruction instruction in robot.InstructionList)
                {
                    if (!robot.Status)
                    {
                        break;
                    }

                    switch (instruction)
                    {
                        case Instruction.Forward:
                            robot.MoveForward(missionData.Grid);
                            break;
                        case Instruction.Right:
                            robot.RotateRight();
                            break;
                        case Instruction.Left:
                            robot.RotateLeft();
                            break;
                        default:
                            //Log wrong instruction
                            break;
                    }
                }
            }
        }
    }
}
