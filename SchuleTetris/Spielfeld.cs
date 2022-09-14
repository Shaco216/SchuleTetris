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
        Label testlabel;
        int AnzReihen;
        int BreiteSpielfeld;
        public Spielfeld(Form Mainform)
        {
            testlabel = new Label();
            testlabel.Location = new Point(20, 20);
            testlabel.BackColor = Color.HotPink;
            testlabel.Size = new Size(30, 20);
            //Dadurch erhalt man beim erstellen des Objekts ein Label:
            Mainform.Controls.Add(testlabel);
        }
    }
}
