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

public partial class CPENGGUNA_Lookupsuggest : AspNetRunnerPage
{
    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGGUNA";
        strTableNameLocale = "dbo_PENGGUNA";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
            string field = (string)Request["searchField"];
            string value = (string)Request["searchFor"];
            string lookupValue = (string)Request["lookupValue"];

            Builder builder = Factory.CreateBuilder();
            Smarty.Table tableInfo = builder.Tables[strTableName];
            Smarty.Field fieldInfo = tableInfo.Fields[field] as Field;

                        CheckSecurity();

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

        private bool CheckSecurity()
    {
        if(string.IsNullOrEmpty(UserName))
        { 
            MyUrl = this.Request.AppRelativeCurrentExecutionFilePath;
            this.Server.Transfer("~/login.aspx?message=expired");
	        return false;
        }
                if(!BaseCheckSecurity(OwnerID, "Search") && !BaseCheckSecurity(OwnerID, "Edit") && !BaseCheckSecurity(OwnerID, "Add"))
        {
	        return false;
        }
        return true;
    }
}
