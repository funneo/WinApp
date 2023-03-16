using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Models;
using Data.Repositories;

namespace WinApp.DanhMuc
{
    public partial class DaiLyUI : BaseComponent.UIBase
    {
        IDaiLyRepository _daiLyRepository;
        int id = 0;
        public DaiLyUI()
        {
            InitializeComponent();
            txtTen.Tag = nameof(Data.Models.DaiLy.TenDaiLy);
            txtMa.Tag = nameof(Data.Models.DaiLy.MaDaiLy);
            _daiLyRepository = (IDaiLyRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IDaiLyRepository));
        }

        protected override void UIBase_Load(object sender, EventArgs e)
        {
            base.UIBase_Load(sender, e);
            if (flagEdit)
            {
                var daiLy = entityData as Data.Models.DaiLy;
                id = daiLy.Id;
            }
        }

        protected override int Add()
        {
           Data.Models.DaiLy daiLy = new Data.Models.DaiLy();
            daiLy.MaDaiLy = txtMa.Text;
            daiLy.TenDaiLy = txtTen.Text;
            daiLy.Status = true;
            var result = _daiLyRepository.Add(daiLy);
            return 1;
        }

        protected override int Edit()
        {
            Data.Models.DaiLy daiLy = new Data.Models.DaiLy();
            daiLy.MaDaiLy = txtMa.Text;
            daiLy.TenDaiLy = txtTen.Text;
            daiLy.Id = id;
            daiLy.Status = true;
            var result = _daiLyRepository.Update(daiLy);
            return 1;
        }

    }
}
