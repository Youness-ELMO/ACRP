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
    public partial class sele : Form
    {
        public static int p;
        SqlConnection cnx;

        public sele()       
          
        {
            InitializeComponent();
        }
        public sele(int op)
        {
            InitializeComponent();
            p = op;
        }

        private void sele_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'eFM_REGIODataSet.Adherent'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.adherentTableAdapter.Fill(this.eFM_REGIODataSet.Adherent);
            cnx = new SqlConnection(@"Data Source=DESKTOP-A7ECOHN\SQLEXPRESS;Initial Catalog=EFM_REGIO;Integrated Security=True;Pooling=False");

            cnx.Open();
            string la = "select codeRandonnee,CodeCircuit,dateR,depart,prix from Randonnee where codeRandonnee =" + p;
            SqlCommand cmd = new SqlCommand(la, cnx);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            label6.Text = r[0].ToString();
            label7.Text = r[1].ToString();
            label8.Text = r[2].ToString();
            label9.Text = r[3].ToString();
            label10.Text = r[4].ToString();

            cnx.Close();







        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx.Open();
            string co = "select * from Adherent where codeAd='"+comboBox1.SelectedValue+"' ";
            SqlCommand cmd = new SqlCommand(co, cnx);
            SqlDataReader r = cmd.ExecuteReader();
           if(r.Read())
            {
                textBox1.Text = r[1].ToString();
                textBox2.Text = r[2].ToString();
                textBox3.Text = r[3].ToString();
                textBox4.Text = r[4].ToString();
                textBox5.Text = r[5].ToString();
            }
           
            r.Close();
            cnx.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            string en = "insert into Participer values("+comboBox1.SelectedValue+","+label6.Text+",'"+DateTime.Now+"')";
            SqlCommand cmd = new SqlCommand(en, cnx);
            SqlDataReader r = cmd.ExecuteReader();
            MessageBox.Show("ajout bien fait !!");
            cnx.Close();
        }
    }
}
