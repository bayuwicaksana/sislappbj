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

public partial class CKELENGKAPANPBJ_Addnewitem : AspNetRunnerPage
{
    protected string table="";
    protected string linkfield="";
    protected string dispfield="";
    protected string categoryField = "";
    protected string category= "";
    protected string categoryvalue="";
    protected string field="";
    protected string obj = "";
    protected string data0 = "";
    protected string data1 = "";
    protected string data2 = "";
    protected string element = "";
    protected string dispelement = "";
    protected bool fastType = false;
    protected bool useAjax = false;
    protected MODE mode;
    protected string id = "";
    protected string saveMsg = "Save";
    protected string closeWindowMsg = "Close window";

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.KELENGKAPANPBJ";
        strTableNameLocale = "dbo_KELENGKAPANPBJ";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        field = (string)Request["field"];
        id = (string)Request["id"];

                if(!CheckSecurity())
        {
            return;
        }

        if(!string.IsNullOrEmpty(categoryField))
        {
	        categoryvalue= (string)Request["category"];
        }

        Builder builder = Factory.CreateBuilder();
        Smarty.Table tableInfo = builder.Tables[strTableName];
        Smarty.Field fieldInfo = tableInfo.Fields[field] as Field;

        smarty.Add("add_new_item", true);

        fastType = fieldInfo.FastType;
        useAjax = true;

        if(!CheckAddNewItemAllowed(field))
        {
	        return;
        }

        if(Request["newitem"] != null)
        {
            obj = Control.GoodFieldName(field);
        }

        mode = Control.FromString((string)Request["mode"]);

        if ( fastType && useAjax) 
        {
            smarty.Add("fastTypeNAjax", true);
	        if ( mode == MODE.MODE_INLINE_EDIT || mode == MODE.MODE_INLINE_ADD ) 
	        {
		        element="window.opener.document.getElementById('" + id + "')";
		        dispelement="window.opener.document.getElementById('display_" + id + "')";
	        }
	        else
	        {
		        element="window.opener.document.forms.editform.value_" + obj;
		        dispelement="window.opener.document.forms.editform.display_value_" + obj;
	        }
            smarty.Add("dispelement", dispelement);
            smarty.Add("element", element);
            smarty.Add("data1", data1);
            smarty.Add("data2", data2);
        }
        else
        {
            smarty.Add("notfastTypeNAjax", true);
            if ( mode == MODE.MODE_INLINE_EDIT || mode == MODE.MODE_INLINE_ADD ) 
            {
		        element="window.opener.document.getElementById('"+ id + "')";
            }
	        else
            {
		        element="window.opener.document.forms.editform.value_" + obj;
            }

            if(!string.IsNullOrEmpty(categoryField) && !useAjax)
            {
                smarty.Add("notAjaxcategoryField", true);
            }

            smarty.Add("dispelement", dispelement);
            smarty.Add("element", element);
            smarty.Add("data1", data1);
            smarty.Add("data2", data2);
            smarty.Add("data0", data0);
            smarty.Add("obj", obj);
            smarty.Add("category", category);
        }

        smarty.Add("save_msg", saveMsg);
        smarty.Add("close_window_msg", closeWindowMsg);

        this.Response.Write(func.BuildOutput(this, @"~\KELENGKAPANPBJ_addnewitem.aspx", smarty));
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
                if(!BaseCheckSecurity(OwnerID, "Edit") && !BaseCheckSecurity(OwnerID, "Add"))
        {
	        return false;
        }
        return true;
    }

    private bool CheckAddNewItemAllowed(string field)
    {
	    return false;
    }
}
