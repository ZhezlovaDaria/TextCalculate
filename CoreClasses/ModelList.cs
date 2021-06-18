using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClasses
{
	[Serializable]
	static public class ModelList
	{
		static public List<Model> modellist=new List<Model>();
	}
	static public class Op_List
	{
		static public List<IOperator> op_list = new List<IOperator>(){
			new Plus(), new Minus(), new Multiplication(), new Divide(),
		};

	}
}
