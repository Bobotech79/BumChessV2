using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BumChessV2
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
            Grid grid = new Grid(3);
            Player player = new Player();
            grid.RenderBoard(this);
        }

       
        private void button1_Click(object sender, EventArgs e)
        {    
            //foreach (Control c in this.Controls)
            //{
            //    string tmpName = "cellB2";
            //    if (c.Name == tmpName)
            //    {
            //        c.Text = "yay";
            //    }       
            //}              
         }



       


    }




}
