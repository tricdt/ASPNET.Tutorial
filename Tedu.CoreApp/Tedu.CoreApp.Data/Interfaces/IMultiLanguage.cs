using System;

namespace Tedu.CoreApp.Data.Interfaces;

public interface IMultiLanguage<T>
{
    T LanguageId { set; get; }
}