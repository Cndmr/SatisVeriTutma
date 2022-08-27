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

namespace Proje_SQL_DB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnKategori_Click(object sender, EventArgs e)
        {
            FrmKategoriler fr=new FrmKategoriler();
            fr.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FrmMusteri fr2=new FrmMusteri();
            fr2.Show();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SatisVT;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // ürünlerin durum seviyesi
            SqlCommand komut = new SqlCommand("Execute TEST4", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable  dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;
            //Grafiğe veri çekme
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select KATEGORIAD,COUNT(*) FROM TBLKATEGORI INNER JOIN TBLURUNLER ON TBLKATEGORI.KATEGORIID=TBLURUNLER.KATEGORI GROUP BY KATEGORIAD", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();
            //Grafiğe veri çekme2
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select MUSTERISEHIR, COUNT(*) FROM TBLMUSTERI GROUP BY MUSTERISEHIR", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                chart2.Series["Sehirler"].Points.AddXY(dr3[0], dr3[1]);
            }
            baglanti.Close();
        }
    }
}
