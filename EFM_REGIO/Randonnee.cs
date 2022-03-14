using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EFM_REGIO
{
    public partial class Randonnee : Form
    {
        public Randonnee()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        SqlDataAdapter da;
        SqlDataAdapter da2;
        SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-A7ECOHN\SQLEXPRESS;Initial Catalog=EFM_REGIO;Integrated Security=True;Pooling=False");
        BindingManagerBase bnd;
        private void Randonnee_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from Randonnee ", cnx);
            da.Fill(ds, "Randonnee");


            da2 = new SqlDataAdapter("select * from Circuits ", cnx);
            da2.Fill(ds, "Circuits");

            comboBox1.DataSource = ds.Tables["Circuits"];
            comboBox1.DisplayMember = "codeCircuit";
            comboBox1.ValueMember = "codeCircuit";


            bnd = this.BindingContext[ds.Tables["Randonnee"]];
            textBox1.DataBindings.Add("text", ds.Tables["Randonnee"], "codeRandonnee");
            comboBox1.DataBindings.Add("text", ds.Tables["Randonnee"], "CodeCircuit");
            textBox2.DataBindings.Add("text", ds.Tables["Randonnee"], "dateR");
            textBox3.DataBindings.Add("text", ds.Tables["Randonnee"], "prix");
            textBox4.DataBindings.Add("text", ds.Tables["Randonnee"], "depart");
            textBox5.DataBindings.Add("text", ds.Tables["Randonnee"], "nbPlacemaxi");
            textBox6.DataBindings.Add("text", ds.Tables["Randonnee"], "nomResponsable");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow r = ds.Tables["Randonnee"].NewRow();
            r[0] = textBox1.Text;
            r[1] = comboBox1.Text;
            r[2] = textBox2.Text;
            r[3] = textBox3.Text;
            r[4] = textBox4.Text;
            r[5] = textBox5.Text;
            r[6] = textBox6.Text;

            ds.Tables["Randonnee"].Rows.Add(r);
            MessageBox.Show("ajout bien fait !!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow dr = ds.Tables["Randonnee"].Select("codeRandonnee=" + textBox1.Text + "")[0];
            dr[1] = comboBox1.SelectedValue;
            dr[2] = textBox2.Text;
            dr[3] = textBox3.Text;
            dr[4] = textBox4.Text;
            dr[5] = textBox5.Text;
            dr[6] = textBox6.Text;
            
            MessageBox.Show("modification bien fait !!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ds.Tables["Randonnee"].Select("codeRandonnee = '" + textBox1.Text + "'")[0].Delete();
            MessageBox.Show("suppression bien fait !!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            da.Update(ds.Tables["Randonnee"]);
            MessageBox.Show("enregistre bien fait !!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            bnd.Position = 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bnd.Position--;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bnd.Position++;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bnd.Position= ds.Tables["Randonnee"].Rows.Count-1;
        }
    }
}
