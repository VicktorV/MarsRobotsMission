namespace MarsRobots.Models.PlanetModels
{
    using System.Collections.Generic;
    public class Grid
    {
        public CartesianCoordinates MaxCoord { get; set; }

        public IList<CartesianCoordinates> ScentedPositionList { get; set; } = new List<CartesianCoordinates>();

        public void ScentCoordinates(CartesianCoordinates coords)
        {
            ScentedPositionList.Add(coords);
        }
    }
}
