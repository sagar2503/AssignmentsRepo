using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YeildKeyword
{
    public partial class Form1 : Form
    {
        private List<int> lstInt = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private Random r = new Random(2);
        public IEnumerable<int> RandomNumer(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return r.Next();
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //FIllList();
            label1.Text = string.Empty;
            foreach (int i in RandomNumer(10))
            {
                //MessageBox.Show(i);
                //Console.WriteLine(i.ToString());
                label1.Text += i.ToString();
            }
        }
    }
}
