using Data.Models.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Systems
{
  public  class AttachFilesViewModel:AttachFiles
    {   
        public string Type { get; set; }
        public string AttachFileTypeName { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool ReadOnly { get; set; }
    }
}
