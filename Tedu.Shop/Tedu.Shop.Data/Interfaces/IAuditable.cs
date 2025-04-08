using System;

namespace Tedu.Shop.Data.Interfaces;

public interface IAuditable
{
    DateTime? CreatedDate { set; get; }
    string CreatedBy { set; get; }
    DateTime? UpdatedDate { set; get; }
    string UpdatedBy { set; get; }

    string MetaKeyword { set; get; }
    string MetaDescription { set; get; }

    bool Status { set; get; }
}
