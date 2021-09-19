namespace MarsRobots.Services
{
    using System;
    using System.IO;
    using MarsRobots.Models;
    using MarsRobots.Services.Contracts;

    public class DataWriterService : IDataWriterService
    {
        public void WriteInputFile(MissionData missionData, string filePath)
        {
            using StreamWriter file = new(filePath, true);

            WriteHeader(file, true);

            foreach (Robot robot in missionData.RobotList)
            {
                file.WriteLine(robot.InformationString());
            }

            file.Close();
        }

        public void WriteOutputFile(MissionData missionData)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using StreamWriter file = new($@"{path}\MarsMissionData\OutputFile.txt");

            WriteHeader(file, false);

            foreach (Robot robot in missionData.RobotList)
            {
                file.WriteLine(robot.InformationString());
            }

            file.Close();
        }

        private static void WriteHeader(StreamWriter file, bool append)
        {
            if (append)
            {
                file.WriteLine(string.Empty);
                file.WriteLine(string.Empty);
            }
            file.WriteLine("------- MISSION OUTPUT -------");
            file.WriteLine(string.Empty);
        }
    }
}
