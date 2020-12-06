using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Bl.BLModels;
namespace Bl.Calcs
{
    public class DistanceCalc
    {
        public static int GooglePlacesDuration(string startPoint, string destenation, int drive)
        {
            string uri;
            if (drive == 1)
            {
                uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?key=AIzaSyA5L81_-5d2Hy7hHsNVhodk1zS90Qu-aP8&origins="
                          + startPoint + "&destinations=" + destenation + "&mode=driving&units=imperial&sensor=false";
            }
            else
            {
                uri = "https://maps.googleapis.com/maps/api/distancematrix/xml?key=AIzaSyA5L81_-5d2Hy7hHsNVhodk1zS90Qu-aP8&origins="
                          + startPoint + "&destinations=" + destenation + "&mode=walking&units=imperial&sensor=false";
            }
            WebClient wc = new WebClient();
            try
            {
                string geoCodeInfo = wc.DownloadString(uri);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(geoCodeInfo);

                string duration = xmlDoc.DocumentElement.SelectSingleNode("/DistanceMatrixResponse/row/element/duration/value").InnerText;
                return Convert.ToInt32(duration) / 60;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public static string[] GeoCodeAddress(string address)
        {
             var latlng = new string[2];

            var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyA5L81_-5d2Hy7hHsNVhodk1zS90Qu-aP8&address={0}&sensor=false", address);

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat = locationElement.Element("lat");
            var lng = locationElement.Element("lng");

            latlng[0]= locationElement.Element("lat").Value;
            latlng[1] = locationElement.Element("lng").Value;
            return latlng;
           
        }

       

        public static void SetAddresses(List<AppointmentDto> apointments)
        {

            foreach (var appointment in apointments)
            {
                var latLng = DistanceCalc.GeoCodeAddress(appointment.Address.formatedAddress);
                appointment.Address.Lat = latLng[0];
                appointment.Address.Lng = latLng[1];

            }
        }


    }
}
