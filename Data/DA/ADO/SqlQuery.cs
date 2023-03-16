using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Data.DA
{
   public class SqlQuery
    {
       public string QueryText
       {
           get;
           set;
       }

       public CommandType QueryType
       {
           get;
           set;
       }

       public SqlQuery()
       {

       }

       public SqlQuery(string sText, CommandType SType)
       {
           QueryText = sText;
           QueryType = SType;
       }

       public SqlQuery(string sText)
       {
           QueryText = sText;
           QueryType = CommandType.Text;
       }
    }
}
