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
using SubSonic;
using System.Web;
using System.Web.Security;
#endregion

public partial class CChangepwd : AspNetRunnerPage 
{
    IDictionary body;
    string message;
    string sUserName;
    string template;
    int go = 1;


    protected void Page_Load( object sender,  System.EventArgs e)  
    {
        
        body = new Hashtable();
        template = @"~\changepwd.aspx";

        if (this.Request["go"] != null)
        {
            go = int.Parse(this.Request["go"].ToString()) + 1;
        }

        CheckSecurity();

        if (Request.Form["btnSubmit"] != null && Request.Form["btnSubmit"].ToString() == "Submit")
        {
            ChangePassword();
        }
        
        BuildBody();
        output.Append(func.BuildOutput(this, template, smarty));
        this.Response.Write(output.ToString());
        this.Response.End();
    }

    private void CheckSecurity()
    {
        UserClass.CheckLogin(Page);
        if(User != null)
        {
            sUserName = User.UserName;
        }
        if (sUserName == "Guest" || sUserName == "") 
        {
            string sLoginURL = ConfigurationManager.AppSettings["LoginFile"];
            if (sLoginURL == string.Empty) sLoginURL = "login.aspx";
            Response.Redirect(sLoginURL);
        }
    }

    private void ChangePassword()
    {
		string sPwdOld = (string)Request.Form["opass"];
		string sPwdNew1 = (string)Request.Form["newpass"];

        
        
          
            if (UserClass.UserExist(sUserName, sPwdOld))
            {
                if(UserClass.ChangePassword(sUserName, sPwdOld, sPwdNew1))
                {
                    message = "Password was changed";
                    smarty.Add("backlink_attrs", "href=\"javascript:history.go(-" + go.ToString() + ")\"");
				    smarty.Add("body", true);
                    
                    
                    template = @"~\changepwd_success.aspx";
                }
            }
            else
            {
                message = "Invalid password";
            }
    }

    private void BuildBody()
    {
        smarty["backlink_attrs"] = "href=\"javascript:history.go(-" + go.ToString() + ")\"";
        if(!string.IsNullOrEmpty(message))
        {
	        smarty["message"] = message;
	        smarty["message_block"] = true;
        }

        body["begin"]="<script language=\"JavaScript\">" +
        "function validate()" +
        "{" + 
	        "if (document.forms.form1.cpass.value!=document.forms.form1.newpass.value)" +
	        "{	" +
		        "alert('" + Control.jsreplace("Passwords do not match. Re-enter password") +
		        "');" +
		        "document.forms.form1.newpass.value='';" +
		        "document.forms.form1.cpass.value='';" +
		        "document.forms.form1.newpass.focus();" +
		        "return false;" +
	        "}" +
	        "return true;" +
        "}" +
        "</script>" +
        "<form method=\"POST\" action=\"changepwd.aspx\" id=form1 name=form1 onsubmit=\"return validate();\">" +
        "<input type=hidden name=btnSubmit value=\"Submit\">" + 
        "<input type=hidden name=go value=\"" + go.ToString() + "\">";
        body["end"]="</form>";
        smarty["body"] = body;
    }
}

