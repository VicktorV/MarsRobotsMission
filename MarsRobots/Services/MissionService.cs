namespace MarsRobots.Services
{
    using System.Linq;
    using MarsRobots.Common;
    using MarsRobots.Models;
    using MarsRobots.Models.PlanetModels;
    using MarsRobots.Services.Contracts;

    public class MissionService : IMissionService
    {
        //private readonly IUnitMovementService UnitMovementService;

        public MissionService(/*IUnitMovementService unitMovementService*/)
        {
            //this.UnitMovementService = unitMovementService;
        }

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
                            MoveForward(robot, missionData.Grid);
                            break;
                        case Instruction.Right:
                            RotateRight(robot);
                            break;
                        case Instruction.Left:
                            RotateLeft(robot);
                            break;
                        default:
                            //Log wrong instruction
                            break;
                    }
                }
            }
        }

        private static void MoveForward(Robot robot, Grid grid)
        {
            CartesianCoordinates currentPosition = robot.Position;

            switch (robot.Orientation)
            {
                case Orientation.N:
                    robot.Position.Y++;
                    break;
                case Orientation.E:
                    robot.Position.X++;
                    break;
                case Orientation.S:
                    robot.Position.Y--;
                    break;
                case Orientation.W:
                    robot.Position.X--;
                    break;
                default:
                    break;
            }

            if (!CheckStatus(robot, grid))
            {
                if (grid.ScentedPositionList.Contains(currentPosition))
                {
                    robot.Position.X = currentPosition.X;
                    robot.Position.Y = currentPosition.Y;
                }
                else
                {
                    robot.Status = false;
                    grid.ScentCoordinates(currentPosition);
                }
            }

        }

        private static bool CheckStatus(Robot robot, Grid grid) => !(0 > robot.Position.X || robot.Position.X > grid.MaxCoord.X || 0 > robot.Position.Y || robot.Position.Y > grid.MaxCoord.Y);

        private static void RotateLeft(Robot robot)
        {
            if (robot.Orientation.Equals(Orientation.N))
            {
                robot.Orientation = Orientation.W;
            }
            else
            {
                robot.Orientation--;
            }
        }

        private static void RotateRight(Robot robot)
        {
            if (robot.Orientation.Equals(Orientation.W))
            {
                robot.Orientation = Orientation.N;
            }
            else
            {
                robot.Orientation++;
            }
        }

    }

}
