namespace MarsRobots.Models
{
    using System.Collections.Generic;
    using MarsRobots.Common;
    using MarsRobots.Models.Contracts;

    public class Robot : MovableUnit
    {
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
