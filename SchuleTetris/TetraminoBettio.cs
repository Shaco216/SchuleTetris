using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuleTetris
{
    internal class TetraminoBettio
    {
        Point _aktPosition; // der _ bedeutet, dass es private ist
        Point[] _form;
        Color _farbe;
        bool _drehbar;
        /// <summary>
        /// Erstellt einen zufälligen gültigen Tetramino
        /// </summary>
        /// <param name="Startposition">Position im Spielfeld zu Beginn</param>
        public TetraminoBettio(Point Startposition)
        {
            _aktPosition = Startposition;
            //ErzeugeTetramino();
        }
    }
}
