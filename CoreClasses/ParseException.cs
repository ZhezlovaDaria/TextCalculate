using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClasses
{
	public class ParseException: Exception
	{
		public int position;
		public int length;
		public ParseException(string message, int pos, int len): base (message)
		{
			position = pos;
			length = len;
		}
	}
}
