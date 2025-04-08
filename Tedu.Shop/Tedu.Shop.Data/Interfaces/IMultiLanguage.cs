using System;

namespace Tedu.Shop.Data.Interfaces;

public interface IMultiLanguage<T>
{
    T LanguageId { set; get; }
}
