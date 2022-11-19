using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XMLDOVIZOFISI
{
    public partial class FrmDoviz : Form
    {
        public FrmDoviz()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lbldolaralis.Text = dolaralis;
            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbldolarsatis.Text = dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbleuroalis.Text = euroalis;
            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleurosatis.Text = eurosatis;

            string audalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='AUD']/BanknoteBuying").InnerXml;
            lblaudalis.Text = audalis;
            string audsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='AUD']/BanknoteSelling").InnerXml;
            lblaudsatis.Text = audsatis;

            string gbpalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            lblgbpalis.Text = gbpalis;
            string gbpsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            lblgbpsatis.Text = gbpsatis;

            string chfalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteBuying").InnerXml;
            lblchfalis.Text = chfalis;
            string chfsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='CHF']/BanknoteSelling").InnerXml;
            lblchfsatis.Text = chfsatis;

            string jpyalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='JPY']/BanknoteBuying").InnerXml;
            lbljpyalis.Text = jpyalis;
            string jpysatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='JPY']/BanknoteSelling").InnerXml;
            lbljpysatis.Text = jpysatis;

            string kwdalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='KWD']/BanknoteBuying").InnerXml;
            lblkwdalis.Text = kwdalis;
            string kwdsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='KWD']/BanknoteSelling").InnerXml;
            lblkwdsatis.Text = kwdsatis;



        }

        private void btndolaral_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleuroalis.Text;
        }

        private void btndolarsatis_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolarsatis.Text;
        }

        private void btnaudal_Click(object sender, EventArgs e)
        {
            txtkur.Text = lblaudalis.Text;
        }

        private void btnaudsat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lblaudsatis.Text;
        }

        private void btneuroalis_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleuroalis.Text;
        }

        private void btneurosatis_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleurosatis.Text;
        }

        private void btngbpal_Click(object sender, EventArgs e)
        {
            txtkur.Text = lblgbpalis.Text;
        }

        private void btngbpsat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lblgbpsatis.Text;
        }

        private void btnchfal_Click(object sender, EventArgs e)
        {
            txtkur.Text = lblchfalis.Text;
        }

        private void btnchfsat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lblchfsatis.Text;
        }

        private void btnjpyal_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbljpyalis.Text;
        }

        private void btnjpysat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbljpysatis.Text;
        }

        private void btnkwdal_Click(object sender, EventArgs e)
        {
            txtkur.Text = lblkwdalis.Text;
        }

        private void btnkwdsat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lblkwdsatis.Text;
        }

        
        private void btnsatisyap_Click(object sender, EventArgs e)
        {
            try
            {
                double kur, miktar, tutar;
                kur = Convert.ToDouble(txtkur.Text);
                miktar = Convert.ToDouble(txtmiktar.Text);
                tutar = kur * miktar;
                txttutar.Text = tutar.ToString();
                txtkalan.Text = "";
            }
            catch
            {
                MessageBox.Show("İlgili alanları doldurunuz");
            }
        }

        private void txtkur_TextChanged(object sender, EventArgs e)
        {
            txtkur.Text = txtkur.Text.Replace(".",",");
        }

        private void btnsatisyap2_Click(object sender, EventArgs e)
        {
            try
            {
                double kur = Convert.ToDouble(txtkur.Text);
                int miktar = Convert.ToInt32(txtmiktar.Text);
                int tutar = Convert.ToInt32(miktar / kur);
                txttutar.Text = tutar.ToString();
                double kalan;
                kalan = miktar % kur;
                txtkalan.Text = kalan.ToString();
            }
            catch
            {
                MessageBox.Show("İlgili alanları doldurunuz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void temizle()
        {
            txtkur.Text = "";
            txtmiktar.Text = "";
            txttutar.Text = "";
            txtkur.Focus();

        }
        void renklendir()
        {
            txtkur.BackColor = Color.DarkGray;
            txtmiktar.BackColor = Color.Tan;
            txttutar.BackColor = Color.Gray;
        }

        private void btnrenk_Click(object sender, EventArgs e)
        {
            renklendir();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void tCMBKURLARSAYFASIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/today.xml");
        }

        private void hAKKIMIZDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AHMET ALTUNTAŞ -- C# DEVELOPER", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
