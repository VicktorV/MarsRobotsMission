namespace MarsRobots.Services
{
    using System;
    using System.IO;
    using System.Linq;
    using MarsRobots.Common;
    using MarsRobots.Models;
    using MarsRobots.Services.Contracts;

    public class DataReaderService : IDataReaderService
    {
        public MissionData ReadInputFile()
        {
            string fileName = "InputFile.txt";
            string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\MarsMissionData";

            string[] fileEntries = Directory.GetFiles(path);
            if (fileEntries.Any(file => file.EndsWith($@"\{fileName}")))
            {
                return ProcessFile($@"{path}\{fileName}");
            }
            else
            {
                throw new FileNotFoundException(@"File 'InputData.txt' was not found in 'Desktop\MarsMissionData' folder");
            }
        }

        private static MissionData ProcessFile(string filePath)
        {
            MissionData inputData = new();

            using (StreamReader file = new(filePath))
            {
                string line;

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
            int x = Int32.TryParse(gridcoords[0], out int parsedCoord) ? parsedCoord : 0;
            int y = Int32.TryParse(gridcoords[1], out parsedCoord) ? parsedCoord : 0;

            inputData.Grid.MaxCoord = ParseInputLimit(x, y);
        }

        private static Robot CreateRobot(string line)
        {
            Robot robot = new();

            string[] initStatus = line.Split(' ');
            int x = Int32.TryParse(initStatus[0], out int parsedPosition) ? parsedPosition : 0;
            int y = Int32.TryParse(initStatus[1], out parsedPosition) ? parsedPosition : 0;

            robot.Position = ParseInputLimit(x, y);
            robot.Status = !(robot.Position.X < 0 || robot.Position.Y < 0);
            robot.Orientation = Enum.TryParse(initStatus[2], true, out Orientation orientation) ? orientation : Orientation.N;

            return robot;
        }

        private static CartesianCoordinates ParseInputLimit(int x, int y)
        {
            if (x > 50) x = 50;
            if (y > 50) y = 50;

            return new(x, y);
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
