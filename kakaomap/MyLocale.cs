using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kakaomap
{
    public class MyLocale
    {
        internal string Name
    {
        get;
        set;
    }
    internal double Lat
    {
        get;
        set;
    }
    internal double Lng
    {
        get;
        set;
    }
    internal MyLocale(string name, double lat, double lng)
    {
        Name = name;
        Lat = lat;
        Lng = lng;
    }



    public override string ToString()
    {
        return Name;
    }
}
}