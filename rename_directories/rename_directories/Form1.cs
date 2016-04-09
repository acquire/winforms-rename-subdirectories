using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace rename_directories
{
    public partial class Form1 : Form
    {
        string[] last;
        string[] subdirs;

        public Form1()
        {
            InitializeComponent();
            GetDirectories();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //check each new filename to see if valid first
                foreach (var s in subdirs)
                {
                    var fileinfo = new FileInfo(s);
                }

                textBox1.Text = textBox1.Text.TrimEnd();
                if (textBox1.Lines.Count() == subdirs.Count())
                {
                    for (var i = 0; i < subdirs.Count(); i++)
                    {
                        var s = subdirs[i];
                        var name = Path.GetFileName(s);
                        var newname = textBox1.Lines[i];
                        var a = s + @"\..\" + newname;

                        var b = Directory.Exists(s);
                        var c = Directory.Exists(a);

                        Directory.Move(s, a);
                    }
                    last = subdirs;
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Number of directories to rename do not match.");
                }
                GetDirectories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string[] GetDirectories()
        {
            subdirs = Directory.GetDirectories(Directory.GetCurrentDirectory());
            textBox2.Clear();
            foreach (var s in subdirs)
            {
                textBox2.Text += Path.GetFileName(s) + "\r\n";
            }
            return subdirs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            foreach (var l in last)
            {
                textBox2.Text += Path.GetFileName(l) + "\r\n";
            }

            try
            {
                for (var i = 0; i < last.Count(); i++)
                {
                    var l = last[i];
                    var newname = Path.GetFileName(l);
                    var a = l + @"\..\" + newname;

                    Directory.Move(subdirs[i], a);
                }
                //last = subdirs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Clear();
            foreach (var s in subdirs)
            {
                textBox1.Text += Path.GetFileName(s) + "\r\n";
            }
            textBox1.Text = textBox1.Text.TrimEnd();
            subdirs = last;


        }

    }
}
