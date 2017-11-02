using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        private CompetitevNetwork net = new CompetitevNetwork();
        private WorkImage work = new WorkImage();
        public Form1()
        {
            InitializeComponent();
            net.learn(work.ItoB());

            int[] clast = new int[5];
            for(int i = 0; i < clast.Length; i++)
            {
                clast[i] = net.getCluster(work.ItoB()[i]);
            }
        }
    }
}
