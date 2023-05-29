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

namespace eczane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan= new SqlConnection("data source=LAPTOP-OQHO7M4T\\SQLEXPRESS;Initial Catalog=eczaneilacstok;Integrated Security=true");
        private void verilerigörüntüle()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("select* from ilac", baglan);
            SqlDataReader oku=komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ilacad"].ToString());
                ekle.SubItems.Add(oku["ilacsirketi"].ToString());
                ekle.SubItems.Add(oku["ilacturu"].ToString());
                ekle.SubItems.Add(oku["ilackutuadeti"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void btn_goruntule_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Insert into ilac(id,ilacad,ilacsirketi,ilacturu,ilackutuadeti)values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "')",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        int id=0;
        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("delete from ilac where id='"+ textBox1.Text + "'",baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
        }

        private void btn_güncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update ilac set id='"+textBox1.Text.ToString()+"',ilacad='"+textBox2.Text.ToString()+"',ilacsirketi='"+textBox3.Text.ToString()+"',ilacturu='"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"' where id="+id+"");
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigörüntüle();
        }
    }
}
