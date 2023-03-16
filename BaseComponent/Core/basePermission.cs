using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using Data.Models.Systems;

namespace BaseComponent
{
    //public enum PermissionType
    //{
    //    PermissionView, PermissionAdd, PermissionEdit, PermissionDelete, PermissionDuyet
    //}
    public static class Permission
    {
        public const string PERMISSION_VIEW = "VIEW";
        public const string PERMISSION_ADD = "CREATE";
        public const string PERMISSION_EDIT = "UPDATE";
        public const string PERMISSION_DELETE = "DELETE";
        public const string PERMISSION_PRINT = "PRINT";
        public const string PERMISSION_EXPORT = "EXPORT";
        public const string PERMISSION_IMPORT = "IMPORT";
        public const string PERMISSION_ACCEPT = "ACCEPT";
        public const string PERMISSION_APPROVED = "APPROVED";
        //public const string PERMISSION_APPROVED_LAYER1 = "APPROVED1";       
        //public const string PERMISSION_APPROVED_LAYER2 = "APPROVED2";
        public static string UserName { get; set; }    
        public static int? BranchId { get; set; }
        public static int? AcountLevel { get; set; }
        public static int? EmployeeId { get; set; }
        public static ApiClient.SysUser User { get; set; }       

        public static bool HasPermission(string funtionId)
        {
           return true;      
        }
    
    }   
}
