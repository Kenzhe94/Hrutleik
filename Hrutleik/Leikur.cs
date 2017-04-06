using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hrutleik
{
    public partial class Leikur : Form
    {
        int playercount = 0;
        public Leikur(int tempPLayer)
        {
            playercount = tempPLayer;
            InitializeComponent();
        }

        private void Leikur_Load(object sender, EventArgs e)
        {
            label1.Text = playercount.ToString();
        }
    }
}
