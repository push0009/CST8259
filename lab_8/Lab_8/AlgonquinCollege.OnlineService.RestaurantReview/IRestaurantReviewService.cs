using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AlgonquinCollege.OnlineService.RestaurantReview
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRestaurantReviewService
    {

        [OperationContract]
        List<Restaurant> GetAllRestaurants();

        [OperationContract]
        List<Restaurant> GetRestaurantByName(string RestaurantName);

        [OperationContract]
        List<Restaurant> GetRestaurantByRating(int Rating);

        //[OperationContract]
        //bool SaveRestaurant(RestaurantInfo restInfo);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class RestaurantInfo
    //{
    //    [DataMember]
    //    public string Name { get; set; }

    //    [DataMember]
    //    public string Summary { get; set; }

    //    [DataMember]
    //    public int Rating { get; set; }

    //    [DataMember]
    //    public Address Location { get; set; }
    //}

    //[DataContract]
    //public class Address
    //{
    //    [DataMember]
    //    public string Street { get; set; }

    //    [DataMember]
    //    public string City { get; set; }

    //    [DataMember]
    //    public string Province { get; set; }

    //    [DataMember]
    //    public string PostalCode { get; set; }
    //}
}
