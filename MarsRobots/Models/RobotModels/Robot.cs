﻿namespace MarsRobots.Models
{
    using System.Collections.Generic;
    using MarsRobots.Common;

    public class Robot
    {
        public bool Status { get; set; } = true;

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public Orientation Orientation { get; set; }

        public IList<Instruction> InstructionList { get; set; } = new List<Instruction>();

    }
}