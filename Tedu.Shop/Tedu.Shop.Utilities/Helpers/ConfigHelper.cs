using System;
using System.Configuration;
namespace Tedu.Shop.Utilities.Helpers;

public class ConfigHelper
{
    public static string GetByKey(string key)
    {
        return ConfigurationManager.AppSettings[key].ToString();
    }
}
