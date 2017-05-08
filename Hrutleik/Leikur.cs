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
        Random rand = new Random();
        List<int> LeikurLeikari = new List<int>();
        List<int> LeikurTolvan = new List<int>();
        List<int> LeikurGeymari = new List<int>();

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            int temp = 0;

            for (int i = 0; i < 26; i++)
            {
                temp = rand.Next(1, 53);
                if (!LeikurLeikari.Contains(temp))
                {
                    LeikurLeikari.Add(temp);
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                temp = rand.Next(1, 53);
                if (!LeikurLeikari.Contains(temp) && !LeikurTolvan.Contains(temp))
                {
                    LeikurTolvan.Add(temp);
                }
                else
                {
                    i--;
                }
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            Start.Enabled = false;
            
        }
    }
}
