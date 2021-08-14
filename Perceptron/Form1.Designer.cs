namespace Perceptron
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.about = new System.Windows.Forms.Button();
            this.train = new System.Windows.Forms.Button();
            this.test = new System.Windows.Forms.Button();
            this.txtalpha = new System.Windows.Forms.TextBox();
            this.lblalpha = new System.Windows.Forms.Label();
            this.lblsigma = new System.Windows.Forms.Label();
            this.txtsigma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtminmse = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtepoches = new System.Windows.Forms.TextBox();
            this.init = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdetect = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstmse = new System.Windows.Forms.ListBox();
            this.btnpat = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtrange = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // about
            // 
            this.about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.about.Location = new System.Drawing.Point(464, 12);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(75, 23);
            this.about.TabIndex = 16;
            this.about.Text = "About";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // train
            // 
            this.train.Location = new System.Drawing.Point(12, 91);
            this.train.Name = "train";
            this.train.Size = new System.Drawing.Size(55, 23);
            this.train.TabIndex = 7;
            this.train.Text = "Train";
            this.train.UseVisualStyleBackColor = true;
            this.train.Click += new System.EventHandler(this.train_Click);
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(154, 91);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(49, 23);
            this.test.TabIndex = 11;
            this.test.Text = "Test";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // txtalpha
            // 
            this.txtalpha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtalpha.Location = new System.Drawing.Point(70, 10);
            this.txtalpha.Name = "txtalpha";
            this.txtalpha.Size = new System.Drawing.Size(51, 20);
            this.txtalpha.TabIndex = 1;
            this.txtalpha.TextChanged += new System.EventHandler(this.txtalpha_TextChanged);
            // 
            // lblalpha
            // 
            this.lblalpha.AutoSize = true;
            this.lblalpha.Location = new System.Drawing.Point(12, 13);
            this.lblalpha.Name = "lblalpha";
            this.lblalpha.Size = new System.Drawing.Size(37, 13);
            this.lblalpha.TabIndex = 53;
            this.lblalpha.Text = "Alpha:";
            // 
            // lblsigma
            // 
            this.lblsigma.AutoSize = true;
            this.lblsigma.Location = new System.Drawing.Point(12, 40);
            this.lblsigma.Name = "lblsigma";
            this.lblsigma.Size = new System.Drawing.Size(39, 13);
            this.lblsigma.TabIndex = 55;
            this.lblsigma.Text = "Sigma:";
            // 
            // txtsigma
            // 
            this.txtsigma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtsigma.Location = new System.Drawing.Point(70, 36);
            this.txtsigma.Name = "txtsigma";
            this.txtsigma.Size = new System.Drawing.Size(51, 20);
            this.txtsigma.TabIndex = 2;
            this.txtsigma.TextChanged += new System.EventHandler(this.txtsigma_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "min MSE:";
            // 
            // txtminmse
            // 
            this.txtminmse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtminmse.Location = new System.Drawing.Point(70, 62);
            this.txtminmse.Name = "txtminmse";
            this.txtminmse.Size = new System.Drawing.Size(51, 20);
            this.txtminmse.TabIndex = 3;
            this.txtminmse.TextChanged += new System.EventHandler(this.txtminmse_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Number of epoches:";
            // 
            // txtepoches
            // 
            this.txtepoches.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.txtepoches.Location = new System.Drawing.Point(12, 137);
            this.txtepoches.Name = "txtepoches";
            this.txtepoches.ReadOnly = true;
            this.txtepoches.Size = new System.Drawing.Size(109, 20);
            this.txtepoches.TabIndex = 13;
            // 
            // init
            // 
            this.init.Location = new System.Drawing.Point(73, 91);
            this.init.Name = "init";
            this.init.Size = new System.Drawing.Size(75, 23);
            this.init.TabIndex = 6;
            this.init.Text = "Initialize";
            this.init.UseVisualStyleBackColor = true;
            this.init.Click += new System.EventHandler(this.init_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "MSE:";
            // 
            // txtdetect
            // 
            this.txtdetect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdetect.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.txtdetect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdetect.Location = new System.Drawing.Point(130, 287);
            this.txtdetect.Name = "txtdetect";
            this.txtdetect.ReadOnly = true;
            this.txtdetect.Size = new System.Drawing.Size(408, 22);
            this.txtdetect.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Detecting:";
            // 
            // lstmse
            // 
            this.lstmse.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.lstmse.FormattingEnabled = true;
            this.lstmse.Location = new System.Drawing.Point(12, 179);
            this.lstmse.Name = "lstmse";
            this.lstmse.Size = new System.Drawing.Size(109, 134);
            this.lstmse.TabIndex = 14;
            // 
            // btnpat
            // 
            this.btnpat.Location = new System.Drawing.Point(209, 91);
            this.btnpat.Name = "btnpat";
            this.btnpat.Size = new System.Drawing.Size(75, 23);
            this.btnpat.TabIndex = 8;
            this.btnpat.Text = "Patterns";
            this.btnpat.UseVisualStyleBackColor = true;
            this.btnpat.Click += new System.EventHandler(this.btnpat_Click);
            // 
            // btnclear
            // 
            this.btnclear.Location = new System.Drawing.Point(154, 134);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(49, 23);
            this.btnclear.TabIndex = 12;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 70;
            this.label5.Text = "hidden layer nerons:";
            // 
            // txtp
            // 
            this.txtp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtp.Location = new System.Drawing.Point(223, 11);
            this.txtp.Name = "txtp";
            this.txtp.Size = new System.Drawing.Size(61, 20);
            this.txtp.TabIndex = 4;
            this.txtp.TextChanged += new System.EventHandler(this.txtp_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(122, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Initial weights range:";
            // 
            // txtrange
            // 
            this.txtrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtrange.Location = new System.Drawing.Point(223, 37);
            this.txtrange.Name = "txtrange";
            this.txtrange.Size = new System.Drawing.Size(61, 20);
            this.txtrange.TabIndex = 5;
            this.txtrange.TextChanged += new System.EventHandler(this.txtrange_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 73;
            this.label7.Text = "Pattern:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(209, 136);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 74;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(551, 321);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtrange);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnpat);
            this.Controls.Add(this.lstmse);
            this.Controls.Add(this.txtdetect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.init);
            this.Controls.Add(this.txtepoches);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtminmse);
            this.Controls.Add(this.lblsigma);
            this.Controls.Add(this.txtsigma);
            this.Controls.Add(this.lblalpha);
            this.Controls.Add(this.txtalpha);
            this.Controls.Add(this.test);
            this.Controls.Add(this.train);
            this.Controls.Add(this.about);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multi Layer Perceptron";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Button train;
        private System.Windows.Forms.Button test;
        private System.Windows.Forms.TextBox txtalpha;
        private System.Windows.Forms.Label lblalpha;
        private System.Windows.Forms.Label lblsigma;
        private System.Windows.Forms.TextBox txtsigma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtminmse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtepoches;
        private System.Windows.Forms.Button init;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdetect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstmse;
        private System.Windows.Forms.Button btnpat;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtrange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

