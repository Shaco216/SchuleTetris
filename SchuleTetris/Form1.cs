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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this als übergabeparameter um genau diese Form1 an den ctor/konstruktor des Spielfelds zu übergeben zur Erstellung des Labels:
            Spielfeld spielfeld = new Spielfeld(this);

        }
    }
}
