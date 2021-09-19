namespace MarsRobots.Services
{
    using System;
    using System.IO;
    using MarsRobots.Common;
    using MarsRobots.Models;
    using MarsRobots.Services.Contracts;

    public class DataReaderService : IDataReaderService
    {
        public MissionData ReadInputFile()
        {
            string line;
            MissionData inputData = new();

            using (StreamReader file = new(@"c:\InputFile.txt"))
            {
                if (file is null)
                {
                    return null;
                }

                if ((line = file.ReadLine()) is not null)
                {
                    ParseGrid(inputData, line);
                }

                while ((line = file.ReadLine()) is not null)
                {
                    Robot robot = CreateRobot(line);
                    if ((line = file.ReadLine()) is not null)
                    {
                        ParseInstructionList(robot, line);
                        inputData.RobotList.Add(robot);
                    }
                }

                file.Close();
            }

            return inputData;
        }

        private static void ParseGrid(MissionData inputData, string line)
        {
            string[] gridcoords = line.Split(' ');
            inputData.Grid.XMaxCoord = Int32.TryParse(gridcoords[0], out int parsedCoord) ? parsedCoord : 0;
            inputData.Grid.YMaxCoord = Int32.TryParse(gridcoords[1], out parsedCoord) ? parsedCoord : 0;

            if (inputData.Grid.XMaxCoord > 50) inputData.Grid.XMaxCoord = 50;
            if (inputData.Grid.YMaxCoord > 50) inputData.Grid.YMaxCoord = 50;
        }

        private static Robot CreateRobot(string line)
        {
            Robot robot = new();

            string[] initStatus = line.Split(' ');
            robot.XPosition = Int32.TryParse(initStatus[0], out int parsedPosition) ? parsedPosition : 0;
            robot.YPosition = Int32.TryParse(initStatus[1], out parsedPosition) ? parsedPosition : 0;

            if (robot.XPosition > 50) robot.XPosition = 50;
            if (robot.YPosition > 50) robot.YPosition = 50;

            robot.Orientation = Enum.TryParse(initStatus[2], true, out Orientation orientation) ? orientation : Orientation.N;

            return robot;
        }

        private static void ParseInstructionList(Robot robot, string line)
        {
            char[] instructionSequence = line.ToCharArray();
            foreach (char instruction in instructionSequence)
            {
                switch (instruction)
                {
                    case 'F':
                        robot.InstructionList.Add(Instruction.Forward);
                        break;
                    case 'L':
                        robot.InstructionList.Add(Instruction.Left);
                        break;
                    case 'R':
                        robot.InstructionList.Add(Instruction.Right);
                        break;
                    default:
                        //Log Wrong Instruction
                        break;
                }
            }
        }
    }
}
