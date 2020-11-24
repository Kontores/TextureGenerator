using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TXGen.Service;
using System.IO;

namespace TXGen.GUI
{
    public partial class Form1 : Form
    {
        private Bitmap _bitmap;
        public Form1()
        {
            InitializeComponent();
            _bitmap = new Bitmap("D:\\Work\\source.bmp");
            pictureBox1.Image = _bitmap;
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            _bitmap = Generator.CreateNoiseMap(1024, 1024, Color.White, Color.Black, 1,  0.5);
            pictureBox1.Image = _bitmap;
        }

        private void buttonIncrease_Click(object sender, EventArgs e)
        {
            if (_bitmap == null)
            {
                return;
            }
            _bitmap = Generator.IncreaseMap(_bitmap);
            pictureBox1.Image = _bitmap;
        }
    }
}
