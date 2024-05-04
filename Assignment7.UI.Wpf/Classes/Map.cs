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

namespace Assignment7
{
    public class Map
    {
        #region Fields

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
                Geometry = new NetTopologySuite.Geometries.Point(56000, 76000)
            });

            MapObj.Info += (s, e) =>
            {
                if (e.MapInfo?.WorldPosition == null) return;

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