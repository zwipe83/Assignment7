namespace Assignment7.Structs
{
    /// <summary>
    /// Represents a position in the world.
    /// </summary>
    public struct WorldPosition
    {
        #region Fields

        /// <summary>
        /// The x-coordinate of the position.
        /// </summary>
        private double _x;

        /// <summary>
        /// The y-coordinate of the position.
        /// </summary>
        private double _y;
        #endregion
        #region Properties

        /// <summary>
        /// Gets or sets the x-coordinate of the position.
        /// </summary>
        public double X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the position.
        /// </summary>
        public double Y
        {
            get => _y;
            set => _y = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldPosition"/> struct with default coordinates (0, 0).
        /// </summary>
        public WorldPosition() : this(0.0, 0.0)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldPosition"/> struct with the specified coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the position.</param>
        /// <param name="y">The y-coordinate of the position.</param>
        public WorldPosition(double x, double y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}
