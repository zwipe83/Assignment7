using Assignment7.Structs;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Nts;
using Mapsui.Styles;
using Mapsui.Tiling;

namespace Assignment7.UI.Wpf.Classes
{
    /// <summary>
    /// Represents a map in the application.
    /// </summary>
    public class Map
    {
        #region Fields
        /// <summary>
        /// The home position on the map.
        /// </summary>
        private WorldPosition _homePosition;

        /// <summary>
        /// The current position on the map.
        /// </summary>
        private WorldPosition _currentPosition = new WorldPosition(1460179, 7522646);

        /// <summary>
        /// The Mapsui map object.
        /// </summary>
        private Mapsui.Map _map;
        #endregion
        #region Properties

        /// <summary>
        /// Gets the Mapsui map object.
        /// </summary>
        public Mapsui.Map MapObj
        {
            get => _map;
            protected set => _map = value;
        }

        /// <summary>
        /// Gets or sets the current position on the map.
        /// </summary>
        public WorldPosition CurrentPosition
        {
            get => _currentPosition;
            set => _currentPosition = value;
        }

        /// <summary>
        /// Gets or sets the home position on the map.
        /// </summary>
        public WorldPosition HomePosition
        {
            get => _homePosition;
            set => _homePosition = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Map class with the default home position.
        /// </summary>
        public Map() : this(new WorldPosition(1460179, 7522646))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Map class with the specified home position.
        /// </summary>
        /// <param name="worldPosition">The home position on the map.</param>
        public Map(WorldPosition worldPosition)
        {
            HomePosition = worldPosition;
            CurrentPosition = worldPosition;
            CreateMapAsync();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// Creates the Mapsui map asynchronously.
        /// </summary>
        /// <returns>The created Mapsui map.</returns>
        internal Task<Mapsui.Map> CreateMapAsync()
        {
            MapObj = new Mapsui.Map();

            MapObj.Layers.Add(OpenStreetMap.CreateTileLayer());

            var layer = new GenericCollectionLayer<List<IFeature>>
            {
                //Style = SymbolStyles.CreatePinStyle()
                Style = SymbolStyles.CreatePinStyle(Color.Chocolate)
            };
            MapObj.Layers.Add(layer);

            layer?.Features.Clear();

            // Add a point to the layer using the home position
            layer?.Features.Add(new GeometryFeature
            {
                Geometry = new NetTopologySuite.Geometries.Point(HomePosition.X, HomePosition.Y)
            });

            MapObj.Home = n => n.CenterOn(HomePosition.X, HomePosition.Y);

            MapObj.Info += (s, e) =>
            {
                if (e.MapInfo?.WorldPosition == null) return;

                _currentPosition.X = e.MapInfo.WorldPosition.X;
                _currentPosition.Y = e.MapInfo.WorldPosition.Y;

                layer?.Features.Clear();

                // Add a point to the layer using the Info position
                layer?.Features.Add(new GeometryFeature
                {
                    Geometry = new NetTopologySuite.Geometries.Point(e.MapInfo.WorldPosition.X, e.MapInfo.WorldPosition.Y)
                });
                // To notify the mapManager that a redraw is needed.
                layer?.DataHasChanged();
                return;
            };

            return Task.FromResult(MapObj);
        }
        #endregion
    }
}