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
using Data;
#endregion

public partial class CSKPD_Fulltext : AspNetRunnerPage
{
    IDictionary<string, object> keys = new Dictionary<string, object>();
    string field = string.Empty;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.SKPD";
        strTableNameLocale = "dbo_SKPD";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        field = (string)Request["field"];

        if(builder.Tables[strTableName].Fields[field].FieldPermissions)
        {
                if(!BaseCheckSecurity(OwnerID, "Search"))
        {
            DisplayCloseWindow();
        }
        else
        {
            BuildBody();
            output.Append(func.BuildOutput(this, @"~\SKPD_fulltext.aspx", smarty));
                }
            DisplayCloseWindow();
        }
        this.Response.Write(output.ToString());
        this.Response.End();
    }

    protected void DisplayCloseWindow()
    {
	    output.Append("<br>");
	    output.Append( "<hr size=1 noshade>");
	    output.Append( "<a href=# onClick='window.close();return false;'>" + "Close window" + "</a>");
    }

    protected void BuildBody()
    {
        keys["KODESKPD"] = Request["key1"];

        Data.SKPDController controller = new Data.SKPDController();
        string text = controller.FetchFullText(keys, field);
        text = Control.HTMLEncodeSpecialChars(text);
        text = text.Replace("\n", "<BR>").Replace("\r", "<BR>");
        output.Append(text);
    }
}
