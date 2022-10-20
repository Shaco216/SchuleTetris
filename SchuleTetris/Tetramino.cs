using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchuleTetris
{
    internal class Tetramino
    {
        const int anzahlTetraminoFelder = 4;
        bool _drehbar;
        Point _aktPosition;
        public Point _AktPosition { get { return _aktPosition; } }
        public enum TetraForm
        {
            I,
            L,
            J,
            T,
            Würfel,
            Z,
            S

        }
        Point[] koordinatenTetramino;
        public Point[] KoordinatenTetramino { get { return koordinatenTetramino; } }
        private TetraForm form;
        public TetraForm Form { get { return form; }}
        #region alte idee
        //Wird mit array dargestellt
        //private int breite;
        //
        //public int Breite
        //{
        //    get { return breite; }
        //    private set { breite = value; }
        //}
        //private int höhe;

        //public int Höhe
        //{
        //    get { return höhe; }
        //    private set { höhe = value; }
        //}

        #endregion
        private Color colorTetramino;
        public Color ColorTetramino
        {
            get { return colorTetramino; }
            set { colorTetramino = value; }
        }

        Random zufallsTetramino = new Random();
        public Tetramino(Point Startposition)
        {
            _aktPosition = Startposition;
            CreateTetramino();
            //Console.WriteLine("Tetramino erstellt");//War erfolgreich!
        }
        #region Erstellung Tetramino
        private void CreateTetramino(bool Drehbar = true)
        {
            this.koordinatenTetramino = new Point[anzahlTetraminoFelder];
            this._drehbar = Drehbar;//für alle gleich  auser würfel
            switch (zufallsTetramino.Next(0, Enum.GetNames(typeof(TetraForm)).Length))//alle tetraminozustände 7 verschiedene 
            {
                case (int)TetraForm.I://0
                    this.form = TetraForm.I;
                    this.ColorTetramino = Color.LightBlue;
                    break;
                case (int)TetraForm.L://1
                    this.form = TetraForm.L;
                    ColorTetramino = Color.Violet;
                    break;
                case (int)TetraForm.J://2
                    this.form = TetraForm.J;
                    this.ColorTetramino = Color.Green;
                    break;
                case (int)TetraForm.T://3
                    this.form = TetraForm.T;
                    this.ColorTetramino = Color.Red;
                    break;
                case (int)TetraForm.Würfel://4
                    this.form = TetraForm.Würfel;
                    this.ColorTetramino = Color.Yellow;
                    this._drehbar = false; //händisch weil einziger nicht drehbarer Tetramino
                    break;
                case (int)TetraForm.Z://5
                    this.form = TetraForm.Z;
                    this.ColorTetramino = Color.GreenYellow;
                    break;
                case (int)TetraForm.S://6
                    this.form = TetraForm.S;
                    this.ColorTetramino = Color.Snow;
                    break;
                default:
                    //MessageBox.Show("no tetramino for you :)");
                    Console.WriteLine("Kein Tetramino erzeugt");
                    break;
            }
            this.koordinatenTetramino = BerechneForm_Felderbelegung(this.form);
        }
        private Point[] BerechneForm_Felderbelegung(TetraForm tetraform, int AnzahlFelderFuerTetramino = anzahlTetraminoFelder)
        {
            Point[] koordinatenTetramino = new Point[AnzahlFelderFuerTetramino];
            int x;
            int y;
            switch (tetraform)//alle tetraminozustände 7 verschiedene 
            {
                case TetraForm.I:
                    y = 0;
                    x = 1;
                    for (int i = 0; AnzahlFelderFuerTetramino > i; i++)
                    {
                        koordinatenTetramino[i] = new Point(x,y+i);//durch y + i wird nach unten felder markiert
                    }
                    break;
                case TetraForm.L:
                    x = 1;
                    y = 0;
                    for (int i = 0; AnzahlFelderFuerTetramino > i; i++)
                    {
                        if (i < 3) 
                        { 
                            koordinatenTetramino[i] = new Point(x, y + i);//durch y + i wird nach unten felder markiert
                        }
                        else if(i == 3)
                        {
                            koordinatenTetramino[i] = new Point(x+1,y+i-1);// x+1 ein feld rechts; y+i-1 auf selber höhe wie bei vorherigem durchlauf um -- zu machen
                        }
                    }
                    break;
                case TetraForm.J:
                    x = 1;
                    y = 0;
                    for (int i = 0; AnzahlFelderFuerTetramino > i; i++)
                    {
                        if (i < 3)
                        {
                            koordinatenTetramino[i] = new Point(x, y + i);//durch y - i wird nach unten felder markiert
                        }
                        else if (i == 3)
                        {
                            koordinatenTetramino[i] = new Point(x - 1, y + i - 1);// x+1 ein feld rechts; y-i+1 auf selber höhe wie bei vorherigem durchlauf um -- zu machen
                        }
                    }
                    break;
                case TetraForm.T:
                    x = 0;
                    y = 0;
                    for (int i = 0; AnzahlFelderFuerTetramino > i; i++)
                    {
                        if (i < 3)
                        {
                            koordinatenTetramino[i] = new Point(x + i, y);//durch y - i wird nach unten felder markiert
                        }
                        else if (i == 3)
                        {
                            koordinatenTetramino[i] = new Point(x - 1, y + 1);// x-1 ein feld weiter links; y-1 ein feld runter
                        }
                    }
                    break;
                case TetraForm.Würfel:
                    x = 1;
                    y = 0;
                    for (int i = 0; AnzahlFelderFuerTetramino > i; i++)
                    {
                        if (i < 2)
                        {
                            koordinatenTetramino[i] = new Point(x + (i%2), y);
                        }
                        else if (i > 2)
                        {
                            x = 1;
                            koordinatenTetramino[i] = new Point(x + (i % 2), y + 1);// x-1 ein feld weiter links; y-1 ein feld runter
                        }
                    }
                    break;
                case TetraForm.Z:
                    x = 0;
                    y = 0;
                    for (int i = 0; AnzahlFelderFuerTetramino > i; i++)
                    {
                        if (i < 2)
                        {
                            koordinatenTetramino[i] = new Point(x + (i % 2), y);
                        }
                        else if (i > 2)
                        {
                            x = 1;
                            koordinatenTetramino[i] = new Point(x + (i % 2), y + 1);
                        }
                    }
                    break;
                case TetraForm.S:
                    x = 1;
                    y = 0;
                    for (int i = 0; AnzahlFelderFuerTetramino > i; i++)
                    {
                        if (i < 2)
                        {
                            koordinatenTetramino[i] = new Point(x + (i % 2), y);
                        }
                        else if (i > 2)
                        {
                            x = 0;
                            koordinatenTetramino[i] = new Point(x + (i % 2), y + 1);
                        }
                    }
                    break;
            }
            return koordinatenTetramino;
        }
        #endregion
        #region BewegungTetramino
        public void MoveLeft()
        {
            _aktPosition.X -= 1;
        }
        public void MoveRight()
        {
            _aktPosition.X += 1;
        }
        public void MoveDown()
        {
            _aktPosition.Y += 1;
        }
        public void MoveRotate()
        {
            Point[] newKoordinaten = new Point[anzahlTetraminoFelder];
            int zähler = 0;
            foreach(Point koordinate in koordinatenTetramino)
            {
                newKoordinaten[zähler].X = -koordinate.Y;
                newKoordinaten[zähler].Y = koordinate.X;
                zähler++;
            }
            koordinatenTetramino = newKoordinaten;
        }
        public void MoveRotatePotoczki()
        {
            var oldKoords = koordinatenTetramino;

            for (int i = 0; i < oldKoords.Length; i++)
            {
                koordinatenTetramino[i].X = -oldKoords[i].Y;
                koordinatenTetramino[i].Y = oldKoords[i].X;
            }
        }
        #endregion
    }
}
