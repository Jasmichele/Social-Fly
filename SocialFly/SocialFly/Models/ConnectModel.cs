using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialFly.Models
{
    public class ConnectModel
    {
        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<Follower> Followers { get; set; }
        public IEnumerable<Compensation> Compensation { get; set; }

        public int RegionID { get; set; }
        public int FollowersID { get; set; }
        public int CompensationID { get; set; }
    }
}