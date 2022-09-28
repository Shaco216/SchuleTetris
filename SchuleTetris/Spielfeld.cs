using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SchuleTetris
{
    internal class Spielfeld
    {
        //Label testlabel;
        //Form1 mainform;
        //int AnzReihen;
        //int BreiteSpielfeld;
        int labelbreite;
        int labelhöhe;
        int Offset;

        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        Size size;
        Color spielfeldfarbe;

        Label[,] labels;
        public Spielfeld()
        {
            labelbreite = 30; //ToDo: Variablisieren...
            labelhöhe = 30;
            //kontrolle über die gui 
            //mainform = Mainform;
            spielfeldfarbe = Color.Azure;
            Offset = 20;
            size = new Size();

            //int anzahlZeilen = 20;
            //int anzahlSpalten = 10;
            #region brauchen wir nachher wieder
            /*
            testlabel = new Label();
            testlabel.Location = new Point(20, 20);
            testlabel.BackColor = Color.HotPink;
            testlabel.Size = new Size(breite, höhe);
            List<Label> Labellist = new List<Label>();
            //Dadurch erhalt man beim erstellen des Objekts ein Label:
            for (int i = 1; i < anzahlZeilen; i++)
            {
                for (int j = 1; j < anzahlSpalten; j++)
                {
                    testlabel.Location = new Point(j * breite, i*höhe);
                    
                    //Mainform.Controls.Add(testlabel);
                    //Mainform.Refresh();

                    Labellist.Add(testlabel);
                }
            }
            foreach (var item in Labellist)
            {
                mainform.Controls.Add(item);
            }*/
            #endregion
        }
        public Spielfeld(Color spielfeldFarbe, int labelHöhe = 30,int labelBreite = 30, int Offset = 20)
        {
            this.labelbreite = labelBreite;
            this.labelhöhe = labelHöhe;
            spielfeldfarbe = spielfeldFarbe;
            this.Offset = Offset;
            size = new Size();
        }

        internal Panel Erstellen(int spielfeldHöhe =22, int spielfeldBreite = 10)
        {
            #region panelerstellen
            Panel spielfeldpanel = new Panel();
            spielfeldpanel.Size = new Size(Offset + spielfeldBreite * (labelbreite + 2) + Offset, Offset  + spielfeldHöhe * labelhöhe + Offset);
            spielfeldpanel.BackColor = Color.Yellow;

            #endregion
            #region labels erstellen
            labels = new Label[spielfeldHöhe, spielfeldBreite];
            for (int akthöhe = 0; akthöhe < spielfeldHöhe; akthöhe++)
            {
                for (int aktbreite = 0; aktbreite < spielfeldBreite; aktbreite++)
                {
                    Label aktLabel = new Label();
                    aktLabel.Location = new Point(labelbreite*aktbreite+Offset,labelhöhe*akthöhe + Offset);
                    aktLabel.BackColor = spielfeldfarbe;
                    aktLabel.BorderStyle = BorderStyle.Fixed3D;
                    aktLabel.Size = new Size(labelbreite, labelhöhe);
                    aktLabel.Text = $"{aktbreite}/{akthöhe}";


                    labels[akthöhe,aktbreite] = aktLabel;
                    spielfeldpanel.Controls.Add(aktLabel);
                }
            }
            //Übertragung der größe des Panels des Spielfelds an size für Form1
            this.size = spielfeldpanel.Size;
            #endregion
            #region Hauptform anpassen
            return spielfeldpanel;
            /*
            int titelhöhe = 20;
            mainform.Size = new Size(Offset + spielfeldBreite * (labelbreite +2) + Offset, Offset + titelhöhe + spielfeldHöhe * labelhöhe + Offset);*/
            #endregion
        }

        public void testmethode()
        {
            // testlabel.
        }
        public Size getSize()
        {
            return this.size;
        }
    }
}
