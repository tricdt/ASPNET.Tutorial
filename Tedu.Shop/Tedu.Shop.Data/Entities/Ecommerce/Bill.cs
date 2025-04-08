using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Data.Entities.System;
using Tedu.Shop.Data.Enums;
using Tedu.Shop.Data.Interfaces;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Ecommerce;

[Table("Bills")]
public class Bill : DomainEntity<Guid>, IDateTracking, IHasUniqueCode
{
    public Bill()
    {
    }

    public Bill(Guid id, string customerName, string customerAddress,
        string customerMobile, string customerMessage,
       BillStatus billStatus, PaymentMethod paymentMethod,
       string customerFacebook, decimal? shippingFee)
    {
        Id = id;
        CustomerName = customerName;
        CustomerAddress = customerAddress;
        CustomerMobile = customerMobile;
        CustomerMessage = customerMessage;
        BillStatus = billStatus;
        PaymentMethod = paymentMethod;
        CustomerFacebook = customerFacebook;
        ShippingFee = shippingFee;
    }

    [Required]
    [MaxLength(256)]
    public string CustomerName { set; get; }

    [Required]
    [MaxLength(256)]
    public string CustomerAddress { set; get; }

    [Required]
    [MaxLength(50)]
    public string CustomerMobile { set; get; }

    [MaxLength(256)]
    public string CustomerMessage { set; get; }

    public string CustomerFacebook { set; get; }

    public decimal? ShippingFee { set; get; }

    public PaymentMethod PaymentMethod { set; get; }

    public BillStatus BillStatus { set; get; }

    public DateTime DateCreated { set; get; }
    public DateTime? DateModified { set; get; }
    public DateTime? DateDeleted { set; get; }
    public Guid CustomerId { set; get; }
    public string UniqueCode { set; get; }
    [ForeignKey("CustomerId")]
    public virtual AppUser Customer { set; get; }
    public virtual IEnumerable<BillDetail> BillDetails { set; get; }
}