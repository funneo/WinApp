using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systems
{
    class UserView
    {
        public UserView(BaseComponent.baseMain frm, string funcId)
        {
            foreach (System.Windows.Forms.Form fChild in frm.MdiChildren)
            {
                if (fChild.GetType() == typeof(UserList))
                {
                    fChild.Activate();
                    return;
                }
            }
            UserList f = new UserList();
            f.Text = "Danh sách tài khoản";
            f.funcId = funcId;
            f.MdiParent = frm;
            f.NameClass = GetType().ToString();
            f.Show();
        }
    }

    class EmployeeView
    {
        public EmployeeView(BaseComponent.baseMain frm, string funcId)
        {
            foreach (System.Windows.Forms.Form fChild in frm.MdiChildren)
            {
                if (fChild.GetType() == typeof(EmployeeList))
                {
                    fChild.Activate();
                    return;
                }
            }
            EmployeeList f = new EmployeeList();
            f.Text = "Danh sách nhân viên";
            f.funcId = funcId;
            f.MdiParent = frm;
            f.NameClass = GetType().ToString();
            f.Show();
        }
    }

    class RoleView
    {
        public RoleView(BaseComponent.baseMain frm, string funcId)
        {
            foreach (System.Windows.Forms.Form fChild in frm.MdiChildren)
            {
                if (fChild.GetType() == typeof(RoleList))
                {
                    fChild.Activate();
                    return;
                }
            }
            RoleList f = new RoleList();
            f.Text = "Nhóm quyền";
            f.funcId = funcId;
            f.MdiParent = frm;
            f.NameClass = GetType().ToString();
            f.Show();
        }
    }

    class PermissionView
    {
        public PermissionView(BaseComponent.baseMain frm, string funcId)
        {
            foreach (System.Windows.Forms.Form fChild in frm.MdiChildren)
            {
                if (fChild.GetType() == typeof(PermissionUI))
                {
                    fChild.Activate();
                    return;
                }
            }
            PermissionUI f = new PermissionUI();
            f.Text = "Phân quyền";
            f.funcId = funcId;
            f.MdiParent = frm;            
            f.Show();
        }
    }

    class ChangedPass
    {
        public ChangedPass(BaseComponent.baseMain frm, string funcId)
        {
            foreach (System.Windows.Forms.Form fChild in frm.MdiChildren)
            {
                if (fChild.GetType() == typeof(ChangePassUI))
                {
                    fChild.Activate();
                    return;
                }
            }
            ChangePassUI f = new ChangePassUI();
            f.Text = "ĐỔI MẬT KHẨU";
            f.funcId = funcId;
            //f.MdiParent = frm;
            f.ShowDialog();
        }
    }

    class CustomerView
    {
        public CustomerView(BaseComponent.baseMain frm, string funcId)
        {
            foreach (System.Windows.Forms.Form fChild in frm.MdiChildren)
            {
                if (fChild.GetType() == typeof(CustomerList))
                {
                    fChild.Activate();
                    return;
                }
            }
            CustomerList f = new CustomerList();
            f.Text = "Danh sách khách hàng";
            f.funcId = funcId;
            f.MdiParent = frm;
            f.NameClass = GetType().ToString();
            f.Show();
        }
    }
}
