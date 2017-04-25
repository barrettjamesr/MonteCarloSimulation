using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "No task has been selected.";
        }

        public enum currenttask { eur, imv, ame, asi, bas}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //Functions that controls UI changes
        private void eurpselection_CheckedChanged(object sender, EventArgs e)
        {
            clearcontrol();
            textBox1.Text = "European Option Pricing Mode";
            setscreen(currenttask.eur);
        }   //Select european options
        private void ipvlselection_CheckedChanged(object sender, EventArgs e)
        {
            clearcontrol();
            textBox1.Text = "Implied Volatility Calculation Mode";
            setscreen(currenttask.imv);
        }   //Select implied vol
        private void amerselection_CheckedChanged(object sender, EventArgs e)
        {
            clearcontrol();
            textBox1.Text = "American Option Pricing Mode";
            setscreen(currenttask.ame);
        }   //Select american options
        private void asiaselection_CheckedChanged(object sender, EventArgs e)
        {
            clearcontrol();
            textBox1.Text = "Asian Option Pricing Mode";
            setscreen(currenttask.asi);
        }   //Select asian options
        private void baskselection_CheckedChanged(object sender, EventArgs e)
        {
            clearcontrol();
            textBox1.Text = "Basket Option Pricing Mode";
            setscreen(currenttask.bas);
        }   //Select basket options
        private void aritselection_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }   //Select arithmetic method
        private void geoselection_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Enabled = true;
        }    //Select geometric method

        //Function that process raw data and call actual calculation implementations
        private void calculatebutton_Click(object sender, EventArgs e)
        {
            parameteroutput.Text = "";
            var checkedButton = groupBox1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            bool valid =true;
            string C_P, PricingMethod, ContVariate;
            C_P = PricingMethod = "";
            ContVariate = "Non";
            double S1,S2,K1,K2,P,Sigma1,Sigma2,T,rate,repo,corr;
            S1 = S2 = K1 = K2 = P = Sigma1 = Sigma2 = T = rate = repo = corr = 0;
            long N, n, M;
            N = n = M = 0;
            if (checkedButton != null)
            {
                var check2 = groupBox2.Controls.OfType<RadioButton>()
                     .FirstOrDefault(r => r.Checked);
                if (check2 != null)
                {
                    if (check2.Name.ToUpper() == "CALLSELECTION") { C_P = "C"; }
                    else if (check2.Name.ToUpper() == "PUTSELECTION") { C_P = "P"; }
                    else { parameteroutput.AppendText("An unknown error has occured!"); return; }
                }
                else { parameteroutput.AppendText("Please select call or put!"); return; }
                //risk free rate
                try
                {
                    rate = Convert.ToDouble(riskfreerateinput.Text);
                    parameteroutput.AppendText("Risk free rate = " + rate.ToString());

                }
                catch (Exception ex)
                {
                    parameteroutput.AppendText("Invalid input for risk free rate.");
                    valid = false;
                }
                //time to maturity
                try
                {
                    T = Convert.ToDouble(timetomaturityinput.Text);
                    if (T > 0)
                    {
                        parameteroutput.AppendText(Environment.NewLine + "Time to maturity = " + T.ToString());
                    }
                    else
                    {
                        parameteroutput.AppendText("Invalid input for time to maturity");
                        valid = false;
                    }
                }
                catch (Exception ex)
                {
                    parameteroutput.AppendText(Environment.NewLine + "Invalid input for time to maturity.");
                    valid = false;
                }
                //spot price for asset1
                try
                {
                    S1 = Convert.ToDouble(spotpriceinput.Text);
                    if (S1 > 0)
                    {
                        parameteroutput.AppendText(Environment.NewLine + "Spot price = " + S1.ToString());
                    }
                    else
                    {
                        parameteroutput.AppendText(Environment.NewLine + "Invalid input for spot price.");
                        valid = false;
                    }

                }
                catch (Exception ex)
                {
                    parameteroutput.AppendText(Environment.NewLine + "Invalid input for spot price.");
                    valid = false;
                }
                //strike price for asset1
                try
                {
                    K1 = Convert.ToDouble(strikepriceinput.Text);
                    if (K1 > 0)
                    {
                        parameteroutput.AppendText(Environment.NewLine + "Strike price = " + K1.ToString());
                    }
                    else 
                    {
                        parameteroutput.AppendText(Environment.NewLine + "Invalid input for strike price.");
                        valid = false;
                    }
                }
                catch (Exception ex)
                {
                    parameteroutput.AppendText(Environment.NewLine + "Invalid input for strike price.");
                    valid = false;
                }
                //task specific parameters
                switch (checkedButton.Name.ToUpper())
                {
                    case "EURPSELECTION":
                        //repo rate
                        try
                        {
                            repo = Convert.ToDouble(reporateinput.Text);
                            parameteroutput.AppendText(Environment.NewLine + "Repurchase rate = " + repo.ToString());
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for repo rate.");
                            valid = false;
                        }
                        //volatility for asset1
                        try
                        {
                            Sigma1 = Convert.ToDouble(volatilityinput.Text);
                            if (Sigma1 > 0)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Volatility = " + Sigma1.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for volatility.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for volatility.");
                            valid = false;
                        }                    
                        //use relavent data for calculation here
                        if (valid)
                        { eur_option(rate = Convert.ToDouble(riskfreerateinput.Text), T = Convert.ToDouble(timetomaturityinput.Text), S1 = Convert.ToDouble(spotpriceinput.Text), K1 = Convert.ToDouble(strikepriceinput.Text), repo = Convert.ToDouble(reporateinput.Text), Sigma1 = Convert.ToDouble(volatilityinput.Text),C_P); }
                        else { Result.Text = "Calculation cannot proceed!"; return; }
                        break;
                    case "IPVLSELECTION":
                        //repo rate
                        try
                        {
                            repo = Convert.ToDouble(reporateinput.Text);
                            parameteroutput.AppendText(Environment.NewLine + "Repurchase rate = " + repo.ToString());                            
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for repo rate.");
                            valid = false;
                        }
                        //option premium
                        try
                        {
                            P = Convert.ToDouble(optionpremiuminput.Text);
                            if (P > 0)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Option premium = " + P.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for option premium.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for option premium.");
                            valid = false;
                        }
                        //use relavent data for calculation here
                        if (valid)
                        { imp_option(rate = Convert.ToDouble(riskfreerateinput.Text), T = Convert.ToDouble(timetomaturityinput.Text), S1 = Convert.ToDouble(spotpriceinput.Text), K1 = Convert.ToDouble(strikepriceinput.Text), repo = Convert.ToDouble(reporateinput.Text), P = Convert.ToDouble(optionpremiuminput.Text), C_P); }
                        else { Result.Text = "Calculation cannot proceed!"; return; }
                        break;
                    case "AMERSELECTION":
                        //volatility for asset1
                        try
                        {
                            Sigma1 = Convert.ToDouble(volatilityinput.Text);
                            if (Sigma1 > 0)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Volatility = " + Sigma1.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for volatility.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for volatility.");
                            valid = false;
                        }  
                        //number of steps
                        try
                        {
                            N = Convert.ToInt64(numberofstepsinput.Text);
                            if (N >= 0 && N<=2000)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Number of steps = " + N.ToString());
                            }
                            else if (N > 2000)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Number of steps is too large!");
                                valid = false;
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for number of steps.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for number of steps.");
                            valid = false;
                        }
                        //use relavent data for calculation here
                        if (valid)
                        { ame_option(rate = Convert.ToDouble(riskfreerateinput.Text), T = Convert.ToDouble(timetomaturityinput.Text), S1 = Convert.ToDouble(spotpriceinput.Text), K1 = Convert.ToDouble(strikepriceinput.Text), N = Convert.ToInt64(numberofstepsinput.Text), Sigma1 = Convert.ToDouble(volatilityinput.Text), C_P); }
                        else { Result.Text = "Calculation cannot proceed!"; return; }
                        break;
                    case "ASIASELECTION":
                        //volatility for asset1
                        try
                        {
                            Sigma1 = Convert.ToDouble(volatilityinput.Text);
                            if (Sigma1 > 0)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Volatility = " + Sigma1.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for volatility.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for volatility.");
                            valid = false;
                        }
                        //number of observations
                        try
                        {
                            n = Convert.ToInt64(numberofstepsinput.Text);
                            if (n >= 0)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Number of observations = " + n.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for number of observations.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for number of observations.");
                            valid = false;
                        }
                        var check3 = panel2.Controls.OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);
                        var check4 = panel1.Controls.OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);
                        if (check3 != null)
                        {
                            if (check3.Name.ToUpper() == "ARITSELECTION")
                            {
                                //number of paths for monte carlo simulation
                                PricingMethod = "ARITSELECTION";
                                try
                                {
                                    M = Convert.ToInt64(montecarlopathsinput.Text);
                                    if (M >= 0)
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Number of Monte Carlo Paths = " + M.ToString());
                                    }
                                    else
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Invalid input for Monte Carlo Paths.");
                                        valid = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    parameteroutput.AppendText(Environment.NewLine + "Invalid input for Monte Carlo Paths.");
                                    valid = false;
                                }

                                if (check4 != null)
                                {
                                    if (check4.Name.ToUpper() == "NOCONSELECTION") { ContVariate = "NON"; }
                                    else if (check4.Name.ToUpper() == "GEOCONSELECTION") { ContVariate = "GEO"; }
                                    else { parameteroutput.AppendText(Environment.NewLine + "An unknown error has occured!"); valid = false; }
                                }
                                else { parameteroutput.AppendText(Environment.NewLine + "Please select control variate method."); valid = false; }
                            }
                            else if(check3.Name.ToUpper() == "GEOSELECTION")
                            {
                                PricingMethod = "GEOSELECTION";
                                try
                                {
                                    if (check4 != null)
                                    {
                                        if (check4.Name.ToUpper() == "GEOCONSELECTION")
                                        {
                                            parameteroutput.AppendText(Environment.NewLine + "Cannot select Geometric Control Variate for Geometric Option!");
                                            valid = false;
                                        }
                                    }
                                    M = Convert.ToInt64(montecarlopathsinput.Text);
                                    if (M >= 0)
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Number of Monte Carlo Paths = " + M.ToString());
                                    }
                                    else
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Invalid input for Monte Carlo Paths.");
                                        valid = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (montecarlopathsinput.Text == "" || montecarlopathsinput.Text == null)
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Using closed form method.");
                                    }
                                    else
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Invalid input for Monte Carlo Paths.");
                                        valid = false;
                                    }
                                }
                            }
                        }
                        else { parameteroutput.AppendText(Environment.NewLine + "Please select Geometric or Arithmetic."); valid = false; }
                        //total number of paths n * M can't be greater than 100,000,000 or it'll take too long
                        try
                        {
                            if (n * M < 100000000)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Total number of paths = " + (n* M).ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for total number of paths (n * m  < 100,000,000).");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for Total number of paths (n * m  < 100,000,000).");
                            valid = false;
                        }
                        //use relavent data for calculation here
                        if (valid)
                        { asi_option(rate = Convert.ToDouble(riskfreerateinput.Text), 
                            T = Convert.ToDouble(timetomaturityinput.Text), 
                            S1 = Convert.ToDouble(spotpriceinput.Text), 
                            K1 = Convert.ToDouble(strikepriceinput.Text), 
                            n = Convert.ToInt64(numberofstepsinput.Text), 
                            Sigma1 = Convert.ToDouble(volatilityinput.Text),                           
                            C_P, 
                            PricingMethod, 
                            M, 
                            ContVariate);
                        }
                        else { Result.Text = "Calculation cannot proceed!"; return; }
                        break;
                    case "BASKSELECTION":
                        //volatility for asset1
                        try
                        {
                            Sigma1 = Convert.ToDouble(volatilityinput.Text);
                            if (Sigma1 > 0)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Volatility = " + Sigma1.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for volatility.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for volatility.");
                            valid = false;
                        }
                        //spot price for asset2
                        try
                        {
                            S2 = Convert.ToDouble(spotpriceinput2.Text);
                            if (S2 > 0)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Spot price for Asset2 = " + S2.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for Asset2 spot price.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for Asset2 spot price.");
                            valid = false;
                        }
                        //volatility for asset2
                        try
                        {
                            Sigma2 = Convert.ToDouble(volatilityinput2.Text);
                            if (Sigma2 >= 0)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Volatility for Asset2 = " + Sigma2.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for Asset2 volatility.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for Asset2 volatility.");
                            valid = false;
                        }
                        //correlation between two assets
                        try
                        {
                            corr = Convert.ToDouble(correlationinput.Text);
                            if (corr >= -1 && corr <= 1)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Correlation of two assets = " + corr.ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for correlation of two assets.");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for correlation of two assets.");
                            valid = false;
                        }
                        check3 = panel2.Controls.OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);
                        check4 = panel1.Controls.OfType<RadioButton>()
                            .FirstOrDefault(r => r.Checked);
                        if (check3 != null)
                        {
                            if (check3.Name.ToUpper() == "ARITSELECTION")
                            {
                                PricingMethod = "ARITSELECTION";
                                //number of paths for monte carlo simulation
                                try
                                {
                                    M = Convert.ToInt64(montecarlopathsinput.Text);
                                    if (M >= 0)
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Number of Monte Carlo Paths = " + M.ToString());
                                    }
                                    else
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Invalid input for Monte Carlo Paths.");
                                        valid = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    parameteroutput.AppendText(Environment.NewLine + "Invalid input for Monte Carlo Paths.");
                                    valid = false;
                                }
                                if (check4 != null)
                                {
                                    if (check4.Name.ToUpper() == "NOCONSELECTION") { ContVariate = "NON"; }
                                    else if (check4.Name.ToUpper() == "GEOCONSELECTION") { ContVariate = "GEO"; }
                                    else { parameteroutput.AppendText(Environment.NewLine + "An unknown error has occured!"); valid = false; }
                                }
                                else { parameteroutput.AppendText(Environment.NewLine + "Please select control variate method."); valid = false; }
                            }
                            else if (check3.Name.ToUpper() == "GEOSELECTION")
                            {
                                PricingMethod = "GEOSELECTION";
                                try
                                {
                                    if (check4 != null)
                                    {
                                        if (check4.Name.ToUpper() == "GEOCONSELECTION")
                                        { 
                                            parameteroutput.AppendText(Environment.NewLine + "Cannot select Geometric Control Variate for Geometric Option!");
                                            valid = false;
                                        }
                                    }
                                    M = Convert.ToInt64(montecarlopathsinput.Text);
                                    if (M >= 0)
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Number of Monte Carlo Paths = " + M.ToString());
                                    }
                                    else
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Invalid input for Monte Carlo Paths.");
                                        valid = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    if (montecarlopathsinput.Text == "" || montecarlopathsinput.Text == null)
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Using closed form method.");
                                    }
                                    else
                                    {
                                        parameteroutput.AppendText(Environment.NewLine + "Invalid input for Monte Carlo Paths.");
                                        valid = false;
                                    }
                                }
                            }
                        }
                        else { parameteroutput.AppendText(Environment.NewLine + "Please select Geometric or Arithmetic."); valid = false; }
                        //number of observations if using MC
                        try
                        {
                            if (M > 0)
                            {
                                n = Convert.ToInt64(numberofstepsinput.Text);
                                if (n >= 0)
                                {
                                    parameteroutput.AppendText(Environment.NewLine + "Number of observations = " + n.ToString());
                                }
                                else
                                {
                                    parameteroutput.AppendText(Environment.NewLine + "Invalid input for number of observations.");
                                    valid = false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for number of observations.");
                            valid = false;
                        }
                        //total number of paths n * M can't be greater than 100,000,000 or it'll take too long
                        try
                        {
                            if (n * M < 100000000)
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Total number of paths = " + (n * M).ToString());
                            }
                            else
                            {
                                parameteroutput.AppendText(Environment.NewLine + "Invalid input for total number of paths (n * m  < 100,000,000).");
                                valid = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            parameteroutput.AppendText(Environment.NewLine + "Invalid input for Total number of paths (n * m  < 100,000,000).");
                            valid = false;
                        }
                        //use relavent data for calculation here
                        if (valid)
                        {
                            bas_option(rate = Convert.ToDouble(riskfreerateinput.Text), T = Convert.ToDouble(timetomaturityinput.Text),
                                  S1 = Convert.ToDouble(spotpriceinput.Text), K1 = Convert.ToDouble(strikepriceinput.Text),
                                  Sigma1 = Convert.ToDouble(volatilityinput.Text), S2 = Convert.ToDouble(spotpriceinput2.Text),
                                  Sigma2 = Convert.ToDouble(volatilityinput2.Text), corr = Convert.ToDouble(correlationinput.Text), 
                                  C_P, PricingMethod, n, M, ContVariate);
                        }
                        else { Result.Text = "Calculation cannot proceed!"; return; }

                        break;
                    default:
                        textBox1.Text = ("Default case");
                        break;
                }
            }
        }

        //Functions that handle calculations
        private void eur_option(double rate, double T, double S1, double K1, double repo, double Sigma1, string C_P) 
        {
            //testing input
            parameteroutput.AppendText(Environment.NewLine + "rate:" + rate.ToString() +", T:" + T.ToString()+", S1:" + S1.ToString() + ", K1:"+ K1.ToString()+", repo:" +repo.ToString()+", Sigma:" + Sigma1.ToString()+", CP:" + C_P);
            //calculation here
            double value = BSFQ(rate, T, S1, K1, repo, Sigma1, C_P);
            Result.Text = "Option Price: " + Math.Round(value,3).ToString();
            return;
        }
        private void imp_option(double rate, double T, double S1, double K1, double repo, double P, string C_P) 
        {
            //testing input
            parameteroutput.AppendText(Environment.NewLine + "rate:" + rate.ToString() + ", T:" + T.ToString() + ", S1:" + S1.ToString() + ", K1:" + K1.ToString() + ", repo:" + repo.ToString() + ", price:" + P.ToString() + ", CP:" + C_P);
            //calculation here
            double tol = 0.00000001; //accuracy for IV calculation
            double sigdiff = 1.0; //initialize sigma difference
            double sig = Math.Sqrt(2 * Math.Abs((Math.Log(S1/K1) + (rate-repo) * T)/T)); //initial test sigma
            int i =1; //iteration counter
            if (validprice(C_P,P,S1,K1,T,rate,repo))
            { //if price is valid, calculate IV
                double N_P,d1,px,cvg,inc,IV;
                while (sigdiff >=tol && i <= 100) //IV calculation iteration
                {   N_P = BSFQ(rate, T, S1, K1, repo, sig, C_P);
                    d1 = (Math.Log(S1 / K1) + (rate - repo) * T) / (sig * Math.Sqrt(T)) + 0.5 * sig * Math.Sqrt(T);
                    px = 1/(Math.Sqrt(Math.PI * 2)) * Math.Pow(Math.E, (-Math.Pow(d1,2)/2));
                    cvg = S1 * Math.Pow(Math.E,(-repo * T)) * Math.Sqrt(T) * px;
                    inc = (N_P - P)/cvg;
                    sig = sig - inc;
                    i+=1;
                    sigdiff = Math.Abs(inc);
                }
                IV = sig;
                Result.Text = "Implied Vol: " + Math.Round(IV * 100, 3).ToString() + "%";
            }
            else
            {Result.Text = "Option price is out of reasonable bound!";}
            return; 
        }
        private void ame_option(double rate, double T, double S1, double K1, long N, double Sigma1, string C_P)
        {
            //testing input
            parameteroutput.AppendText(Environment.NewLine + "rate:" + rate.ToString() + ", T:" + T.ToString() + ", S1:" + S1.ToString() + ", K1:" + K1.ToString() + ", N:" + N.ToString() + ", Sigma1:" + Sigma1.ToString() + ", CP:" + C_P);
            //calculation here
            double DeltaT = T / N;
            double[,] StockPrices = new double[N+1, N+1];
            double[,] OptionValues = new double [N+1,N+1];
            double u = Math.Pow(Math.E, Sigma1 * Math.Sqrt(DeltaT));
            double d = 1 / u;
            StockPrices[N, 0] = S1 * Math.Pow(d,N);
            double p = (Math.Pow(Math.E, rate * DeltaT) - d) / (u - d);
            for (long i = 1;i<=N;i++)
            {
                StockPrices[N, i] = StockPrices[N, i-1] * u/d;
            }
            if (C_P.ToUpper() == "C")
            {
                for (long i = 0; i <= N; i++)
                {
                    OptionValues[N, i] = Math.Max(StockPrices[N, i] - K1, 0);
                }
            }
            else
            {
                for (long i = 0; i <= N; i++)
                {
                    OptionValues[N, i] = Math.Max(K1 - StockPrices[N, i], 0);
                }
            }
            for (long i = N-1; i >= 0; i--)
            {
                for (long j = 0; j <= i; j++)
                {
                    OptionValues[i, j] = Math.Pow(Math.E, -rate * DeltaT) * (p * OptionValues[i+1, j + 1] + (1 - p) * OptionValues[i+1, j]);
                    StockPrices[i, j] = StockPrices[i + 1, j] / d;
                    if (C_P.ToUpper() == "C")
                    {
                        OptionValues[i, j] = Math.Max(OptionValues[i, j], StockPrices[i, j] - K1);
                    }
                    else
                    {
                        OptionValues[i, j] = Math.Max(OptionValues[i, j], K1 - StockPrices[i, j]);    
                    }
                }
            }
            Result.Text = "Option Price: " + Math.Round(OptionValues[0, 0], 3).ToString();
        }
        private void asi_option(double rate, double T, double S1, double K1, long n, double Sigma1, string C_P, string PricingMethod, long M, string ContVariate)
        {
            //testing input
            parameteroutput.AppendText(Environment.NewLine + "rate:" + rate.ToString() + ", T:" + T.ToString() + ", S1:" + S1.ToString() +
                ", K1:" + K1.ToString() + ", n:" + n.ToString() + ", Sigma1:" + Sigma1.ToString() + ", CP:" + C_P + ", Mode:" + PricingMethod + ", M:" + M.ToString() + ", Control Variate:" + ContVariate);
            //calculation here
            //the following is for Geometric Asian Options, used in multiple places.
                double sigmastar = Sigma1 * Math.Sqrt((n + 1)*(2*n +1)/(6 * Math.Pow(n,2)));
                double miu = (rate - 0.5 * Math.Pow(Sigma1, 2)) * (n+1) / (2*n) + 0.5 * Math.Pow(sigmastar,2);
                double d1 = (Math.Log(S1/K1) + (miu + 0.5 * Math.Pow(sigmastar,2)) * T)/(sigmastar*Math.Sqrt(T));
                double d2 = d1 - sigmastar*Math.Sqrt(T);
                double geo = 0;
                if (C_P == "C")
                { geo = Math.Pow(Math.E, -rate * T) * (S1 * Math.Pow(Math.E, miu * T) * N(d1) - K1 * N(d2)); }
                else
                { geo = Math.Pow(Math.E, -rate * T) * (K1 * N(-d2) - S1 * Math.Pow(Math.E, miu * T) * N(-d1)); }
            if (PricingMethod.ToUpper() == "GEOSELECTION" && M == 0) //Closed form 
            {
                Result.Text = "Closed Form Option Price: " + Math.Round(geo,3).ToString();
            }
            //Monte Carlo for Geometric Asian Options here:
            else if (PricingMethod.ToUpper() == "GEOSELECTION" && M >= 0)
            {
                double DeltaT = T / n;
                double ConfInt = 1.96;

                // seeded pseudo-random number with gaussian distribution, using box-muller calculation
                Gaussian rand = new Gaussian();
                double seed = rand.BoxMuller();

                double[] geoPayoff = new double[M];
                double geoMean;

                // "M" number of sample stock paths
                for (int j = 0; j < M; j++)
                {
                    double S_t1 = S1;
                    double[] Spath = new double[n];
                    double[] LogSpath = new double[n];

                    // From 0 to T is "n" number of steps
                    for (int i = 0; i < n; i++)
                    {
                        //price drifts according to geometric brownian motion
                        double curRand = rand.BoxMuller();
                        S_t1 = S_Brownian(S_t1, rate, Sigma1, DeltaT, curRand);
                        Spath[i] = S_t1;
                        LogSpath[i] = Math.Log(S_t1);
                    }

                    geoMean = Math.Exp(LogSpath.Sum() / n);
                    if (C_P.ToUpper() == "C")
                    {
                        geoPayoff[j] = Math.Max(geoMean - K1, 0) / Math.Exp(rate * T);
                    }
                    else
                    {
                        geoPayoff[j] = Math.Max(K1 - geoMean, 0) / Math.Exp(rate * T);
                    }
                }

                // standard MC
                double Pmean = geoPayoff.Average();
                double Pstdev = Math.Pow(geoPayoff.Select(val => (val - Pmean) * (val - Pmean)).Sum() / M, 0.5);

                Result.Text = "Option Price: " + Math.Round(Pmean, 3).ToString() + ", Conf Int: " + Math.Round(Pmean - ConfInt * Pstdev / Math.Pow(M, 0.5), 3).ToString() + "/" + Math.Round(Pmean + ConfInt * Pstdev / Math.Pow(M, 0.5), 3).ToString();

            }
            else
            // Monte Carlo for Arithmetic Asian Options
            {
                double DeltaT = T / n;
                double ConfInt = 1.96;

                // seeded pseudo-random number with gaussian distribution, using box-muller calculation
                Gaussian rand = new Gaussian();
                double seed = rand.BoxMuller();

                double[] arithPayoff = new double[M];
                double[] geoPayoff = new double[M];
                double arithMean;
                double geoMean;

                // "M" number of sample stock paths
                for (int j = 0; j < M; j++)
                {
                    double S_t1 = S1;
                    double[] Spath = new double[n];
                    double[] LogSpath = new double[n];

                    // From 0 to T is "n" number of steps
                    for (int i = 0; i < n; i++)
                    {
                        //price drifts according to geometric brownian motion
                        double curRand = rand.BoxMuller();
                        S_t1 = S_Brownian(S_t1, rate, Sigma1, DeltaT, curRand);
                        Spath[i] = S_t1;
                        LogSpath[i] = Math.Log(S_t1);
                    }

                    // payoff based on average prices
                    arithMean = Spath.Average();
                    geoMean = Math.Exp(LogSpath.Sum() / n);
                    if (C_P.ToUpper() == "C")
                    {
                        arithPayoff[j] = Math.Max(arithMean - K1, 0) / Math.Exp(rate * T);
                        geoPayoff[j] = Math.Max(geoMean - K1, 0) / Math.Exp(rate * T);
                    }
                    else
                    {
                        arithPayoff[j] = Math.Max(K1 - arithMean, 0) / Math.Exp(rate * T);
                        geoPayoff[j] = Math.Max(K1 - geoMean, 0) / Math.Exp(rate * T);

                    }
                }

                // using closed-form geometric option as control variate
                if (ContVariate.ToUpper() == "GEO")
                {
                    double pointDiffMean = arithPayoff.Zip(geoPayoff, (arith, geom) => arith * geom).Average();
                    double covXY = pointDiffMean - arithPayoff.Average() * geoPayoff.Average();
                    double geoPayoffMean = geoPayoff.Average();
                    double varY = geoPayoff.Select(val => (val - geoPayoffMean) * (val - geoPayoffMean)).Sum() / M;
                    double theta = covXY / varY;

                    double[] ExpectedX;
                    ExpectedX = geoPayoff.Zip(arithPayoff, (x, y) => theta * (geo - x) + y).ToArray();
                    double Xmean = ExpectedX.Average();
                    double Xstdev = Math.Pow(ExpectedX.Select(val => (val - Xmean) * (val - Xmean)).Sum() / M, 0.5);

                    Result.Text = "Option Price: " + Math.Round(Xmean, 3).ToString() + ", Conf Int: " + Math.Round(Xmean - ConfInt * Xstdev / Math.Pow(M, 0.5), 3).ToString() + "/" + Math.Round(Xmean + ConfInt * Xstdev / Math.Pow(M, 0.5), 3).ToString();
                }
                else // standard MC
                {
                    double Pmean = arithPayoff.Average();
                    double Pstdev = Math.Pow(arithPayoff.Select(val => (val - Pmean) * (val - Pmean)).Sum() / M, 0.5);

                    Result.Text = "Option Price: " + Math.Round(Pmean, 3).ToString() + ", Conf Int: " + Math.Round(Pmean - ConfInt * Pstdev / Math.Pow(M, 0.5), 3).ToString() + "/" + Math.Round(Pmean + ConfInt * Pstdev / Math.Pow(M, 0.5), 3).ToString();

                }
            }
            return;
        }
        private void bas_option(double rate, double T, double S1, double K1, double Sigma1, double S2, double Sigma2, double corr, string C_P, string PricingMethod, long n, long M, string ContVariate)
        {
            //testing input
            parameteroutput.AppendText(Environment.NewLine + "rate:" + rate.ToString() + ", T:" + T.ToString() + ", S1:" + S1.ToString() +  ", K1:" + K1.ToString() +
                ", Sigma1:" + Sigma1.ToString() + ", S2:" + S2.ToString() + ", Sigma2:" + Sigma2.ToString() + ", Corr:" + corr.ToString() +
                ", CP:" + C_P + ", Mode:" + PricingMethod + ", M:" + M.ToString() + ", Control Variate:" + ContVariate);
            //calculation here
            //the following is for Geometric Basket Options
            double sigmabask = Math.Sqrt(Math.Pow(Sigma1, 2) + Math.Pow(Sigma2, 2) + 2 * corr * Sigma1 * Sigma2) / 2;
            double miu = rate - 0.5 * (Math.Pow(Sigma1, 2) + Math.Pow(Sigma2, 2)) / 2 + 0.5 * Math.Pow(sigmabask, 2);
            double Bg0 = Math.Sqrt(S1 * S2);
            double d1 = (Math.Log(Bg0 / K1) + (miu + 0.5 * Math.Pow(sigmabask, 2)) * T) / (sigmabask * Math.Sqrt(T));
            double d2 = d1 - sigmabask * Math.Sqrt(T);
            double geo = 0;
            if (C_P.ToUpper() == "C")
            { geo = Math.Pow(Math.E, -rate * T) * (Bg0 * Math.Pow(Math.E, miu * T) * N(d1) - K1 * N(d2)); }
            else
            { geo = Math.Pow(Math.E, -rate * T) * (K1 * N(-d2) - Bg0 * Math.Pow(Math.E, miu * T) * N(-d1)); }

            if (PricingMethod.ToUpper() == "GEOSELECTION" && M == 0) //Closed form solution
            { 
                Result.Text = "Closed Form Option Price: " + Math.Round(geo, 3).ToString();
            }
            else if (PricingMethod.ToUpper() == "GEOSELECTION" && M >= 0)
            {
                //Monte Carlo for Geometric Basket Options here:
                double DeltaT = T / n;
                double ConfInt = 1.96;

                // seeded pseudo-random number with gaussian distribution, using box-muller calculation
                Gaussian rand = new Gaussian();
                double seed = rand.BoxMuller();

                double[] geoPayoff = new double[M];
                double geoMean;

                // "M" number of sample stock paths
                for (int j = 0; j < M; j++)
                {
                    double S1_t1 = S1;
                    double S2_t1 = S2;
                    double[] S1path = new double[n];
                    double[] S2path = new double[n];

                    // From 0 to T is "n" number of steps
                    for (int i = 0; i < n; i++)
                    {
                        //price drifts according to geometric brownian motion
                        //curRand2 is a correlated random variable, to generate two stock price time series with correlated returns = corr
                        double curRand1 = rand.BoxMuller();
                        double curRand2 = corr * curRand1 + rand.BoxMuller() * Math.Pow(1 - corr * corr, 0.5);
                        S1_t1 = S_Brownian(S1_t1, rate, Sigma1, DeltaT, curRand1);
                        S2_t1 = S_Brownian(S2_t1, rate, Sigma2, DeltaT, curRand2);
                        S1path[i] = S1_t1;
                        S2path[i] = S2_t1;
                    }

                    // payoff based off geometric mean at expiry
                    geoMean = Math.Pow(S1path[n - 1] * S2path[n - 1], 0.5);
                    if (C_P.ToUpper() == "C")
                    {
                        geoPayoff[j] = Math.Max(geoMean - K1, 0) / Math.Exp(rate * T);
                    }
                    else
                    {
                        geoPayoff[j] = Math.Max(K1 - geoMean, 0) / Math.Exp(rate * T);
                    }
                }

                // Standard MC
                double Pmean = geoPayoff.Average();
                double Pstdev = Math.Pow(geoPayoff.Select(val => (val - Pmean) * (val - Pmean)).Sum() / M, 0.5);

                Result.Text = "Option Price: " + Math.Round(Pmean, 3).ToString() + ", Conf Int: " + Math.Round(Pmean - ConfInt * Pstdev / Math.Pow(M, 0.5), 3).ToString() + "/" + Math.Round(Pmean + ConfInt * Pstdev / Math.Pow(M, 0.5), 3).ToString();

            }
            else
            // Monte Carlo for Arithmetic Basket Options
            {
                double DeltaT = T / n;
                double ConfInt = 1.96;

                // seeded pseudo-random number with gaussian distribution, using box-muller calculation
                Gaussian rand = new Gaussian();
                double seed = rand.BoxMuller();

                double[] arithPayoff = new double[M];
                double[] geoPayoff = new double[M];
                double arithMean;
                double geoMean;

                // "M" number of sample stock paths
                for (int j = 0; j < M; j++)
                {
                    double S1_t1 = S1;
                    double S2_t1 = S2;
                    double[] S1path = new double[n];
                    double[] S2path = new double[n];

                    // From 0 to T is "n" number of steps
                    for (int i = 0; i < n; i++)
                    {
                        //price drifts according to geometric brownian motion
                        //curRand2 is a correlated random variable, to generate two stock price time series with correlated returns = corr
                        double curRand1 = rand.BoxMuller();
                        double curRand2 = corr * curRand1 + rand.BoxMuller() * Math.Pow(1 - corr * corr, 0.5);
                        S1_t1 = S_Brownian(S1_t1, rate, Sigma1, DeltaT, curRand1);
                        S2_t1 = S_Brownian(S2_t1, rate, Sigma2, DeltaT, curRand2);
                        S1path[i] = S1_t1;
                        S2path[i] = S2_t1;
                    }

                    // payoff based off mean at expiry
                    arithMean = (S1path[n - 1] + S2path[n - 1]) / 2;
                    geoMean = Math.Pow(S1path[n - 1] * S2path[n - 1], 0.5);
                    if (C_P.ToUpper() == "C")
                    {
                        arithPayoff[j] = Math.Max(arithMean - K1, 0) / Math.Exp(rate * T);
                        geoPayoff[j] = Math.Max(geoMean - K1, 0) / Math.Exp(rate * T);
                    }
                    else
                    {
                        arithPayoff[j] = Math.Max(K1 - arithMean, 0) / Math.Exp(rate * T);
                        geoPayoff[j] = Math.Max(K1 - geoMean, 0) / Math.Exp(rate * T);
                    }
                }

                // using closed-form geometric option as control variate
                if (ContVariate.ToUpper() == "GEO")
                {
                    double pointDiffMean = arithPayoff.Zip(geoPayoff, (arith, geom) => arith * geom).Average();
                    double covXY = pointDiffMean - arithPayoff.Average() * geoPayoff.Average();
                    double geoPayoffMean = geoPayoff.Average();
                    double varY = geoPayoff.Select(val => (val - geoPayoffMean) * (val - geoPayoffMean)).Sum() / M;
                    double theta = covXY / varY;

                    double[] ExpectedX;
                    ExpectedX = geoPayoff.Zip(arithPayoff, (x, y) => theta * (geo - x) + y).ToArray();
                    double Xmean = ExpectedX.Average();
                    double Xstdev = Math.Pow(ExpectedX.Select(val => (val - Xmean) * (val - Xmean)).Sum() / M, 0.5);

                    Result.Text = "Option Price: " + Math.Round(Xmean, 3).ToString() + ", Conf Int: " + Math.Round(Xmean - ConfInt * Xstdev / Math.Pow(M, 0.5), 3).ToString() + "/" + Math.Round(Xmean + ConfInt * Xstdev / Math.Pow(M, 0.5), 3).ToString();
                }
                else  // Standard MC
                {
                    double Pmean = arithPayoff.Average();
                    double Pstdev = Math.Pow(arithPayoff.Select(val => (val - Pmean) * (val - Pmean)).Sum() / M, 0.5);

                    Result.Text = "Option Price: " + Math.Round(Pmean, 3).ToString() + ", Conf Int: " + Math.Round(Pmean - ConfInt * Pstdev / Math.Pow(M, 0.5), 3).ToString() + "/" + Math.Round(Pmean + ConfInt * Pstdev / Math.Pow(M, 0.5), 3).ToString();
                }
            }

            return;
        }

        //Some utility functions below
        private void setscreen(currenttask task)
        {
            switch (task)
            {
                case currenttask.eur:
                    callselection.Enabled = true;
                    putselection.Enabled = true;
                    panel2.Enabled = false;
                    Spot_Price.Enabled = true;
                    spotpriceinput.Enabled = true;
                    Strike_Price.Enabled = true;
                    strikepriceinput.Enabled = true;
                    Volatility.Enabled = true;
                    volatilityinput.Enabled = true;
                    Risk_Free_Rate.Enabled = true;
                    riskfreerateinput.Enabled = true;
                    Repo_Rate.Enabled = true;
                    reporateinput.Enabled = true;
                    Time_to_Maturity.Enabled = true;
                    timetomaturityinput.Enabled = true;
                    Option_Premium.Enabled = false;
                    optionpremiuminput.Text = "";
                    optionpremiuminput.Enabled = false;
                    Number_of_Steps.Enabled = false;
                    numberofstepsinput.Text = "";
                    numberofstepsinput.Enabled = false;
                    panel1.Enabled = false;
                    panel3.Enabled = false;
                    break;
                case currenttask.imv:
                    callselection.Enabled = true;
                    putselection.Enabled = true;
                    panel2.Enabled = false;
                    Spot_Price.Enabled = true;
                    spotpriceinput.Enabled = true;
                    Strike_Price.Enabled = true;
                    strikepriceinput.Enabled = true;
                    Volatility.Enabled = false;
                    volatilityinput.Text = "";
                    volatilityinput.Enabled = false;
                    Risk_Free_Rate.Enabled = true;
                    riskfreerateinput.Enabled = true;
                    Repo_Rate.Enabled = true;
                    reporateinput.Enabled = true;
                    Time_to_Maturity.Enabled = true;
                    timetomaturityinput.Enabled = true;
                    Option_Premium.Enabled = true;
                    optionpremiuminput.Enabled = true;
                    Number_of_Steps.Enabled = false;
                    numberofstepsinput.Text = "";
                    numberofstepsinput.Enabled = false;
                    panel1.Enabled = false;
                    panel3.Enabled = false;
                    break;
                case currenttask.ame:
                    callselection.Enabled = true;
                    putselection.Enabled = true;
                    panel2.Enabled = false;
                    Spot_Price.Enabled = true;
                    spotpriceinput.Enabled = true;
                    Strike_Price.Enabled = true;
                    strikepriceinput.Enabled = true;
                    Volatility.Enabled = true;
                    volatilityinput.Enabled = true;
                    Risk_Free_Rate.Enabled = true;
                    riskfreerateinput.Enabled = true;
                    Repo_Rate.Enabled = false;
                    reporateinput.Text = "";
                    reporateinput.Enabled = false;
                    Time_to_Maturity.Enabled = true;
                    timetomaturityinput.Enabled = true;
                    Option_Premium.Enabled = false;
                    optionpremiuminput.Text = "";
                    optionpremiuminput.Enabled = false;
                    Number_of_Steps.Enabled = true;
                    numberofstepsinput.Enabled = true;
                    panel1.Enabled = false;
                    panel3.Enabled = false;                    
                    break;
                case currenttask.asi:
                    callselection.Enabled = true;
                    putselection.Enabled = true;
                    panel2.Enabled = true;
                    Spot_Price.Enabled = true;
                    spotpriceinput.Enabled = true;
                    Strike_Price.Enabled = true;
                    strikepriceinput.Enabled = true;
                    Volatility.Enabled = true;
                    volatilityinput.Enabled = true;
                    Risk_Free_Rate.Enabled = true;
                    riskfreerateinput.Enabled = true;
                    Repo_Rate.Enabled = false;
                    reporateinput.Text = "";
                    reporateinput.Enabled = false;
                    Time_to_Maturity.Enabled = true;
                    timetomaturityinput.Enabled = true;
                    Option_Premium.Enabled = false;
                    optionpremiuminput.Text = "";
                    optionpremiuminput.Enabled = false;
                    Number_of_Steps.Enabled = true;
                    numberofstepsinput.Enabled = true;
                    panel1.Enabled = false;
                    panel3.Enabled = false;                    
                    break;
                case currenttask.bas:
                    callselection.Enabled = true;
                    putselection.Enabled = true;
                    panel2.Enabled = true;
                    Spot_Price.Enabled = true;
                    spotpriceinput.Enabled = true;
                    Strike_Price.Enabled = true;
                    strikepriceinput.Enabled = true;
                    Volatility.Enabled = true;
                    volatilityinput.Enabled = true;
                    Risk_Free_Rate.Enabled = true;
                    riskfreerateinput.Enabled = true;
                    Repo_Rate.Enabled = false;
                    reporateinput.Enabled = false;
                    Time_to_Maturity.Enabled = true;
                    timetomaturityinput.Enabled = true;
                    Option_Premium.Enabled = false;
                    optionpremiuminput.Enabled = false;
                    Number_of_Steps.Enabled = true;
                    numberofstepsinput.Enabled = true;
                    panel1.Enabled = false;
                    panel3.Enabled = true;
                    break;
                default:
                    textBox1.Text = ("Default case");
                    break;
            } 
        }   //Set UI based on selection of methods
        private void resetbutton_Click(object sender, EventArgs e)
        {
            clearcontrol();
        } //Call clearcontrol function
        private void clearcontrol() 
        {
            foreach (Control ctrl in groupBox2.Controls)//this will only select controls of groupbox2
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                }
            }
            foreach (Control ctrl in panel1.Controls)//this will only select controls of groupbox2
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                }
            }
            foreach (Control ctrl in panel2.Controls)//this will only select controls of groupbox2
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                }
            }
            foreach (Control ctrl in panel3.Controls)//this will only select controls of groupbox2
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).Text = "";
                }
                if (ctrl is RadioButton)
                {
                    (ctrl as RadioButton).Checked = false;
                }
            }
        } //Reset previous selections and inputs
        static double erf(double x)
        {
            // constants
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;

            // Save the sign of x
            int sign = 1;
            if (x < 0)
                sign = -1;
            x = Math.Abs(x);

            // A&S formula 7.1.26
            double t = 1.0 / (1.0 + p * x);
            double y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        } //Error function
        static double N(double x)
        {
            double phi = 0.5 * (1 + erf(x/Math.Sqrt(2)));
            return phi;
        } //CDF function
        static double BSFQ(double rate, double T, double S1, double K1, double repo, double Sigma1, string C_P)
        {
            double d1 = (Math.Log(S1 / K1) + (rate - repo) * T) / (Sigma1 * Math.Sqrt(T)) + 0.5 * Sigma1 * Math.Sqrt(T);
            double d2 = d1 - Sigma1 * Math.Sqrt(T);
            double value = 0;
            if (C_P == "C")
            {
                value = S1 * Math.Pow(Math.E, (-repo * T)) * N(d1) - K1 * Math.Pow(Math.E, (-rate * T)) * N(d2);
            }
            else
            {
                value = K1 * Math.Pow(Math.E, (-rate * T)) * N(-d2) - S1 * Math.Pow(Math.E, (-repo * T)) * N(-d1);
            }
            return value;
        } //Black-Scholes formula with repo rate
        static bool validprice(string C_P,double P,double S1,double K1,double T,double rate, double repo) //Check if the price of option is within boundaries
        {
            if (C_P == "C")
            {
                if (P < Math.Max((S1*Math.Pow(Math.E,(-repo)*T)-K1*Math.Pow(Math.E,(-rate)*T)),0)){return false;}
                if (P <= 0){return false;}
                if (P > S1){return false;}
                return true;
            }
            else
            {
                if (P < Math.Max((K1*Math.Pow(Math.E,(-rate)*T)-S1*Math.Pow(Math.E,(-repo)*T)),0)){return false;}
                if (P <= 0){return false;}
                if (P > K1*Math.Pow(Math.E,(-rate)*T)){return false;}
                return true;
            }
        }
        private static double S_Brownian(double S, double r, double sigma, double Dt, double Z)
        //Brownian movement function
        {
            return S * Math.Exp((r - 0.5 * sigma * sigma) * Dt + sigma * Math.Pow(Dt, 0.5) * Z);
        }
    }
    public class Gaussian
    {
        //  generator of seeded pseudo-random number with gaussian distribution, using box-muller calculation
        private Random random;

        public Gaussian()
        {
            random = new Random(0);
        }

        public double BoxMuller()
        {
            //https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform
            double u1 = 1.0 - random.NextDouble();
            double u2 = 1.0 - random.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
        }
    }

}
