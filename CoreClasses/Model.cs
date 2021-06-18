using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreClasses
{
	[Serializable]
	public class Model
    {
        int state;
        public string origin_text;
		public IExpression expression;
		public List<Lexem> syntax_tree;
		public int error_position=-1;
        string error_text;
        public DoubleValue result;

		public Model(string original)
		{
			origin_text = original;
		}


        public int State
        {
            get { return state; }
            set { state = State; }
        }

        public string Origin_Text
        {
            get { return origin_text; }
            set { origin_text = Origin_Text; }
        }
		
        public string Error_Text
        {
            get { return error_text; }
            set { error_text = Error_Text; }
        }

	}
}
