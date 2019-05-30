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
#endregion

public partial class CLogin : AspNetRunnerPage 
{
    IDictionary body;
    int mypage = 1;
    int gPageSize = 20;
    string myurl;
    string defaulturl;
    string message;
    string cUserName;
    string cPassword;
    string pUsername;
    string pPassword;
    string rememberbox_checked;
    string rememberbox_attrs;

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
            body = new Hashtable();

            rememberbox_checked="";
            rememberbox_attrs = "name=\"remember_password\" value=\"1\"";

            // mandatory entry so compiler knows what table is processing

            if(RequestAction == "logout")
            {
                Logout();
            }
            else
            {
                CreateDefaultUrl();
                if (Request.Form["btnSubmit"] != null && Request.Form["btnSubmit"].ToString() == "Login")
                {
                    if(Login())
                    {
                                                if(!string.IsNullOrEmpty(myurl))
                        {
		                    Response.Redirect(myurl);
                        }
	                    else
                        {
                            Response.Redirect(@"~\" + defaulturl);
                        }
                    }
                    else
                    {
                                            }
                }
                
            }

            BuildBody();
            output.Append(func.BuildOutput(this, @"~\login.aspx", smarty));
            this.Response.Write(output.ToString());
            this.Response.End();
    }

    private void BuildBody()
    {
        smarty.Add("rememberbox_attrs", rememberbox_attrs + rememberbox_checked);

        MyUrl = myurl;
        if(!string.IsNullOrEmpty(myurl))
        {
	        smarty.Add("guestlink_attrs","href=\"" + myurl + "\"");
        }
        else
        {
	        smarty.Add("guestlink_attrs","href=\"" + defaulturl + "\"");
        }

        if(Request.Form["username"] != null || Request["username"] != null)
        {
	        smarty.Add("username_attrs","value=\"" + Control.HTMLEncodeSpecialChars(pUsername) + "\"");
        }
        else
        {
            string user = string.Empty;
                if(this.Request.Cookies["username"] == null)
                { user = string.Empty;}
            else
                {user = this.Request.Cookies["username"].Value;}
	        smarty.Add("username_attrs","value=\"" + Control.HTMLEncodeSpecialChars(user) + "\"");
        }


        string password_attrs="onkeydown=\"e=event; if(!e) e = window.event; if (e.keyCode != 13) return; e.cancel = true; e.cancelBubble=true; document.forms[0].submit(); return false;\"";
        if(Request.Form["password"] != null)
        {
	        password_attrs += " value=\"" + Control.HTMLEncodeSpecialChars(pPassword) + "\"";
        }
        else
        {
            string password = string.Empty;
            if(this.Request.Cookies["username"] == null)
            {
                password = string.Empty;
            }
            else
            {
                password = this.Request.Cookies["password"].Value;
            }
	        password_attrs += " value=\"" + Control.HTMLEncodeSpecialChars(password) +"\"";
        }
        smarty.Add("password_attrs", password_attrs);

        if(Request["message"]=="expired")
        {
            message = "Your session has expired. Please login again.";
        }

        if(!string.IsNullOrEmpty(message))
        {
	        smarty.Add("message_block",true);
	        smarty.Add("message", message);
        }

        IDictionary<string,string> body = new Dictionary<string,string>();
        body["begin"]="<form method=post action=\"login.aspx\" id=form1 name=form1>" +
		        "<input type=hidden name=btnSubmit id=btnSubmit value=\"Login\">";
        body["end"]="</form>" +
        "<script>" +
        "document.forms[0].elements['username'].focus();" +
        "</script>";
        smarty.Add("body",body);
    }

    private bool Login()
    {
        
        
        pUsername = (string)Request.Form["username"];
        pPassword = (string)Request.Form["password"];

        
        if(Request.Cookies["username"] != null || Request.Cookies["password"] != null)
        {
	        rememberbox_checked=" checked";
        }

        if (Request.Form["btnSubmit"] != null &&  Request.Form["btnSubmit"].ToString() == "Login")
        {
	        if(Request.Form["remember_password"] != null &&  Request.Form["remember_password"].ToString() == "1")
	        {
                SetCookies(pUsername, pPassword, 365*1440*60);
		        rememberbox_checked=" checked";
	        }
	        else
	        {
		        ResetCookies();
		        rememberbox_checked="";
	        }

                        return LoginDatabase();
        }

        return false;
    }
        private bool LoginDatabase()
    {
        UserClass login = new UserClass();
        login = login.Login(pUsername, pPassword);
        if(login != null)
        {
            UserName = pUsername;
            User = login;
            AccessLevel = Control.ACCESS_LEVEL_USER;
            		        GroupID = login.GroupID;
            
            PENGGUNACollection usersCollection = 
            new PENGGUNACollection().Where("KODEPENGGUNA", pUsername).Load();

            PENGGUNA theUser = usersCollection[0];

                Session["_KELOMPOKPENGGUNA_OwnerID"] = theUser.KODEPENGGUNA;
                Session["_KELOMPOKPENGGUNA_OwnerColumn"] = "";

                Session["pusername"] = pUsername; //NIP Login // Needed for LPSE Query
                Session["pkelompok"] = theUser.KODEKELOMPOK; //NIP Login // Needed for LPSE Query

            return true;
        }
        else
        {
            message = "Invalid Login";
        }
        return false;
    }
        private void CreateDefaultUrl()
    {
        myurl = MyUrl;
        this.Session.Remove("MyURL");

        defaulturl = string.Empty;
                	        		        defaulturl="menu.aspx";
    }

    private void ProcessLanguge()
    {
            }

    private void SetCookies(string username, string password, int seconds)
    {
        HttpCookie userCookie= new HttpCookie("username");
        userCookie.Value = username;
        userCookie.Expires = DateTime.Now.AddSeconds(seconds);
        HttpCookie passwordCookie = new HttpCookie("password");
        passwordCookie.Expires = DateTime.Now.AddSeconds(seconds);
        passwordCookie.Value = password;
    }

    private void ResetCookies()
    {
        SetCookies(string.Empty, string.Empty, -365*1440*60);
    }

    private void Logout()
    {
        ResetCookies();
        UserName = null;
        User = null;
        AccessLevel = null;
        GroupID = null;
            Session.Remove("_KELOMPOKPENGGUNA_OwnerID");
            Session.Remove("_KELOMPOKPENGGUNA_OwnerColumn");
            Session.Remove("pusername");

        Response.Redirect(@"~\login.aspx");
    }
}

