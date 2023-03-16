using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseComponent.Core;
using Data.Models;
using Data.Repositories;

namespace Systems
{
    public partial class RoleUI : BaseComponent.UIBase
    {
        IRoleRepository _roleRepository;
        string _roleId = "";
        public RoleUI()
        {
            InitializeComponent();
            txtName.Tag = nameof(Data.Models.Role.Name);
            txtMoTa.Tag = nameof(Data.Models.Role.Description);
            _roleRepository = (IRoleRepository)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IRoleRepository));
        }

        protected override void UIBase_Load(object sender, EventArgs e)
        {
            base.UIBase_Load(sender, e);
            if (flagEdit)
            {
                var role = entityData as Data.Models.Role;
                _roleId = role.Id.ToString();
            }
        }

        protected override int Add()
        {
            Data.Models.Role role = new Data.Models.Role();
            role.Name = txtName.Text;
            role.Description = txtMoTa.Text;
            role.Id = new Guid();
            var result = _roleRepository.Add(role);
            if (result!=null)
            {
                BaseComponent.MessageEx.Show(Common.MessageContstants.INSERT_OK, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                flagExit = true;
                return 1;
            }
            else
            {
                BaseComponent.MessageEx.Show(Common.MessageContstants.INSERT_ERR, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                flagExit = false;
                return 0;
            }              
           
        }

        protected override int Edit()
        {
            Data.Models.Role role = new Data.Models.Role();
            role.Name = txtName.Text;
            role.Description = txtMoTa.Text;
            role.Id = new Guid(_roleId);
            var result = _roleRepository.Update(role);
            if (result!=null)
            {
                BaseComponent.MessageEx.Show(Common.MessageContstants.UPDATE_OK, null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                flagExit = true;
                return 1;
            }
            else
            {
                BaseComponent.MessageEx.Show(Common.MessageContstants.UPDATE_ERR, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                flagExit = true;
                return 0;
            }
        }

    }
}
