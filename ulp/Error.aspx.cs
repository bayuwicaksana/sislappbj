using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;

public partial class Error : System.Web.UI.Page
{
    protected Exception _ex = new Exception();
    protected string _stack = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        _ex = (Exception)Session["LastError"];
        if (!string.IsNullOrEmpty(_ex.StackTrace))
        {
            StringBuilder sbTraces = new StringBuilder();
            string[] traces = _ex.StackTrace.Split(new char[] { '\r' });
            foreach (string trace in traces)
            {
                sbTraces.Append(trace).Append("<BR>");
            }
            _stack = sbTraces.ToString();
        }
    }
}