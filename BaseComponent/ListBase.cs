using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils;
using BaseComponent.Core;
using System.Activities.Expressions;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace BaseComponent
{
    public partial class ListBase : baseForm
    {       
        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; } 
        public int? BranchId { get; set; }
        public string NameClass { get; set; }
        public List<string> ListColumn { get; set; }
        public bool flagCheck { get; set; }
        public string keyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }

        public UIBase frmUI;
        public object entityItem=null;
        public int rowHandle = -1;
        int rowHandleGroup = -1;      
        public bool flagSua = false;
        public bool flagXoa = false;
        public bool flagThem = true;
        protected virtual void OpenUI()
        {          
            frmUI = new UIBase();
        }
        public ListBase()
        {        
            InitializeComponent();
            phanTrang1.SoBanGhiMotTrang = 25;
            phanTrang1.ListSoBanGhiMotTrang = new List<string>(new string[] { "25", "50", "100", "250", "500", "1000", "5000","N/A" });

        }

        protected virtual void ListBase_Load(object sender, EventArgs e)
        {
            phanTrang1._LoadData = Loaddata_1;
            PageSize = (int)phanTrang1.SoBanGhiMotTrang;
            PageIndex = 1;
            var d = DateTime.Now;
            TuNgay = new DateTime(d.Year, d.Month, 1);
            DenNgay = new DateTime(d.Year, d.Month,DateTime.DaysInMonth(d.Year,d.Month));
            UpdateData();
            btnEdit.Enabled = flagSua;
            btnDelete.Enabled = flagXoa;
            btnAdd.Enabled=flagThem;
            CreateColums(gridView1,NameClass);           
                if (flagCheck)
                {
                    gridView1.Columns.Add(colChon);
                    colChon.VisibleIndex = 0;
                }
            phanTrang1.TongSoBanGhi = TotalRows;
            SetData();
            txttextSearch.AllowFocused = true;
        }

        protected void Print()
        {
            gridBase.ShowPrintPreview();
        }

        protected void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasAddPermission())
            {
                MessageEx.Show(MessageContstants.NOT_PERMISSION_ADD, MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            rowHandleGroup = gridView1.FocusedRowHandle;
            bool expanded = gridView1.GetRowExpanded(gridView1.FocusedRowHandle);
            OpenUI();
            frmUI.flagEdit = false;
            //frmUI.funcId = this.funcId;
            //frmUI.b_Duyet = HasDuyetPermission();
            frmUI.ShowDialog();
            if (frmUI.flagChanged)
            {
                Search();
                //UpdateData();
                //SetData();
                gridView1.FocusedRowHandle = rowHandleGroup;
                gridView1.ClearColumnsFilter();
            }
        }

        protected void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!HasEditPermission())
            {
                MessageEx.Show(MessageContstants.NOT_PERMISSION_UPDATE, MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(entityItem!=null)
            {
                OpenUI();
                frmUI.flagEdit = true;
                frmUI.entityData = entityItem;
                frmUI.ShowDialog();
                if (frmUI.flagChanged)
                {
                    Search();
                    //UpdateData();
                    //SetData();
                    gridView1.FocusedRowHandle = rowHandleGroup;
                }
            }
            else
            {
                MessageEx.Show(MessageContstants.NOT_SELECT_ROW, MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int delete = 0;
            if (!HasDeletePermission())
            {
                MessageEx.Show(MessageContstants.NOT_PERMISSION_DELETE, MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }            
            if (entityItem != null)
            {
                if (MessageEx.Show(MessageContstants.DELTE_CONFIRM, MessageContstants.TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }               
                try
                {
                    delete = Delete(entityItem);
                }
                catch { BaseComponent.MessageEx.Show(MessageContstants.DELTE_ERR, MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error); }
                if (delete >= 1)
                {                  
                 gridView1.DeleteRow(rowHandle);
                 btnEdit.Enabled=  flagSua = false;
                 btnDelete.Enabled=   flagXoa = false;
                    phanTrang1.TongSoBanGhi--;
                    return;
                }
                else
                    return;
            }
            else
            {
                MessageEx.Show(MessageContstants.NOT_SELECT_ROW, MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        protected void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search();
        }

        protected void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print();
        }

        protected void btnCustom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmOption frmCustom = new frmOption();
            frmCustom.ClassName = NameClass;
            frmCustom.ListColumnName = ListColumn;
            frmCustom.Text = this.Text;           
            frmCustom.ShowDialog();
            CreateColums(gridView1, NameClass);
            if (flagCheck)
            {
                gridView1.Columns.Add(colChon);
                colChon.VisibleIndex = 0;
            }                   
            SetData();
        }

        protected void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void gridView1_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);
            if (hitInfo.InRowCell)
            {
                view.FocusedRowHandle = rowHandle = hitInfo.RowHandle;
                //column = hitInfo.Column;
                popupMenu1.ShowPopup(barManager1, view.GridControl.PointToScreen(e.Point));
            }
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {         
            rowHandle = e.RowHandle;
            BeginInvoke(new Action(() =>
            {
                var gridView = sender as GridView;
                gridView.PostEditor();
                gridView.UpdateCurrentRow();
            }));
            if (rowHandle >= 0)
            {              
                cellValueChanged();
                btnDelete.Enabled = flagXoa;
                btnEdit.Enabled = flagSua;
            }
        }           
      
        protected virtual int Delete(object item)
        {
            return 0;
        }
        protected virtual void UpdateData()
        {
            btnEdit.Enabled = flagSua=false;
            btnDelete.Enabled = flagXoa=false;           
        }
        protected virtual void SetData()
        {
                   
        }

        public virtual int Loaddata_1(int pageSize,int pageIndex)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            UpdateData();
            SetData();
            return TotalRows;
        }      

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(e.Location);
            if (hitInfo.HitTest == GridHitTest.ColumnFilterButton)
                DXMouseEventArgs.GetMouseArgs(e).Handled = false;
        }         

        protected virtual void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            //return;
            if (e.RowHandle <= -1)
                return;
            if (e.RowHandle % 2 != 0)
                e.Appearance.BackColor = Color.BlanchedAlmond;           
        }

        private void btnSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Search();
        }

        protected virtual void Search()
        {                  
            phanTrang1.TongSoBanGhi = Loaddata_1((int)phanTrang1.SoBanGhiMotTrang, 1);
            //UpdateData();
            //SetData();
        }

        protected virtual void ItemComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
        }      

        private void txttextSearch_EditValueChanged(object sender, EventArgs e)
        {
            barEditItemtextSearch.EditValue = ((DevExpress.XtraEditors.TextEdit)sender).EditValue;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                var gridView = sender as GridView;
                gridView.PostEditor();
                gridView.UpdateCurrentRow();
            }));
            if (e.Column==colChon)
            {               
                cellValueChanged();
                btnDelete.Enabled = flagXoa;
                btnEdit.Enabled = flagSua;
            }    
           
        }

        protected virtual void cellValueChanged()
        {
            return;
        }  

        private void repositoryItemCheck_EditValueChanged(object sender, EventArgs e)
        {
            var baseEdit = sender as BaseEdit;
            var gridView = ((baseEdit.Parent as GridControl).MainView as GridView);
            gridView.PostEditor();
            gridView.UpdateCurrentRow();
        }

        private void btnthamso_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Getthamso();
        }

        protected virtual void Getthamso()
        {            
            var f = new thamsoUI(BranchId, TuNgay, DenNgay);
            f.ShowDialog();
            TuNgay = f.Tungay;
            DenNgay = f.Denngay;          
            if (f.Ok)
            {
                Search();
                //UpdateData();
                //SetData();
            }
            else
                return;
        }      
    }
}