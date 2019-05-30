#region " using "
using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Globalization;
using System.Text;
using System.IO;
using Smarty;
#endregion

public partial class CPENGADAAN_LANGSUNG_Lookupsuggest : AspNetRunnerPage
{
    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGADAAN_LANGSUNG";
        strTableNameLocale = "dbo_PENGADAAN_LANGSUNG";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            string field = (string)Request["searchField"];
            string value = (string)Request["searchFor"];
            string lookupValue = (string)Request["lookupValue"];

            Builder builder = Factory.CreateBuilder();
            Smarty.Table tableInfo = builder.Tables[strTableName];
            Smarty.Field fieldInfo = tableInfo.Fields[field] as Field;

            
            if(fieldInfo.LookupFields.Count == 0)
            {
                func.PopulateLookupFields(fieldInfo);
            }

            for(int i = 0; i < fieldInfo.LookupFields.Count && i < 40; ++ i)
            {
                if(fieldInfo.LookupFields[i].Display.StartsWith(value, StringComparison.CurrentCultureIgnoreCase))
                {
                    output.Append(fieldInfo.LookupFields[i].Link + "\n" + fieldInfo.LookupFields[i].Display + "\n");
                }
            }


            this.Response.Write(output.ToString());
            this.Response.End();
    }

    }
