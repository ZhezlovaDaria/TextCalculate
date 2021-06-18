using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace CoreClasses
{
	public class Plugin
	{
		public List<IOperator> opertor = new List<IOperator>();
		public List<IExpression> exp = new List<IExpression>();
		private readonly string pluginPath = System.IO.Path.Combine(
												Directory.GetCurrentDirectory(),
												"Plugins");

		public void RefreshPlugins()
		{
			opertor.Clear();
			exp.Clear();

			DirectoryInfo pluginDirectory = new DirectoryInfo(pluginPath);
			if (!pluginDirectory.Exists)
				pluginDirectory.Create();
   
			var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
			foreach (var file in pluginFiles)
			{
				Assembly asm = Assembly.LoadFrom(file);
				var types = asm.GetTypes().
								Where(t => t.GetInterfaces().
								Where(i => i.FullName == typeof(IOperator).FullName).Any());
				foreach (var type in types)
				{
					var plugin = asm.CreateInstance(type.FullName) as IOperator;
					opertor.Add(plugin);
				}
			}
			foreach (var file in pluginFiles)
			{
				Assembly asm = Assembly.LoadFrom(file);
				var types = asm.GetTypes().
								Where(t => t.GetInterfaces().
								Where(i => i.FullName == typeof(IExpression).FullName).Any());

				foreach (var type in types)
				{
					var plugin = asm.CreateInstance(type.FullName) as IExpression;
					exp.Add(plugin);
				}
			}

		}
	}
}
