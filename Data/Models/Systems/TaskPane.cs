using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Systems
{
    public class TaskPane
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FunctionId { get; set; }
        public string AltText { get; set; }
        public string Image { get; set; }
        public string AltTextEn { get; set; }
        public int? SortOrder { get; set; }
        public int? TypeShow { get; set; }
        public bool? Status { get; set; }
        public bool? IsDef { get; set; }
    }
}
