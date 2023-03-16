namespace BaseComponent
{
    partial class baseMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(baseMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.barhostName = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticIP = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticUser = new DevExpress.XtraBars.BarStaticItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            resources.ApplyResources(this.ribbon, "ribbon");
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barStaticItem3,
            this.barStaticItem4,
            this.barhostName,
            this.barStaticIP,
            this.barStaticUser});
            this.ribbon.MaxItemId = 15;
            this.ribbon.Name = "ribbon";
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barStaticItem1
            // 
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barStaticItem2
            // 
            resources.ApplyResources(this.barStaticItem2, "barStaticItem2");
            this.barStaticItem2.Id = 3;
            this.barStaticItem2.ItemAppearance.Disabled.Font = ((System.Drawing.Font)(resources.GetObject("barStaticItem2.ItemAppearance.Disabled.Font")));
            this.barStaticItem2.ItemAppearance.Disabled.ForeColor = System.Drawing.Color.Blue;
            this.barStaticItem2.ItemAppearance.Disabled.Options.UseFont = true;
            this.barStaticItem2.ItemAppearance.Disabled.Options.UseForeColor = true;
            this.barStaticItem2.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("barStaticItem2.ItemAppearance.Normal.Font")));
            this.barStaticItem2.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.barStaticItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem2.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BarStaticItem2_ItemClick);
            // 
            // barStaticItem3
            // 
            resources.ApplyResources(this.barStaticItem3, "barStaticItem3");
            this.barStaticItem3.Id = 4;
            this.barStaticItem3.Name = "barStaticItem3";
            // 
            // barStaticItem4
            // 
            resources.ApplyResources(this.barStaticItem4, "barStaticItem4");
            this.barStaticItem4.Id = 5;
            this.barStaticItem4.Name = "barStaticItem4";
            // 
            // barhostName
            // 
            this.barhostName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.barhostName, "barhostName");
            this.barhostName.Id = 6;
            this.barhostName.Name = "barhostName";
            // 
            // barStaticIP
            // 
            this.barStaticIP.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.barStaticIP, "barStaticIP");
            this.barStaticIP.Id = 7;
            this.barStaticIP.Name = "barStaticIP";
            // 
            // barStaticUser
            // 
            this.barStaticUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.barStaticUser, "barStaticUser");
            this.barStaticUser.Id = 8;
            this.barStaticUser.Name = "barStaticUser";
            // 
            // repositoryItemCheckEdit1
            // 
            resources.ApplyResources(this.repositoryItemCheckEdit1, "repositoryItemCheckEdit1");
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem3);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem4, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1, true);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem2);
            this.ribbonStatusBar.ItemLinks.Add(this.barhostName);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticIP);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticUser);
            resources.ApplyResources(this.ribbonStatusBar, "ribbonStatusBar");
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // navBarControl1
            // 
            this.navBarControl1.Appearance.Background.BackColor = System.Drawing.Color.Blue;
            this.navBarControl1.Appearance.Background.Options.UseBackColor = true;
            resources.ApplyResources(this.navBarControl1, "navBarControl1");
            this.navBarControl1.ForeColor = System.Drawing.Color.Black;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            // 
            // baseMain
            // 
            this.Appearance.Image = global::BaseComponent.Properties.Resources.businesswoman_man;
            this.Appearance.Options.UseImage = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Name = "baseMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBaseMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmBaseMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.BarStaticItem barhostName;
        private DevExpress.XtraBars.BarStaticItem barStaticIP;
        private DevExpress.XtraBars.BarStaticItem barStaticUser;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
    }
}