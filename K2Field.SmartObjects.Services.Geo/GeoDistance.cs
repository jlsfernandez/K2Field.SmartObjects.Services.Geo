using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceCode.SmartObjects.Services.ServiceSDK.Objects;
using Attributes = SourceCode.SmartObjects.Services.ServiceSDK.Attributes;
using SourceCode.SmartObjects.Services.ServiceSDK.Types;
using System.Net;
using Microsoft.Win32;

namespace K2Field.SmartObjects.Services.Geo
{
    [Attributes.ServiceObject("GeoDistance", "Geo Distance", "Geo Distance")]
    public class GeoDistance
    {
        const string _decimalFormat = "#.######";

        public ServiceConfiguration ServiceConfiguration { get; set; }


        [Attributes.Property("PrimaryLatitude", SoType.Decimal, "Primary Latitude", "Primary Latitude")]
        public double PrimaryLatitude { get; set; }

        [Attributes.Property("PrimaryLongitutde", SoType.Decimal, "Primary Longitude", "Primary Longitude")]
        public double PrimaryLongitutde { get; set; }


        [Attributes.Property("SecondaryLatitude", SoType.Decimal, "Secondary Latitude", "Secondary Latitude")]
        public double SecondaryLatitude { get; set; }

        [Attributes.Property("SecondaryLongitutde", SoType.Decimal, "Secondary Longitude", "Secondary Longitude")]
        public double SecondaryLongitutde { get; set; }


        [Attributes.Property("DistanceMetres", SoType.Decimal, "Distance Metres", "Distance Metres")]
        public double DistanceMetres { get; set; }

        [Attributes.Property("DistanceYards", SoType.Decimal, "Distance Yards", "Distance Yards")]
        public double DistanceYards { get; set; }

        [Attributes.Property("DistanceKilometres", SoType.Decimal, "Distance Kilometres", "Distance Kilometres")]
        public double DistanceKilometres { get; set; }

        [Attributes.Property("DistanceMiles", SoType.Decimal, "Distance Miles", "Distance Miles")]
        public double DistanceMiles { get; set; }

        [Attributes.Property("WithinRange", SoType.YesNo, "Within Range", "Within Range")]
        public bool WithinRange { get; set; }


        [Attributes.Property("RangeMetres", SoType.Decimal, "Range Metres", "Range Metres")]
        public double RangeMetres { get; set; }

        [Attributes.Property("RangeYards", SoType.Decimal, "Range Yards", "Range Yards")]
        public double RangeYards { get; set; }


        [Attributes.Property("ResultStatus", SoType.Text, "Result Status", "Result Status")]
        public string ResultStatus { get; set; }

        [Attributes.Property("ResultMessage", SoType.Text, "Result Message", "Result Message")]
        public string ResultMessage { get; set; }



        [Attributes.Method("DistanceBetweenMetric", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Distance Between Metric", "Distance Between Metric",
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde" }, //required property array (no required properties for this sample)
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde" }, //input property array (no optional input properties for this sample)
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde", "DistanceMetres", "DistanceKilometres", "ResultStatus", "ResultMessage" })]
        public GeoDistance DistanceBetweenMetric()
        {
            try
            {
                System.Device.Location.GeoCoordinate primaryCoords = new System.Device.Location.GeoCoordinate(this.PrimaryLatitude, this.PrimaryLongitutde);
                System.Device.Location.GeoCoordinate secondaryCoords = new System.Device.Location.GeoCoordinate(this.SecondaryLatitude, this.SecondaryLongitutde);

                double distanceMetres = primaryCoords.GetDistanceTo(secondaryCoords);

                this.DistanceMetres = distanceMetres;
                this.DistanceKilometres = distanceMetres / 1000;
                this.ResultStatus = "OK";

                return this;
            }
            catch (Exception ex)
            {
                this.ResultStatus = "Exception";
                this.ResultMessage = ex.GetBaseException().Message;
                return this;
            }
        }


        [Attributes.Method("DistanceBetweenImperial", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Distance Between Imperial", "Distance Between Imperial",
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde" }, //required property array (no required properties for this sample)
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde" }, //input property array (no optional input properties for this sample)
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde", "DistanceYards", "DistanceMiles", "ResultStatus", "ResultMessage" })]
        public GeoDistance DistanceBetweenImperial()
        {
            try
            {
                System.Device.Location.GeoCoordinate primaryCoords = new System.Device.Location.GeoCoordinate(this.PrimaryLatitude, this.PrimaryLongitutde);
                System.Device.Location.GeoCoordinate secondaryCoords = new System.Device.Location.GeoCoordinate(this.SecondaryLatitude, this.SecondaryLongitutde);

                double distanceMetres = primaryCoords.GetDistanceTo(secondaryCoords);

                this.DistanceYards = distanceMetres * 1.09361;
                this.DistanceMiles = this.DistanceYards / 1760;
                this.ResultStatus = "OK";

                return this;
            }
            catch (Exception ex)
            {
                this.ResultStatus = "Exception";
                this.ResultMessage = ex.GetBaseException().Message;
                return this;
            }
        }


        [Attributes.Method("WithinRangeMetric", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Within Range Metric", "Within Range Metric",
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde", "RangeMetres" }, 
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde", "RangeMetres" }, 
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde", "RangeMetres", "WithinRange", "DistanceMetres", "DistanceKilometres", "ResultStatus", "ResultMessage" })]
        public GeoDistance WithinRangeMetric()
        {
            try
            {
                System.Device.Location.GeoCoordinate primaryCoords = new System.Device.Location.GeoCoordinate(this.PrimaryLatitude, this.PrimaryLongitutde);
                System.Device.Location.GeoCoordinate secondaryCoords = new System.Device.Location.GeoCoordinate(this.SecondaryLatitude, this.SecondaryLongitutde);

                double distanceMetres = primaryCoords.GetDistanceTo(secondaryCoords);

                this.DistanceMetres = distanceMetres;
                this.DistanceKilometres = distanceMetres / 1000;

                if (distanceMetres <= this.RangeMetres)
                {
                    this.WithinRange = true;
                }
                else
                {
                    this.WithinRange = false;
                }

                this.ResultStatus = "OK";

                return this;
            }
            catch (Exception ex)
            {
                this.ResultStatus = "Exception";
                this.ResultMessage = ex.GetBaseException().Message;
                return this;
            }
        }


        [Attributes.Method("WithinRangeImperial", SourceCode.SmartObjects.Services.ServiceSDK.Types.MethodType.Read, "Within Range Imperial", "Within Range Imperial",
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde", "RangeYards" }, //required property array (no required properties for this sample)
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde", "RangeYards" }, //input property array (no optional input properties for this sample)
        new string[] { "PrimaryLatitude", "PrimaryLongitutde", "SecondaryLatitude", "SecondaryLongitutde", "RangeYards", "WithinRange", "DistanceYards", "DistanceMiles", "ResultStatus", "ResultMessage" })]
        public GeoDistance WithinRangeImperial()
        {
            try
            {
                System.Device.Location.GeoCoordinate primaryCoords = new System.Device.Location.GeoCoordinate(this.PrimaryLatitude, this.PrimaryLongitutde);
                System.Device.Location.GeoCoordinate secondaryCoords = new System.Device.Location.GeoCoordinate(this.SecondaryLatitude, this.SecondaryLongitutde);

                double distanceMetres = primaryCoords.GetDistanceTo(secondaryCoords);

                this.DistanceYards = distanceMetres * 1.09361;
                this.DistanceMiles = this.DistanceYards / 1760;

                if (this.DistanceYards <= this.RangeYards)
                {
                    this.WithinRange = true;
                }
                else
                {
                    this.WithinRange = false;
                }
                this.ResultStatus = "OK";

                return this;
            }
            catch (Exception ex)
            {
                this.ResultStatus = "Exception";
                this.ResultMessage = ex.GetBaseException().Message;
                return this;
            }
        }

    }

    


}
