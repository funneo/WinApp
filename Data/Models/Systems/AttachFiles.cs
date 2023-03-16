using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Systems
{
   public class AttachFiles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string FunctionName { get; set; }
        public string FrmName { get; set; }
        public string RefNo { get; set; }
        public int AttachFileTypeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime InitialTime { get; set; }
        public int BranchId { get; set; }
        public string JobId { get; set; }
        public int Size { get; set; }
        public string PathFile { get; set; }
    }
}
