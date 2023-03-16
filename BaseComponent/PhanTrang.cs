using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseComponent
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(PhanTrang), "PhanTrang.bmp")]
    public partial class PhanTrang : UserControl
    {
        public delegate int LoadData(int soBanGhiMotTrang, int trang);
        public LoadData _LoadData;       

        private bool IsLoadData { get; set; }

        private int _TongSoBanGhi;

        public int TongSoBanGhi
        {
            get;set;
        }

        private void RefreshControl()
        {           
            btnLui.Enabled = false;
            btnDauTien.Enabled = false;
            btnCuoiCung.Enabled = TongSoTrang == 1 ? false : true;
            btnTien.Enabled = TongSoTrang == 1 ? false : true;
        }

        public List<string> ListSoBanGhiMotTrang { get; set; }
        public int? SoBanGhiMotTrang
        {
            get;set;
        }

        private int _TrangHienTai;

        public int TrangHienTai
        {
            get;set;
        }

        private int _TongSoTrang;

        public int TongSoTrang
        {
            get { return _TongSoTrang; }
            //set { _TongSoTrang = value; }
        }

        public PhanTrang()
        {
           
        }

        private void PhanTrang_Load(object sender, EventArgs e)
        {
            return;
        }

        #region MyRegion
        private void RunLoadData(int soBanGhiMotTrang, int trang)
        {
            return;

        }

        private int TinhTongSoTrang(int tongSoBanGhi)
        {
            if (TongSoBanGhi <= 0)
            {
                return 1;
            }
            else
            {
                return tongSoBanGhi / (int)SoBanGhiMotTrang + (tongSoBanGhi % (int)SoBanGhiMotTrang == 0 ? 0 : 1);
            }
        }

        private void LoadCmb(int trangHienTai)
        {
            return;
        }

        private void ChuyenTrang(bool isNextPage)
        {
            if (isNextPage)
            {
                if (TrangHienTai < TongSoTrang)
                {
                    TrangHienTai += 1;
                }
                else
                {                   
                    //RunLoadData((int)SoBanGhiMotTrang, TrangHienTai);
                }               
            }
            else
            {
                if (TrangHienTai != 1)
                {
                    TrangHienTai -= 1;
                }
                else
                {                   
                    //RunLoadData((int)SoBanGhiMotTrang, TrangHienTai);
                }              
            }
            if (TrangHienTai == TongSoTrang)
            {
                btnTien.Enabled = false;
                btnCuoiCung.Enabled = false;
               
            }
            else
            {
                btnTien.Enabled = true;
                btnCuoiCung.Enabled = true;
              
            }
            if (TrangHienTai == 1)
            {
                btnLui.Enabled = false;
                btnDauTien.Enabled = false;
            }
            else
            {
                btnLui.Enabled = true;
                btnDauTien.Enabled = true;
            }
        }
        #endregion

        private void cmbSoBanGhiMotTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(cmbSoBanGhiMotTrang.SelectedItem.ToString(), out int n))
                SoBanGhiMotTrang = n;
            else
                SoBanGhiMotTrang = 1000000;           
            LoadCmb(1);
            RunLoadData((int)SoBanGhiMotTrang, TrangHienTai);
        }

        private void btnDauTien_Click(object sender, EventArgs e)
        {
            btnLui.Enabled = false;
            btnDauTien.Enabled = false;
            if (TrangHienTai != 1)
            {
                TrangHienTai = 1;
            }
            else
            {
                RunLoadData((int)SoBanGhiMotTrang, TrangHienTai);
            }
        }

        private void btnLui_Click(object sender, EventArgs e)
        {
            ChuyenTrang(false);
        }

        private void btnTien_Click(object sender, EventArgs e)
        {
            ChuyenTrang(true);
        }

        private void btnCuoiCung_Click(object sender, EventArgs e)
        {
            btnTien.Enabled = false;
            btnCuoiCung.Enabled = false;
            if (TrangHienTai != TongSoTrang)
            {
                TrangHienTai = TongSoTrang;

            }
            else
            {
                RunLoadData((int)SoBanGhiMotTrang, TrangHienTai);
            }
          
        }

        private void cmbTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoadData)
            {
                _TrangHienTai = int.Parse(cmbTrang.SelectedItem.ToString());
                RunLoadData((int)SoBanGhiMotTrang, TrangHienTai);
            }
        }
    }
}
