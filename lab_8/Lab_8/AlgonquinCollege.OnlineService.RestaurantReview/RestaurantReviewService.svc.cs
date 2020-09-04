using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace AlgonquinCollege.OnlineService.RestaurantReview
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RestaurantReviewService : IRestaurantReviewService
    {
        public List<Restaurant> GetAllRestaurants()
        {
            XDocument db = GetDb();
            List<Restaurant> lstRestaurants
                =
                (from restaurant in db.Descendants("restaurant")
                 select new Restaurant()
                 {
                     Name = restaurant.Element("name").Value,
                     Summary = restaurant.Element("summary").Value
                 }).ToList<Restaurant>();
            return lstRestaurants;
        }

        private XDocument GetDb()
        {
            var path = "D:/WebDev/WP2/Lab8/AlgonquinCollege.OnlineService.RestaurantReview/AlgonquinCollege.OnlineService.RestaurantReview/test.xml";
            var route = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return XDocument.Load(path);
        }

        public List<Restaurant> GetRestaurantByName(string RestaurantName)
        {
            XDocument db = GetDb();
            List<Restaurant> lstRestaurants =
                (from restaurant in db.Descendants("restaurant")
                 where restaurant.Element("name").Value.Equals(RestaurantName)
                 select new Restaurant()
                 {
                     Name = restaurant.Element("name").Value
                 }).ToList();
            return lstRestaurants;
        }

        public List<Restaurant> GetRestaurantByRating(int Rating)
        {
            throw new NotImplementedException();
        }

        //public bool SaveRestaurant(RestaurantInfo restInfo)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
