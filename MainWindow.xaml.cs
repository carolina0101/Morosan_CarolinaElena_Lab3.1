using Morosan_CarolinaElena_Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Morosan_CarolinaElena_Lab2
{
    class DoughnutMachine {
        private int mRaisedGlazed;
        private int mRaisedSugar;
        private int mFilledLemon;
        private int mFilledChocolate;
        private int mFilledVanilla;
        private object glazedToolStripMenuItem;
        private object sugarToolStripMenuItem;

        /// <summary>
        /// /////////////////
        /// </summary>
        
            public System.Collections.ArrayList mDoughnuts = new System.Collections.ArrayList();
            public Doughnut this[int Index]
            {
                get
                {
                    return (Doughnut)mDoughnuts[Index];
                }
                set
                {
                    mDoughnuts[Index] = value;
                }
            }

            public DoughnutMachine()
            {
                InitializeComponent();
            }
            public void MakeDoughnuts(DoughnutType dFlavor)
            {
                Flavor = dFlavor;
                switch (Flavor)
                {
                    case DoughnutType.Glazed: Interval = 3; break;
                    case DoughnutType.Sugar: Interval = 2; break;
                    case DoughnutType.Lemon: Interval = 5; break;
                    case DoughnutType.Chocolate: Interval = 7; break;
                    case DoughnutType.Vanilla: Interval = 4; break;
                }
                doughnutTimer.Start();
            }


            private void doughnutTimer_Tick(object sender, EventArgs e)
            {
                Doughnut aDoughnut = new Doughnut(this.Flavor);
                mDoughnuts.Add(aDoughnut);
                DoughnutComplete();
            }
            public bool Enabled
            {
                set
                {
                    doughnutTimer.IsEnabled = value;
                }
            }
            public int Interval

            {
                set
                {
                    doughnutTimer.Interval = new TimeSpan(0, 0, value);
                }
            }
            public delegate void DoughnutCompleteDelegate();
            public event DoughnutCompleteDelegate DoughnutComplete;
            DispatcherTimer doughnutTimer;
  
            public DoughnutType Flavor { get; private set; }

            private void InitializeComponent()
            {
                this.doughnutTimer = new DispatcherTimer();

                this.doughnutTimer.Tick += new System.EventHandler(this.doughnutTimer_Tick);
            }


            private void DoughnutTimer_Tick(object sender, EventArgs e)
            {
                Doughnut aDoughnut = new Doughnut(this.Flavor);
                mDoughnuts.Add(aDoughnut);
                DoughnutComplete();
                throw new NotImplementedException();
            }
        



        //////////////////////////
        
        private DoughnutMachine myDoughnutMachine;
        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine = new DoughnutMachine();
        }   
           

        private void glazedToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsCheked = true;
            sugarToolStripMenuItem.IsChecked = false;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Glazed);
        }

            private void MakeDoughnuts(DoughnutType sugar)
            {
            throw new NotImplementedException();
            }

        private void sugarToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            glazedToolStripMenuItem.IsChecked = false;
            sugarToolStripMenuItem.IsChecked = true;
            myDoughnutMachine.MakeDoughnuts(DoughnutType.Sugar);
        }
        private void stopToolStripMenuItem_Click(object sender, RoutedEventArgs e)
        {
            myDoughnutMachine.Enabled = false;
        }


        myDoughnutMachine.DoughnutComplete += new
            DoughnutMachine.DoughnutCompleteDelegate DoughnutCompleteHandler;
        

        
    }

    internal class DoughnutCompleteHandler
    {
    }
}