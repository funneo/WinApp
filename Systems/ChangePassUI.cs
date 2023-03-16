using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data.Repositories;
using Data.ViewModels.Systems;

namespace Systems
{
    public partial class ChangePassUI : BaseComponent.baseForm
    {
        IUserRepository _userRepository;
        public ChangePassUI()
        {
            InitializeComponent();
            btnSave.Enabled = false;
            _userRepository = (IUserRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IUserRepository));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var model = new ChangedPasswordViewModel();
            model.UserName = BaseComponent.Permission.UserName;
            model.CurrentPassword = txtPassCurent.Text.Trim();
            model.Password = txtPassNew.Text.Trim();
            model.ConfirmPassword = txtPassNew2.Text.Trim();
            var i=  _userRepository.ChangedPass(model);
            if(i!=null && i == 1)
            {
                BaseComponent.MessageEx.Show(Common.MessageContstants.UPDATE_OK,Common.MessageContstants.TITLE,MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                BaseComponent.MessageEx.Show(Common.DeltaError.Message, Common.DeltaError.Code,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtPassNew2_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPassNew2.Text == txtPassNew.Text)
            {
                btnSave.Enabled = true;
            }
            else btnSave.Enabled = false;
        }
    }
}
