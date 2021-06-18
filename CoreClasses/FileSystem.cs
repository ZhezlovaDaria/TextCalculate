using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CoreClasses
{
	public class FileSystem
	{
		BinaryFormatter formatter = new BinaryFormatter();
		public void SaveFile(string path)
		{
			
			using (FileStream fs = new FileStream(path+".dat", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, ModelList.modellist);
			}
		}

		public void OpenFile(string path)
		{
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				ModelList.modellist  = (List<Model>)formatter.Deserialize(fs);
			}
		}

	}
}
