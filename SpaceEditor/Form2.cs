using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceEditor
{
    public partial class Form2 : Form
    {
        private Form1 parent;

        public Form2(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
                     
        }

        public void setVals(Double x, Double y, Double z)
        {
            xBox.Text = x.ToString();
            yBox.Text = y.ToString();
            zBox.Text = z.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parent.setPosition(float.Parse(xBox.Text), float.Parse(yBox.Text), float.Parse(zBox.Text));
            this.Close();
        }

  

        
    }
}
