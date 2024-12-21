using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Kitaplik_Test
{
    internal class KitapVT
    {
        OleDbConnection bgl = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Koray\Desktop\Kitaplik2.mdb");

        public List<Kitap> Liste()
        {
            List<Kitap> ktp = new List<Kitap>();
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("Select * From Kitaplar", bgl);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Kitap k = new Kitap();
                k.ID = Convert.ToInt16(dr[0].ToString());
                k.Ad = dr[1].ToString();
                k.Yazar = dr[2].ToString();

                ktp.Add(k);
            }
            bgl.Close();
            return ktp;
        }

        public void KitapEkle(Kitap kt)
        {
            bgl.Open();
            OleDbCommand cmd = new OleDbCommand("Insert Into Kitaplar (KitapAd, Yazar) Values (@p1, @p2)", bgl);
            cmd.Parameters.AddWithValue("@p1", kt.Ad);
            cmd.Parameters.AddWithValue("@p2", kt.Yazar);
            cmd.ExecuteNonQuery();
            bgl.Close();
        }
    }
}
