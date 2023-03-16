using System;
using System.Collections.Generic;
using System.Text;

namespace API.ViewModels
{
    public class FunctionActionViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public int SortOrder { set; get; }
        public List<ActionViewModel> Actions { set; get; }
    }
}
