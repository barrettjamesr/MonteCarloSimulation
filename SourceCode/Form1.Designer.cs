namespace WindowsFormsApplication1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.baskselection = new System.Windows.Forms.RadioButton();
            this.asiaselection = new System.Windows.Forms.RadioButton();
            this.amerselection = new System.Windows.Forms.RadioButton();
            this.ipvlselection = new System.Windows.Forms.RadioButton();
            this.eurpselection = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.aritselection = new System.Windows.Forms.RadioButton();
            this.geoselection = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.volatilityinput2 = new System.Windows.Forms.TextBox();
            this.Volatility2 = new System.Windows.Forms.Label();
            this.correlationinput = new System.Windows.Forms.TextBox();
            this.Correlation = new System.Windows.Forms.Label();
            this.Asset2 = new System.Windows.Forms.Label();
            this.spotpriceinput2 = new System.Windows.Forms.TextBox();
            this.Spot_Price2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.geoconselection = new System.Windows.Forms.RadioButton();
            this.Monte_Carlo_Paths = new System.Windows.Forms.Label();
            this.montecarlopathsinput = new System.Windows.Forms.TextBox();
            this.noconselection = new System.Windows.Forms.RadioButton();
            this.Spot_Price = new System.Windows.Forms.Label();
            this.Number_of_Steps = new System.Windows.Forms.Label();
            this.spotpriceinput = new System.Windows.Forms.TextBox();
            this.strikepriceinput = new System.Windows.Forms.TextBox();
            this.numberofstepsinput = new System.Windows.Forms.TextBox();
            this.Option_Premium = new System.Windows.Forms.Label();
            this.Strike_Price = new System.Windows.Forms.Label();
            this.optionpremiuminput = new System.Windows.Forms.TextBox();
            this.volatilityinput = new System.Windows.Forms.TextBox();
            this.putselection = new System.Windows.Forms.RadioButton();
            this.Volatility = new System.Windows.Forms.Label();
            this.callselection = new System.Windows.Forms.RadioButton();
            this.Time_to_Maturity = new System.Windows.Forms.Label();
            this.timetomaturityinput = new System.Windows.Forms.TextBox();
            this.Repo_Rate = new System.Windows.Forms.Label();
            this.reporateinput = new System.Windows.Forms.TextBox();
            this.riskfreerateinput = new System.Windows.Forms.TextBox();
            this.Risk_Free_Rate = new System.Windows.Forms.Label();
            this.resetbutton = new System.Windows.Forms.Button();
            this.calculatebutton = new System.Windows.Forms.Button();
            this.parameteroutput = new System.Windows.Forms.RichTextBox();
            this.Result = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.baskselection);
            this.groupBox1.Controls.Add(this.asiaselection);
            this.groupBox1.Controls.Add(this.amerselection);
            this.groupBox1.Controls.Add(this.ipvlselection);
            this.groupBox1.Controls.Add(this.eurpselection);
            this.groupBox1.Location = new System.Drawing.Point(30, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Task Selection";
            // 
            // baskselection
            // 
            this.baskselection.AutoSize = true;
            this.baskselection.Location = new System.Drawing.Point(25, 180);
            this.baskselection.Name = "baskselection";
            this.baskselection.Size = new System.Drawing.Size(125, 16);
            this.baskselection.TabIndex = 1;
            this.baskselection.Text = "Basket Option Pricing";
            this.baskselection.UseVisualStyleBackColor = true;
            this.baskselection.CheckedChanged += new System.EventHandler(this.baskselection_CheckedChanged);
            // 
            // asiaselection
            // 
            this.asiaselection.AutoSize = true;
            this.asiaselection.Location = new System.Drawing.Point(25, 140);
            this.asiaselection.Name = "asiaselection";
            this.asiaselection.Size = new System.Drawing.Size(120, 16);
            this.asiaselection.TabIndex = 1;
            this.asiaselection.Text = "Asian Option Pricing";
            this.asiaselection.UseVisualStyleBackColor = true;
            this.asiaselection.CheckedChanged += new System.EventHandler(this.asiaselection_CheckedChanged);
            // 
            // amerselection
            // 
            this.amerselection.AutoSize = true;
            this.amerselection.Location = new System.Drawing.Point(25, 100);
            this.amerselection.Name = "amerselection";
            this.amerselection.Size = new System.Drawing.Size(139, 16);
            this.amerselection.TabIndex = 1;
            this.amerselection.Text = "American Option Pricing";
            this.amerselection.UseVisualStyleBackColor = true;
            this.amerselection.CheckedChanged += new System.EventHandler(this.amerselection_CheckedChanged);
            // 
            // ipvlselection
            // 
            this.ipvlselection.AutoSize = true;
            this.ipvlselection.Location = new System.Drawing.Point(25, 60);
            this.ipvlselection.Name = "ipvlselection";
            this.ipvlselection.Size = new System.Drawing.Size(122, 16);
            this.ipvlselection.TabIndex = 1;
            this.ipvlselection.Text = "Volatility Calculation";
            this.ipvlselection.UseVisualStyleBackColor = true;
            this.ipvlselection.CheckedChanged += new System.EventHandler(this.ipvlselection_CheckedChanged);
            // 
            // eurpselection
            // 
            this.eurpselection.AutoSize = true;
            this.eurpselection.Location = new System.Drawing.Point(25, 20);
            this.eurpselection.Name = "eurpselection";
            this.eurpselection.Size = new System.Drawing.Size(139, 16);
            this.eurpselection.TabIndex = 1;
            this.eurpselection.Text = "European Option Pricing";
            this.eurpselection.UseVisualStyleBackColor = true;
            this.eurpselection.CheckedChanged += new System.EventHandler(this.eurpselection_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 281);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(250, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.Spot_Price);
            this.groupBox2.Controls.Add(this.Number_of_Steps);
            this.groupBox2.Controls.Add(this.spotpriceinput);
            this.groupBox2.Controls.Add(this.strikepriceinput);
            this.groupBox2.Controls.Add(this.numberofstepsinput);
            this.groupBox2.Controls.Add(this.Option_Premium);
            this.groupBox2.Controls.Add(this.Strike_Price);
            this.groupBox2.Controls.Add(this.optionpremiuminput);
            this.groupBox2.Controls.Add(this.volatilityinput);
            this.groupBox2.Controls.Add(this.putselection);
            this.groupBox2.Controls.Add(this.Volatility);
            this.groupBox2.Controls.Add(this.callselection);
            this.groupBox2.Controls.Add(this.Time_to_Maturity);
            this.groupBox2.Controls.Add(this.timetomaturityinput);
            this.groupBox2.Controls.Add(this.Repo_Rate);
            this.groupBox2.Controls.Add(this.reporateinput);
            this.groupBox2.Controls.Add(this.riskfreerateinput);
            this.groupBox2.Controls.Add(this.Risk_Free_Rate);
            this.groupBox2.Location = new System.Drawing.Point(288, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(478, 337);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Method and Input Selection";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.aritselection);
            this.panel2.Controls.Add(this.geoselection);
            this.panel2.Location = new System.Drawing.Point(2, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 82);
            this.panel2.TabIndex = 23;
            // 
            // aritselection
            // 
            this.aritselection.AutoSize = true;
            this.aritselection.Location = new System.Drawing.Point(3, 54);
            this.aritselection.Name = "aritselection";
            this.aritselection.Size = new System.Drawing.Size(115, 16);
            this.aritselection.TabIndex = 24;
            this.aritselection.Text = "Arithmetic Method";
            this.aritselection.UseVisualStyleBackColor = true;
            this.aritselection.CheckedChanged += new System.EventHandler(this.aritselection_CheckedChanged);
            // 
            // geoselection
            // 
            this.geoselection.AutoSize = true;
            this.geoselection.Location = new System.Drawing.Point(3, 32);
            this.geoselection.Name = "geoselection";
            this.geoselection.Size = new System.Drawing.Size(110, 16);
            this.geoselection.TabIndex = 23;
            this.geoselection.Text = "Geometric Method";
            this.geoselection.UseVisualStyleBackColor = true;
            this.geoselection.CheckedChanged += new System.EventHandler(this.geoselection_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.volatilityinput2);
            this.panel3.Controls.Add(this.Volatility2);
            this.panel3.Controls.Add(this.correlationinput);
            this.panel3.Controls.Add(this.Correlation);
            this.panel3.Controls.Add(this.Asset2);
            this.panel3.Controls.Add(this.spotpriceinput2);
            this.panel3.Controls.Add(this.Spot_Price2);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(3, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(221, 171);
            this.panel3.TabIndex = 26;
            // 
            // volatilityinput2
            // 
            this.volatilityinput2.Location = new System.Drawing.Point(118, 90);
            this.volatilityinput2.Name = "volatilityinput2";
            this.volatilityinput2.Size = new System.Drawing.Size(100, 22);
            this.volatilityinput2.TabIndex = 16;
            // 
            // Volatility2
            // 
            this.Volatility2.AutoSize = true;
            this.Volatility2.Location = new System.Drawing.Point(3, 90);
            this.Volatility2.Name = "Volatility2";
            this.Volatility2.Size = new System.Drawing.Size(77, 12);
            this.Volatility2.TabIndex = 28;
            this.Volatility2.Text = "Volatility (δ2)";
            // 
            // correlationinput
            // 
            this.correlationinput.Location = new System.Drawing.Point(118, 59);
            this.correlationinput.Name = "correlationinput";
            this.correlationinput.Size = new System.Drawing.Size(100, 22);
            this.correlationinput.TabIndex = 14;
            // 
            // Correlation
            // 
            this.Correlation.AutoSize = true;
            this.Correlation.Location = new System.Drawing.Point(3, 60);
            this.Correlation.Name = "Correlation";
            this.Correlation.Size = new System.Drawing.Size(81, 12);
            this.Correlation.TabIndex = 31;
            this.Correlation.Text = "Correlation (ρ)";
            // 
            // Asset2
            // 
            this.Asset2.AutoSize = true;
            this.Asset2.Location = new System.Drawing.Point(3, 39);
            this.Asset2.Name = "Asset2";
            this.Asset2.Size = new System.Drawing.Size(38, 12);
            this.Asset2.TabIndex = 29;
            this.Asset2.Text = "Asset 2";
            // 
            // spotpriceinput2
            // 
            this.spotpriceinput2.Location = new System.Drawing.Point(118, 120);
            this.spotpriceinput2.Name = "spotpriceinput2";
            this.spotpriceinput2.Size = new System.Drawing.Size(100, 22);
            this.spotpriceinput2.TabIndex = 18;
            // 
            // Spot_Price2
            // 
            this.Spot_Price2.AutoSize = true;
            this.Spot_Price2.Location = new System.Drawing.Point(3, 120);
            this.Spot_Price2.Name = "Spot_Price2";
            this.Spot_Price2.Size = new System.Drawing.Size(75, 12);
            this.Spot_Price2.TabIndex = 28;
            this.Spot_Price2.Text = "Spot Price (S2)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.geoconselection);
            this.panel1.Controls.Add(this.Monte_Carlo_Paths);
            this.panel1.Controls.Add(this.montecarlopathsinput);
            this.panel1.Controls.Add(this.noconselection);
            this.panel1.Location = new System.Drawing.Point(228, 254);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 81);
            this.panel1.TabIndex = 25;
            // 
            // geoconselection
            // 
            this.geoconselection.AutoSize = true;
            this.geoconselection.Location = new System.Drawing.Point(6, 53);
            this.geoconselection.Name = "geoconselection";
            this.geoconselection.Size = new System.Drawing.Size(146, 16);
            this.geoconselection.TabIndex = 24;
            this.geoconselection.Text = "Geometric Control Variate";
            this.geoconselection.UseVisualStyleBackColor = true;
            // 
            // Monte_Carlo_Paths
            // 
            this.Monte_Carlo_Paths.AutoSize = true;
            this.Monte_Carlo_Paths.Location = new System.Drawing.Point(2, 5);
            this.Monte_Carlo_Paths.Name = "Monte_Carlo_Paths";
            this.Monte_Carlo_Paths.Size = new System.Drawing.Size(112, 12);
            this.Monte_Carlo_Paths.TabIndex = 22;
            this.Monte_Carlo_Paths.Text = "Monte Carlo Paths (M)";
            // 
            // montecarlopathsinput
            // 
            this.montecarlopathsinput.Location = new System.Drawing.Point(144, 5);
            this.montecarlopathsinput.Name = "montecarlopathsinput";
            this.montecarlopathsinput.Size = new System.Drawing.Size(100, 22);
            this.montecarlopathsinput.TabIndex = 22;
            // 
            // noconselection
            // 
            this.noconselection.AutoSize = true;
            this.noconselection.Location = new System.Drawing.Point(6, 31);
            this.noconselection.Name = "noconselection";
            this.noconselection.Size = new System.Drawing.Size(112, 16);
            this.noconselection.TabIndex = 23;
            this.noconselection.Text = "No Control Variate";
            this.noconselection.UseVisualStyleBackColor = true;
            // 
            // Spot_Price
            // 
            this.Spot_Price.AutoSize = true;
            this.Spot_Price.Location = new System.Drawing.Point(230, 200);
            this.Spot_Price.Name = "Spot_Price";
            this.Spot_Price.Size = new System.Drawing.Size(69, 12);
            this.Spot_Price.TabIndex = 5;
            this.Spot_Price.Text = "Spot Price (S)";
            // 
            // Number_of_Steps
            // 
            this.Number_of_Steps.AutoSize = true;
            this.Number_of_Steps.Location = new System.Drawing.Point(230, 140);
            this.Number_of_Steps.Name = "Number_of_Steps";
            this.Number_of_Steps.Size = new System.Drawing.Size(111, 12);
            this.Number_of_Steps.TabIndex = 20;
            this.Number_of_Steps.Text = "Steps/Observations (N)";
            // 
            // spotpriceinput
            // 
            this.spotpriceinput.Location = new System.Drawing.Point(372, 200);
            this.spotpriceinput.Name = "spotpriceinput";
            this.spotpriceinput.Size = new System.Drawing.Size(100, 22);
            this.spotpriceinput.TabIndex = 19;
            // 
            // strikepriceinput
            // 
            this.strikepriceinput.Location = new System.Drawing.Point(372, 230);
            this.strikepriceinput.Name = "strikepriceinput";
            this.strikepriceinput.Size = new System.Drawing.Size(100, 22);
            this.strikepriceinput.TabIndex = 21;
            // 
            // numberofstepsinput
            // 
            this.numberofstepsinput.Location = new System.Drawing.Point(372, 140);
            this.numberofstepsinput.Name = "numberofstepsinput";
            this.numberofstepsinput.Size = new System.Drawing.Size(100, 22);
            this.numberofstepsinput.TabIndex = 15;
            // 
            // Option_Premium
            // 
            this.Option_Premium.AutoSize = true;
            this.Option_Premium.Location = new System.Drawing.Point(230, 110);
            this.Option_Premium.Name = "Option_Premium";
            this.Option_Premium.Size = new System.Drawing.Size(99, 12);
            this.Option_Premium.TabIndex = 18;
            this.Option_Premium.Text = "Option Premium (P)";
            // 
            // Strike_Price
            // 
            this.Strike_Price.AutoSize = true;
            this.Strike_Price.Location = new System.Drawing.Point(230, 230);
            this.Strike_Price.Name = "Strike_Price";
            this.Strike_Price.Size = new System.Drawing.Size(77, 12);
            this.Strike_Price.TabIndex = 6;
            this.Strike_Price.Text = "Strike Price (K)";
            // 
            // optionpremiuminput
            // 
            this.optionpremiuminput.Location = new System.Drawing.Point(372, 110);
            this.optionpremiuminput.Name = "optionpremiuminput";
            this.optionpremiuminput.Size = new System.Drawing.Size(100, 22);
            this.optionpremiuminput.TabIndex = 13;
            // 
            // volatilityinput
            // 
            this.volatilityinput.Location = new System.Drawing.Point(372, 170);
            this.volatilityinput.Name = "volatilityinput";
            this.volatilityinput.Size = new System.Drawing.Size(100, 22);
            this.volatilityinput.TabIndex = 17;
            // 
            // putselection
            // 
            this.putselection.AutoSize = true;
            this.putselection.Location = new System.Drawing.Point(6, 44);
            this.putselection.Name = "putselection";
            this.putselection.Size = new System.Drawing.Size(73, 16);
            this.putselection.TabIndex = 2;
            this.putselection.Text = "Put Option";
            this.putselection.UseVisualStyleBackColor = true;
            // 
            // Volatility
            // 
            this.Volatility.AutoSize = true;
            this.Volatility.Location = new System.Drawing.Point(230, 170);
            this.Volatility.Name = "Volatility";
            this.Volatility.Size = new System.Drawing.Size(71, 12);
            this.Volatility.TabIndex = 8;
            this.Volatility.Text = "Volatility (δ)";
            // 
            // callselection
            // 
            this.callselection.AutoSize = true;
            this.callselection.Location = new System.Drawing.Point(6, 22);
            this.callselection.Name = "callselection";
            this.callselection.Size = new System.Drawing.Size(77, 16);
            this.callselection.TabIndex = 2;
            this.callselection.Text = "Call Option";
            this.callselection.UseVisualStyleBackColor = true;
            // 
            // Time_to_Maturity
            // 
            this.Time_to_Maturity.AutoSize = true;
            this.Time_to_Maturity.Location = new System.Drawing.Point(230, 80);
            this.Time_to_Maturity.Name = "Time_to_Maturity";
            this.Time_to_Maturity.Size = new System.Drawing.Size(102, 12);
            this.Time_to_Maturity.TabIndex = 14;
            this.Time_to_Maturity.Text = "Time to Maturity (T)";
            // 
            // timetomaturityinput
            // 
            this.timetomaturityinput.Location = new System.Drawing.Point(372, 80);
            this.timetomaturityinput.Name = "timetomaturityinput";
            this.timetomaturityinput.Size = new System.Drawing.Size(100, 22);
            this.timetomaturityinput.TabIndex = 12;
            // 
            // Repo_Rate
            // 
            this.Repo_Rate.AutoSize = true;
            this.Repo_Rate.Location = new System.Drawing.Point(230, 50);
            this.Repo_Rate.Name = "Repo_Rate";
            this.Repo_Rate.Size = new System.Drawing.Size(71, 12);
            this.Repo_Rate.TabIndex = 12;
            this.Repo_Rate.Text = "Repo Rate (q)";
            // 
            // reporateinput
            // 
            this.reporateinput.Location = new System.Drawing.Point(372, 50);
            this.reporateinput.Name = "reporateinput";
            this.reporateinput.Size = new System.Drawing.Size(100, 22);
            this.reporateinput.TabIndex = 11;
            // 
            // riskfreerateinput
            // 
            this.riskfreerateinput.Location = new System.Drawing.Point(372, 20);
            this.riskfreerateinput.Name = "riskfreerateinput";
            this.riskfreerateinput.Size = new System.Drawing.Size(100, 22);
            this.riskfreerateinput.TabIndex = 10;
            // 
            // Risk_Free_Rate
            // 
            this.Risk_Free_Rate.AutoSize = true;
            this.Risk_Free_Rate.Location = new System.Drawing.Point(230, 20);
            this.Risk_Free_Rate.Name = "Risk_Free_Rate";
            this.Risk_Free_Rate.Size = new System.Drawing.Size(88, 12);
            this.Risk_Free_Rate.TabIndex = 9;
            this.Risk_Free_Rate.Text = "Risk Free Rate (r)";
            // 
            // resetbutton
            // 
            this.resetbutton.Location = new System.Drawing.Point(508, 378);
            this.resetbutton.Name = "resetbutton";
            this.resetbutton.Size = new System.Drawing.Size(126, 49);
            this.resetbutton.TabIndex = 3;
            this.resetbutton.Text = "Reset All";
            this.resetbutton.UseVisualStyleBackColor = true;
            this.resetbutton.Click += new System.EventHandler(this.resetbutton_Click);
            // 
            // calculatebutton
            // 
            this.calculatebutton.Location = new System.Drawing.Point(640, 378);
            this.calculatebutton.Name = "calculatebutton";
            this.calculatebutton.Size = new System.Drawing.Size(126, 49);
            this.calculatebutton.TabIndex = 0;
            this.calculatebutton.Text = "Calculate";
            this.calculatebutton.UseVisualStyleBackColor = true;
            this.calculatebutton.Click += new System.EventHandler(this.calculatebutton_Click);
            // 
            // parameteroutput
            // 
            this.parameteroutput.Location = new System.Drawing.Point(30, 366);
            this.parameteroutput.Name = "parameteroutput";
            this.parameteroutput.ReadOnly = true;
            this.parameteroutput.Size = new System.Drawing.Size(472, 249);
            this.parameteroutput.TabIndex = 5;
            this.parameteroutput.TabStop = false;
            this.parameteroutput.Text = "";
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(512, 440);
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.Size = new System.Drawing.Size(253, 22);
            this.Result.TabIndex = 6;
            this.Result.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 627);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.parameteroutput);
            this.Controls.Add(this.calculatebutton);
            this.Controls.Add(this.resetbutton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Super Profit Option Pricing Calculator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton eurpselection;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label Spot_Price;
        private System.Windows.Forms.TextBox strikepriceinput;
        private System.Windows.Forms.TextBox spotpriceinput;
        private System.Windows.Forms.RadioButton ipvlselection;
        private System.Windows.Forms.Label Volatility;
        private System.Windows.Forms.TextBox volatilityinput;
        private System.Windows.Forms.Label Strike_Price;
        private System.Windows.Forms.Label Time_to_Maturity;
        private System.Windows.Forms.TextBox timetomaturityinput;
        private System.Windows.Forms.Label Repo_Rate;
        private System.Windows.Forms.TextBox reporateinput;
        private System.Windows.Forms.TextBox riskfreerateinput;
        private System.Windows.Forms.Label Risk_Free_Rate;
        private System.Windows.Forms.RadioButton putselection;
        private System.Windows.Forms.RadioButton callselection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Monte_Carlo_Paths;
        private System.Windows.Forms.TextBox montecarlopathsinput;
        private System.Windows.Forms.Label Number_of_Steps;
        private System.Windows.Forms.TextBox numberofstepsinput;
        private System.Windows.Forms.Label Option_Premium;
        private System.Windows.Forms.TextBox optionpremiuminput;
        private System.Windows.Forms.RadioButton amerselection;
        private System.Windows.Forms.RadioButton asiaselection;
        private System.Windows.Forms.RadioButton baskselection;
        private System.Windows.Forms.RadioButton aritselection;
        private System.Windows.Forms.RadioButton geoselection;
        private System.Windows.Forms.RadioButton geoconselection;
        private System.Windows.Forms.RadioButton noconselection;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Asset2;
        private System.Windows.Forms.TextBox spotpriceinput2;
        private System.Windows.Forms.Label Spot_Price2;
        private System.Windows.Forms.TextBox volatilityinput2;
        private System.Windows.Forms.Label Volatility2;
        private System.Windows.Forms.TextBox correlationinput;
        private System.Windows.Forms.Label Correlation;
        private System.Windows.Forms.Button resetbutton;
        private System.Windows.Forms.Button calculatebutton;
        private System.Windows.Forms.RichTextBox parameteroutput;
        private System.Windows.Forms.TextBox Result;
    }
}

