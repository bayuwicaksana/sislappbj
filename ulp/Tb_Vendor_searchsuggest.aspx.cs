#define DEBUG
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
using SubSonic;
using Data;
#endregion

public partial class CTb_Vendor_Searchsuggest : AspNetRunnerPage
{
    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.Tb_Vendor";
        strTableNameLocale = "dbo_Tb_Vendor";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
                        CheckSecurity();

            bool suggestAllContent = true;
            bool searchAll = false;
            if(Request["start"] == null || (string)Request["start"] == "0")
            {
	            suggestAllContent=false;
            }

            string field = (string)Request["searchField"];
            string value = (string)Request["searchFor"];

            if(!string.IsNullOrEmpty(value))
            {
                Builder bldr = Factory.CreateBuilder();
                Smarty.Table tableInfo = bldr.Tables[strTableName];
                
                if (string.IsNullOrEmpty(field))
                {
                    searchAll = true;
                }

                List<string> fields = new List<string>();
                List<string> items = null;
                try
                {
	                                            if(string.IsNullOrEmpty(field))
                {
                    Field fieldInfo = tableInfo.Fields["KD_VENDOR"] as Field;
                    if(fieldInfo.FieldPermissions)
                    {
                        fields.Add("KD_VENDOR");
                    }
                }
                if (field=="KD_VENDOR")
	            {
                    field = "KD_VENDOR";
                    if(!bldr.Tables[strTableName].Fields[field].FieldPermissions)
                    {
                        throw new ArgumentException("Access denied");
                    }
                }
	                            	                            	                            	                            	                            	                            	                                            if(string.IsNullOrEmpty(field))
                {
                    Field fieldInfo = tableInfo.Fields["STATUS"] as Field;
                    if(fieldInfo.FieldPermissions)
                    {
                        fields.Add("STATUS");
                    }
                }
                if (field=="STATUS")
	            {
                    field = "STATUS";
                    if(!bldr.Tables[strTableName].Fields[field].FieldPermissions)
                    {
                        throw new ArgumentException("Access denied");
                    }
                }

                Data.Tb_VendorController controller = new Data.Tb_VendorController();
                    
		            items = searchAll ? controller.FetchForSearchSuggestAll(fields, value, suggestAllContent, OwnerColumn, OwnerID) :
                    controller.FetchForSearchSuggest(field, value, suggestAllContent, OwnerColumn, OwnerID);
                    }
                catch
                    {
                        items = new List<string>();
                        items.Add(string.Empty);
                }
                foreach (string item in items)
                {
                    //if (suggestAllContent)
                    //{
                        string str = item.Substring(0, item.Length > 50 ? 50 : item.Length);
                        int pos = my_stripos(str, value, 0);
                        if(pos < 0)
                        {
                            output.Append(str);
                        }
                        else
                        {
                            output.Append(str.Substring(0,pos) + "<b>" + str.Substring(pos, value.Length) + "</b>" + str.Substring(pos + value.Length));
                        }
                        output.Append("\n");
                    //}
                    //else
                    //{
                    //    output.Append("<b>" + item.Substring(0,value.Length) + "</b>" + value.Substring(value.Length, (item.Length > 50 ? 50 : item.Length) - value.Length) + "\n");
                    //}
                }
            }

            this.Response.Write(output.ToString());
            this.Response.End();
    }

    int my_stripos(string str, string needle, int offest)
    {
        if ( needle.Length == 0 ||str.Length ==0 )
        {
		    return -1;
        }
        return str.ToLower().IndexOf(needle.ToLower());
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
