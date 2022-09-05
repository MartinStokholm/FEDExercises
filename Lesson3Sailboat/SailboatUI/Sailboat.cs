
namespace SailboatUI 
{ 
    /// <summary>
    /// Simple class to use in lab 3.1.
    /// </summary>
    public class Sailboat
    {

        /// <summary>
        /// Gets or sets the name of the boat.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the length of the boat. Unit MUST be feets!.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Calculate the hull speed for the boat.
        /// </summary>
        /// <returns>Hull speed in knots</returns>
        public double Hullspeed()
        {
            return 1.34 * System.Math.Sqrt(Length);
        }

    }
}