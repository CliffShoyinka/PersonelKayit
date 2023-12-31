﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayit
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=MEHMETHAN;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        //Toplam personel sayısı
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            { 
                LblToplamPersonel.Text = dr1[0].ToString();
            }

            baglanti.Close();


            //Evli personel sayisi

            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();

            if (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString();
            }

            baglanti.Close();



            //Bekar Personel Sayisi

            baglanti.Open();

            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                LblBekarPersonel.Text = dr3[0].ToString();
            }

            baglanti.Close();



            //Sehir sayisi

            baglanti.Open();

            SqlCommand komut4 = new SqlCommand("Select Count(distinct(PerSehir)) From Tbl_Personel",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehirSayisi.Text = dr4[0].ToString(); 
            }

            baglanti.Close();
        }
    }
}
