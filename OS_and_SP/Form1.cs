using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OS.SP.Lab1
{
    public partial class Form1 : Form
    {
        //private Encoding _encoding { get; set; } = Encoding.Unicode;
        private ASCIIEncoding _ascii = new ASCIIEncoding();

        public Form1()
        {
            InitializeComponent();
            OpenFile.InitialDirectory = Directory.GetCurrentDirectory();
            SaveFile.InitialDirectory = Directory.GetCurrentDirectory();
            EncodingSelect.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (OpenFile.FileName != "OpenFile")
                {
                    var bytes = File.ReadAllBytes(OpenFile.FileName);
                    TextBox.Text = EncodingSelect.Text == "Unicode" ? Encoding.Unicode.GetString(bytes) : _ascii.GetString(bytes);
                }
            }
            catch
            {
                MessageBox.Show("Try again please!");
            }
        }

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile.ShowDialog();
                var bytes = File.ReadAllBytes(OpenFile.FileName);
                TextBox.Text = EncodingSelect.Text == "Unicode" ? Encoding.Unicode.GetString(bytes) : _ascii.GetString(bytes);
            }
            catch
            {
                MessageBox.Show("Try again please!");
            }
        }

        private void SaveFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFile.ShowDialog();
                var filename = SaveFile.FileName;
                var bytes = new byte[] { };

                if (EncodingSelect.Text == "Unicode")
                {
                    bytes = Encoding.Unicode.GetBytes(TextBox.Text);
                }
                else
                {
                    bytes = _ascii.GetBytes(TextBox.Text);
                }

                File.WriteAllBytes(filename, bytes);
            }
            catch
            {
                MessageBox.Show("Try again please!");
            }
        }
    }
}