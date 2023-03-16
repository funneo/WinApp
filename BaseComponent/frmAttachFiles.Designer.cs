namespace BaseComponent
{
    partial class frmAttachFiles
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttachFiles));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControlAttachFiles = new DevExpress.XtraGrid.GridControl();
            this.gridViewAttachFiles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInitialTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSize = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUpload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnUpload = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumnView = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDownload = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumnCommand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSave = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumnPathFile = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAttachFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttachFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlAttachFiles
            // 
            this.gridControlAttachFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlAttachFiles.Location = new System.Drawing.Point(0, 0);
            this.gridControlAttachFiles.MainView = this.gridViewAttachFiles;
            this.gridControlAttachFiles.Name = "gridControlAttachFiles";
            this.gridControlAttachFiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnUpload,
            this.btnDownload,
            this.btnSave});
            this.gridControlAttachFiles.Size = new System.Drawing.Size(952, 629);
            this.gridControlAttachFiles.TabIndex = 0;
            this.gridControlAttachFiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAttachFiles});
            // 
            // gridViewAttachFiles
            // 
            this.gridViewAttachFiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnTitle,
            this.gridColumnFileName,
            this.gridColumnUserName,
            this.gridColumnInitialTime,
            this.gridColumnSize,
            this.gridColumnUpload,
            this.gridColumnView,
            this.gridColumnCommand,
            this.gridColumnPathFile});
            this.gridViewAttachFiles.GridControl = this.gridControlAttachFiles;
            this.gridViewAttachFiles.Name = "gridViewAttachFiles";
            this.gridViewAttachFiles.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewAttachFiles.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewAttachFiles.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewAttachFiles.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewAttachFiles.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewAttachFiles.OptionsView.ShowGroupPanel = false;
            this.gridViewAttachFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewAttachFiles_KeyDown);
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "Id";
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            // 
            // gridColumnTitle
            // 
            this.gridColumnTitle.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnTitle.AppearanceHeader.Options.UseFont = true;
            this.gridColumnTitle.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnTitle.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnTitle.Caption = "Nội dung";
            this.gridColumnTitle.FieldName = "Title";
            this.gridColumnTitle.Name = "gridColumnTitle";
            this.gridColumnTitle.Visible = true;
            this.gridColumnTitle.VisibleIndex = 0;
            this.gridColumnTitle.Width = 262;
            // 
            // gridColumnFileName
            // 
            this.gridColumnFileName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnFileName.AppearanceHeader.Options.UseFont = true;
            this.gridColumnFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnFileName.Caption = "Tên Tập tin";
            this.gridColumnFileName.FieldName = "FileName";
            this.gridColumnFileName.Name = "gridColumnFileName";
            this.gridColumnFileName.OptionsColumn.AllowEdit = false;
            this.gridColumnFileName.Visible = true;
            this.gridColumnFileName.VisibleIndex = 1;
            this.gridColumnFileName.Width = 120;
            // 
            // gridColumnUserName
            // 
            this.gridColumnUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnUserName.AppearanceHeader.Options.UseFont = true;
            this.gridColumnUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnUserName.Caption = "Người tạo";
            this.gridColumnUserName.FieldName = "UserName";
            this.gridColumnUserName.Name = "gridColumnUserName";
            this.gridColumnUserName.OptionsColumn.AllowEdit = false;
            this.gridColumnUserName.Visible = true;
            this.gridColumnUserName.VisibleIndex = 2;
            this.gridColumnUserName.Width = 120;
            // 
            // gridColumnInitialTime
            // 
            this.gridColumnInitialTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnInitialTime.AppearanceHeader.Options.UseFont = true;
            this.gridColumnInitialTime.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnInitialTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnInitialTime.Caption = "Ngày/giờ";
            this.gridColumnInitialTime.FieldName = "InitialTime";
            this.gridColumnInitialTime.Name = "gridColumnInitialTime";
            this.gridColumnInitialTime.OptionsColumn.AllowEdit = false;
            this.gridColumnInitialTime.Visible = true;
            this.gridColumnInitialTime.VisibleIndex = 3;
            this.gridColumnInitialTime.Width = 151;
            // 
            // gridColumnSize
            // 
            this.gridColumnSize.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnSize.AppearanceHeader.Options.UseFont = true;
            this.gridColumnSize.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSize.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSize.Caption = "Kích thước (KB)";
            this.gridColumnSize.Name = "gridColumnSize";
            this.gridColumnSize.OptionsColumn.AllowEdit = false;
            this.gridColumnSize.Visible = true;
            this.gridColumnSize.VisibleIndex = 4;
            this.gridColumnSize.Width = 135;
            // 
            // gridColumnUpload
            // 
            this.gridColumnUpload.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnUpload.AppearanceHeader.Options.UseFont = true;
            this.gridColumnUpload.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnUpload.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnUpload.Caption = "Tải lên";
            this.gridColumnUpload.ColumnEdit = this.btnUpload;
            this.gridColumnUpload.MaxWidth = 70;
            this.gridColumnUpload.MinWidth = 70;
            this.gridColumnUpload.Name = "gridColumnUpload";
            this.gridColumnUpload.Visible = true;
            this.gridColumnUpload.VisibleIndex = 5;
            this.gridColumnUpload.Width = 70;
            // 
            // btnUpload
            // 
            this.btnUpload.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.btnUpload.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // gridColumnView
            // 
            this.gridColumnView.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumnView.AppearanceHeader.Options.UseFont = true;
            this.gridColumnView.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnView.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnView.Caption = "Hiển thị";
            this.gridColumnView.ColumnEdit = this.btnDownload;
            this.gridColumnView.MaxWidth = 70;
            this.gridColumnView.MinWidth = 70;
            this.gridColumnView.Name = "gridColumnView";
            this.gridColumnView.Visible = true;
            this.gridColumnView.VisibleIndex = 6;
            this.gridColumnView.Width = 70;
            // 
            // btnDownload
            // 
            this.btnDownload.AutoHeight = false;
            editorButtonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions2.Image")));
            this.btnDownload.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // gridColumnCommand
            // 
            this.gridColumnCommand.ColumnEdit = this.btnSave;
            this.gridColumnCommand.MaxWidth = 50;
            this.gridColumnCommand.MinWidth = 50;
            this.gridColumnCommand.Name = "gridColumnCommand";
            this.gridColumnCommand.Visible = true;
            this.gridColumnCommand.VisibleIndex = 7;
            this.gridColumnCommand.Width = 50;
            // 
            // btnSave
            // 
            this.btnSave.AutoHeight = false;
            editorButtonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions3.Image")));
            this.btnSave.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "Cập nhật nội dung", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btnSave.Name = "btnSave";
            this.btnSave.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridColumnPathFile
            // 
            this.gridColumnPathFile.FieldName = "PathFile";
            this.gridColumnPathFile.Name = "gridColumnPathFile";
            // 
            // frmAttachFiles
            // 
            this.Appearance.BackColor = System.Drawing.Color.Azure;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(952, 629);
            this.Controls.Add(this.gridControlAttachFiles);
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmAttachFiles";
            this.Text = "Tải File đính kèm";
            this.Load += new System.EventHandler(this.frmAttachFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAttachFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttachFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAttachFiles;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAttachFiles;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTitle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFileName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInitialTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSize;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUpload;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnUpload;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnView;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDownload;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCommand;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPathFile;
    }
}
