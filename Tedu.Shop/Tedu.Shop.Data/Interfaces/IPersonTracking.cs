using System;

namespace Tedu.Shop.Data.Interfaces;

public interface IPersonTracking
{
    /// <summary>
    /// Gets or sets the date and time the object was created.
    /// </summary>
    Guid CreatorUserId { get; set; }

    /// <summary>
    /// Gets or sets the date and time the object was last modified.
    /// </summary>
    Guid? LastModifierUserId { get; set; }


    /// <summary>
    /// Gets or sets the date and time the object was created.
    /// </summary>
    Guid? DeleterUserId { get; set; }
}
