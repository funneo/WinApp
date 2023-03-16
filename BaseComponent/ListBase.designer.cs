namespace BaseComponent
{
    partial class ListBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListBase));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustom = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItemtextSearch = new DevExpress.XtraBars.BarEditItem();
            this.txttextSearch = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnSearch = new DevExpress.XtraBars.BarButtonItem();
            this.btnthamso = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barEdit = new DevExpress.XtraBars.BarButtonItem();
            this.barDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barExport = new DevExpress.XtraBars.BarButtonItem();
            this.Option = new DevExpress.XtraBars.BarButtonItem();
            this.barExit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSeach = new DevExpress.XtraBars.BarButtonItem();
            this.barEvent01 = new DevExpress.XtraBars.BarButtonItem();
            this.barEvent02 = new DevExpress.XtraBars.BarButtonItem();
            this.barEvent03 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ItemComboBoxFilter = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.phanTrang1 = new BaseComponent.PhanTrang();
            this.gridBase = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttextSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemComboBoxFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnRefresh,
            this.btnPrint,
            this.btnExit,
            this.btnCustom,
            this.barAdd,
            this.barEdit,
            this.barDelete,
            this.barRefresh,
            this.barExport,
            this.Option,
            this.barExit,
            this.btnSeach,
            this.barEditItemtextSearch,
            this.btnSearch,
            this.barEvent01,
            this.barEvent02,
            this.barEvent03,
            this.btnthamso});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 41;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.ItemComboBoxFilter,
            this.repositoryItemTextEdit2,
            this.txttextSearch});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEdit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrint, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCustom, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExit, true),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.barEditItemtextSearch, "", false, true, true, 195),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSearch),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnthamso)});
            this.bar2.OptionsBar.UseWholeRow = true;
            resources.ApplyResources(this.bar2, "bar2");
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnAdd.ItemAppearance.Normal.Font")));
            this.btnAdd.ItemAppearance.Normal.Options.UseFont = true;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Id = 1;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnEdit.ItemAppearance.Normal.Font")));
            this.btnEdit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Id = 2;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnDelete.ItemAppearance.Normal.Font")));
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Id = 3;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnRefresh.ItemAppearance.Normal.Font")));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Id = 4;
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnPrint.ItemAppearance.Normal.Font")));
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // btnCustom
            // 
            resources.ApplyResources(this.btnCustom, "btnCustom");
            this.btnCustom.Id = 6;
            this.btnCustom.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnCustom.ItemAppearance.Normal.Font")));
            this.btnCustom.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnCustom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustom_ItemClick);
            // 
            // btnExit
            // 
            resources.ApplyResources(this.btnExit, "btnExit");
            this.btnExit.Id = 5;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnExit.ItemAppearance.Normal.Font")));
            this.btnExit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExit.Name = "btnExit";
            this.btnExit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barEditItemtextSearch
            // 
            this.barEditItemtextSearch.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.barEditItemtextSearch, "barEditItemtextSearch");
            this.barEditItemtextSearch.Edit = this.txttextSearch;
            this.barEditItemtextSearch.Id = 35;
            this.barEditItemtextSearch.Name = "barEditItemtextSearch";
            // 
            // txttextSearch
            // 
            resources.ApplyResources(this.txttextSearch, "txttextSearch");
            this.txttextSearch.Name = "txttextSearch";
            this.txttextSearch.EditValueChanged += new System.EventHandler(this.txttextSearch_EditValueChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnSearch.Id = 36;
            this.btnSearch.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.ImageOptions.Image")));
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSearch_ItemClick);
            // 
            // btnthamso
            // 
            this.btnthamso.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.btnthamso, "btnthamso");
            this.btnthamso.Id = 40;
            this.btnthamso.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnthamso.ImageOptions.Image")));
            this.btnthamso.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("btnthamso.ItemAppearance.Normal.Font")));
            this.btnthamso.ItemAppearance.Normal.Options.UseFont = true;
            this.btnthamso.Name = "btnthamso";
            this.btnthamso.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnthamso_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            resources.ApplyResources(this.barDockControlTop, "barDockControlTop");
            this.barDockControlTop.Manager = this.barManager1;
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            resources.ApplyResources(this.barDockControlBottom, "barDockControlBottom");
            this.barDockControlBottom.Manager = this.barManager1;
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            resources.ApplyResources(this.barDockControlLeft, "barDockControlLeft");
            this.barDockControlLeft.Manager = this.barManager1;
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            resources.ApplyResources(this.barDockControlRight, "barDockControlRight");
            this.barDockControlRight.Manager = this.barManager1;
            // 
            // barAdd
            // 
            resources.ApplyResources(this.barAdd, "barAdd");
            this.barAdd.Id = 21;
            this.barAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barAdd.ImageOptions.Image")));
            this.barAdd.Name = "barAdd";
            this.barAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // barEdit
            // 
            resources.ApplyResources(this.barEdit, "barEdit");
            this.barEdit.Id = 22;
            this.barEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barEdit.ImageOptions.Image")));
            this.barEdit.Name = "barEdit";
            this.barEdit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // barDelete
            // 
            resources.ApplyResources(this.barDelete, "barDelete");
            this.barDelete.Id = 23;
            this.barDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDelete.ImageOptions.Image")));
            this.barDelete.Name = "barDelete";
            this.barDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // barRefresh
            // 
            resources.ApplyResources(this.barRefresh, "barRefresh");
            this.barRefresh.Id = 24;
            this.barRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barRefresh.ImageOptions.Image")));
            this.barRefresh.Name = "barRefresh";
            this.barRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // barExport
            // 
            resources.ApplyResources(this.barExport, "barExport");
            this.barExport.Id = 25;
            this.barExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barExport.ImageOptions.Image")));
            this.barExport.Name = "barExport";
            this.barExport.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // Option
            // 
            resources.ApplyResources(this.Option, "Option");
            this.Option.Id = 26;
            this.Option.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Option.ImageOptions.Image")));
            this.Option.Name = "Option";
            this.Option.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.Option.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustom_ItemClick);
            // 
            // barExit
            // 
            resources.ApplyResources(this.barExit, "barExit");
            this.barExit.Id = 27;
            this.barExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barExit.ImageOptions.Image")));
            this.barExit.Name = "barExit";
            this.barExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // btnSeach
            // 
            this.btnSeach.Id = 32;
            this.btnSeach.Name = "btnSeach";
            // 
            // barEvent01
            // 
            resources.ApplyResources(this.barEvent01, "barEvent01");
            this.barEvent01.Id = 37;
            this.barEvent01.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barEvent01.ImageOptions.Image")));
            this.barEvent01.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("barEvent01.ItemAppearance.Normal.Font")));
            this.barEvent01.ItemAppearance.Normal.Options.UseFont = true;
            this.barEvent01.Name = "barEvent01";
            this.barEvent01.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barEvent02
            // 
            resources.ApplyResources(this.barEvent02, "barEvent02");
            this.barEvent02.Id = 38;
            this.barEvent02.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barEvent02.ImageOptions.Image")));
            this.barEvent02.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("barEvent02.ItemAppearance.Normal.Font")));
            this.barEvent02.ItemAppearance.Normal.Options.UseFont = true;
            this.barEvent02.Name = "barEvent02";
            this.barEvent02.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // barEvent03
            // 
            resources.ApplyResources(this.barEvent03, "barEvent03");
            this.barEvent03.Id = 39;
            this.barEvent03.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barEvent03.ImageOptions.Image")));
            this.barEvent03.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("barEvent03.ItemAppearance.Normal.Font")));
            this.barEvent03.ItemAppearance.Normal.Options.UseFont = true;
            this.barEvent03.Name = "barEvent03";
            this.barEvent03.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // repositoryItemTextEdit1
            // 
            resources.ApplyResources(this.repositoryItemTextEdit1, "repositoryItemTextEdit1");
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // ItemComboBoxFilter
            // 
            resources.ApplyResources(this.ItemComboBoxFilter, "ItemComboBoxFilter");
            this.ItemComboBoxFilter.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("ItemComboBoxFilter.Buttons"))))});
            this.ItemComboBoxFilter.Name = "ItemComboBoxFilter";
            this.ItemComboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.ItemComboBoxFilter_SelectedIndexChanged);
            // 
            // repositoryItemTextEdit2
            // 
            resources.ApplyResources(this.repositoryItemTextEdit2, "repositoryItemTextEdit2");
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barButtonItem1
            // 
            resources.ApplyResources(this.barButtonItem1, "barButtonItem1");
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.ImageOptions.ImageIndex = ((int)(resources.GetObject("barButtonItem1.ImageOptions.ImageIndex")));
            this.barButtonItem1.ItemAppearance.Normal.Font = ((System.Drawing.Font)(resources.GetObject("barButtonItem1.ItemAppearance.Normal.Font")));
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.barRefresh, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barExport, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.Option, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEvent01, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEvent02),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEvent03),
            new DevExpress.XtraBars.LinkPersistInfo(this.barExit)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // phanTrang1
            // 
            resources.ApplyResources(this.phanTrang1, "phanTrang1");
            this.phanTrang1.ListSoBanGhiMotTrang = null;
            this.phanTrang1.Name = "phanTrang1";
            this.phanTrang1.SoBanGhiMotTrang = 1000000;
            this.phanTrang1.TongSoBanGhi = 0;
            this.phanTrang1.TrangHienTai = 1;
            // 
            // gridBase
            // 
            resources.ApplyResources(this.gridBase, "gridBase");
            this.gridBase.MainView = this.gridView1;
            this.gridBase.Name = "gridBase";
            this.gridBase.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheck});
            this.gridBase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FooterPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.FooterPanel.Font")));
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.GroupFooter.Font")));
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.LightCyan;
            this.gridView1.Appearance.HeaderPanel.BackColor2 = ((System.Drawing.Color)(resources.GetObject("gridView1.Appearance.HeaderPanel.BackColor2")));
            this.gridView1.Appearance.HeaderPanel.Font = ((System.Drawing.Font)(resources.GetObject("gridView1.Appearance.HeaderPanel.Font")));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChon});
            this.gridView1.GridControl = this.gridBase;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colChon
            // 
            resources.ApplyResources(this.colChon, "colChon");
            this.colChon.ColumnEdit = this.repositoryItemCheck;
            this.colChon.FieldName = "flagCheck";
            this.colChon.Name = "colChon";
            // 
            // repositoryItemCheck
            // 
            resources.ApplyResources(this.repositoryItemCheck, "repositoryItemCheck");
            this.repositoryItemCheck.Name = "repositoryItemCheck";
            this.repositoryItemCheck.CheckedChanged += new System.EventHandler(this.repositoryItemCheck_EditValueChanged);
            // 
            // ListBase
            // 
            this.Appearance.BackColor = System.Drawing.Color.Azure;
            this.Appearance.Options.UseBackColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridBase);
            this.Controls.Add(this.phanTrang1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ListBase";
            this.Load += new System.EventHandler(this.ListBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttextSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemComboBoxFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarManager barManager1;
        //     private DevExpress.ExpressApp.Win.Core.FormStateModelSynchronizer formStateModelSynchronizer1;
        protected DevExpress.XtraBars.BarButtonItem btnAdd;
        protected DevExpress.XtraBars.BarButtonItem btnEdit;
        protected DevExpress.XtraBars.BarButtonItem btnDelete;
        protected DevExpress.XtraBars.BarButtonItem btnRefresh;
        protected DevExpress.XtraBars.BarButtonItem btnPrint;
        protected DevExpress.XtraBars.BarButtonItem btnExit;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem btnSeach;
        protected DevExpress.XtraBars.BarButtonItem btnCustom;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        protected DevExpress.XtraEditors.Repository.RepositoryItemComboBox ItemComboBoxFilter;
        protected DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txttextSearch;
        protected DevExpress.XtraBars.BarEditItem barEditItemtextSearch;
        protected DevExpress.XtraBars.BarButtonItem btnSearch;
        protected DevExpress.XtraBars.BarButtonItem barAdd;
        protected DevExpress.XtraBars.BarButtonItem barEdit;
        protected DevExpress.XtraBars.BarButtonItem barDelete;
        protected DevExpress.XtraBars.BarButtonItem barRefresh;
        protected DevExpress.XtraBars.BarButtonItem barExport;
        protected DevExpress.XtraBars.BarButtonItem Option;
        protected DevExpress.XtraBars.BarButtonItem barExit;
        protected DevExpress.XtraBars.BarButtonItem barEvent01;
        protected DevExpress.XtraBars.BarButtonItem barEvent02;
        protected DevExpress.XtraBars.BarButtonItem barEvent03;
        private DevExpress.XtraBars.BarButtonItem btnthamso;
        protected DevExpress.XtraGrid.GridControl gridBase;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        protected DevExpress.XtraGrid.Columns.GridColumn colChon;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheck;
        private PhanTrang phanTrang1;
    }
}