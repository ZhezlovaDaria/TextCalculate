using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using CoreClasses;
using System.IO;

namespace CalculateForm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			
			UpdateFunction();
		}

		Parser parser = new Parser();
		Calculate calculate = new Calculate();
		FileSystem fileSystem = new FileSystem();
		Plugin plugin = new Plugin();

		private void UpdateFunction()
		{
			plugin.RefreshPlugins();
			foreach (IOperator o in plugin.opertor)
			{
				Op_List.op_list.Add(o);
				parser.pattern_list.Add(o.Name);
			}
		}

		private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (printDialog1.ShowDialog() == DialogResult.OK)
			{
				PrintDocument def = new PrintDocument();
				def.PrintPage += new PrintPageEventHandler(PRD);
				def.DocumentName = "Document1";
				def.PrinterSettings = printDialog1.PrinterSettings;
				def.Print();
			}
		}
		void PRD(object sender, PrintPageEventArgs e)
		{
			Graphics g = e.Graphics;
			g.DrawString(richTextBox1.Text, Font, new SolidBrush(Color.Black), 0, 0);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			parser.Split_full_text(richTextBox1.Text);
			richTextBox1.Text="";
			string ans;
			for (int i=0; i<ModelList.modellist.Count;i++)
			{

				if (ModelList.modellist[i].error_position == -1)
				{
					calculate.StackExp(ModelList.modellist[i]);
				}
				ans=ModelList.modellist[i].Origin_Text + "=";
				if (ModelList.modellist[i].error_position == -1)
				{
					ans += ModelList.modellist[i].result.ToString();
				}
				richTextBox1.Text += ans + "\n";
				string select = "";
				if (ModelList.modellist[i].error_position != -1)
				{
					richTextBox1.Select(richTextBox1.Text.IndexOf(ModelList.modellist[i].Origin_Text) + ModelList.modellist[i].error_position, 1);
					select+=richTextBox1.SelectedText;
					richTextBox1.SelectionColor = Color.Red;
				}
			}
		}

		private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = "";
			OpenFileDialog fn = new OpenFileDialog();
			if (fn.ShowDialog() == DialogResult.OK)
			{
				fileSystem.OpenFile(fn.FileName);
			}
			foreach (Model o in ModelList.modellist)
			{
				richTextBox1.Text += o.Origin_Text + "\n";
			}
		}

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ModelList.modellist.Count == 0)
			{
				parser.Split_full_text(richTextBox1.Text);
			}
			SaveFileDialog sfd = new SaveFileDialog();
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				fileSystem.SaveFile(sfd.FileName);
			}
		}

		private void дабавитьПлагинToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog fn = new OpenFileDialog();
			if (fn.ShowDialog() == DialogResult.OK)
			{
				string fname = Path.GetFileName(fn.FileName);
				string path = Path.Combine(Directory.GetCurrentDirectory() + "\\Plugins"+"\\"+ fname);
				System.IO.File.Copy(fn.FileName, path, true);
			}
			UpdateFunction();
		}
	}
}
