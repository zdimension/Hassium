using System;
using System.Linq;

namespace Hassium.Functions
{
	public class ConversionFunctions : ILibrary
	{
		[IntFunc("tonum")]
		public static object ToNum(object[] args)
		{
			double tmp = 0;
			if (double.TryParse(args[0].ToString(), out tmp))
				return tmp;
			else
				return args[0].ToString();
		}

		[IntFunc("tostr")]
		public static object ToStr(object[] args)
		{
			if(args[0] is Array)
			{
				return ((Array)(args[0])).Cast<object>()
						.Aggregate("Array { ",
							(current, item) => current + ((item is Array ? ToStr(new[] { item }) : (item.ToString().Replace("\"", "\\\""))) + " ")) + "}";
			}
			return String.Join("", args);
		}

		[IntFunc("tohex")]
		public static object ToHex(object[] args)
		{
			try
			{
			    return Convert.ToInt32(args[0]).ToString("{0:X}");
			}
			catch
			{
				return args[0].ToString();
			}
		}

		[IntFunc("tobyte")]
		public static object ToByte(object[] args)
		{
			try
			{
				return Convert.ToByte(args[0]);
			}
			catch
			{
				return args[0].ToString();
			}
		}

		[IntFunc("toarr")]
		public static object ToArr(object[] args)
		{
			return args;
		}
	}
}
