using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchuleTetris
{
    public partial class Form1 : Form
    {
        Spielfeld spielfeld;
        Point startpunkt;
        Tetramino tetramino;

        public Form1()
        {
            InitializeComponent();
            //spielfeld = new Spielfeld();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this als übergabeparameter um genau diese Form1 an den ctor/konstruktor des Spielfelds zu übergeben zur Erstellung des Labels:

            SpielfeldGenerieren();
            //test
        }
        private void SpielfeldGenerieren()
        {
            //Test

            startpunkt = new Point(0,0);
            tetramino = new Tetramino(startpunkt);
            
            //TestEnde
            spielfeld = new Spielfeld(Color.Red);
            int spielfeldBreite = 10;
            int spielfeldHöhe = 22;

            splitContainer1.Panel1.Controls.Add(spielfeld.Erstellen(spielfeldHöhe, spielfeldBreite));
            splitContainer1.SplitterDistance = spielfeld.getSize().Width;
            splitContainer1.Height = spielfeld.getSize().Height;
            ////Fenster anpassen:
            //Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle);
            //int titleHeight = screenRectangle.Top - this.Top;

            //this.Height = spielfeld.getSize().Height + titleHeight;//+ SystemInformation.CaptionHeight + SystemInformation.MenuHeight; oder spielfeld.getSize().Height + 43 -> ist höhe titelbar
            ////SystemInformation.CaptionHeight von https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.systeminformation.captionheight?view=windowsdesktop-6.0
            //// taskbar height bzw title bar

            FensterAnpassen();

        }
        public void FensterAnpassen()
        {
            //Fenster anpassen:
            Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;

            this.Height = spielfeld.getSize().Height + titleHeight;//+ SystemInformation.CaptionHeight + SystemInformation.MenuHeight; oder spielfeld.getSize().Height + 43 -> ist höhe titelbar
            //SystemInformation.CaptionHeight von https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.systeminformation.captionheight?view=windowsdesktop-6.0
            // taskbar height bzw title bar
        }
        private void test_Click(object sender, EventArgs e)
        {
            spielfeld.testmethode();
        }

        private void splitContainer1_Panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            //splitContainer1.SplitterDistance = spielfeld.getSize().Width;
        }
    }
}
