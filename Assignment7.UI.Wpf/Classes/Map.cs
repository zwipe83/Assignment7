using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Mapsui.Layers;
using Mapsui.Styles;
using Mapsui.Tiling;
using Mapsui;
using Mapsui.UI.Wpf;
using Mapsui.Nts;
using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Assignment7.Structs;

namespace Assignment7
{
    public class Map
    {
        #region Fields

        private readonly WorldPosition homePosition = new WorldPosition(1460179, 7522646);
        private WorldPosition currentPosition = new WorldPosition();

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
            get => currentPosition;
        }
        #endregion
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public Map()
        {
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
                Geometry = new NetTopologySuite.Geometries.Point(homePosition.X, homePosition.Y)
            });

            MapObj.Home = n => n.CenterOn(homePosition.X, homePosition.Y);

            MapObj.Info += (s, e) =>
            {
                if (e.MapInfo?.WorldPosition == null) return;

                currentPosition.X = e.MapInfo.WorldPosition.X;
                currentPosition.Y = e.MapInfo.WorldPosition.Y;
                //MessageBox.Show($"{e.MapInfo.WorldPosition}");
                //return;

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