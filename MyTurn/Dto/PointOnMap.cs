using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dto
{
   public class PointOnMap
    {
        public string formatedAddress { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
      public  PointOnMap()
        {

        }
      public  PointOnMap(string formatedAddress)
        {
     
            var latlng = new string[2];

            var requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyA5L81_-5d2Hy7hHsNVhodk1zS90Qu-aP8&address={0}&sensor=false", formatedAddress);

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat = locationElement.Element("lat");
            var lng = locationElement.Element("lng");

            Lat = locationElement.Element("lat").Value;
            Lng = locationElement.Element("lng").Value;
            this.formatedAddress = formatedAddress;

        

    }

}
}
