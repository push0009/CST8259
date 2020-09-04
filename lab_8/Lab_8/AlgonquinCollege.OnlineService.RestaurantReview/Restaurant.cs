using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace AlgonquinCollege.OnlineService.RestaurantReview
{
    [DataContract]
    public class Restaurant
    {
        [DataMember]
        public string Name;
        [DataMember]
        public int Rating;
        [DataMember]
        public string Summary;
    }
}