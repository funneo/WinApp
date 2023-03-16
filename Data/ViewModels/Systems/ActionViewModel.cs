using System;
using System.Collections.Generic;
using System.Text;

namespace API.ViewModels
{
    public class ActionViewModel
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public int? SortOrder { get; set; }
        public bool? Status { get; set; }
    }
}
