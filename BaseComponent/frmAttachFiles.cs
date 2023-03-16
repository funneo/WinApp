using Data.Interfaces.Systems;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Data.ViewModels.Systems;
using Data.Models.Systems;
using System.Net;
using System.IO;
using DevExpress.XtraGrid;

namespace BaseComponent
{
    public partial class frmAttachFiles : BaseComponent.baseForm
    {
        readonly IAttachFiles _attachFilesRepository;
        public string FunctionName = string.Empty;
        public string FrmName = string.Empty;
        public string RefNo = string.Empty;
        public int AttachFileType = 0;
        public bool IsApproved = false;
        private DataTable DbUpload;

        private string fileInitialDirectory = $"C:\\";

        public frmAttachFiles()
        {
            InitializeComponent();
            _attachFilesRepository=(IAttachFiles)BaseComponent.AppConfig.ServiceProvider.GetService(typeof(IAttachFiles));
        }

        private void LoadAttachFiles(bool IsTheFirstLoad)
        {
            var listData = new List<AttachFilesViewModel>();
            var r = _attachFilesRepository.Get(FunctionName, FrmName, RefNo);
            if (r.Code.Equals("201"))
            {
                listData = (List<AttachFilesViewModel>)r.Data;
            }
            else if(r.Code.Equals("204"))
            {
                listData = new List<AttachFilesViewModel>();
            }
            else
            {
                if (r.Code.Equals("401"))
                {
                    MessageBox.Show("TokenKey không đúng!", Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi:" + r.Message, Common.MessageContstants.MSG_ERR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (IsTheFirstLoad)
            {
                DbUpload = Common.Utils.ToDataTable<AttachFilesViewModel>(listData);
                gridControlAttachFiles.DataSource = Common.Utils.ToDataTable<AttachFilesViewModel>(listData); ;
            }
                
            else
            {
                var db = Common.Utils.ToDataTable<AttachFilesViewModel>(listData);
                gridControlAttachFiles.DataSource = db;
            }
            
            gridViewAttachFiles.FocusedRowHandle = gridViewAttachFiles.RowCount - 1;
        }
        private void gridViewAttachFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (BaseComponent.MessageEx.Show("Có muốn xóa tập tin đã được tại lên này hay không?", Common.MessageContstants.DELTE_CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                GridView view = sender as GridView;
                int rowHandle = view.FocusedRowHandle;
                if (rowHandle > -1)
                {
                    if ((Guid)gridViewAttachFiles.GetDataRow(rowHandle)["UserId"] != BaseComponent.Permission.User.UserId)
                        return;                  
                    var _id = (int)gridViewAttachFiles.GetDataRow(rowHandle)["Id"];
                    var _userId = (Guid)gridViewAttachFiles.GetDataRow(rowHandle)["UserId"];
                    string _pathFile = gridViewAttachFiles.GetDataRow(rowHandle)["PathFile"] == DBNull.Value ? string.Empty :
                        gridViewAttachFiles.GetDataRow(rowHandle)["PathFile"].ToString();
                    //Nếu đã được duyệt hoặc cấm thì không cho xóa những dòng đã upload lên, chỉ xóa những dòng mới up
                    //So sánh với bảng tải lên khi mới load form
                    if (IsApproved)
                    {
                        foreach (DataRow row in DbUpload.Rows)
                        {
                            var idrow = (int)row["Id"];
                            if (idrow.Equals(_id)) return;
                        }
                    }
                    var rval = _attachFilesRepository.Delete(_id, _userId, _pathFile);
                    if (rval.Code.Equals("200"))
                    {
                        LoadAttachFiles(false);
                    }
                    else
                    {
                        MessageBox.Show(Common.MessageContstants.DELTE_ERR, Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void frmAttachFiles_Load(object sender, EventArgs e)
        {
            LoadAttachFiles(true);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UpLoadFile();
        }

        private void UpLoadFile()
        {
            //Biến này xác định xem kiểu upload là upload thay đỏi file cũ hay upload mới
            bool _isUpdate = false;
            DataRow r = gridViewAttachFiles.GetFocusedDataRow();
            if (r == null)
                return;
            if (r["Title"] == null || r["Title"] == DBNull.Value || r["Title"].ToString().Length == 0)
                return;
            
            OpenFileDialog Openfile = new OpenFileDialog();
            Openfile.InitialDirectory = fileInitialDirectory;
            Openfile.Filter = "Image Documents(*.tif; *.tiff; *.mdi,*.png,*.jpeg,*.jpg)|*.tif; *.tiff; *.mdi;*.png;*.jpeg;*.jpg|Pdf(*.pdf)|*.pdf|Office(*.doc; *.docx; *.xls; *.xlsx;)|*.doc; *.docx; *.xls; *.xlsx;|Other file(*.msg)|*.msg";
            Openfile.FilterIndex = 1;
            Openfile.Title = "Mở danh sách tập tin";
            if (Openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Openfile.FileName.EndsWith(".exe"))
                    return;
                //Kiểm tra dung lượng file không được lớn hơn 1MB
                System.IO.FileStream objFileStream = new System.IO.FileStream(Openfile.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                int intLength = Convert.ToInt32(objFileStream.Length);
                if (intLength > 1.0 * Math.Pow(2, 20))
                {
                    MessageBox.Show("Dung lượng file upload lớn hơn giá trị cho phép 1MB, kiểm tra lại!",
                        "Lỗi upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Nếu đã có file upload thì xóa file cũ đi và thực hiện update lại thông tin
                if (!(r["Id"] == DBNull.Value || r["Id"].ToString() == "0"))
                {
                    _isUpdate = true;
                    if ((Guid)r["UserId"] != BaseComponent.Permission.User.UserId)
                        return;
                    var _id = (int)r["Id"];
                    if (IsApproved)
                    {
                        foreach (DataRow row in DbUpload.Rows)
                        {
                            var idrow = (int)row["Id"];
                            if (idrow.Equals(_id)) return;
                        }
                    }       
                    //xóa file đã upload 
                    string pathFile = r["pathFiles"] == DBNull.Value ? string.Empty : r["pathFiles"].ToString();
                    var rfile = pathFile.Substring(pathFile.LastIndexOf('/') + 1);
                    //Xóa file trên máy chủ
                    var rvalDelete = _attachFilesRepository.DeleteAttachFiles(rfile);
                    if (!rvalDelete.Code.Equals("00"))
                    {
                        var rval = MessageBox.Show("Có lỗi sảy ra khi xóa file cũ, tiếp tục tải tập tin lên hay không?", Common.MessageContstants.DELTE_ERR, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rval == DialogResult.No)
                            return;
                    }
                       
                }
                //Nếu file có đuôi là msg (file email) thì đổi thành txt để khi down về sẽ đổi lại thành msg --> web sẽ nhận dạng được

                var t = Openfile.FileName;
                var item = new AttachFiles()
                {
                    Id= _isUpdate ? (int)r["Id"]:0,
                    Title = r["Title"].ToString(),
                    FunctionName = this.FunctionName,
                    FrmName = this.FrmName,
                    RefNo = this.RefNo,
                    AttachFileTypeId = AttachFileType,
                    UserId = BaseComponent.Permission.User.UserId,
                    BranchId = BaseComponent.Permission.BranchId ?? 0
                };
                var pathFiles = new List<string>();
                pathFiles.Add(t);
                if (_isUpdate)
                {
                    var rvalUpload = _attachFilesRepository.Update(item);
                    if (rvalUpload.Code.Equals("200"))
                    {
                        MessageBox.Show("Cập nhật thay đổi tập tin thành công!", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAttachFiles(false);
                    }
                    else
                    {
                        MessageBox.Show("Upload tài liệu bị lỗi: " + rvalUpload.Message, Common.MessageContstants.TITLE, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    var rvalUpload = _attachFilesRepository.Add(item, pathFiles);
                    if (rvalUpload.Code.Equals("201"))
                    {
                        MessageBox.Show("Tải tập tin thành công!", Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAttachFiles(false);
                    }
                    else
                    {
                        MessageBox.Show("Upload tài liệu bị lỗi: " + rvalUpload.Message, Common.MessageContstants.TITLE, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }    
            }
        }
        private void DownLoadfile()
        {
            string FromFolder = null;
            FromFolder = Application.StartupPath;
            DataRow r = gridViewAttachFiles.GetFocusedDataRow();
            if (r == null)
                return;
            string strId = (r["Id"] == null || r["Id"] == DBNull.Value) ? "0" : r["Id"].ToString();
            if (strId == "0")
                return;
            string fileName = (r["FileName"] == null || r["FileName"] == DBNull.Value) ? "" : (string)r["FileName"];
            string pathFile = (r["PathFile"] == null || r["PathFile"] == DBNull.Value) ? "" : (string)r["PathFile"];
            if (pathFile.Length < 1) return;
            var url = pathFile.Replace("~", "");
            var fullUrl = @"https://localhost:44352" + url;
            //Kiểm tra xem có phải là dạng file ggg không thì chuyển thành msg file outloock
            if (Path.GetExtension(fileName).Equals(".txt"))
            {
                fileName = Path.GetFileName(fileName) + ".msg";
            }
            var pathUpload = FromFolder + "\\temps";
            if (!Directory.Exists(pathUpload))
            {
                Directory.CreateDirectory(pathUpload);
            }
            var fileUpload = FromFolder + "\\temps\\" + fileName;
            if (System.IO.File.Exists(fileUpload))
                try
                {
                    System.IO.File.Delete(fileUpload);
                }
                catch { MessageBox.Show("File is Openning", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(fullUrl, fileUpload);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            System.Diagnostics.Process.Start(fileUpload);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownLoadfile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            int rowHandle = view.FocusedRowHandle;
            if (rowHandle > -1)
            {
                if ((Guid)gridViewAttachFiles.GetDataRow(rowHandle)["UserId"] != BaseComponent.Permission.User.UserId)
                    return;
                var _id = (int)gridViewAttachFiles.GetDataRow(rowHandle)["Id"];
                var _userId = (Guid)gridViewAttachFiles.GetDataRow(rowHandle)["UserId"];
                string _pathFile = gridViewAttachFiles.GetDataRow(rowHandle)["PathFile"] == DBNull.Value ? string.Empty :
                    gridViewAttachFiles.GetDataRow(rowHandle)["PathFile"].ToString();
                //Nếu đã được duyệt hoặc cấm thì không cho xóa những dòng đã upload lên, chỉ xóa những dòng mới up
                //So sánh với bảng tải lên khi mới load form
                if (IsApproved)
                {
                    foreach (DataRow row in DbUpload.Rows)
                    {
                        var idrow = (int)row["Id"];
                        if (idrow.Equals(_id)) return;
                    }
                }
                var item = new AttachFiles()
                {
                    Id = _id,
                    Title = gridViewAttachFiles.GetDataRow(rowHandle)["Title"].ToString(),
                    UserId = BaseComponent.Permission.User.UserId,
                    FileName= gridViewAttachFiles.GetDataRow(rowHandle)["FileName"].ToString(),
                    PathFile=_pathFile
                };
                var rval = _attachFilesRepository.Update(item);
                MessageBox.Show(Common.MessageContstants.UPDATE_OK, Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (rval.Code.Equals("200"))
                {
                    LoadAttachFiles(false);
                }
                else
                {
                    MessageBox.Show(Common.MessageContstants.DELTE_ERR, Common.MessageContstants.TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
