using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JM.Splash
{
    public partial class SplashScreen : Form
    {
        public Action Worker { get; set; }
        public SplashScreen(/*Action worker*/)
        {
            InitializeComponent();
            //     if (worker==null)
            //            throw new ArgumentNullException();
            //            Worker = worker;


            //    protected override void OnLoad(EventArgs e)
            //   {
            //     base.OnLoad(e);
            //        Task.Factory.StartNew(Worker).ContinueWith(t=>{this.Close();}, TaskScheduler.FromCurrentSynchronizationContext());

            //    }


            //private void SplashScreen_Load(object sender, EventArgs e)
            //{

            //}
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rectangleShape2.Width += 5;
            if (rectangleShape2.Width>=424)
            {
                timer1.Stop();
                Login a = new Login();
                this.Hide();
                a.ShowDialog();
               
            }
        }
    }
}