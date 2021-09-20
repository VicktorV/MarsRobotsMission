namespace MarsRobots.Models.Contracts
{
    using MarsRobots.Common;
    using MarsRobots.Models.PlanetModels;

    public abstract class MovableUnit
    {
        public bool Status { get; set; } = true;

        public CartesianCoordinates Position { get; set; }

        public Orientation Orientation { get; set; }

        internal void MoveForward(Grid grid)
        {
            CartesianCoordinates lastPosition = Position;

            switch (Orientation)
            {
                case Orientation.N:
                    Position.Y++;
                    break;
                case Orientation.E:
                    Position.X++;
                    break;
                case Orientation.S:
                    Position.Y--;
                    break;
                case Orientation.W:
                    Position.X--;
                    break;
                default:
                    break;
            }

            if (!CheckStatus(grid))
            {
                if (grid.ScentedPositionList.Contains(lastPosition))
                {
                    Position.X = lastPosition.X;
                    Position.Y = lastPosition.Y;
                }
                else
                {
                    Status = false;
                    grid.ScentCoordinates(lastPosition);
                }
            }
        }

        private bool CheckStatus(Grid grid) => !(0 > Position.X || Position.X > grid.MaxCoord.X || 0 > Position.Y || Position.Y > grid.MaxCoord.Y);

        internal void RotateLeft()
        {
            if (Orientation.Equals(Orientation.N))
            {
                Orientation = Orientation.W;
            }
            else
            {
                Orientation--;
            }
        }

        internal void RotateRight()
        {
            if (Orientation.Equals(Orientation.W))
            {
                Orientation = Orientation.N;
            }
            else
            {
                Orientation++;
            }
        }
    }
}
