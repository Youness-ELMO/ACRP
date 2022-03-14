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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection cnx;
        public static int op;
        private void Form2_Load(object sender, EventArgs e)
        {
             cnx = new SqlConnection(@"Data Source=DESKTOP-A7ECOHN\SQLEXPRESS;Initial Catalog=EFM_REGIO;Integrated Security=True;Pooling=False");
            textBox1.Enabled= false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            button2.Enabled = false;

            dataGridView1.Columns.Add("codeRandonnee", "codeRandonnee");
            dataGridView1.Columns.Add("CodeCircuit", "CodeCircuit");
            dataGridView1.Columns.Add("dateR", "dateR");
            dataGridView1.Columns.Add("prix", "prix");
            dataGridView1.Columns.Add("depart", "departv");
            dataGridView1.Columns.Add("nbPlacemaxi", "nbPlacemaxi");
            dataGridView1.Columns.Add("nomResponsable", "nomResponsable");
            dataGridView1.Columns.Add("nbparticipants", "nbparticipants");

            dataGridView1.Columns[1].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cnx.Open();
            var dgv = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string af= "select * from Circuits where codeCircuit ="+dgv;
            SqlCommand cmd = new SqlCommand(af,cnx);
            SqlDataReader r = cmd.ExecuteReader();
            r.Read();
            textBox1.Text = r[0].ToString();
            textBox2.Text = r[1].ToString();
            textBox3.Text = r[2].ToString();
            textBox4.Text = r[3].ToString();
            textBox5.Text = r[4].ToString();

            cnx.Close();

            int np = int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString());
            int nm = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            DateTime dat =(DateTime)dataGridView1.CurrentRow.Cells[2].Value;


            if (np > nm && dat > DateTime.Now)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }

            op = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cnx.Open();
            string r = "select Randonnee.*,count(*) as nombre_particicer from Randonnee join Circuits on Randonnee.CodeCircuit=Circuits.codeCircuit where dateR between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'  group by Randonnee.codeRandonnee ,Randonnee.CodeCircuit, Randonnee.dateR,Randonnee.prix , Randonnee.depart ,Randonnee.nbPlacemaxi, Randonnee.nomResponsable ";
            SqlCommand cmd = new SqlCommand(r, cnx);
            MessageBox.Show("" + r);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                dataGridView1.Rows.Add(rd[0],rd[1], rd[2], rd[3], rd[4], rd[5], rd[6], rd[7]);
            }
            rd.Close();
            cnx.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sele s=new sele(op);
            s.Show();
        }
    }
}
