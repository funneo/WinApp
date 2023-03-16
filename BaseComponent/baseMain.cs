using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Reflection;
using Data.Models.Systems;
using System.Linq;
using Data.Repositories;
using DevExpress.XtraNavBar;
using BaseComponent.Core;

namespace BaseComponent
{
    public partial class baseMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        IMenuBarRepository _menuBarRepository;
        ITaskPaneRepository _taskPaneRepository;
        IFunctionRepository _functionRepository;

        public baseMain()
        {
            _menuBarRepository = (IMenuBarRepository)AppConfig.ServiceProvider.GetService(typeof(IMenuBarRepository));
            _functionRepository = (IFunctionRepository)AppConfig.ServiceProvider.GetService(typeof(IFunctionRepository));
            _taskPaneRepository = (ITaskPaneRepository)AppConfig.ServiceProvider.GetService(typeof(ITaskPaneRepository));
            InitializeComponent();          
        }

        private void InitModule(string nameSpace, string nameClass,string funcId)
        {
            //if (!Permission.HasPermission(funcId, PermissionType.PermissionView))
            //{
            //    MessageEx.Show("Bạn không có quyền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            Object[] args = new object[2];
            args[0] = this;
            args[1] = funcId;
            try
            {
                Activator.CreateInstance(nameSpace,nameClass,
                    true,
                    BindingFlags.Instance | BindingFlags.Public,
                    null,
                    args,
                    null,                    
                    null);
            }
            catch  (Exception ex)
            {
                //clsSqlExcept err = new Base.clsSqlExcept(ex);
                MessageEx.Show(ex.Message);
            }
        }

        #region Menu
        private void CreateMenu()
        {
            ribbon.Pages.Clear();           
            var listMenuBars = _menuBarRepository.GetByUserName(Permission.UserName);
            if (listMenuBars != null)
            {
                var listParent = listMenuBars.Where(x => x.ParentId == null);
                foreach (var rPage in listParent)
                {
                    DevExpress.XtraBars.Ribbon.RibbonPage rbbPage = new DevExpress.XtraBars.Ribbon.RibbonPage
                    {
                        Text = rPage.AltText
                    };
                    var listGroup = listMenuBars.Where(x => x.ParentId == rPage.Id);
                    foreach (var rGroup in listGroup)
                    {
                        DevExpress.XtraBars.Ribbon.RibbonPageGroup rbbGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup
                        {
                            ShowCaptionButton = false,
                            Text = rGroup.AltText
                        };
                        var rItem = listMenuBars.Where(x => x.ParentId == rGroup.Id);
                        int intType = rGroup.TypeShow ?? 0;
                        BarSubItem _barSubItem = new BarSubItem
                        {
                            Caption = rbbGroup.Text,
                            RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText,
                            PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
                        };
                        if (rItem != null)
                        {
                            foreach (var ri in rItem)
                            {
                                int _intType = ri.TypeShow ?? 0;
                                DevExpress.XtraBars.BarButtonItem b = new BarButtonItem
                                {
                                    RibbonStyle = _intType == 0 ? DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large : DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText,
                                    PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph,
                                    Caption = ri.AltText,
                                    Tag = ri.FunctionId
                                };
                                b.ItemClick += new ItemClickEventHandler(ButtonItem_ItemClick);
                                b.LargeWidth = b.Caption.Length >= 15 ? b.Caption.Length * 5 : (b.Caption.Length >= 10 ? b.Caption.Length * 7 : b.Caption.Length * 8);
                                if (ri.Image != null && ri.Image.Length > 0)
                                {
                                    try
                                    {
                                        var filePath = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, $"Images\\{ri.Image}");
                                        b.Glyph = System.Drawing.Image.FromFile(filePath);
                                    }
                                    catch { }
                                }
                                if (intType == 1)
                                {
                                    _barSubItem.AddItem(b);
                                    ribbon.Items.Add(b);
                                }
                                else
                                    rbbGroup.ItemLinks.Add(b);
                            }
                        }
                        else
                        {
                            DevExpress.XtraBars.BarButtonItem b = new BarButtonItem
                            {
                                RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large,
                                Caption = rGroup.AltText,
                                Tag = rGroup.FunctionId
                            };
                            b.ItemClick += new ItemClickEventHandler(ButtonItem_ItemClick);
                            if (intType == 1)
                            {
                                _barSubItem.AddItem(b);
                                ribbon.Items.Add(b);
                            }
                            else
                                rbbGroup.ItemLinks.Add(b);
                        }
                        if (intType == 1)
                        {
                            rbbGroup.ItemLinks.Add(_barSubItem);
                            rbbGroup.Text = string.Empty;
                        }
                        rbbPage.Groups.Add(rbbGroup);
                    }
                    ribbon.Pages.Add(rbbPage);
                }
            }
        }
        private void ButtonItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            var funtionId = e.Item.Tag.ToString();   
            var funtion = _functionRepository.GetById(funtionId);
            if (funtion == null)
            {
                MessageEx.Show(MessageContstants.MSG_ERR, MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (funtion.IsMenu)
            {
                InitModule(funtion.NameClass.Substring(0,funtion.NameClass.LastIndexOf(".")), funtion.NameClass,funtion.Id);
            }
            else
            {
                switch (funtion.NameClass.ToLower())
                {
                    case "exit":
                        if (MessageEx.Show(MessageContstants.EXIT_APP, MessageContstants.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                          if(ApiClient.Apibase.Logout())
                            this.Close();
                        }
                        break;
                    case "login":
                        foreach (Form frmChild in this.MdiChildren)
                        {
                            frmChild.Dispose();
                        }                       
                        bool hasLoginFrom = false;
                        foreach (Form f in this.OwnedForms)
                        {
                            if (f.GetType() == typeof(frmLogin))
                            {
                                hasLoginFrom = true;
                                f.ShowDialog();
                                if (((frmLogin)f).conti)
                                {
                                    CreateMenu();
                                    CreateTaskPanel();                                   
                                }
                                else Application.Exit();
                                break;
                            }
                        }
                        if (!hasLoginFrom)
                        {
                            frmLogin login = new frmLogin();
                            this.AddOwnedForm(login);
                            login.ShowDialog();
                            if (login.conti)
                            {
                                CreateMenu();
                                CreateTaskPanel();
                            }
                            else Application.Exit();
                        }
                        break;                   
                }
            }
        }
        #endregion

        #region TaskPanel
        private void CreateTaskPanel()
        {
            navBarControl1.Groups.Clear();                      
            var listTaskPanes = _taskPaneRepository.GetByUserName(Permission.UserName);            
            if (listTaskPanes != null)
            {             
                navBarControl1.Width = 200;
                var listParent = listTaskPanes.Where(x => x.ParentId == null);            
                foreach (var bGroup in listParent)
                {
                    DevExpress.XtraNavBar.NavBarGroup barGroup = new DevExpress.XtraNavBar.NavBarGroup
                    {
                        Caption = bGroup.AltText,
                        Tag = bGroup.FunctionId
                    };
                    barGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    barGroup.Appearance.ForeColor = System.Drawing.Color.MidnightBlue;
                    barGroup.Appearance.Options.UseFont = true;
                    barGroup.Appearance.Options.UseForeColor = true;
                    int intStyleGroup = bGroup.TypeShow==null?0: (int)bGroup.TypeShow;
                    switch (intStyleGroup)
                    {
                        case 1:
                            barGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
                            break;
                        case 2:
                            barGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
                            break;
                        case 3:
                            barGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
                            break;
                        case 4:
                            barGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsList;
                            break;
                        case 5:
                            barGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
                            break;
                        default:
                            barGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
                            break;
                    }                   
                    var listItem = listTaskPanes.Where(x => x.ParentId == bGroup.Id);
                    if (listItem != null)
                    {
                        foreach (var ri in listItem)
                        {                          
                            DevExpress.XtraNavBar.NavBarItem item = new DevExpress.XtraNavBar.NavBarItem
                            {
                                Caption = ri.AltText,                                
                                Tag = ri.FunctionId
                            };
                            item.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(LinkClicked);
                            if (ri.Image!=null && ri.Image.Length > 0)
                            {
                                try
                                {
                                    var filePath = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, $"Images\\{ri.Image}");
                                    item.SmallImage = Image.FromFile(filePath);
                                    item.LargeImage = Image.FromFile(filePath);
                                }
                                catch { }
                            }
                            barGroup.ItemLinks.Add(item);
                        }
                    }
                    if (intStyleGroup>0)
                        barGroup.Expanded = true;                  
                    navBarControl1.Groups.Add(barGroup);
                    if (bGroup.IsDef!=null && (bool)bGroup.IsDef)
                        navBarControl1.ActiveGroup = barGroup;
                }              
            }            
            else
            {
                navBarControl1.Width = 0;
            }
            //TaskPane           
            this.navBarControl1.MenuManager = this.ribbon;         
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 164;
            this.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.navBarControl1.Size = new System.Drawing.Size(234, 687);          
            this.navBarControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;          }
        protected void LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DevExpress.XtraNavBar.NavBarItem item = sender as DevExpress.XtraNavBar.NavBarItem;
            var funtionId = item.Tag.ToString();           
            var funtion = _functionRepository.GetById(funtionId);
            if (funtion == null)
            {
                MessageEx.Show(MessageContstants.MSG_ERR, MessageContstants.TITLE,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }    
               
            if (funtion.IsMenu)
            {
                InitModule(funtion.NameClass.Substring(0, funtion.NameClass.LastIndexOf(".")), funtion.NameClass, funtion.Id);
            }           
            else
            {
                switch (funtion.NameClass.ToLower())
                {
                    case "exit":
                        //if (MessageEx.Show(Properties.Resources.ExitApplicationConfirmText, Properties.Resources.ConfirmCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        this.Close();
                        //}
                        break;
                    case "login":
                        foreach (Form frmChild in this.MdiChildren)
                        {
                            frmChild.Dispose();
                        }
                        bool hasLoginFrom = false;
                        foreach (Form f in this.OwnedForms)
                        {
                            if (f.GetType() == typeof(frmLogin))
                            {
                                hasLoginFrom = true;
                                f.ShowDialog();
                                if (((frmLogin)f).conti)
                                {
                                    CreateMenu();
                                    CreateTaskPanel();
                                }
                                else Application.Exit();
                                break;
                            }
                        }
                        if (!hasLoginFrom)
                        {
                            frmLogin login = new frmLogin();
                            this.AddOwnedForm(login);
                            login.ShowDialog();
                            if (login.conti)
                            {
                                CreateMenu();
                                CreateTaskPanel();
                            }
                            else Application.Exit();
                        }
                        break;
                    case "langv":
                        //Properties.Settings.Default.Language = "vi-VN";
                        //Properties.Settings.Default.Save();
                        //MessageEx.Show(Properties.Resources.ReLoginToChangeEffect, Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case "lange":
                        //Properties.Settings.Default.Language = "en-US";
                        //Properties.Settings.Default.Save();
                        //MessageEx.Show("Chức năng chưa được kích hoạt!", Properties.Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }
        }
        #endregion

        private void FrmBaseMain_Load(object sender, EventArgs e)
        {           
                CreateMenu();           
                CreateTaskPanel();            
        }

        private void FrmBaseMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //BusinessLogic.CFCCDatabaseFacade.GetUserslogBL().Update(Permission.UserName, BusinessLogic.Data.GetCurrentdate());
            }
            catch
            {
                Application.Exit();
            }
            Application.Exit();
        }

        private void BarStaticItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start(barStaticItem2.Caption);
        }
      
    }
}