using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HavaDurumuApisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "İstanbul,TR";
            lblTarih.Text = DateTime.Now.ToShortDateString();
            string api = "3cfb88a0a3c2dcf2b3be5b1177e86b44";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Konya&mode=xml&lang=tr&units=metric&appid=" +api;
            XDocument hava = XDocument.Load(connection);
            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            var ruzgar = hava.Descendants("speed").ElementAt(0).Attribute("value").Value;
            var nem = hava.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;
            lblSicaklik.Text = sicaklik.ToString();
            lblRuz.Text = ruzgar +" m/s";
            lblNem.Text = nem + " %";
            lblDurum.Text = durum;
            lblHissedilen.Text = sicaklik.ToString();
            durum = "bulutlu";

            if (durum=="açık")
            {
                pictureBox1.ImageLocation = @"C:\Users\tugba\Downloads\EnglishWords\sun_1_preview.jpg";
            }
            if (durum == "bulutlu")
            {
                pictureBox1.ImageLocation = @"C:\Users\tugba\Downloads\EnglishWords\bulutlu.png";
            }
        }
    }
}


