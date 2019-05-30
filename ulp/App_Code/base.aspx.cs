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
using System.Xml;
using System.Data.SqlClient;
#endregion

public class AspNetRunnerPage : System.Web.UI.Page
{
    protected string strTableName;
    protected string strTableNameLocale;
    protected Dictionary<string, object> smarty = new Dictionary<string, object>();
    protected Language lang = null;
    protected Builder builder = null;
    protected StringBuilder output = new StringBuilder();
    protected bool useAJAX = true;
    protected string sCulture;
    protected int nCulture;
    protected Dictionary<string, string> tableCaptions = new Dictionary<string, string>();

    protected object SessionPropertyGet(string name, object default_value)
    {
        object sessionVal = this.Session[name];
        if (sessionVal == null)
        {
            return default_value;
        }
        return sessionVal;
    }

    static public IDictionary<string, string> GetTableCaptions(XmlNode parent, string lang)
    {
        XmlNode langNode = parent.SelectSingleNode("//Language[@Title='" + lang + "']");
        IDictionary<string, string> tableCaptions = new Dictionary<string, string>();
        foreach (XmlNode tableNode in langNode.ChildNodes)
        {
            string title = tableNode.Attributes["Title"].Value;
            string caption = tableNode.Attributes["Caption"].Value;
            tableCaptions.Add(title, caption);
        }
        return tableCaptions;
    }

    static public IDictionary<string, string> GetFieldCaptions(XmlNode parent, string lang, string table)
    {
        XmlNode tableNode = parent.SelectSingleNode("//Language[@Title='" + lang + "']/Table[@Title='" + table + "']");
        IDictionary<string, string> fieldCaptions = new Dictionary<string, string>();
        foreach (XmlNode fieldNode in tableNode.ChildNodes)
        {
            string title = fieldNode.Attributes["Title"].Value;
            string caption = fieldNode.Attributes["Caption"].Value;
            fieldCaptions.Add(title, caption);
        }
        return fieldCaptions;
    }

    protected void AddCustomMarkup()
    {
        //if (File.Exists(this.MapPath("~/include/header.aspx")))
        //{
        //    smarty["header"] = File.ReadAllText(this.MapPath("~/include/header.aspx"));
        //}

		//show appropriate menu based on user group
        SqlConnection myConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        string ssql = "select distinct kodekelompok from pengguna where KODEPENGGUNA = '"+UserName+"';";
        SqlCommand myCommand = new SqlCommand();
        myCommand.CommandText = ssql;
        myCommand.CommandType = CommandType.Text;
        myCommand.Connection = myConnection;
        myConnection.Open();
        SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
        while (myReader.Read())
            {
				if (myReader.GetValue(0).ToString() == "DLP") {
					smarty["header"] = File.ReadAllText(this.MapPath("~/include/header_admin.aspx"));
				} else if (myReader.GetValue(0).ToString() == "SEKRETARIAT") {
					smarty["header"] = File.ReadAllText(this.MapPath("~/include/header_ulp.aspx"));
				} else if (myReader.GetValue(0).ToString() == "ANGGOTA") {
					smarty["header"] = File.ReadAllText(this.MapPath("~/include/header_other.aspx"));
				} else if (myReader.GetValue(0).ToString() == "SKPD") {
					smarty["header"] = File.ReadAllText(this.MapPath("~/include/header_skpd.aspx"));
				} else if (myReader.GetValue(0).ToString() == "UMUM") {
					smarty["header"] = File.ReadAllText(this.MapPath("~/include/header_sekretaris.aspx"));
				}
				//Response.Write(myReader.GetValue(0).ToString());
				//Response.End();
            }
        myReader.Close();

        if (File.Exists(this.MapPath("~/include/footer.aspx")))
        {
            smarty["footer"] = File.ReadAllText(this.MapPath("~/include/footer.aspx"));
        }
    }

    
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        builder = Factory.CreateBuilder();
        sCulture = ConfigurationManager.AppSettings["LCID"];
        if (!String.IsNullOrEmpty(sCulture)) 
        {
            nCulture = int.Parse(sCulture);
            smarty.Add("LCID", nCulture);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(nCulture, false);
        } 
        smarty.Add("__table", strTableName);
        AddCustomMarkup();
        

        if (string.IsNullOrEmpty(UserName))
        {
	        UserName = "Guest";
	        GroupID = "<Guest>";
	        AccessLevel = Control.ACCESS_LEVEL_GUEST;
            UserClass  UserLogin = new UserClass();
            UserLogin.UserID = "Guest";
            UserLogin.GroupID = "<Guest>";
            UserLogin.UserName = "Guest";
            User = UserLogin;
        }
    }

    protected void SessionPropertySet(string name, object val)
    {
        this.Session[name] = val;
    }

    protected string OwnerID
    {
        get
        {
            object id = SessionPropertyGet("_" + strTableName + "_OwnerID", null);
            if(id == null)
            {
                return string.Empty;
            }
            return id.ToString();
        }
        set
        {
            SessionPropertySet("_" + strTableName + "_OwnerID", value);
        }
    }

    protected string OwnerColumn
    {
        get
        {
            return (string)SessionPropertyGet("_" + strTableName + "_OwnerColumn", string.Empty);
        }
        set
        {
            SessionPropertySet("_" + strTableName + "_OwnerColumn", value);
        }
    }

    protected bool BaseCheckSecurity(string action)
    {
                return func.CheckSecurity(strTableName, action, OwnerID);
    }

    protected bool BaseCheckSecurity(string owner, string action)
    {
                return func.CheckSecurity(strTableName, action, owner);
    }

    protected string Language
    {
        get
        {
            return (string)SessionPropertyGet("language", string.Empty);
        }
        set
        {
            SessionPropertySet("language", value);
        }
    }

    protected XmlDocument LocaleXML
    {
        get
        {
            return (XmlDocument)SessionPropertyGet("locale_xml", null);
        }
        set
        {
            SessionPropertySet("locale_xml", value);
        }
    }

    protected string RequestAction
    {
        get
        {
            object action = this.Request["a"];
            if(action != null)
            {
                return action.ToString();
            }
            return string.Empty;
        }
    }

    protected string AccessLevel
    {
        get
        {
            return (string)SessionPropertyGet("AccessLevel", string.Empty);
        }
        set
        {
            SessionPropertySet("AccessLevel", value);
        }
    }

    protected string MyUrl
    {
        get
        {
            return (string)SessionPropertyGet("MyUrl", string.Empty);
        }
        set
        {
            SessionPropertySet("MyUrl", value);
        }
    }

    protected string OrderBy
    {
        get
        {
            return (string)SessionPropertyGet(strTableName + "_orderby", string.Empty);
        }
        set
        {
            SessionPropertySet(strTableName + "_orderby", value);
        }
    }

    protected string UserName
    {
        get
        {
            return (string)SessionPropertyGet("UserName", string.Empty);
        }
        set
        {
            SessionPropertySet("UserName", value);
        }
    }

    protected string GroupID
    {
        get
        {
            return (string)SessionPropertyGet("GroupID", string.Empty);
        }
        set
        {
            SessionPropertySet("GroupID", value);
        }
    }

    protected UserClass User
    {
        get
        {
            return (UserClass)SessionPropertyGet("User", null);
        }
        set
        {
            SessionPropertySet("User", value);
        }
    }

    protected bool UserCan(string action)
    {
        if(AccessLevel == Control.ACCESS_LEVEL_ADMIN)
        {
            return true;
        }
                bool perm = func.CheckUserPermissions("AKTOR", "EDSP");

        if( perm )
        {
            return true;
        }

        return false;
    }
}
