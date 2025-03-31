using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Data.Enums;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.Enums;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities;

[Table("Posts")]
public class Post : DomainEntity<Guid>, ISwitchable,
        IDateTracking, IHasSeoMetaData
{
    public Post()
    {
    }

    public Post(string name, string thumbnailImage,
       string description, string content, bool? homeFlag, bool? hotFlag,
       string tags, Status status, string seoPageTitle,
       string seoAlias, string seoMetaKeyword,
       string seoMetaDescription)
    {
        Name = name;
        Image = thumbnailImage;
        Description = description;
        Content = content;
        HomeFlag = homeFlag;
        HotFlag = hotFlag;
        Tags = tags;
        Status = status;
        SeoPageTitle = seoPageTitle;
        SeoAlias = seoAlias;
        SeoKeywords = seoMetaKeyword;
        SeoDescription = seoMetaDescription;
    }

    public Post(Guid id, string name, string thumbnailImage,
         string description, string content, bool? homeFlag, bool? hotFlag,
         string tags, Status status, string seoPageTitle,
         string seoAlias, string seoMetaKeyword,
         string seoMetaDescription)
    {
        Id = id;
        Name = name;
        Image = thumbnailImage;
        Description = description;
        Content = content;
        HomeFlag = homeFlag;
        HotFlag = hotFlag;
        Tags = tags;
        Status = status;
        SeoPageTitle = seoPageTitle;
        SeoAlias = seoAlias;
        SeoKeywords = seoMetaKeyword;
        SeoDescription = seoMetaDescription;
    }

    [Required]
    [MaxLength(256)]
    public string Name { set; get; }

    [MaxLength(256)]
    public string Image { set; get; }

    [MaxLength(500)]
    public string Description { set; get; }

    public string Content { set; get; }

    public bool? HomeFlag { set; get; }
    public bool? HotFlag { set; get; }
    public int? ViewCount { set; get; }

    public string Tags { get; set; }
    public virtual ICollection<PostTag> PostTags { set; get; }
    public DateTime DateCreated { set; get; }
    public DateTime? DateModified { set; get; }
    public Status Status { set; get; }

    [MaxLength(256)]
    public string SeoPageTitle { set; get; }

    [MaxLength(256)]
    public string SeoAlias { set; get; }

    [MaxLength(256)]
    public string SeoKeywords { set; get; }

    [MaxLength(256)]
    public string SeoDescription { set; get; }
    public DateTime? DateDeleted { set; get; }
}