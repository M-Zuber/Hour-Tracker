using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Tests.Helpers
{
    public static class Extensions
    {
        public static T GetPrivateProperty<T>(this object obj, string propertyName)
        {
            PrivateObject pobj = new PrivateObject(obj);
            return (T)pobj.GetProperty(propertyName);
        }

        public static void SetPrivateProperty<T>(this object obj, string propertyName, T value)
        {
            PrivateObject pobj = new PrivateObject(obj);
            pobj.SetProperty(propertyName, value);
        }
    }
}
