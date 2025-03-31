using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.CoreApp.Data.Interfaces;
using Tedu.CoreApp.Infrastructure.SharedKernel;

namespace Tedu.CoreApp.Data.Entities.Ecommerce;

[Table("ProductWishlists")]
public class ProductWishlist : DomainEntity<Guid>, IDateTracking
{
    public ProductWishlist()
    {
    }

    public ProductWishlist(Guid id, Guid userId, Guid productId)
    {
        Id = id;
        UserId = userId;
        ProductId = productId;
    }

    public Guid ProductId { get; set; }

    public Guid UserId { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public DateTime? DateDeleted { set; get; }

    [ForeignKey("ProductId")]
    public virtual Product Product { set; get; }

    [ForeignKey("UserId")]
    public virtual AppUser User { set; get; }
}