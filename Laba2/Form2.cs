using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            textBox1.Text = "2";
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Int32 count;
             OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
            openFileDialog1.InitialDirectory = @"C:\Users\diego\Desktop\easy\";
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Filter = "Image files(*.jpeg;*.jpg;*.bmp;*.png)| *.jpeg;*.jpg;*.bmp;*.png";


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    count = Convert.ToInt32(textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Размер маски должно быть положителное число", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                new Form1(openFileDialog1.FileName, count).Show();
            }
        }
    }
}
