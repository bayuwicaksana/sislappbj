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

public partial class CTIPEAKTOR_View : AspNetRunnerPage
{
    string filename="";	
    string message="";
    string all = string.Empty;
    string pdf = string.Empty;
    int mypage = 1;
    int id = 1;
    IDictionary<string, object> key = new Dictionary<string, object>();
    string templatefile = string.Empty;

    Data.TIPEAKTORController controller = new Data.TIPEAKTORController();
    Data.TIPEAKTOR item = null;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.TIPEAKTOR";
        strTableNameLocale = "dbo_TIPEAKTOR";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        all = (string)Request["all"];
        pdf = (string)Request["pdf"];

	        key.Add("KODETIPE", Request["editid1"]);

                CheckSecurity();
        BuildForm();
        BuildBody();
        BuildPdfControl();
        output.Append(func.BuildOutput(this, @"~\TIPEAKTOR_view.aspx", smarty));
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
                if(!BaseCheckSecurity(OwnerID, "Search") && !BaseCheckSecurity(OwnerID, "View"))
        {
                }
        return true;
    }

    private void BuildForm()
    {
        if(key.Count > 1)
        {
            item = controller.FetchByManyID(key);
        }
        else
        {
            item = Data.TIPEAKTOR.FetchByID(Request["editid1"]);
        }
	                        Control control_key_KODETIPE = new Control("KODETIPE", item.KODETIPE, false, smarty, this.Request, builder, MODE.MODE_VIEW);
                smarty.Add("show_key1", Control.HTMLEncodeSpecialChars(control_key_KODETIPE.GetData()));
        if(item != null)
        {

            string value="";
            string keylink = string.Empty;
	        keylink +="&key1=" + Control.HTMLEncodeSpecialChars(this.Server.UrlEncode(item.KODETIPE.ToString()));

        //	KODETIPE - 
                Control control_KODETIPE = new Control("KODETIPE", item.KODETIPE, false, smarty, this.Request, builder, MODE.MODE_VIEW);
	                                value = control_KODETIPE.GetData();
			        value = control_KODETIPE.ProcessLargeText(value,"field=KODETIPE" + keylink,"",MODE.MODE_VIEW);
            smarty.Add("KODETIPE_value",value);
	        smarty.Add("KODETIPE_fieldblock",true);

        //	DESKRIPSI - 
                Control control_DESKRIPSI = new Control("DESKRIPSI", item.DESKRIPSI, false, smarty, this.Request, builder, MODE.MODE_VIEW);
	                                value = control_DESKRIPSI.GetData();
			        value = control_DESKRIPSI.ProcessLargeText(value,"field=DESKRIPSI" + keylink,"",MODE.MODE_VIEW);
            smarty.Add("DESKRIPSI_value",value);
	        smarty.Add("DESKRIPSI_fieldblock",true);
        }
    }

    private void BuildBody()
    {
        IDictionary<string, string> body = new Dictionary<string, string>();
        body["begin"]="";
                
        smarty.Add("body",body);
        smarty.Add("style_block",true);
        smarty.Add("stylefiles_block",true);
    }

    protected void BuildPdfControl()
    {
        if(string.IsNullOrEmpty(pdf) && string.IsNullOrEmpty(all))
        {
	        smarty.Add("back_button",true);
	        smarty.Add("backbutton_attrs","onclick=\"window.location.href='TIPEAKTOR_list.aspx?a=return'\"");
        }

        string oldtemplatefile = templatefile;
        templatefile = @"~\TIPEAKTOR_view.aspx";
    }
}
