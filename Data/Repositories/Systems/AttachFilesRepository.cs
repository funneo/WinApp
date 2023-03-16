using Data.FromBody;
using Data.Interfaces.Systems;
using Data.Models.Systems;
using Data.Response;
using Data.ViewModels.Systems;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Systems
{
    public class AttachFilesRepository : IAttachFiles
    {
        private string tokenKey = Common.CommonVariable.TokenKey;

        public  ResponseValue<IEnumerable<AttachFilesViewModel>> Add(AttachFiles obj, List<string> pathFiles)
        {
            var urlStr = $"/api/AttachFiles/Create2";
            var fBody = new FromBodyBase<AttachFiles>()
            {
                TokenKey=tokenKey,
                Item=obj,
            };
            var parameters= JsonConvert.SerializeObject(fBody);
            var result =  ApiClient.ApiClient.PostFormData<ResponseValue<IEnumerable<AttachFilesViewModel>>>(urlStr, parameters, pathFiles);
            return result;
        }

        public ResponseValue<AttachFilesViewModel> Add(AttachFiles obj)
        {
            var urlStr = $"/api/AttachFiles/Create";
            var fromBody = new FromBodyBase<AttachFiles>()
            {
                TokenKey=tokenKey,
                Item=obj
            };
            var result = ApiClient.ApiClient.Post<ResponseValue<AttachFilesViewModel>>(urlStr, fromBody);
            return result;
        }

        public ResponseValue<int> Delete(int id,Guid userId,string pathFile)
        {
            var urlStr = $"/api/AttachFiles/Delete";
            var item = new AttachFiles()
            {
                Id=id,
                UserId=userId,
                PathFile=pathFile
            };
            var fromBody = new FromBodyBase<AttachFiles>()
            {
                TokenKey = tokenKey,
                Item=item
            };
            var result = ApiClient.ApiClient.Post<ResponseValue<int>>(urlStr, fromBody);
            return result;
        }

        public ResponseValue<string> DeleteAttachFiles(string fileName)
        {
            var urlStr = $"/api/UploadFiles/DeleteFiles";
            var item = new AttachFiles()
            {
                FileName = fileName,
            };
            var fromBody = new FromBodyBase<AttachFiles>()
            {
                TokenKey = tokenKey,
                Item = item
            };
            var result = ApiClient.ApiClient.Post<ResponseValue<string>>(urlStr, fromBody);
            return result;
        }

        public ResponseValue<List<AttachFilesViewModel>> Get(string functionName, string frmName, string refNo)
        {
            var urlStr = $"/api/AttachFiles/Get";
            var item = new AttachFiles()
            {
                FunctionName=functionName,
                FrmName=frmName,
                RefNo=refNo,
            };
            var fromBody = new FromBodyBase<AttachFiles>()
            {
                TokenKey = tokenKey,
                Item=item
            };
            var result = ApiClient.ApiClient.Post<ResponseValue<List<AttachFilesViewModel>>>(urlStr, fromBody);
            return result;
        }

        public ResponseValue<AttachFilesViewModel> Update(AttachFiles obj)
        {
            var urlStr = $"/api/AttachFiles/Update";
            var fromBody = new FromBodyBase<AttachFiles>()
            {
                TokenKey = tokenKey,
                Item = obj
            };
            var result = ApiClient.ApiClient.Post<ResponseValue<AttachFilesViewModel>>(urlStr, fromBody);
            return result;
        }

        public ResponseValue<AttachFilesViewModel> Update(AttachFiles obj, List<string> pathFiles)
        {
            var urlStr = $"/api/AttachFiles/Create2";
            var fBody = new FromBodyBase<AttachFiles>()
            {
                TokenKey = tokenKey,
                Item = obj,
            };
            var parameters = JsonConvert.SerializeObject(fBody);
            var result = ApiClient.ApiClient.PostFormData<ResponseValue<AttachFilesViewModel>>(urlStr, parameters, pathFiles);
            return result;
        }

        public ResponseValue<List<string>> UploadAttachFiles(List<string> filesName)
        {
            var urlStr = $"/api/UploadFiles/UploadFiles";
            var result = ApiClient.ApiClient.PostIFormFile<ResponseValue<List<string>>>(urlStr, filesName);
            return result;
        }
    }
}
