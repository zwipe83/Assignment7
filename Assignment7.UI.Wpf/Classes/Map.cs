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

namespace WpfApp2
{
    public class Map
    {
        private Mapsui.Map _map;

        public Mapsui.Map MapObj
        {
            get => _map; 
            protected set => _map = value;
        }

        public Map()
        {
            CreateMapAsync();
        }

        public Task<Mapsui.Map> CreateMapAsync()
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
    }
}