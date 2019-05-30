#region "using"
using System;
using System.Configuration;
using System.Data;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using SubSonic;
using Data;
using System.Data.Common;
using Smarty;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;
using System.Xml;
using System.Net.Mail;
#endregion
public class func 
{

    public static string BuildOutput(System.Web.UI.Page page, string template, Dictionary<string, object> smarty)
    {
        string path = page.Server.MapPath(template);
        string source = File.ReadAllText(path);
        //int index = source.IndexOf("\n");
        string output = null;
        //if (index > 0)
        //{
            //source = source.Substring(index);
            Compiler compiler = new Compiler(smarty, page);
            compiler.Builder = Factory.CreateBuilder();
            output = compiler.Run(source);
        //}
        return output;
    }

    public static List<string> GetSelection(string[] columns, string[] selection)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < columns.Length; ++i)
        {
            result.Add(string.Empty);
            for (int j = 0; j < selection.Length; ++j)
            {
                string[] ids = selection[j].Split(new char[] { '&' });
                if (ids.Length < columns.Length)
                {
                    throw new ArgumentOutOfRangeException("Must be equal or more than columns.Length", "ids.Length");
                }
                result[i] += ids[i] + '\0';
            }
        }
        
        return result;
    }

    public static void PopulateLookupFields(Field field)
    {
        if (string.IsNullOrEmpty(field.LookupTable))
        {
            return;
        }
        DataProvider provider = DataService.Providers["MyProvider"];
        if (Path.HasExtension(field.LookupTable))
        {
            field.LookupTable = Path.GetExtension(field.LookupTable).Substring(1);
        }
        Query qry = new Query(DataService.GetSchema(field.LookupTable, provider.Name, TableType.Table));
        qry.SelectList = field.LinkField;
        if (field.LinkField != field.DisplayField)
        {
            qry.SelectList += "," + field.DisplayField;
        }
        if (field.UseCategory && !string.IsNullOrEmpty(field.CategoryControlField))
        {
            qry.SelectList += "," + field.CategoryControlField;
        }
        if (!string.IsNullOrEmpty(field.Where))
        {
            qry.WHERE(field.Where);
        }

        if (field.Parent != null && field.Parent.Value != null && !string.IsNullOrEmpty(field.Parent.Value.ToString()))
        {
            qry.WHERE(field.CategoryControlField, field.Parent.Value);
        }

        if (field.Unique)
        {
            qry.DISTINCT();
        }

        if (!string.IsNullOrEmpty(field.OrderBy))
        {
	        if(field.Desc)
            {
	            qry.OrderBy = SubSonic.OrderBy.Desc(field.OrderBy);
            }
            else
            {
	            qry.OrderBy = SubSonic.OrderBy.Asc(field.OrderBy);
            }
        }

        field.LookupFields.Clear();
        string[] values = null;
        if(field.Multiselect)
        {
            if (field.Value != null)
            {
                values = field.Value.ToString().Split(new char[]{','});
            }
        }


        IDataReader reader = qry.ExecuteReader();
        while (reader.Read())
        {
            LookupField newField = null;
            object link = reader[0] ?? string.Empty;
            if (field.LinkField != field.DisplayField)
            {
                object display = reader[1] ?? string.Empty;
                newField = new LookupField(link.ToString(),
                display.ToString());
            }
            else
            {
                newField = new LookupField(link.ToString(),
                    link.ToString());
            }
            object val = field.Value ?? string.Empty;
            if(field.Multiselect && values != null)
            {
                foreach(string msvalue in values)
                {
                    if (link.ToString() == msvalue)
                    {
                        newField.Selected = true;
                    }
                }
            }
            else
            {
                if (link.ToString() == val.ToString())
                {
                    newField.Selected = true;
                }
            }
            field.LookupFields.Add(newField);
        }
        reader.Close();
    }

    public static string GetLookupValue(Field field)
    {
        string result = string.Empty;
        if(field.Value != null)
        {
            result = field.Value.ToString();
        }
        if (string.IsNullOrEmpty(field.LookupTable) || string.IsNullOrEmpty(field.DisplayField))
        {
            return result;
        }
        DataProvider provider = DataService.Providers["MyProvider"];
        if (Path.HasExtension(field.LookupTable))
        {
            field.LookupTable = Path.GetExtension(field.LookupTable).Substring(1);
        }
        Query qry = new Query(DataService.GetSchema(field.LookupTable, provider.Name, TableType.Table));
        qry.SelectList = field.DisplayField;

        qry.WHERE(field.LinkField, field.Value);

        IDataReader reader = qry.ExecuteReader();
        while (reader.Read())
        {
            object display = reader[0] ?? string.Empty;
            result = display.ToString();
            break;
        }
        reader.Close();
        return result;
    }

    public static List<LookupField> LoadSelectContent(Field src, object value, object fvalue)
    {
        List<LookupField> results = new List<LookupField>();

        if (string.IsNullOrEmpty(src.LookupTable) || value == null)
        {
            return results;
        }

        if (string.IsNullOrEmpty(value.ToString()))
        {
            return results;
        }
        DataProvider provider = DataService.Providers["MyProvider"];
        if (Path.HasExtension(src.LookupTable))
        {
            src.LookupTable = Path.GetExtension(src.LookupTable).Substring(1);
        }
        Query qry = new Query(DataService.GetSchema(src.LookupTable, provider.Name, TableType.Table));
        qry.SelectList = src.LinkField;
        if (src.LinkField != src.DisplayField)
        {
            qry.SelectList += "," + src.DisplayField;
        }
        if (src.UseCategory && !string.IsNullOrEmpty(src.CategoryControlField))
        {
            qry.SelectList += "," + src.CategoryControlField;
        }
        if (!string.IsNullOrEmpty(src.Where))
        {
            qry.WHERE(src.Where);
        }
        if (src.UseCategory && !string.IsNullOrEmpty(src.CategoryControl))
        {
            qry.AddWhere(src.CategoryControlField, value);
        }
        if (src.Unique)
        {
            qry.DISTINCT();
        }

        if (!string.IsNullOrEmpty(src.OrderBy))
        {
            if (src.Desc)
            {
                qry.OrderBy = SubSonic.OrderBy.Desc(src.OrderBy);
            }
            else
            {
                qry.ORDER_BY(src.OrderBy);
            }
        }

        IDataReader reader = qry.ExecuteReader();
        while (reader.Read())
        {
            object link = reader[0] ?? string.Empty;
            object display = reader[1] ?? string.Empty;
            if (src.LinkField != src.DisplayField)
            {
                results.Add(new LookupField(link.ToString(),
                display.ToString()));
            }
            else
            {
                results.Add(new LookupField(link.ToString(),
                    link.ToString()));
            }
        }
        reader.Close();

        return results;
    }

    public static string AddLinkPrefix(string field, string link, string table)
    {
        if (!link.StartsWith("mailto:") && link.Substring(1, 3) == "://")
        {
            return Factory.CreateBuilder().Tables[table].Fields[field].LinkPrefix + link;
        }

        return link;
    }

    public static string WrapWithBrackets(string wrappie)
    {
        if (string.IsNullOrEmpty(wrappie))
        {
            return wrappie;
        }

        StringBuilder result = new StringBuilder();

        if (!wrappie.StartsWith("["))
        {
            result.Append("[");
        }
        result.Append(wrappie);
        if (!wrappie.EndsWith("]"))
        {
            result.Append("]");
        }

        return result.ToString();
    }

public static DateTime str2date(String sDate, string sFormat)
{
  if (sDate == string.Empty) return DateTime.MinValue;
    if (sFormat == "CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern")
        sFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
  sDate = sDate.Trim(); 
    if (sFormat.IndexOfAny("ms:".ToCharArray()) >= 0 && sDate.Length < 19)
    {
        if (sDate.Split(" ".ToCharArray()).Length > 1 && sDate.Length == 16)
        {
            sDate += ":00";
        }
        else sDate += " 00:00:00";
    } 
    return System.Xml.XmlConvert.ToDateTime(sDate, sFormat);
}

public static String date2str(DateTime dtDate, string sFormat)
{
  if (dtDate == DateTime.MinValue) return string.Empty;
    if (sFormat == "CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern")
       sFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
    return System.Xml.XmlConvert.ToString(dtDate, sFormat);
}

    public static string GetDateFormat(bool time)
    {
		string dateFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
		if (time) dateFormat += " HH:mm:ss";
        return dateFormat;
    }
public static void GetMenu(DropDownList ddlQuickJump, string sCaption) 
{
    ddlQuickJump.Items.Clear();
    ddlQuickJump.Items.Add(new ListItem("Back to menu", "menu.aspx"));
    if (ddlQuickJump.Items.FindByText(sCaption) == null ) 
    {
        ddlQuickJump.Items.Add(new ListItem("", ""));
        ddlQuickJump.Items.FindByText("").Selected = true;
    } 
    else ddlQuickJump.Items.FindByText(sCaption).Selected = true;
}
public static DbDataReader GetSqlDataSource(string sSQLSelect)
{
    QueryCommand cmd = new QueryCommand(sSQLSelect);
    DbDataReader reader = (DbDataReader)DataService.GetReader(cmd);
    return reader;
}

    public static string GetTotals(string field, IList<string> argvalue, string stype, string sFormat, int nCulture, Dictionary<string, object> smarty, Builder builder, HttpRequest request, Smarty.MODE mode)
    {
        double value = 0.0;
        if(argvalue.Count == 0)
        {
            return string.Empty;
        }
        if(stype != "COUNT")
        {
            foreach(string listValue in argvalue)
            {
                double testVal;
                if(double.TryParse(listValue, out testVal))
                {
                    value += testVal;
                }
            }
        }
	    if(stype=="AVERAGE")
	    {
		    if(argvalue.Count > 0)
            {
			    value = Math.Round(value/argvalue.Count, 2);
            }
		    else
            {
			    return string.Empty;
            }
	    }

	    string sValue = string.Empty;
        FORMAT format = Control.StringToFormat(sFormat);

	    if(format == FORMAT.FORMAT_CURRENCY)
        {
            CultureInfo ci = new CultureInfo(nCulture);
            sValue = value.ToString("C3", ci);
        }
	    else if(format == FORMAT.FORMAT_PERCENT)
        {
            CultureInfo ci = new CultureInfo(nCulture);
            sValue = value.ToString("P", ci);
        }
	    else if(format == FORMAT.FORMAT_NUMBER)
        {
 		    CultureInfo ci = new CultureInfo(nCulture);
            sValue = value.ToString("N", ci);
        }
	    else if(format == FORMAT.FORMAT_CUSTOM && stype!="COUNT")
        {
            Control control = new Control(field, value, false, smarty, request, builder, mode);
 		    sValue = control.GetData();
        }
	    else 
        {
 		    sValue = value.ToString();
        }

	    if(stype == "COUNT") 
		    return argvalue.Count.ToString();
	    if(stype == "TOTAL") 
		    return sValue;
	    if( stype=="AVERAGE") 
		    return sValue;
	    return string.Empty;
    }

public static string  GetLookupValue( string  sDisplayField,  string  sLinkField,  string  sTable,  string  sValue,  TypeCode TType)
{
    return GetLookupValue(sDisplayField, sLinkField, sTable, sValue, TType, false);
}
public static string  GetLookupValue( string  sDisplayField,  string  sLinkField,  string  sTable,  string  sValue,  TypeCode TType, bool isMultiline)
{
    string sGetLookupValue = "";
    
    string sqlSelect = "SELECT " + sDisplayField + " FROM " + sTable + " WHERE ";
    try
    {
        QueryCommand cmd = new QueryCommand(sqlSelect);
        if (isMultiline)
        {
            int i = 0;
            foreach (string s in sValue.Split(','))
            {
                string paramName = "param" + i.ToString();
                cmd.CommandSql += sLinkField + "=@" + paramName + " Or ";
                cmd.AddParameter(paramName, s);
                i += 1;
            }
           if (cmd.CommandSql.Length > 2) cmd.CommandSql = cmd.CommandSql.Remove(cmd.CommandSql.Length - 3);
        }
        else
        {
            cmd.CommandSql += sLinkField + "= @LinkField";
            cmd.AddParameter("LinkField", sValue);
        }
        
        System.Data.Common.DbDataReader dbDr = (System.Data.Common.DbDataReader)DataService.GetReader(cmd);
        if (dbDr.HasRows) 
        {
            if (isMultiline)
            {
                while (dbDr.Read()) {sGetLookupValue += dbDr[0].ToString() + ","; }               
                sGetLookupValue = sGetLookupValue.Trim(",".ToCharArray());
            }
            else if (dbDr.Read()) sGetLookupValue = dbDr[0].ToString();
        }    
    dbDr.Dispose();
    }    
    finally
    {
    }
    return sGetLookupValue;
}

//Upload binary file
public static object GetBinary(ref FileUpload _InputFile) 
{
  if (_InputFile.PostedFile != null )
  {
    int iImageSize = _InputFile.PostedFile.ContentLength;
        if ( iImageSize == 0 ) throw new System.Exception(" File '" + _InputFile.PostedFile.FileName + "' not found<br>");
        
    System.IO.Stream ImageStream = _InputFile.PostedFile.InputStream;
        byte[] ImageContent = new byte[iImageSize];
        ImageStream.Read(ImageContent, 0, iImageSize);
        return ImageContent;
  }
  else return DBNull.Value;
}
 
public static string ProcessLargeText( string  sValue,  int iNumberOfChars, string tableName, string param) 
{
    string sProcessLargeText = "";
    if ( sValue.TrimStart().StartsWith("<a href")  || sValue == "" || sValue == "&nbsp;" ) return sValue;
    if ( iNumberOfChars > 0 ) 
    {
        if ( sValue.Length > iNumberOfChars && !sValue.TrimStart().StartsWith("<a href") ) 
        {
                sProcessLargeText = sValue.Substring(0, iNumberOfChars).Replace("'","\'")
                + " <a href=\"#\" onClick=\"javascript: pwin = window.open('',null,'height=300,width=400,status=yes,resizable=yes,toolbar=no,menubar=no,location=no,left=150,top=200,scrollbars=yes'); "
                + "pwin.location='" + tableName + "_fulltext.aspx?" + HttpUtility.HtmlEncode(param) + "';"
                + "return false;\">" + "More" + "&nbsp;...</a>";
        }
    }
    return sProcessLargeText; 
}


public static bool IsAdminUser()
{
        if (System.Web.HttpContext.Current.Session["User"] == null) return false;

    string  sUserAdmin = GetOptions("AdminID");
    string  sUserName = ((UserClass)System.Web.HttpContext.Current.Session["User"]).UserName;

    return sUserAdmin == sUserName && sUserAdmin != "";
}

public static bool CheckSecurity( string  sTable,  string  sAction,  string  sOwnerID) 
{
    if(string.IsNullOrEmpty(sTable) || string.IsNullOrEmpty(sAction) || string.IsNullOrEmpty(sOwnerID))
    {
        return true;
    }
	if (System.Web.HttpContext.Current.Session["User"] == null) return false;
	string  sUserID = ((UserClass)System.Web.HttpContext.Current.Session["User"]).GetUserOwnerID(sTable);
    bool hasPermission = CheckUserPermissions(sTable, sAction);
    bool isAdmin = IsAdminUser();
    string advSecurityMethod = GetsAdvSecurityMethod(sTable);
    return hasPermission && ((sOwnerID == sUserID) || isAdmin 
       || advSecurityMethod == "0" || (advSecurityMethod == "2" && sAction.ToLower().IndexOfAny("s".ToCharArray()) > -1) );
}

public static bool CheckUserPermissions( string  sTable,  string  sAction) 
{

    if (System.Web.HttpContext.Current.Session["User"] == null) return false;
    if ( IsAdminUser() ) return true;

    XmlDocument myXmlDocument = GetConfigXML("");

    if ( myXmlDocument.DocumentElement.SelectSingleNode("/Security/Tables/Table") == null ) return true;

	if (sTable.StartsWith("[") && sTable.EndsWith("]")) sTable = sTable.Substring(1, sTable.Length - 2);
    string  sDefautPremissons = "";
    if ( GetTableProp(sTable, "DEFAULT") != null ) sDefautPremissons = GetTableProp(sTable, "DEFAULT").ToLower();
    sAction = sAction.ToLower();
    if ( myXmlDocument.DocumentElement.SelectSingleNode("/Security/Tables/Table/UserGroups/User") == null ) return (sDefautPremissons.IndexOfAny(sAction.ToCharArray()) > -1);

    string  sUserName = ((UserClass)System.Web.HttpContext.Current.Session["User"]).GroupID;
    string  sPath = "/Security/Tables/Table[@Name='" + sTable + "']/UserGroups/User[@Name='" + sUserName + "']";
    XmlNode node = myXmlDocument.DocumentElement.SelectSingleNode(sPath);

    if ( node != null ) 
    {
        if ( node.Attributes["Permission"] == null ) return (sDefautPremissons.IndexOfAny(sAction.ToCharArray()) > -1);
        else return (node.Attributes["Permission"].Value.ToLower().IndexOfAny(sAction.ToCharArray()) > -1);
    }
    else return (sDefautPremissons.IndexOfAny(sAction.ToCharArray()) > -1);
}

public static string GetCurrentUserID()
{
  if (System.Web.HttpContext.Current.Session["User"] == null) return "";
    return ((UserClass)(System.Web.HttpContext.Current.Session["User"])).UserID;
}

public static string  GetsAdvSecurityMethod( string  sTableName) 
{
  return GetTableProp(sTableName, "AdvSecurityMethod");
}

public static string GetFieldUserOwnerID(string sTableName)
{
    return GetTableProp(sTableName, "FieldUserOwnerID");
}

public static string  GetOwnerIDField( string  sTableName) 
{
  return GetTableProp(sTableName, "OwnerIDField");
}

public static string  GetTableProp( string  sTableName,  string  sPropertyName)
{
    XmlDocument myXmlDocument = GetConfigXML("");
    string  sPath = "/Security/Tables/Table[@Name='" + sTableName + "']";
    XmlNode node = myXmlDocument.DocumentElement.SelectSingleNode(sPath);

  if (node == null) return "";
    else return node.Attributes[sPropertyName].Value;

}

public static string  GetOptions( string  sOptionsName) 
{
  string sGetOptions = "";
    try 
  {
    XmlDocument myXmlDocument = GetConfigXML("");
        XmlNode node = myXmlDocument.DocumentElement.SelectSingleNode("/Security/Options");
        sGetOptions = node.Attributes[sOptionsName].Value;
    }
  catch
  {
            //throw new System.Exception("Attribute '" + sOptionsName + "' not found in security options file :" + ex.Message)
    sGetOptions = "";
    }
    return sGetOptions;
}

private static XmlDocument GetConfigXML( string  sXmlFileName )
{
  if ( System.Web.HttpContext.Current.Session["XmlDocument"] == null ) 
  {
    try 
    {
      if ( sXmlFileName == "" ) sXmlFileName = ConfigurationManager.AppSettings["TablesFile"];
      XmlDocument myXmlDocument = new XmlDocument();
            myXmlDocument.Load(System.Web.HttpContext.Current.Server.MapPath(sXmlFileName));
            return myXmlDocument;
        } 
    catch (Exception ex)
    {
          throw new System.Exception("Security file '" + sXmlFileName + "' not correct : " + ex.Message);
    }
  }
  else return (XmlDocument)System.Web.HttpContext.Current.Session["XmlDocument"];      
}
public static void SendMail( string  mailTo,  string  subj,  string  body) 
{
    string mailSender = ConfigurationManager.AppSettings["MailSender"];
    string mailSmtpServer = ConfigurationManager.AppSettings["MailSmtpServer"];
    string mailSmtpPort = ConfigurationManager.AppSettings["MailSmtpPort"];
    string mailSMTPUser = ConfigurationManager.AppSettings["MailSMTPUser"];
    string mailSMTPPassword = ConfigurationManager.AppSettings["MailSMTPPassword"];

    if (string.IsNullOrEmpty(mailSender) || string.IsNullOrEmpty(mailTo)) return;
    MailMessage mail = new MailMessage(mailSender, mailTo, subj, body);

    //send the message
    SmtpClient smtp = new SmtpClient(mailSmtpServer);
    if(string.IsNullOrEmpty(mailSmtpPort))
    {
        mailSmtpPort = "25";
    }
    smtp.Port = Convert.ToInt32(mailSmtpPort);

    if (mailSMTPUser != null && mailSMTPUser != "")
    {
        //to authenticate we set the username and password properites on the SmtpClient
        smtp.Credentials = new System.Net.NetworkCredential(mailSMTPUser, mailSMTPPassword);
    }
    smtp.Send(mail);
}

public static bool IsDate(object dt)
{
  try
    {
        System.DateTime.Parse(dt.ToString());
        return true;
      }
      catch
      {
        return false;
      }
}
public static bool IsNumeric(object oValue)
{
  try
    {
        double.Parse(oValue.ToString());
        return true;
      }
      catch
      {
        return false;
      }
}

}//class func
public class UserClass {

    private Guid _id;
    private string  _UserID = "";
    private string  _GroupID = "";
    private string  _userName;
    private string  _password;


    public Guid ID
    {
        get {return _id;}
        set {_id = value;}
    }

public string  UserID
{
  get {return _UserID;}
    set {_UserID = value;}
}
public string  GroupID
{
  get {return _GroupID;}
    set {_GroupID = value;}
}
public string  UserName
{
  get {return _userName;}
    set {_userName = value;}
}

public string Password
{
  get {return _password;}
  set {_password = value;}
}

public UserClass Login( string  txtUser,  string  txtPassword)
{
    
    UserClass  UserLogin = new UserClass();

    string  sLoginFrom = ConfigurationManager.AppSettings["LoginFrom"];
    if ( sLoginFrom == "DB" ) 
    { // User Name and Password from DB
        string  sTable = ConfigurationManager.AppSettings["UserListTable"];
        string  sLogin = ConfigurationManager.AppSettings["FieldUserLogin"];
        string  sLoginType = ConfigurationManager.AppSettings["FieldUserLoginType"];
        string  sPwd = ConfigurationManager.AppSettings["FieldUserPwd"];
        string  sPwdType = ConfigurationManager.AppSettings["FieldUserPwdType"];
    
        if ( sTable == "" || sLogin == "" || sPwd == "" )  return null;   
        string  sUserID = func.GetOptions("FieldUserOwnerID");
        string  sGroupID = func.GetOptions("FieldUserGroupID");
        string sSQL = "select [" + sLogin + "],[" + sPwd +"]";
    if (ConfigurationManager.AppSettings["TablesFile"] != string.Empty && sUserID != string.Empty) sSQL += ", [" + sUserID +"]";
    if (ConfigurationManager.AppSettings["TablesFile"] != string.Empty && sGroupID != string.Empty) sSQL += ", [" + sGroupID +"]";
    sSQL += " from " + sTable + " where [" + sLogin + "] = @Login and [" + sPwd + "] = @Password ";

        QueryCommand query = new QueryCommand(sSQL);
        
        try
        {
            query.AddParameter("Login", txtUser);
            query.AddParameter("Password", txtPassword);

            DbDataReader dbDr = (DbDataReader) DataService.GetReader(query);
            
            if (dbDr.HasRows && dbDr.Read())
            {
                if ( dbDr[sLogin].ToString() == txtUser && dbDr[sPwd].ToString() == txtPassword ) 
                {
                    UserLogin.ID = Guid.NewGuid();
                    if (ConfigurationManager.AppSettings["TablesFile"] != "" && sUserID != string.Empty) UserLogin.UserID = Convert.ToString(dbDr[sUserID]);
                    if (ConfigurationManager.AppSettings["TablesFile"] != "" && sGroupID != string.Empty) UserLogin.GroupID = Convert.ToString(dbDr[sGroupID]);
					UserLogin.UserID = Convert.ToString(dbDr[sLogin]);
                }
            }
            dbDr.Dispose();
        }
        finally
        {
        }
    }        
    else 
    { // hardcoded
        if ( txtUser == ConfigurationManager.AppSettings["UserLogin"] && txtPassword == ConfigurationManager.AppSettings["UserPassword"] ) 
            UserLogin.ID = Guid.NewGuid();
    }
            

  if ( UserLogin.ID == Guid.Empty ) return null;
  else 
  {
    UserLogin.UserName = txtUser;
    return UserLogin;
  }

}

public static void CheckLogin( System.Web.UI.Page Page) 
{
    if ( string.IsNullOrEmpty(ConfigurationManager.AppSettings["LoginMethod"]) || (ConfigurationManager.AppSettings["LoginMethod"]).ToUpper()  == "WITHOUTLOGIN" ) return;
//    Page.Response.CacheControl = "no-cache";
//    Page.Response.AddHeader("Pragma", "no-cache");
//    Page.Response.Expires = -1;
    if ( Page.Session["User"] == null ) Page.Response.Redirect(ConfigurationManager.AppSettings["LoginFile"] + "?url=" + Page.Request.RawUrl);
    if ( ((UserClass)Page.Session["User"]).ID == Guid.Empty) Page.Response.Redirect(ConfigurationManager.AppSettings["LoginFile"] + "?url=" + Page.Request.RawUrl);
}
        public static bool UserExist(string sLogin)
    {
        string  sTable = ConfigurationManager.AppSettings["UserListTable"];
        string  sLoginField = ConfigurationManager.AppSettings["FieldUserLogin"];
        Query query = new Query(Data.PENGGUNA.Schema).WHERE(sLoginField, Comparison.Equals, sLogin);
        query.SelectList = sLoginField;
        DbDataReader reader = (DbDataReader) query.ExecuteReader();
        return (reader.Read() && reader.HasRows);
    }

    public static bool UserExist(string sLogin, string sPassword)
    {
        string  sTable = ConfigurationManager.AppSettings["UserListTable"];
        string  sLoginField = ConfigurationManager.AppSettings["FieldUserLogin"];
        string  sPwdField = ConfigurationManager.AppSettings["FieldUserPwd"];
        Query query = new Query(Data.PENGGUNA.Schema).WHERE(sLoginField, Comparison.Equals, sLogin).AND(sPwdField, Comparison.Equals, sPassword);
        query.SelectList = sLoginField;
        DbDataReader reader = (DbDataReader) query.ExecuteReader();
        return (reader.Read() && reader.HasRows);
    }
    public string GetUserOwnerID(string sTable)
    {
        string result = "";
		try
        {
	        if (!string.IsNullOrEmpty(sTable))
	        {
	            string sUserTable = ConfigurationManager.AppSettings["UserListTable"];
	            string sUserOwnerIDField = func.GetFieldUserOwnerID(sTable);
	            string sLoginField = ConfigurationManager.AppSettings["FieldUserLogin"];
	            if (!string.IsNullOrEmpty(sUserTable) && 
	                !string.IsNullOrEmpty(sUserOwnerIDField) && 
	                !string.IsNullOrEmpty(sLoginField))
	            {
	                Query query = new Query(Data.PENGGUNA.Schema).WHERE(sLoginField, Comparison.Equals, this.UserID);
	                query.SelectList = sUserOwnerIDField;
	                DbDataReader reader = (DbDataReader)query.ExecuteReader();
	                if (reader.Read())
	                {
	                    result = reader[sUserOwnerIDField].ToString();
	                }
	                reader.Close();
	            }
	        }
        }
        finally
        { 
        }			
        return result;
    }
    public static void AddUser(string sLogin, string sPassword)
    {
        PENGGUNA item = new PENGGUNA();
		item.KODEPENGGUNA = sLogin;
		item.KATAKUNCI = sPassword;
		item.Save("");
    }
	
	public static bool ChangePassword(string sLogin, string sOldPassword, string sNewPassword)
    {
        Query qry = new Query(PENGGUNA.Schema);
        qry.WHERE("KODEPENGGUNA", sLogin).AND("KATAKUNCI", sOldPassword);
        PENGGUNAController controller = new PENGGUNAController();
        PENGGUNACollection col = controller.FetchByQuery(qry);
        if(col != null && col.Count > 0)
        {
            col[0].KATAKUNCI = sNewPassword;
                col[0].IsNew = false;
            col[0].Save("");
        }
		return true;
    }

    public static DbDataReader GetUserByID(bool isIdUid, string sIdValue)
    {
        string  sLogin = ConfigurationManager.AppSettings["FieldUserLogin"];
        string  sPwd = ConfigurationManager.AppSettings["FieldUserPwd"];
        string  sEmail = ConfigurationManager.AppSettings["FieldUserEmail"];

        string idField = isIdUid ? sLogin : sEmail;

        Query query = new Query(Data.PENGGUNA.Schema).WHERE(idField, Comparison.Equals, sIdValue);
        query.SelectList = string.Format("{0},{1},{2}", sLogin, sPwd, sEmail);
        DbDataReader reader = (DbDataReader) query.ExecuteReader();
        return reader;
    }
}
