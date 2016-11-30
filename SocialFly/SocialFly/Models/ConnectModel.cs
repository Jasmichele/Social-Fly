using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialFly.Models
{
    public class ConnectModel
    {
        public List<Region> Regions { get; set; }
        public List<Follower> Followers { get; set; }
        public List<Compensation> Compensation { get; set; }
    }
}