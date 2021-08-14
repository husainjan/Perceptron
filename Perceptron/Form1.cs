using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Perceptron
{
    public partial class Form1 : Form
    {
        #region defining.variables.and.functions
        
        //defining global variables and functions
        bool canfill = false;            
        int count = 0;                   
        double MSE = 0;                  
        int rangewidth;                  
        double rangewidthd;              
        const int n=50,pi=100, m=26;     
        int p = 15;                      
        int noe = 0;                     
        int[,] col = new int[7, 7]; //a matrix that hold values for graphical things.(1=on,-1=off).
        char[] s ={ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        bool initial=true;
        double minMSE, alpha, sigma;
        int[] Xtest = new int[n];
        int[][] X = new int[m][];
        double[][] V = new double[n][];
        int[] t = new int[m];
        double[][] W = new double[pi][];
        double[] Zin = new double[pi];
        double[] Z = new double[pi];
        double[] Yin = new double[m];
        double[] Y = new double[m];
        double[] deltak = new double[m];
        double[] deltainj = new double[pi];
        double[] deltaj = new double[pi];
        double[][] deltaV = new double[n][];
        double[][] deltaW = new double[pi][];
        double[][] vcopy = new double[n][];         //copy of weight matrix 'V' for realize the effect of alpha,sigma,... 
        double[][] wcopy = new double[pi][];        //copy of 'W'
        Random rand = new Random();
        Random rando = new Random();

        double F(double yzink)
        {
            double yzk;
            yzk = (1 - Math.Exp(-sigma * yzink)) / (1 + Math.Exp(-sigma * yzink));
            return yzk;
        }

        double Fpri(double yzink)
        {
            double yzk;
            yzk = F(yzink);
            yzk =Math.Pow(yzk,2);
            yzk = (sigma / 2) * (1 - yzk);
            return yzk;
        }
        
        #endregion

        public Form1()
        {
            InitializeComponent();
            txtdetect.Text = "";
            test.Enabled = false;
            for (int i = 0; i < m; i++)
            {
                X[i] = new int[n];
            }
            for (int i = 0; i < n; i++)
            {
                V[i] = new double[pi];
                vcopy[i] = new double[pi];
                deltaV[i] = new double[pi];
            }
            for (int i = 0; i < pi; i++)
            {
                W[i] = new double[m];
                wcopy[i] = new double[m];
                deltaW[i] = new double[m];
            }
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    col[i, j] = -1;
        }

        
        #region buttons

        private void about_Click(object sender, EventArgs e)
        {
            FrmAbout frmab = new FrmAbout();
            frmab.ShowDialog();
        }

        private void train_Click(object sender, EventArgs e)
        {
            if (txtp.Text == "" || txtalpha.Text == "" || txtsigma.Text == "" || txtminmse.Text == "" || txtrange.Text == "")
            {
                MessageBox.Show("Please check below fields to verify\nthey are'nt emty, then press initialize:  \n\n -Alpha\n -Sigma\n -min MSE\n -hidden layer nerons\n -initial weights range");
            }
            else
            {
                if (!test.Enabled)          // if train is running for the first time, the test buttons should be usable after that.
                {
                    test.Enabled = true;
                }

                for (int i = 0; i < 7; i++)
                    for (int j = 0; j < 7; j++)
                        col[i, j] = -1;

                double sump = 0;
                double sum = 0;
                noe = 0;
                txtdetect.Text = "";
                txtepoches.Text = "";
                lstmse.Items.Clear();
                p = (Convert.ToInt32(txtp.Text));
                alpha = (Convert.ToDouble(txtalpha.Text));
                sigma = (Convert.ToDouble(txtsigma.Text));
                minMSE = (Convert.ToDouble(txtminmse.Text));
                rangewidthd = (Convert.ToDouble(txtrange.Text));
                rangewidth = (int)(10 * rangewidthd);
                #region step0.init
                if (initial)
                {
                    initial = false;
                    init.Enabled = true;
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < p; j++)
                        {
                            V[i][j] = ((double)rand.Next(1, rangewidth + 1)) / 10;
                            if (rando.Next() % 2 == 0)
                            {
                                V[i][j] = -V[i][j];
                            }
                        }
                    }
                    for (int j = 0; j < p; j++)
                    {
                        for (int k = 0; k < m; k++)
                        {

                            W[j][k] = ((double)rand.Next(1, rangewidth + 1)) / 10;
                            if ((rando.Next(1, 50)) % 2 == 0)
                            {
                                W[j][k] = -W[j][k];
                            }
                        }
                    }
                }
                else
                {
                    Array.Copy(V, vcopy, n);
                    Array.Copy(W, wcopy, p);
                }
                #endregion

                #region Standard.BP.Algorithm
                string path;
                string line;
                string[] aline;
                char[] splitchar ={ ',' };


                do
                {
                    sump = 0;
                    for (int a = 0; a < m; a++)
                    {
                        for (int k = 0; k < m; k++)
                        {
                            t[k] = -1;
                        }
                        t[a] = 1;

                        #region read.file
                        path = Directory.GetCurrentDirectory();
                        path = path + "\\patterns\\{0}.txt";
                        path = String.Format(path, a + 1);
                        StreamReader sr = new StreamReader(path);
                        line = sr.ReadLine();
                        aline = line.Split(splitchar);
                        for (int i = 0; i < aline.Length; i++)
                        {
                            if (i == 0)
                            {
                                X[a][i] = 1;
                            }
                            if (aline[i] != null)
                            {
                                X[a][i + 1] = Convert.ToInt32(aline[i]) - 1;
                            }
                        }
                        #endregion




                        #region feedforward

                        #region step4.hidden.unit
                        for (int j = 0; j < p; j++)
                        {
                            sum = 0;
                            for (int i = 1; i < n; i++)
                            {
                                sum = sum + (X[a][i] * V[i][j]);
                            }
                            Zin[j] = V[0][j] + sum;
                            Z[j] = F(Zin[j]);
                        }
                        #endregion

                        #region step5.output.unit

                        for (int k = 0; k < m; k++)
                        {
                            sum = 0;
                            for (int j = 1; j < p; j++)
                            {
                                sum = sum + (Z[j] * W[j][k]);
                            }
                            Yin[k] = W[0][k] + sum;
                            Y[k] = F(Yin[k]);
                        }

                        #endregion

                        #endregion



                        #region Backpropagation.of.error

                        #region step6.output.unit

                        for (int k = 0; k < m; k++)
                        {
                            deltak[k] = (t[k] - Y[k]) * Fpri(Yin[k]);
                            for (int j = 1; j < p; j++)
                            {
                                deltaW[j][k] = alpha * deltak[k] * Z[j];
                            }
                            deltaW[0][k] = alpha * deltak[k];
                        }

                        #endregion

                        #region step7.hidden.unit

                        for (int j = 0; j < p; j++)
                        {
                            sum = 0;
                            for (int k = 0; k < m; k++)
                            {
                                sum = sum + deltak[k] * W[j][k];
                            }
                            deltainj[j] = sum;
                            deltaj[j] = deltainj[j] * Fpri(Zin[j]);

                            for (int i = 1; i < n; i++)
                            {
                                deltaV[i][j] = alpha * deltaj[j] * X[a][i];
                            }
                            deltaV[0][j] = alpha * deltaj[j];
                        }

                        #endregion

                        #endregion



                        #region update.weights.and.biased

                        for (int k = 0; k < m; k++)
                        {
                            for (int j = 0; j < p; j++)
                            {
                                W[j][k] = W[j][k] + deltaW[j][k];
                            }
                        }
                        for (int j = 0; j < p; j++)
                        {
                            for (int i = 0; i < n; i++)
                            {
                                V[i][j] = V[i][j] + deltaV[i][j];
                            }
                        }

                        #endregion


                        for (int k = 0; k < m; k++)
                        {
                            sump = sump + Math.Pow((t[k] - Y[k]), 2);
                        }
                        MSE = 0.5 * sump;
                    }
                    noe = noe + 1;
                    lstmse.Items.Add(Math.Round(MSE, 10) + "\n");
                } while (MSE > minMSE);

                #endregion
                txtepoches.Text = noe.ToString();
                MessageBox.Show("Training finished.");
                canfill = true;
                SolidBrush s = new SolidBrush(Color.White);
                Graphics c = CreateGraphics();
                for (int i = 60; i < 270; i += 30)
                {
                    for (int j = 300; j < 510; j += 30)
                    {
                        s.Color = Color.White;
                        c.FillRectangle(s, j, i, 29, 29);
                    }
                }
            }

        }

        private void test_Click(object sender, EventArgs e)
        {
            
            txtdetect.Text = "";
            int f=1;
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                {
                    Xtest[f++] = col[i, j];
                }
            Xtest[0] = 1;
            

            #region step3.hidden.unit
            double sum;
            for (int j = 0; j < p; j++)
            {
                sum = 0;
                for (int i = 1; i < n; i++)
                {
                    sum = sum + (Xtest[i] * V[i][j]);
                }
                Zin[j] = V[0][j] + sum;
                Z[j] = F(Zin[j]);
            }
            #endregion

            #region step4.output.unit

            for (int k = 0; k < m; k++)
            {
                sum = 0;
                for (int j = 1; j < p; j++)
                {
                    sum = sum + (Z[j] * W[j][k]);
                }
                Yin[k] = W[0][k] + sum;
                Y[k] = F(Yin[k]);
            }
            #endregion

            for (int k = 0; k < m; k++)
            {

                if (Y[k] >= 0.7)
                {
                    txtdetect.Text += s[k]+", ";
                }

            }
            if (txtdetect.Text != "")
            {
                txtdetect.Text = txtdetect.Text.Remove(txtdetect.Text.Length - 2);
            }
            
        }

        private void init_Click(object sender, EventArgs e)
        {
            if (txtp.Text == "" || txtalpha.Text == "" || txtsigma.Text == "" || txtminmse.Text == "" || txtrange.Text == "")
            {
                MessageBox.Show("Please check below fields to verify\nthey are'nt emty, then press initialize:  \n\n -Alpha\n -Sigma\n -min MSE\n -hidden layer nerons\n -initial weights range");
            }
            else
            {
                alpha = (Convert.ToDouble(txtalpha.Text));
                sigma = (Convert.ToDouble(txtsigma.Text));
                minMSE = (Convert.ToDouble(txtminmse.Text));
                p = (Convert.ToInt32(txtp.Text));
                initial = true;
                init.Enabled = false;
                btnclear_Click(null, null);
                canfill = false;
            }
        }

        private void btnpat_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string path;
            string line;
            string[] aline;
            char[] splitchar ={ ',' };
            txtdetect.Text = "";
            count = 0;
            for (int a = 0; a < 26; a++)
            {
                comboBox1.Items.Add(s[a]);
                path = Directory.GetCurrentDirectory();
                path = path + "\\patterns\\{0}.txt";
                path = String.Format(path, a + 1);
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                aline = line.Split(splitchar);
                for (int i = 0; i < aline.Length; i++)
                {
                    if (i == 0)
                    {
                        X[a][i] = 1;
                    }
                    if (aline[i] != null)
                    {
                        X[a][i + 1] = Convert.ToInt32(aline[i]) - 1;
                    }
                }
            }
            SolidBrush bs = new SolidBrush(Color.White);
            Graphics c = CreateGraphics();
            for (int i = 60; i < 270; i += 30)
            {
                for (int j = 300; j < 510; j += 30)
                {
                    bs.Color = Color.White;
                    c.FillRectangle(bs, j, i, 29, 29);
                }
            }
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    col[i, j] = -1;
            MessageBox.Show("Patterns successfully\nloaded into below combobox.");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (canfill)
            {
                SolidBrush s = new SolidBrush(Color.White);
                float x, y; int n, m;
                x = e.X / 30;
                y = e.Y / 30;
                n = (int)x; m = (int)y;
                if (e.X > 300 && e.X < 510 && e.Y > 60 && e.Y < 270)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (col[m - 2, n - 10] == -1 || col[m - 2, n - 10] == 0)
                        {
                            s.Color = Color.Blue;
                            col[m - 2, n - 10] = 1;
                        }
                        else
                        {
                            s.Color = Color.White;
                            col[m - 2, n - 10] = -1;
                        }
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        if (col[m - 2, n - 10] == -1 || col[m - 2, n - 10] == 1)
                        {
                            s.Color = Color.Red;
                            col[m - 2, n - 10] = 0;
                        }
                        else
                        {
                            s.Color = Color.White;
                            col[m - 2, n - 10] = -1;
                        }
                    }
                    Graphics c = CreateGraphics();
                    c.FillRectangle(s, x * 30, y * 30, 29, 29);
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            canfill = true;
            txtdetect.Text = "";
            SolidBrush s = new SolidBrush(Color.White);
            Graphics c = CreateGraphics();
            for (int i = 60; i < 270; i += 30)
            {
                for (int j = 300; j < 510; j += 30)
                {
                    s.Color = Color.White;
                    c.FillRectangle(s, j, i, 29, 29);
                }
            }
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 7; j++)
                    col[i, j] = -1;
        }

        #endregion


        #region textboxes_combobox_changed

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            count = comboBox1.SelectedIndex;
            int k = 1;
            SolidBrush s = new SolidBrush(Color.White);
            Graphics c = CreateGraphics();

            for (int i = 60; i < 270; i += 30)
            {
                for (int j = 300; j < 510; j += 30)
                {
                    if (X[count % 26][k++] == 1)
                    {
                        s.Color = Color.Blue;
                        col[(int)(i / 30) - 2, (int)(j / 30) - 10] = 1;
                    }
                    else
                    {
                        s.Color = Color.White;
                        col[(int)(i / 30) - 2, (int)(j / 30) - 10] = -1;
                    }
                    c.FillRectangle(s, j, i, 29, 29);
                }
            }
        }

        private void txtalpha_TextChanged(object sender, EventArgs e)
        {
            if (txtalpha.Text != "")
                txtalpha.BackColor = Color.White;
            else
                txtalpha.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void txtsigma_TextChanged(object sender, EventArgs e)
        {
            if (txtsigma.Text != "")
                txtsigma.BackColor = Color.White;
            else
                txtsigma.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void txtminmse_TextChanged(object sender, EventArgs e)
        {
            if (txtminmse.Text != "")
                txtminmse.BackColor = Color.White;
            else
                txtminmse.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void txtp_TextChanged(object sender, EventArgs e)
        {
            if (txtp.Text != "")
                txtp.BackColor = Color.White;
            else
                txtp.BackColor = Color.FromArgb(255, 255, 128);
        }

        private void txtrange_TextChanged(object sender, EventArgs e)
        {
            if (txtrange.Text != "")
                txtrange.BackColor = Color.White;
            else
                txtrange.BackColor = Color.FromArgb(255, 255, 128);
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }








    }
}