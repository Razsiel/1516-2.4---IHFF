using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Threading;

namespace IHFF
{
    public static class Globals
    {
        static Globals()
        {
            Thread.CurrentThread.CurrentCulture = CurrentCulture;
        }

        public readonly static CultureInfo CurrentCulture = CultureInfo.CreateSpecificCulture("nl-NL");
    }
}