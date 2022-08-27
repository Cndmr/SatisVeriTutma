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
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=SatisVT;Integrated Security=True");
        private void BtnListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut= new SqlCommand("select * from TBLKATEGORI",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt=new DataTable();
            da.Fill(dt);
            DataGridView1.DataSource = dt;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBLKATEGORI(KATEGORIAD) VALUES (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", TxtKategoriAd.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close  ();
            MessageBox.Show("kategori Ekleme işlemi gerçekleşti");

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtKategoriId.Text = DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtKategoriAd.Text = DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete from TBLKATEGORI where KATEGORIID = @p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", TxtKategoriId.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kategori Silme işlemi gerçekleşti");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4=new SqlCommand("update TBLKATEGORI set KATEGORIAD = @p1 where KATEGORIID=@P2", baglanti);
            komut4.Parameters.AddWithValue("@p1", TxtKategoriAd.Text);
            komut4.Parameters.AddWithValue("@p2", TxtKategoriId.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kategori Güncelleme işlemi gerçekleşti");
        }

        private void FrmKategoriler_Load(object sender, EventArgs e)
        {

        }
    }
}
//Data Source=.\SQLEXPRESS;Initial Catalog=SatisVT;Integrated Security=True