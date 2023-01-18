using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Helpers;
public static class StringHelper
{
    // 1.) Class & members must be static
    // 2.) First parameter must be the datatype you want to extend the method on
    // 3.) prefixed with keyword 'this'
    public static string AppendEllipses(this string input)
    {
        return $"{input}...";
    }
}
