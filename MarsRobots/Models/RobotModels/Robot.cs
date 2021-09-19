namespace MarsRobots.Models
{
    using System.Collections.Generic;
    using MarsRobots.Common;

    public class Robot
    {
        public bool Status { get; set; } = true;

        public CartesianCoordinates Position { get; set; }

        public Orientation Orientation { get; set; }

        public IList<Instruction> InstructionList { get; set; } = new List<Instruction>();

        #region Methods

        public string InformationString()
        {
            string statusString = this.Status ? string.Empty : "LOST";
            return $"{this.Position.X} {this.Position.Y} {this.Orientation} {statusString}";
        }

        #endregion
    }
}
