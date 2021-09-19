using System.Collections.Generic;

namespace MarsRobots.Models.PlanetModels
{
    public class Grid
    {
        public int XMaxCoord { get; set; }

        public int YMaxCoord { get; set; }

        public IList<CartesianCoordinates> ScentedPositionList { get; set; } = new List<CartesianCoordinates>();

        public void ScentCoordinates(CartesianCoordinates coords)
        {
            ScentedPositionList.Add(coords);
        }
    }
}
