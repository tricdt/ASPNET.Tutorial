using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tedu.Shop.Infrastructure.SharedKernel;

namespace Tedu.Shop.Data.Entities.Ecommerce;

[Table("BillDetails")]
public class BillDetail : DomainEntity<Guid>
{
    public BillDetail()
    {
    }

    public BillDetail(Guid id, Guid billId, Guid productId,
        int quantity, decimal price)
    {
        Id = id;
        BillId = billId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
    }

    public Guid BillId { set; get; }

    public Guid ProductId { set; get; }

    public int Quantity { set; get; }

    public decimal Price { set; get; }

    [ForeignKey("BillId")]
    public virtual Bill Bill { set; get; }

    [ForeignKey("ProductId")]
    public virtual Product Product { set; get; }

}
