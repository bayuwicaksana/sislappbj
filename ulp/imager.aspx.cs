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

public partial class CImager: System.Web.UI.Page
{

private void Page_Load( object sender,  System.EventArgs e)
{
    UserClass.CheckLogin(Page);

    string  sKeyFields = Request.QueryString["key1"];
    string  sTableName = Request.QueryString["table"];
    string  sImgFieldName = Request.QueryString["field"];
    if (! func.CheckUserPermissions(sTableName, "S") ) 
    {
        Response.Write("<p>" + "You don't have permissions to access this table" + "<a href=\"login.aspx\">&nbsp;" + "Back to login page" + "</a></p>");
        Response.End();
        return;
    }  
    if ( sKeyFields == null ) GetImageFromFile(sImgFieldName);
    else GetImageFromDB(sKeyFields, sTableName, sImgFieldName);
}

private void GetImageFromFile( string  sImgFileName) 
{
    try
    {
        FileStream fStream = new FileStream(Server.MapPath(sImgFileName), FileMode.OpenOrCreate, FileAccess.Read);
        byte[] b = new byte[fStream.Length];
        while ((fStream.Read(b, 0, (int)fStream.Length) > 0));
        fStream.Close();
        DisplayImage(b);
    }
    catch
    {
        DisplayNoImage();
        Response.End();
    }
}

private void GetImageFromDB( string  sKeyFields,  string  sTableName,  string  sImgFieldName) 
{
    if ( string.IsNullOrEmpty(sKeyFields)  || string.IsNullOrEmpty(sTableName)  || string.IsNullOrEmpty(sImgFieldName )) return;

    try
    {
        TableSchema.Table schema = Query.BuildTableSchema(sTableName);
        Query qry = new Query(schema).WHERE(schema.PrimaryKey.ColumnName, sKeyFields);
        qry.SelectList = sImgFieldName;
        using(IDataReader reader = qry.ExecuteReader())
        {
            if(reader != null && reader.Read())
            {
                byte[] b = (byte[])reader[sImgFieldName];                       
                if(b.Length > 0) 
                {
                    DisplayImage(b);
                }
                else 
                {
                    DisplayNoImage();
                }
            }
            else 
            {
                DisplayNoImage();
            }
        }
    }
    catch 
    {
        DisplayNoImage();
        Response.End();
    }
}

private void DisplayImage(byte[] b) 
{
        if ( b.Length == 0 ) 
    {
            DisplayNoImage();
            Response.End();
            return;
        }

        int nSkip = 0;
        string  sContentType = GetImageType(b, ref nSkip);

        if ( sContentType == "" ) 
    {
            DisplayFileImage();
            Response.End();
            return;
        }

    Response.ContentType = sContentType;
    byte[] c = new byte[b.Length - nSkip];
      Array.Copy(b, nSkip, c, 0, b.Length - nSkip);
    Response.BinaryWrite(c);
}

private void DisplayNoImage() 
{
        Response.ContentType = "image/gif";
        FileStream fs = File.OpenRead(Server.MapPath("images/no_image.gif"));

        byte[] b = new byte[fs.Length];
        fs.Read(b, 0, (int)fs.Length);
        Response.BinaryWrite(b);
}

private void DisplayFileImage() 
{
      Response.ContentType = "image/gif";
        FileStream fs = File.OpenRead(Server.MapPath("images/file.gif"));

        byte[] b = new byte[fs.Length];
        fs.Read(b, 0, (int)fs.Length);
        Response.BinaryWrite(b);
}

private string GetImageType(byte[] b, ref int nSkip)
{
        char c1, c2, c3, c4, c7, c8, c9,  c10;
    string sGetImageType = "";

        c1 = System.Convert.ToChar(b[0]);
        c2 = System.Convert.ToChar(b[1]);
        c3 = System.Convert.ToChar(b[2]);
        c4 = System.Convert.ToChar(b[3]);
        c7 = System.Convert.ToChar(b[6]);
        c8 = System.Convert.ToChar(b[7]);
        c9 = System.Convert.ToChar(b[8]);
        c10 = System.Convert.ToChar(b[9]);       
        nSkip = 0;

        if ( c1 == 'B' && c2 == 'M' ) sGetImageType = "image/bmp";
        else 
      if ( c1 == 'G' && c2 == 'I' && c3 == 'F' ) sGetImageType = "image/gif";
      else 
        if ((c7 == 'J' && c8 == 'F' && c9 == 'I' && c10 == 'F') || (c7 == 'E' && c8 == 'x' && c9 == 'i' && c10 == 'f') ) sGetImageType = "image/jpg";
	  else
	    if (b[0] == 0x89 && b[1] == 0x50 && b[2] == 0x4E && b[3] == 0x47 && b[4] == 0xD && b[5] == 0xA && b[6] == 0x1A && b[7] == 0xA) sGetImageType = "image/png";

        if ( sGetImageType == "" ) 
    {
      int i;
            int nLen = 300;
            if ( b.Length - 3 < 300 )
                nLen = b.Length - 3;
            for ( i = 1;i <= nLen; i++)
                if ( System.Convert.ToChar(b[i]) == 'B' && System.Convert.ToChar(b[i+1]) == 'M' ) 
        {
                    sGetImageType = "image/bmp";
                    nSkip = i;
                    i = b.Length;
                } 
        else if ( System.Convert.ToChar(b[i]) == 'G' && System.Convert.ToChar(b[i+1]) == 'I' && System.Convert.ToChar(b[i+2]) == 'F' && System.Convert.ToChar(b[i+3]) == '8' ) 
            {
              sGetImageType = "image/gif";
              nSkip = i;
              i = b.Length;
            } else 
                if ( System.Convert.ToChar(b[i]) == 'J' && System.Convert.ToChar(b[i+1]) == 'F' && System.Convert.ToChar(b[i+2]) == 'I' && System.Convert.ToChar(b[i+3]) == 'F' ) 
                {
                  sGetImageType = "image/jpeg";
                  nSkip = i - 6;
                  i = b.Length;
                    }
        } //
    return sGetImageType;
}
 


}


