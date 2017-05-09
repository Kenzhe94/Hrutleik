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
        Gagnagrunnur gagnagrunnur = new Gagnagrunnur();
        Random rand = new Random();
        List<int> LeikurLeikari = new List<int>();
        List<int> LeikurTolvan = new List<int>();
        List<int> LeikurGeymari = new List<int>();

        int playercount = 0;
        public Leikur(int tempPLayer)
        {
            playercount = tempPLayer;
            InitializeComponent();
            try
            {
                gagnagrunnur.TengingVidGagnagrunn();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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
        string tempPlayer, tempAI = null;
        private void thyngd_Click(object sender, EventArgs e)
        {
            panel1.Show();
            tempPlayer = "SELECT * FROM hopverkefni WHERE id='" + LeikurLeikari[0] + "'";
            List<string> lines = new List<string>();

            string[] arr = new string[2];
            try
            {
                lines = gagnagrunnur.LesariSQL(tempPlayer);

                foreach (string lin in lines)
                {
                    string[] lineFromList = lin.Split(':');
                    arr[0] = lineFromList[3];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            tempAI = "SELECT * FROM hopverkefni WHERE id='" + LeikurTolvan[0] + "'";
            
            List<string> lines2 = new List<string>();

            try
            {
                lines2 = gagnagrunnur.LesariSQL(tempAI);

                foreach (string lin in lines2)
                {
                    string[] lineFromList2 = lin.Split(':');
                    arr[1] = lineFromList2[3];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Spilari er með " + arr[0] + " og tölvan er með " + arr[1]);

            if (Convert.ToDouble(arr[0]) > Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú vinnur");

                LeikurLeikari.Add(LeikurTolvan[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                if (LeikurGeymari.Count > 0)
                {
                    LeikurLeikari.AddRange(LeikurGeymari);
                }
                panel1.Hide();

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else if (Convert.ToDouble(arr[0]) <= Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú tapar");

                LeikurTolvan.Add(LeikurLeikari[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                if (LeikurGeymari.Count > 0)
                {
                    LeikurTolvan.AddRange(LeikurGeymari);
                }
                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else
            {
                MessageBox.Show("Það er jafntefli");

                LeikurGeymari.Add(LeikurLeikari[0]);
                LeikurGeymari.Add(LeikurTolvan[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = LeikurTolvan;
                
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            panel1.BackgroundImage = Spil.Images[LeikurTolvan[0]];
            
        }

        private void Mjolkurlagni_Click(object sender, EventArgs e)
        {
            panel1.Show();
            tempPlayer = "SELECT * FROM hopverkefni WHERE id='" + LeikurLeikari[0] + "'";
            List<string> lines = new List<string>();

            string[] arr = new string[2];
            try
            {
                lines = gagnagrunnur.LesariSQL(tempPlayer);

                foreach (string lin in lines)
                {
                    string[] lineFromList = lin.Split(':');
                    arr[0] = lineFromList[4];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            tempAI = "SELECT * FROM hopverkefni WHERE id='" + LeikurTolvan[0] + "'";
            List<string> lines2 = new List<string>();

            try
            {
                lines2 = gagnagrunnur.LesariSQL(tempAI);

                foreach (string lin in lines2)
                {
                    string[] lineFromList2 = lin.Split(':');
                    arr[1] = lineFromList2[4];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Spilari er með " + arr[0] + " og tölvan er með " + arr[1]);

            if (Convert.ToDouble(arr[0]) > Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú vinnur");

                LeikurLeikari.Add(LeikurTolvan[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                if (LeikurGeymari.Count > 0)
                {
                    LeikurLeikari.AddRange(LeikurGeymari);
                }

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else if (Convert.ToDouble(arr[0]) < Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú tapar");

                LeikurTolvan.Add(LeikurLeikari[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                if (LeikurGeymari.Count > 0)
                {
                    LeikurTolvan.AddRange(LeikurGeymari);
                }
                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else
            {
                MessageBox.Show("Það er jafntefli");

                LeikurGeymari.Add(LeikurLeikari[0]);
                LeikurGeymari.Add(LeikurTolvan[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = LeikurTolvan;
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            panel1.BackgroundImage = Spil.Images[LeikurTolvan[0]];
        }

        private void einkunnUllar_Click(object sender, EventArgs e)
        {
            panel1.Show();
            tempPlayer = "SELECT * FROM hopverkefni WHERE id='" + LeikurLeikari[0] + "'";
            List<string> lines = new List<string>();

            string[] arr = new string[2];
            try
            {
                lines = gagnagrunnur.LesariSQL(tempPlayer);

                foreach (string lin in lines)
                {
                    string[] lineFromList = lin.Split(':');
                    arr[0] = lineFromList[5];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            tempAI = "SELECT * FROM hopverkefni WHERE id='" + LeikurTolvan[0] + "'";
            List<string> lines2 = new List<string>();

            try
            {
                lines2 = gagnagrunnur.LesariSQL(tempAI);

                foreach (string lin in lines2)
                {
                    string[] lineFromList2 = lin.Split(':');
                    arr[1] = lineFromList2[5];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Spilari er með " + arr[0] + " og tölvan er með " + arr[1]);

            if (Convert.ToDouble(arr[0]) > Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú vinnur");

                LeikurLeikari.Add(LeikurTolvan[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                if (LeikurGeymari.Count > 0)
                {
                    LeikurLeikari.AddRange(LeikurGeymari);
                }

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else if (Convert.ToDouble(arr[0]) < Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú tapar");

                LeikurTolvan.Add(LeikurLeikari[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                if (LeikurGeymari.Count > 0)
                {
                    LeikurTolvan.AddRange(LeikurGeymari);
                }
                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else
            {
                MessageBox.Show("Það er jafntefli");

                LeikurGeymari.Add(LeikurLeikari[0]);
                LeikurGeymari.Add(LeikurTolvan[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = LeikurTolvan;
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            panel1.BackgroundImage = Spil.Images[LeikurTolvan[0]];
        }

        private void FjoldiAfkvaema_Click(object sender, EventArgs e)
        {
            panel1.Show();
            tempPlayer = "SELECT * FROM hopverkefni WHERE id='" + LeikurLeikari[0] + "'";
            List<string> lines = new List<string>();

            string[] arr = new string[2];
            try
            {
                lines = gagnagrunnur.LesariSQL(tempPlayer);

                foreach (string lin in lines)
                {
                    string[] lineFromList = lin.Split(':');
                    arr[0] = lineFromList[6];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            tempAI = "SELECT * FROM hopverkefni WHERE id='" + LeikurTolvan[0] + "'";
            List<string> lines2 = new List<string>();

            try
            {
                lines2 = gagnagrunnur.LesariSQL(tempAI);

                foreach (string lin in lines2)
                {
                    string[] lineFromList2 = lin.Split(':');
                    arr[1] = lineFromList2[6];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Spilari er með " + arr[0] + " og tölvan er með " + arr[1]);

            if (Convert.ToDouble(arr[0]) > Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú vinnur");

                LeikurLeikari.Add(LeikurTolvan[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                if (LeikurGeymari.Count > 0)
                {
                    LeikurLeikari.AddRange(LeikurGeymari);
                }

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else if (Convert.ToDouble(arr[0]) < Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú tapar");

                LeikurTolvan.Add(LeikurLeikari[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                if (LeikurGeymari.Count > 0)
                {
                    LeikurTolvan.AddRange(LeikurGeymari);
                }
                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else
            {
                MessageBox.Show("Það er jafntefli");

                LeikurGeymari.Add(LeikurLeikari[0]);
                LeikurGeymari.Add(LeikurTolvan[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = LeikurTolvan;
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            panel1.BackgroundImage = Spil.Images[LeikurTolvan[0]];
        }

        private void EinkunFyrirMalir_Click(object sender, EventArgs e)
        {
            panel1.Show();
            tempPlayer = "SELECT * FROM hopverkefni WHERE id='" + LeikurLeikari[0] + "'";
            List<string> lines = new List<string>();

            string[] arr = new string[2];
            try
            {
                lines = gagnagrunnur.LesariSQL(tempPlayer);

                foreach (string lin in lines)
                {
                    string[] lineFromList = lin.Split(':');
                    arr[0] = lineFromList[7];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            tempAI = "SELECT * FROM hopverkefni WHERE id='" + LeikurTolvan[0] + "'";
            List<string> lines2 = new List<string>();

            try
            {
                lines2 = gagnagrunnur.LesariSQL(tempAI);

                foreach (string lin in lines2)
                {
                    string[] lineFromList2 = lin.Split(':');
                    arr[1] = lineFromList2[7];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Spilari er með " + arr[0] + " og tölvan er með " + arr[1]);

            if (Convert.ToDouble(arr[0]) > Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú vinnur");

                LeikurLeikari.Add(LeikurTolvan[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                if (LeikurGeymari.Count > 0)
                {
                    LeikurLeikari.AddRange(LeikurGeymari);
                }

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else if (Convert.ToDouble(arr[0]) < Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú tapar");

                LeikurTolvan.Add(LeikurLeikari[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                if (LeikurGeymari.Count > 0)
                {
                    LeikurTolvan.AddRange(LeikurGeymari);
                }
                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else
            {
                MessageBox.Show("Það er jafntefli");

                LeikurGeymari.Add(LeikurLeikari[0]);
                LeikurGeymari.Add(LeikurTolvan[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = LeikurTolvan;
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            panel1.BackgroundImage = Spil.Images[LeikurTolvan[0]];
        }

        private void Frjosemi_Click(object sender, EventArgs e)
        {
            panel1.Show();
            tempPlayer = "SELECT * FROM hopverkefni WHERE id='" + LeikurLeikari[0] + "'";
            List<string> lines = new List<string>();

            string[] arr = new string[2];
            try
            {
                lines = gagnagrunnur.LesariSQL(tempPlayer);

                foreach (string lin in lines)
                {
                    string[] lineFromList = lin.Split(':');
                    arr[0] = lineFromList[8];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            tempAI = "SELECT * FROM hopverkefni WHERE id='" + LeikurTolvan[0] + "'";
            List<string> lines2 = new List<string>();

            try
            {
                lines2 = gagnagrunnur.LesariSQL(tempAI);

                foreach (string lin in lines2)
                {
                    string[] lineFromList2 = lin.Split(':');
                    arr[1] = lineFromList2[8];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Spilari er með " + arr[0] + " og tölvan er með " + arr[1]);

            if (Convert.ToDouble(arr[0]) > Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú vinnur");

                LeikurLeikari.Add(LeikurTolvan[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                if (LeikurGeymari.Count > 0)
                {
                    LeikurLeikari.AddRange(LeikurGeymari);
                }

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else if (Convert.ToDouble(arr[0]) < Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú tapar");

                LeikurTolvan.Add(LeikurLeikari[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                if (LeikurGeymari.Count > 0)
                {
                    LeikurTolvan.AddRange(LeikurGeymari);
                }
                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else
            {
                MessageBox.Show("Það er jafntefli");

                LeikurGeymari.Add(LeikurLeikari[0]);
                LeikurGeymari.Add(LeikurTolvan[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = LeikurTolvan;
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            panel1.BackgroundImage = Spil.Images[LeikurTolvan[0]];
        }

        private void Gerd_Click(object sender, EventArgs e)
        {
            panel1.Show();
            tempPlayer = "SELECT * FROM hopverkefni WHERE id='" + LeikurLeikari[0] + "'";
            List<string> lines = new List<string>();

            string[] arr = new string[2];
            try
            {
                lines = gagnagrunnur.LesariSQL(tempPlayer);

                foreach (string lin in lines)
                {
                    string[] lineFromList = lin.Split(':');
                    arr[0] = lineFromList[9];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            tempAI = "SELECT * FROM hopverkefni WHERE id='" + LeikurTolvan[0] + "'";
            List<string> lines2 = new List<string>();

            try
            {
                lines2 = gagnagrunnur.LesariSQL(tempAI);

                foreach (string lin in lines2)
                {
                    string[] lineFromList2 = lin.Split(':');
                    arr[1] = lineFromList2[9];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Spilari er með " + arr[0] + " og tölvan er með " + arr[1]);

            if (Convert.ToDouble(arr[0]) > Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú vinnur");

                LeikurLeikari.Add(LeikurTolvan[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                if (LeikurGeymari.Count > 0)
                {
                    LeikurLeikari.AddRange(LeikurGeymari);
                }

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else if (Convert.ToDouble(arr[0]) < Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú tapar");

                LeikurTolvan.Add(LeikurLeikari[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                if (LeikurGeymari.Count > 0)
                {
                    LeikurTolvan.AddRange(LeikurGeymari);
                }
                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else
            {
                MessageBox.Show("Það er jafntefli");

                LeikurGeymari.Add(LeikurLeikari[0]);
                LeikurGeymari.Add(LeikurTolvan[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = LeikurTolvan;
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            panel1.BackgroundImage = Spil.Images[LeikurTolvan[0]];
        }

        private void EinkunLaeris_Click(object sender, EventArgs e)
        {
            panel1.Show();
            tempPlayer = "SELECT * FROM hopverkefni WHERE id='" + LeikurLeikari[0] + "'";
            List<string> lines = new List<string>();

            string[] arr = new string[2];
            try
            {
                lines = gagnagrunnur.LesariSQL(tempPlayer);

                foreach (string lin in lines)
                {
                    string[] lineFromList = lin.Split(':');
                    arr[0] = lineFromList[10];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            tempAI = "SELECT * FROM hopverkefni WHERE id='" + LeikurTolvan[0] + "'";
            List<string> lines2 = new List<string>();

            try
            {
                lines2 = gagnagrunnur.LesariSQL(tempAI);

                foreach (string lin in lines2)
                {
                    string[] lineFromList2 = lin.Split(':');
                    arr[1] = lineFromList2[10];

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Spilari er með " + arr[0] + " og tölvan er með " + arr[1]);

            if (Convert.ToDouble(arr[0]) > Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú vinnur");

                LeikurLeikari.Add(LeikurTolvan[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                if (LeikurGeymari.Count > 0)
                {
                    LeikurLeikari.AddRange(LeikurGeymari);
                }

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else if (Convert.ToDouble(arr[0]) < Convert.ToDouble(arr[1]))
            {
                MessageBox.Show("þú tapar");

                LeikurTolvan.Add(LeikurLeikari[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                if (LeikurGeymari.Count > 0)
                {
                    LeikurTolvan.AddRange(LeikurGeymari);
                }
                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = spilAI;

            }
            else
            {
                MessageBox.Show("Það er jafntefli");

                LeikurGeymari.Add(LeikurLeikari[0]);
                LeikurGeymari.Add(LeikurTolvan[0]);
                LeikurLeikari.Remove(LeikurLeikari[0]);
                LeikurTolvan.Remove(LeikurTolvan[0]);

                //listBox1.DataSource = LeikurLeikari;
                //listBox2.DataSource = LeikurTolvan;
            }
            panel2.BackgroundImage = Spil.Images[LeikurLeikari[0]];
            panel1.BackgroundImage = Spil.Images[LeikurTolvan[0]];
        }
    }
}
