namespace MarsRobots.Models.PlanetModels
{
    using System.Collections.Generic;
    using System.Linq;

    public class Grid
    {
        public CartesianCoordinates MaxCoord { get; set; }

        public IList<CartesianCoordinates> ScentedPositionList { get; set; } = new List<CartesianCoordinates>();

        public void ScentCoordinates(CartesianCoordinates coords)
        {
            ScentedPositionList.Add(coords);
        }

        public bool IsScentedPosition(CartesianCoordinates cc)
        {
            return ScentedPositionList.Any(sp => sp.X == cc.X && sp.Y == cc.Y);
        }
    }
}
