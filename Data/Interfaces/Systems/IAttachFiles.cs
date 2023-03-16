using Data.Models.Systems;
using Data.Response;
using Data.ViewModels.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces.Systems
{
    public interface IAttachFiles
    {
        ResponseValue<IEnumerable<AttachFilesViewModel>> Add( AttachFiles obj,List<string> pathFiles);
        ResponseValue<AttachFilesViewModel> Add(AttachFiles obj);
        ResponseValue<AttachFilesViewModel> Update(AttachFiles obj,List<string> pathFiles);
        ResponseValue<AttachFilesViewModel> Update(AttachFiles obj);
        ResponseValue<int> Delete(int id,Guid userId, string pathFile);
        ResponseValue<List<AttachFilesViewModel>> Get(string functionName, string frmName, string refNo);

        ResponseValue<string> DeleteAttachFiles(string pathFile);
        ResponseValue<List<string>> UploadAttachFiles(List<string> filesName);

    }
}
