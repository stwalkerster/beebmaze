namespace BeebMaze
{
    partial class Options
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.block5 = new BeebMaze.Block();
            this.block6 = new BeebMaze.Block();
            this.block7 = new BeebMaze.Block();
            this.block8 = new BeebMaze.Block();
            this.block4 = new BeebMaze.Block();
            this.block3 = new BeebMaze.Block();
            this.block2 = new BeebMaze.Block();
            this.block1 = new BeebMaze.Block();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maze Size";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(68, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 119);
            this.label1.TabIndex = 5;
            this.label1.Text = "Smaller sizes mean smaller squares on the maze - hence a larger and harder maze. " +
                "However, the more squares the maze has, the longer it takes to generate.";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 111);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(37, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "64";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(37, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "48";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(37, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "32";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(37, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "24";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(37, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "16";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(488, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(6, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 49);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Algorithm randomness factor";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("ReadOnly", global::BeebMaze.Properties.Settings.Default, "PrimsRandomUseMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::BeebMaze.Properties.Settings.Default, "PrimsRandomMaximum", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Location = new System.Drawing.Point(6, 19);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = global::BeebMaze.Properties.Settings.Default.PrimsRandomUseMax;
            this.numericUpDown1.Size = new System.Drawing.Size(81, 20);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.Value = global::BeebMaze.Properties.Settings.Default.PrimsRandomMaximum;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = global::BeebMaze.Properties.Settings.Default.PrimsRandomUseMax;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BeebMaze.Properties.Settings.Default, "PrimsRandomUseMax", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox1.Location = new System.Drawing.Point(93, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Use maximum";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.block5);
            this.groupBox3.Controls.Add(this.block6);
            this.groupBox3.Controls.Add(this.block7);
            this.groupBox3.Controls.Add(this.block8);
            this.groupBox3.Controls.Add(this.block4);
            this.groupBox3.Controls.Add(this.block3);
            this.groupBox3.Controls.Add(this.block2);
            this.groupBox3.Controls.Add(this.block1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(218, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(345, 162);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(123, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Doors";
            // 
            // button8
            // 
            this.button8.BackColor = global::BeebMaze.Properties.Settings.Default.ColorDoors;
            this.button8.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BeebMaze.Properties.Settings.Default, "ColorDoors", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button8.Location = new System.Drawing.Point(211, 48);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(23, 23);
            this.button8.TabIndex = 24;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(123, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Walls";
            // 
            // button7
            // 
            this.button7.BackColor = global::BeebMaze.Properties.Settings.Default.ColorWalls;
            this.button7.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BeebMaze.Properties.Settings.Default, "ColorWalls", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button7.Location = new System.Drawing.Point(211, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(23, 23);
            this.button7.TabIndex = 22;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Incorrect Block";
            // 
            // button6
            // 
            this.button6.BackColor = global::BeebMaze.Properties.Settings.Default.ColorIncorrectBlock;
            this.button6.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BeebMaze.Properties.Settings.Default, "ColorIncorrectBlock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button6.Location = new System.Drawing.Point(94, 133);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(23, 23);
            this.button6.TabIndex = 20;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Unvisited Block";
            // 
            // button5
            // 
            this.button5.BackColor = global::BeebMaze.Properties.Settings.Default.ColorUnvisitedBlock;
            this.button5.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BeebMaze.Properties.Settings.Default, "ColorUnvisitedBlock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button5.Location = new System.Drawing.Point(94, 104);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(23, 23);
            this.button5.TabIndex = 18;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Exit Block";
            // 
            // button4
            // 
            this.button4.BackColor = global::BeebMaze.Properties.Settings.Default.ColorExitBlock;
            this.button4.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BeebMaze.Properties.Settings.Default, "ColorExitBlock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button4.Location = new System.Drawing.Point(94, 75);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(23, 23);
            this.button4.TabIndex = 16;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Visited Block";
            // 
            // button3
            // 
            this.button3.BackColor = global::BeebMaze.Properties.Settings.Default.ColorVisitedBlock;
            this.button3.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BeebMaze.Properties.Settings.Default, "ColorVisitedBlock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button3.Location = new System.Drawing.Point(94, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 14;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Current Block";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Revealed Maze";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hidden Maze";
            // 
            // block5
            // 
            this.block5.currentState = BeebMaze.Block.State.Unvisited;
            this.block5.inMaze = false;
            this.block5.Location = new System.Drawing.Point(301, 104);
            this.block5.Name = "block5";
            this.block5.revealMaze = true;
            this.block5.Size = new System.Drawing.Size(24, 24);
            this.block5.TabIndex = 10;
            this.block5.wBottom = null;
            this.block5.wLeft = null;
            this.block5.wRight = null;
            this.block5.wTop = null;
            // 
            // block6
            // 
            this.block6.currentState = BeebMaze.Block.State.Exit;
            this.block6.inMaze = false;
            this.block6.Location = new System.Drawing.Point(278, 104);
            this.block6.Name = "block6";
            this.block6.revealMaze = true;
            this.block6.Size = new System.Drawing.Size(24, 24);
            this.block6.TabIndex = 9;
            this.block6.wBottom = null;
            this.block6.wLeft = null;
            this.block6.wRight = null;
            this.block6.wTop = null;
            // 
            // block7
            // 
            this.block7.currentState = BeebMaze.Block.State.Current;
            this.block7.inMaze = false;
            this.block7.Location = new System.Drawing.Point(301, 80);
            this.block7.Name = "block7";
            this.block7.revealMaze = true;
            this.block7.Size = new System.Drawing.Size(24, 24);
            this.block7.TabIndex = 8;
            this.block7.wBottom = null;
            this.block7.wLeft = null;
            this.block7.wRight = null;
            this.block7.wTop = null;
            // 
            // block8
            // 
            this.block8.currentState = BeebMaze.Block.State.Visited;
            this.block8.inMaze = false;
            this.block8.Location = new System.Drawing.Point(278, 80);
            this.block8.Name = "block8";
            this.block8.revealMaze = true;
            this.block8.Size = new System.Drawing.Size(24, 24);
            this.block8.TabIndex = 7;
            this.block8.wBottom = null;
            this.block8.wLeft = null;
            this.block8.wRight = null;
            this.block8.wTop = null;
            // 
            // block4
            // 
            this.block4.currentState = BeebMaze.Block.State.Unvisited;
            this.block4.inMaze = true;
            this.block4.Location = new System.Drawing.Point(302, 34);
            this.block4.Name = "block4";
            this.block4.revealMaze = false;
            this.block4.Size = new System.Drawing.Size(24, 24);
            this.block4.TabIndex = 6;
            this.block4.wBottom = null;
            this.block4.wLeft = null;
            this.block4.wRight = null;
            this.block4.wTop = null;
            // 
            // block3
            // 
            this.block3.currentState = BeebMaze.Block.State.Exit;
            this.block3.inMaze = true;
            this.block3.Location = new System.Drawing.Point(278, 34);
            this.block3.Name = "block3";
            this.block3.revealMaze = false;
            this.block3.Size = new System.Drawing.Size(24, 24);
            this.block3.TabIndex = 4;
            this.block3.wBottom = null;
            this.block3.wLeft = null;
            this.block3.wRight = null;
            this.block3.wTop = null;
            // 
            // block2
            // 
            this.block2.currentState = BeebMaze.Block.State.Current;
            this.block2.inMaze = true;
            this.block2.Location = new System.Drawing.Point(302, 10);
            this.block2.Name = "block2";
            this.block2.revealMaze = false;
            this.block2.Size = new System.Drawing.Size(24, 24);
            this.block2.TabIndex = 3;
            this.block2.wBottom = null;
            this.block2.wLeft = null;
            this.block2.wRight = null;
            this.block2.wTop = null;
            // 
            // block1
            // 
            this.block1.currentState = BeebMaze.Block.State.Visited;
            this.block1.inMaze = true;
            this.block1.Location = new System.Drawing.Point(278, 10);
            this.block1.Name = "block1";
            this.block1.revealMaze = false;
            this.block1.Size = new System.Drawing.Size(24, 24);
            this.block1.TabIndex = 2;
            this.block1.wBottom = null;
            this.block1.wLeft = null;
            this.block1.wRight = null;
            this.block1.wTop = null;
            // 
            // button2
            // 
            this.button2.BackColor = global::BeebMaze.Properties.Settings.Default.ColorCurrentBlock;
            this.button2.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::BeebMaze.Properties.Settings.Default, "ColorCurrentBlock", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button2.Location = new System.Drawing.Point(94, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = global::BeebMaze.Properties.Settings.Default.RevealMaze;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::BeebMaze.Properties.Settings.Default, "RevealMaze", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBox2.Location = new System.Drawing.Point(218, 180);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(89, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Reveal Maze";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button9.Location = new System.Drawing.Point(407, 180);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 7;
            this.button9.Text = "Defaults";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Options
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 213);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.optionsLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private Block block1;
        private System.Windows.Forms.Button button2;
        private Block block4;
        private Block block3;
        private Block block2;
        private Block block5;
        private Block block6;
        private Block block7;
        private Block block8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button9;
    }
}