using Assignment7.Structs;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Nts;
using Mapsui.Styles;
using Mapsui.Tiling;

namespace Assignment7.UI.Wpf.Classes
{
    public class Map
    {
        #region Fields


        private WorldPosition _homePosition;
        private WorldPosition _currentPosition = new WorldPosition(1460179, 7522646);

        /// <summary>
        /// 
        /// </summary>
        private Mapsui.Map _map;
        #endregion
        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public Mapsui.Map MapObj
        {
            get => _map;
            protected set => _map = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public WorldPosition CurrentPosition
        {
            get => _currentPosition;
            set => _currentPosition = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public WorldPosition HomePosition
        {
            get => _homePosition;
            set => _homePosition = value;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public Map() : this(new WorldPosition(1460179, 7522646))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public Map(WorldPosition worldPosition)
        {
            HomePosition = worldPosition;
            CurrentPosition = worldPosition;
            CreateMapAsync();
        }
        #endregion
        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

            // Add a point to the layer using the Info position
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