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

public partial class CPOKJA_Fulltext : AspNetRunnerPage
{
    IDictionary<string, object> keys = new Dictionary<string, object>();
    string field = string.Empty;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.POKJA";
        strTableNameLocale = "dbo_POKJA";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        field = (string)Request["field"];

        if(builder.Tables[strTableName].Fields[field].FieldPermissions)
        {
                    BuildBody();
            output.Append(func.BuildOutput(this, @"~\POKJA_fulltext.aspx", smarty));
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
        keys["KODEPOKJA"] = Request["key1"];

        Data.POKJAController controller = new Data.POKJAController();
        string text = controller.FetchFullText(keys, field);
        text = Control.HTMLEncodeSpecialChars(text);
        text = text.Replace("\n", "<BR>").Replace("\r", "<BR>");
        output.Append(text);
    }
}
