namespace BaseComponent
{
    partial class frmOption
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colhienthi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colVisible = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colwidth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colFormatString = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnsum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridColumnAllowFilter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumnAllowFocus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ColAllowEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControlOption = new DevExpress.XtraEditors.GroupControl();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxShowFooter = new System.Windows.Forms.CheckBox();
            this.checkBoxShowGroupPanel = new System.Windows.Forms.CheckBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnDefault = new DevExpress.XtraEditors.SimpleButton();
            this.checkBoxShowAutoFilterRow = new System.Windows.Forms.CheckBox();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.checkColumnAutoWidth = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOption)).BeginInit();
            this.groupControlOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(5, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2,
            this.repositoryItemCheckEdit2,
            this.repositoryItemComboBox2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4,
            this.repositoryItemCheckEdit5,
            this.repositoryItemComboBox3});
            this.gridControl1.Size = new System.Drawing.Size(963, 466);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colValue,
            this.colhienthi,
            this.colVisible,
            this.colwidth,
            this.colGroup,
            this.colType,
            this.colFormatString,
            this.gridColumnsum,
            this.gridColumnAllowFilter,
            this.gridColumnAllowFocus,
            this.ColAllowEdit});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            // 
            // colName
            // 
            this.colName.Caption = "Mã cột";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsFilter.AllowAutoFilter = false;
            this.colName.OptionsFilter.AllowFilter = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 44;
            // 
            // colValue
            // 
            this.colValue.Caption = "Tiêu đề cột";
            this.colValue.FieldName = "Value";
            this.colValue.Name = "colValue";
            this.colValue.OptionsFilter.AllowAutoFilter = false;
            this.colValue.OptionsFilter.AllowFilter = false;
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 1;
            this.colValue.Width = 111;
            // 
            // colhienthi
            // 
            this.colhienthi.Caption = "Hiển thị";
            this.colhienthi.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colhienthi.FieldName = "Visible";
            this.colhienthi.Name = "colhienthi";
            this.colhienthi.Visible = true;
            this.colhienthi.VisibleIndex = 2;
            this.colhienthi.Width = 52;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemCheckEdit1_EditValueChanged);
            // 
            // colVisible
            // 
            this.colVisible.Caption = "Thứ tự";
            this.colVisible.ColumnEdit = this.repositoryItemSpinEdit1;
            this.colVisible.FieldName = "VisibleIndex";
            this.colVisible.Name = "colVisible";
            this.colVisible.OptionsFilter.AllowAutoFilter = false;
            this.colVisible.OptionsFilter.AllowFilter = false;
            this.colVisible.Visible = true;
            this.colVisible.VisibleIndex = 3;
            this.colVisible.Width = 43;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // colwidth
            // 
            this.colwidth.Caption = "Độ rộng";
            this.colwidth.ColumnEdit = this.repositoryItemSpinEdit2;
            this.colwidth.FieldName = "Width";
            this.colwidth.Name = "colwidth";
            this.colwidth.OptionsFilter.AllowAutoFilter = false;
            this.colwidth.OptionsFilter.AllowFilter = false;
            this.colwidth.Visible = true;
            this.colwidth.VisibleIndex = 4;
            this.colwidth.Width = 54;
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit2.MaxValue = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // colGroup
            // 
            this.colGroup.Caption = "Nhóm";
            this.colGroup.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colGroup.FieldName = "Group";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsFilter.AllowAutoFilter = false;
            this.colGroup.OptionsFilter.AllowFilter = false;
            this.colGroup.Visible = true;
            this.colGroup.VisibleIndex = 7;
            this.colGroup.Width = 44;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colType
            // 
            this.colType.Caption = "Kiểu dữ liệu";
            this.colType.ColumnEdit = this.repositoryItemComboBox1;
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.OptionsFilter.AllowAutoFilter = false;
            this.colType.OptionsFilter.AllowFilter = false;
            this.colType.Visible = true;
            this.colType.VisibleIndex = 5;
            this.colType.Width = 71;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Chuỗi",
            "Số",
            "Ngày tháng",
            "Đúng/sai"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // colFormatString
            // 
            this.colFormatString.Caption = "Định dạng";
            this.colFormatString.ColumnEdit = this.repositoryItemComboBox3;
            this.colFormatString.FieldName = "FormatString";
            this.colFormatString.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colFormatString.Name = "colFormatString";
            this.colFormatString.Visible = true;
            this.colFormatString.VisibleIndex = 6;
            this.colFormatString.Width = 59;
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.AutoHeight = false;
            this.repositoryItemComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox3.Items.AddRange(new object[] {
            "None",
            "dd/MM/yyyy",
            "dd MMM yy",
            "MMM dd yy",
            "hh:mm:ss tt",
            "dd/MM/yyyy hh:mm tt",
            "######",
            "###,###",
            "###,###.0",
            "###,###.00",
            "###,###.000"});
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // gridColumnsum
            // 
            this.gridColumnsum.Caption = "Tính toán";
            this.gridColumnsum.ColumnEdit = this.repositoryItemComboBox2;
            this.gridColumnsum.FieldName = "Summary";
            this.gridColumnsum.Name = "gridColumnsum";
            this.gridColumnsum.Visible = true;
            this.gridColumnsum.VisibleIndex = 8;
            this.gridColumnsum.Width = 53;
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Items.AddRange(new object[] {
            "Tổng",
            "Nhỏ nhất",
            "Lớn nhất",
            "Đếm",
            "Trung bình",
            "None"});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // gridColumnAllowFilter
            // 
            this.gridColumnAllowFilter.Caption = "Cho phép lọc";
            this.gridColumnAllowFilter.ColumnEdit = this.repositoryItemCheckEdit4;
            this.gridColumnAllowFilter.FieldName = "AllowFilter";
            this.gridColumnAllowFilter.Name = "gridColumnAllowFilter";
            this.gridColumnAllowFilter.Visible = true;
            this.gridColumnAllowFilter.VisibleIndex = 9;
            this.gridColumnAllowFilter.Width = 60;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // gridColumnAllowFocus
            // 
            this.gridColumnAllowFocus.Caption = "Cho phép chọn";
            this.gridColumnAllowFocus.ColumnEdit = this.repositoryItemCheckEdit5;
            this.gridColumnAllowFocus.FieldName = "AllowFocus";
            this.gridColumnAllowFocus.Name = "gridColumnAllowFocus";
            this.gridColumnAllowFocus.Visible = true;
            this.gridColumnAllowFocus.VisibleIndex = 10;
            this.gridColumnAllowFocus.Width = 70;
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoHeight = false;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            // 
            // ColAllowEdit
            // 
            this.ColAllowEdit.Caption = "Cho phép sửa";
            this.ColAllowEdit.ColumnEdit = this.repositoryItemCheckEdit3;
            this.ColAllowEdit.FieldName = "AllowEdit";
            this.ColAllowEdit.Name = "ColAllowEdit";
            this.ColAllowEdit.Visible = true;
            this.ColAllowEdit.VisibleIndex = 11;
            this.ColAllowEdit.Width = 54;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // groupControlOption
            // 
            this.groupControlOption.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupControlOption.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupControlOption.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupControlOption.Appearance.ForeColor = System.Drawing.Color.Black;
            this.groupControlOption.Appearance.Options.UseBackColor = true;
            this.groupControlOption.Appearance.Options.UseBorderColor = true;
            this.groupControlOption.Appearance.Options.UseForeColor = true;
            this.groupControlOption.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControlOption.AppearanceCaption.Options.UseFont = true;
            this.groupControlOption.Controls.Add(this.label1);
            this.groupControlOption.Controls.Add(this.checkBoxShowFooter);
            this.groupControlOption.Controls.Add(this.checkBoxShowGroupPanel);
            this.groupControlOption.Controls.Add(this.txtTitle);
            this.groupControlOption.Controls.Add(this.btnCancel);
            this.groupControlOption.Controls.Add(this.btnDefault);
            this.groupControlOption.Controls.Add(this.checkBoxShowAutoFilterRow);
            this.groupControlOption.Controls.Add(this.btnSave);
            this.groupControlOption.Controls.Add(this.gridControl1);
            this.groupControlOption.Controls.Add(this.checkColumnAutoWidth);
            this.groupControlOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControlOption.Location = new System.Drawing.Point(0, 0);
            this.groupControlOption.Name = "groupControlOption";
            this.groupControlOption.Size = new System.Drawing.Size(980, 598);
            this.groupControlOption.TabIndex = 1;
            this.groupControlOption.Text = "Tùy chỉnh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tiêu đề";
            // 
            // checkBoxShowFooter
            // 
            this.checkBoxShowFooter.AutoSize = true;
            this.checkBoxShowFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxShowFooter.Location = new System.Drawing.Point(90, 539);
            this.checkBoxShowFooter.Name = "checkBoxShowFooter";
            this.checkBoxShowFooter.Size = new System.Drawing.Size(87, 17);
            this.checkBoxShowFooter.TabIndex = 10;
            this.checkBoxShowFooter.Tag = "ShowFooter";
            this.checkBoxShowFooter.Text = "Hiển thị tổng";
            this.checkBoxShowFooter.UseVisualStyleBackColor = false;
            // 
            // checkBoxShowGroupPanel
            // 
            this.checkBoxShowGroupPanel.AutoSize = true;
            this.checkBoxShowGroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxShowGroupPanel.Location = new System.Drawing.Point(197, 539);
            this.checkBoxShowGroupPanel.Name = "checkBoxShowGroupPanel";
            this.checkBoxShowGroupPanel.Size = new System.Drawing.Size(91, 17);
            this.checkBoxShowGroupPanel.TabIndex = 11;
            this.checkBoxShowGroupPanel.Tag = "ShowGroupPanel";
            this.checkBoxShowGroupPanel.Text = "Hiển thị nhóm";
            this.checkBoxShowGroupPanel.UseVisualStyleBackColor = false;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(93, 497);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(566, 21);
            this.txtTitle.TabIndex = 8;
            this.txtTitle.Tag = "Title";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(891, 560);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(77, 26);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefault.Appearance.Options.UseFont = true;
            this.btnDefault.Location = new System.Drawing.Point(808, 559);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(77, 26);
            this.btnDefault.TabIndex = 2;
            this.btnDefault.Text = "Mặc định";
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // checkBoxShowAutoFilterRow
            // 
            this.checkBoxShowAutoFilterRow.AutoSize = true;
            this.checkBoxShowAutoFilterRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkBoxShowAutoFilterRow.Location = new System.Drawing.Point(307, 542);
            this.checkBoxShowAutoFilterRow.Name = "checkBoxShowAutoFilterRow";
            this.checkBoxShowAutoFilterRow.Size = new System.Drawing.Size(140, 17);
            this.checkBoxShowAutoFilterRow.TabIndex = 9;
            this.checkBoxShowAutoFilterRow.Tag = "ShowAutoFilterRow";
            this.checkBoxShowAutoFilterRow.Text = "Hiển thị dòng lọc dữ liệu";
            this.checkBoxShowAutoFilterRow.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(725, 559);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkColumnAutoWidth
            // 
            this.checkColumnAutoWidth.AutoSize = true;
            this.checkColumnAutoWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.checkColumnAutoWidth.Location = new System.Drawing.Point(472, 542);
            this.checkColumnAutoWidth.Name = "checkColumnAutoWidth";
            this.checkColumnAutoWidth.Size = new System.Drawing.Size(187, 17);
            this.checkColumnAutoWidth.TabIndex = 6;
            this.checkColumnAutoWidth.Tag = "ColumnAutoWidth";
            this.checkColumnAutoWidth.Text = "Tự động điều chỉnh kích thước cột";
            this.checkColumnAutoWidth.UseVisualStyleBackColor = false;
            // 
            // frmOption
            // 
            this.Appearance.BackColor = System.Drawing.Color.Azure;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 598);
            this.Controls.Add(this.groupControlOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tùy chỉnh";
            this.Load += new System.EventHandler(this.frmOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlOption)).EndInit();
            this.groupControlOption.ResumeLayout(false);
            this.groupControlOption.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn colVisible;
        private DevExpress.XtraGrid.Columns.GridColumn colwidth;
        private DevExpress.XtraEditors.GroupControl groupControlOption;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnDefault;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colhienthi;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnsum;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn ColAllowEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAllowFilter;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAllowFocus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn colFormatString;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox3;
        private System.Windows.Forms.CheckBox checkColumnAutoWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox checkBoxShowAutoFilterRow;
        private System.Windows.Forms.CheckBox checkBoxShowFooter;
        private System.Windows.Forms.CheckBox checkBoxShowGroupPanel;
    }
}

