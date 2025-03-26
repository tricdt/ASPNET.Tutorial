using System;

namespace XTLab.MvcApp.Data.Interfaces;

public interface IHasSoftDelete
{
    bool IsDeleted { set; get; }
}
