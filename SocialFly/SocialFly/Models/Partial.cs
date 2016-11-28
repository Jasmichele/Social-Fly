using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialFly
{
    [MetadataType(typeof(BrandMetaData))]
    public partial class Brand
    {

    }

    public class BrandMetaData
    {
        [DisplayName("Company")]
        [Required(ErrorMessage = "Company Name Required")]
        public string CompanyName { get; set; }
        [DisplayName("Product")]
        [Required(ErrorMessage = "Product Required")]
        public string Product { get; set; }
        [DisplayName("Product Description")]
        [Required(ErrorMessage = "Product Description Required")]
        public string ProductDescription { get; set; }
        [DisplayName("Required Posts")]
        [Required(ErrorMessage = "Post Amount Required")]
        public int PostId { get; set; }
        [DisplayName("Compensation")]
        [Required(ErrorMessage = "Compensation Required")]
        public int CompId { get; set; }
    }

    [MetadataType(typeof(SocialUserMetaData))]
    public partial class SocialUser
    {

    }

    public class SocialUserMetaData
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [DisplayName("Social Media Name")]
        [Required(ErrorMessage = "Social Media Name Required")]
        public string SocialMName { get; set; }
        [DisplayName("Follower's")]
        [Required(ErrorMessage = "Follower Amount Required")]
        public int FollowerCountId { get; set; }
        [DisplayName("Region")]
        [Required(ErrorMessage = "Region Required")]
        public int RegionId { get; set; }
        [DisplayName("Compensation")]
        [Required(ErrorMessage = "Compensation Required")]
        public int CompId { get; set; }
        public byte[] Image { get; set; }
    }

    [MetadataType(typeof(CompMetaData))]
    public partial class Compensation
    {

    }

    public class CompMetaData
    {
        [DisplayName("Compensation")]
        [Required(ErrorMessage = "Compensation Required")]
        public int CompId { get; set; }
        [DisplayName("Compensation")]
        [Required(ErrorMessage = "Compensation Required")]
        public string CompPay { get; set; }
    }

    [MetadataType(typeof(FollowerMetaData))]
    public partial class Follower
    {

    }

    public class FollowerMetaData
    {
        [DisplayName("Folllower's")]
        [Required(ErrorMessage = "Follower's Required")]
        public int FollowerId { get; set; }
        [DisplayName("Folllower's")]
        [Required(ErrorMessage = "Follower's Required")]
        public string FollowerCount { get; set; }
    }

    [MetadataType(typeof(PostMetaData))]
    public partial class Post
    {

    }

    public class PostMetaData
    {
        [DisplayName("Posts Required")]
        [Required(ErrorMessage = "Posts Required")]
        public int PostId { get; set; }
        [DisplayName("Posts Required")]
        [Required(ErrorMessage = "Posts Required")]
        public string PostNum { get; set; }
    }

    [MetadataType(typeof(RegionMetaData))]
    public partial class Region
    {

    }

    public class RegionMetaData
    {
        [DisplayName("Region")]
        [Required(ErrorMessage = "Region Required")]
        public int RegionId { get; set; }
        [DisplayName("Region")]
        [Required(ErrorMessage = "Region Required")]
        public string RegionName { get; set; }
    }
}