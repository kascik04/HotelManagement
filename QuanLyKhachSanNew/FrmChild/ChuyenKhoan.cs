using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Skins.SolidColorHelper;

namespace QuanLyKhachSanNew.FrmChild
{
    public partial class ChuyenKhoan : Form
    {
        public ChuyenKhoan()
        {
            InitializeComponent();
            pictureBoxQR.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBoxQR_Click(object sender, EventArgs e)
        {
            
        }
    }
}
