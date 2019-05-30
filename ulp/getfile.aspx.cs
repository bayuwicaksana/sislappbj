#region " using "
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;
using SubSonic;
#endregion

public partial class GetFile : System.Web.UI.Page
{

private void Page_Load( object sender,  System.EventArgs e)
{
    UserClass.CheckLogin(Page);

    string  sKeyFields = Request.QueryString["key1"];
    string  sTableName = Request.QueryString["table"];
    string  sDataFieldName = Request.QueryString["field"];
    string  sFileName = Request.QueryString["filename"];
    string  sUploadDir = Request.QueryString["uploaddir"];

    if (! func.CheckUserPermissions(sTableName, "S") ) 
    {
        Response.Write("<p>" + "You don't have permissions to access this table" + "<a href=\"login.aspx\">&nbsp;" + "Back to login page" + "</a></p>");
        Response.End();
        return;
    }  
    
    if ( sKeyFields == null ) fGetFile(sFileName, sUploadDir);
    else GetFileFromDB(sKeyFields, sTableName, sFileName, sDataFieldName);
}

private void fGetFile( string  sFileName, string sUploadDir) 
{
        if ( sFileName == "" ) return;
        try 
    {
            FileStream fStream = new FileStream(Server.MapPath(sUploadDir + sFileName), FileMode.OpenOrCreate, FileAccess.Read);
            byte[] b = new byte[fStream.Length];
            while ((fStream.Read(b, 0, (int)fStream.Length) > 0));
            fStream.Close();
            DownloadFile(b, sFileName);
        }
    catch (Exception ex)
          {  Response.Write(ex.Message); }
    finally
    {
            
    }
}

private void GetFileFromDB( string  sKeyFields,  string  sTableName,  string  sFileName,  string  sDataFieldName) 
{
    if ( string.IsNullOrEmpty(sKeyFields)  || string.IsNullOrEmpty(sTableName)  || string.IsNullOrEmpty(sFileName )) return;
    
    
    
    TableSchema.Table schema = Query.BuildTableSchema(sTableName);
    Query qry = new Query(schema).WHERE(schema.PrimaryKey.ColumnName, sKeyFields);
    qry.SelectList = sDataFieldName;
    using(IDataReader reader = qry.ExecuteReader())
    {
        if(reader != null && reader.Read())
        {
            byte[] b = (byte[])reader[sDataFieldName];  
            DownloadFile(b, sFileName); 
        }
    }
    Response.End();
}

private void DownloadFile(byte[] b,  string  sFileName) 
{
    if ( b.Length == 0 ) return;
    string sContentType = "application/octet-stream";
    switch (sFileName.Remove(0, sFileName.Length-4))
    {
        case ".asf":
            sContentType = "video/x-ms-asf";
      break;
        case ".avi":
            sContentType = "video/avi";
      break;
        case ".doc":
            sContentType = "application/msword";
      break;
        case ".zip":
            sContentType = "application/zip";
      break;
        case ".xls":
            sContentType = "application/vnd.ms-excel";
      break;
        case ".gif":
            sContentType = "image/gif";
      break;
        case ".jpg":
        case "jpeg":
            sContentType = "image/jpeg";
      break;
        case ".wav":
            sContentType = "audio/wav";
      break;
        case ".mp3":
            sContentType = "audio/mpeg3";
      break;
        case ".mpg":
        case "mpeg":
            sContentType = "video/mpeg";
            break;
        case ".rtf":
            sContentType = "application/rtf";
            break;
        case ".htm":
        case "html":
            sContentType = "text/html";
            break;
        case ".asp":
            sContentType = "text/asp";
            break;
        case ".pdf":
            ContentType = "application/pdf";
            break;
    }

    Response.AddHeader("Content-Disposition", "attachment;Filename=" + sFileName.Remove(0, sFileName.LastIndexOfAny("\\/".ToCharArray()) + 1));
    Response.AddHeader("Content-Length", b.Length.ToString());
    Response.ContentType = sContentType;
    Response.BinaryWrite(b);
}
  
}
