using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Processing file , please wait";

            // Task<bool> t = new Task<bool>(ReadFile);
            //t.Start();
            
            //Action a = ReadFile;
            //Task t = new Task(a);
            await Task.Run(new Action(ReadFile));
            //int b = await t;
            //if (await t)
            {
                label1.Text = "Processing complete.......";

            }

        }

        public static void ReadFile()
        {
            int count;
            using (StreamReader sr = new StreamReader("sampledata.txt"))
            {
                string filecontent = sr.ReadToEnd();
                count = filecontent.Length;
                Thread.Sleep(10000);
            }
            //return true;
        }

    }
}
