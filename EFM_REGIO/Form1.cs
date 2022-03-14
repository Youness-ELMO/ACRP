using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFM_REGIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void randonnéeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Randonnee r = new Randonnee();
            r.Show();
        }

        private void listeRandoneeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f= new Form2();
            f.Show();
        }
    }
}
