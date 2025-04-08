using System;

namespace Tedu.Shop.Data.Interfaces;

public interface ISortable
{
    int SortOrder { set; get; }
}
