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
#endregion

public partial class CPENGADAAN_LANGSUNG_Export : AspNetRunnerPage 
{
    int numrows = 0;
    IDictionary body;
    int mypage = 1;
    int gPageSize = 20;
    int recno = 1;
    int records = 0;
    int pageindex = 1;
    bool options = false;
    bool all = false;
    IDictionary<char, string> xmlRejects = new Dictionary<char, string>();

    PENGADAAN_LANGSUNGController controller = new PENGADAAN_LANGSUNGController();
    PENGADAAN_LANGSUNGCollection collection;

    protected void Page_Init( object sender,  System.EventArgs e)  
    {
        strTableName = "dbo.PENGADAAN_LANGSUNG";
        strTableNameLocale = "dbo_PENGADAAN_LANGSUNG";
    }

    protected void Page_Load( object sender,  System.EventArgs e)  
    {
            body = new Hashtable();
            xmlRejects.Add(' ',string.Empty);
            xmlRejects.Add('#',string.Empty);
            xmlRejects.Add('/',string.Empty);
            xmlRejects.Add('\\',string.Empty);
            xmlRejects.Add('(',string.Empty);
            xmlRejects.Add(')',string.Empty);
            xmlRejects.Add(',',string.Empty);
            xmlRejects.Add('[',string.Empty);
            xmlRejects.Add(']',string.Empty);
            xmlRejects.Add('+',string.Empty);
            xmlRejects.Add('\'',string.Empty);
            xmlRejects.Add('-',string.Empty);
            xmlRejects.Add('_',string.Empty);
            xmlRejects.Add('|',string.Empty);
            xmlRejects.Add('}',string.Empty);
            xmlRejects.Add('{',string.Empty);
            xmlRejects.Add('=',string.Empty);

            if(Request["records"] != null)
            {
                if((string)Request["records"] == "all")
                {
                    all = true;
                }
            }

                        options = string.IsNullOrEmpty(RequestAction);
            if(Request["type"] != null)
	        {
                GetData();
                BuildPagination();
                Export();
            }
            else
            {
                Selection = this.Request.Params.GetValues("selection[]");
                BuildBody();
                output.Append(func.BuildOutput(this, @"~\PENGADAAN_LANGSUNG_export.aspx", smarty));
            }
            this.Response.Write(output.ToString());
            this.Response.End();
    }

    private void WriteTableData()
    {
	    output.Append("<tr>");
	    if(Request["type"] != null && Request["type"].ToString() == "excel")
	    {
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("NAMAKEGIATAN") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("NAMAPAKET") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("KODESKPD") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("TANGGALKONTRAK") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("PAGU") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("HPS") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("NILAIKONTRAK") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("PEMENANG") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("KETERANGAN") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("PEJABATPENGADAAN") + "</td>");
		    output.Append("<td style=\"width: 100\" x:str>" + PrepareForExcel("MENGETAHUI") + "</td>");
	    }
	    else
	    {
		    output.Append("<td>NAMAKEGIATAN</td>");
		    output.Append("<td>NAMAPAKET</td>");
		    output.Append("<td>KODESKPD</td>");
		    output.Append("<td>TANGGALKONTRAK</td>");
		    output.Append("<td>PAGU</td>");
		    output.Append("<td>HPS</td>");
		    output.Append("<td>NILAIKONTRAK</td>");
		    output.Append("<td>PEMENANG</td>");
		    output.Append("<td>KETERANGAN</td>");
		    output.Append("<td>PEJABATPENGADAAN</td>");
		    output.Append("<td>MENGETAHUI</td>");
	    }
	    output.Append( "</tr>");

	    IDictionary<string, IList<string>> totals = new Dictionary<string, IList<string>>();
    // write data rows
	    for(int i = 0; i < collection.Count; ++ i)
	    {
            object totalValue = null;
		    output.Append("<tr>");
    Control control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", collection[i].NAMAKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    
	    		    if(Request["type"] != null && Request["type"].ToString() == "excel")
            {
			    output.Append( PrepareForExcel(control_NAMAKEGIATAN.GetData()));
            }
		    else
            {
			    output.Append( Control.HTMLEncodeSpecialChars(control_NAMAKEGIATAN.GetData()));
            }
	    output.Append( "</td>" );
    Control control_NAMAPAKET = new Control("NAMAPAKET", collection[i].NAMAPAKET, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    
	    		    if(Request["type"] != null && Request["type"].ToString() == "excel")
            {
			    output.Append( PrepareForExcel(control_NAMAPAKET.GetData()));
            }
		    else
            {
			    output.Append( Control.HTMLEncodeSpecialChars(control_NAMAPAKET.GetData()));
            }
	    output.Append( "</td>" );
    Control control_KODESKPD = new Control("KODESKPD", collection[i].KODESKPD, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    		    if((object)collection[i].KODESKPD != null)
		    {
                control_KODESKPD.Value = func.GetLookupValue(control_KODESKPD.FieldInfo);
			    string strValue_KODESKPD = control_KODESKPD.Value;
			    			    if(Request["type"] != null && Request["type"].ToString() == "excel")
				    output.Append( PrepareForExcel(strValue_KODESKPD));
			    else
				    output.Append( Control.HTMLEncodeSpecialChars(strValue_KODESKPD));

		    }
	    output.Append( "</td>" );
    Control control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", collection[i].TANGGALKONTRAK, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    output.Append("<td>");
    
	    		    if(Request["type"] != null && Request["type"].ToString() == "excel")
            {
			    output.Append( PrepareForExcel(control_TANGGALKONTRAK.GetData()));
            }
		    else
            {
			    output.Append( Control.HTMLEncodeSpecialChars(control_TANGGALKONTRAK.GetData()));
            }
	    output.Append( "</td>" );
    Control control_PAGU = new Control("PAGU", collection[i].PAGU, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    output.Append("<td>");
    
	    		    output.Append( Control.HTMLEncodeSpecialChars(control_PAGU.GetData()));
	    output.Append( "</td>" );
    Control control_HPS = new Control("HPS", collection[i].HPS, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    output.Append("<td>");
    
	    		    output.Append( Control.HTMLEncodeSpecialChars(control_HPS.GetData()));
	    output.Append( "</td>" );
    Control control_NILAIKONTRAK = new Control("NILAIKONTRAK", collection[i].NILAIKONTRAK, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    output.Append("<td>");
    
	    		    output.Append( Control.HTMLEncodeSpecialChars(control_NILAIKONTRAK.GetData()));
	    output.Append( "</td>" );
    Control control_PEMENANG = new Control("PEMENANG", collection[i].PEMENANG, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    
	    		    if(Request["type"] != null && Request["type"].ToString() == "excel")
            {
			    output.Append( PrepareForExcel(control_PEMENANG.GetData()));
            }
		    else
            {
			    output.Append( Control.HTMLEncodeSpecialChars(control_PEMENANG.GetData()));
            }
	    output.Append( "</td>" );
    Control control_KETERANGAN = new Control("KETERANGAN", collection[i].KETERANGAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    		    if((object)collection[i].KETERANGAN != null)
		    {
                control_KETERANGAN.Value = func.GetLookupValue(control_KETERANGAN.FieldInfo);
			    string strValue_KETERANGAN = control_KETERANGAN.Value;
			    			    if(Request["type"] != null && Request["type"].ToString() == "excel")
				    output.Append( PrepareForExcel(strValue_KETERANGAN));
			    else
				    output.Append( Control.HTMLEncodeSpecialChars(strValue_KETERANGAN));

		    }
	    output.Append( "</td>" );
    Control control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", collection[i].PEJABATPENGADAAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    		    if((object)collection[i].PEJABATPENGADAAN != null)
		    {
                control_PEJABATPENGADAAN.Value = func.GetLookupValue(control_PEJABATPENGADAAN.FieldInfo);
			    string strValue_PEJABATPENGADAAN = control_PEJABATPENGADAAN.Value;
			    			    if(Request["type"] != null && Request["type"].ToString() == "excel")
				    output.Append( PrepareForExcel(strValue_PEJABATPENGADAAN));
			    else
				    output.Append( Control.HTMLEncodeSpecialChars(strValue_PEJABATPENGADAAN));

		    }
	    output.Append( "</td>" );
    Control control_MENGETAHUI = new Control("MENGETAHUI", collection[i].MENGETAHUI, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
    	    if(Request["type"] != null && Request["type"].ToString() == "excel")
        {
		    output.Append("<td x:str>");
        }
	    else
        {
		    output.Append("<td>");
        }
    		    if((object)collection[i].MENGETAHUI != null)
		    {
                control_MENGETAHUI.Value = func.GetLookupValue(control_MENGETAHUI.FieldInfo);
			    string strValue_MENGETAHUI = control_MENGETAHUI.Value;
			    			    if(Request["type"] != null && Request["type"].ToString() == "excel")
				    output.Append( PrepareForExcel(strValue_MENGETAHUI));
			    else
				    output.Append( Control.HTMLEncodeSpecialChars(strValue_MENGETAHUI));

		    }
	    output.Append( "</td>" );
		    output.Append( "</tr>" );
	    }
    
    }

    private void ExportToCSV()
    {
        Response.AddHeader("Content-type", "application/csv");
	    Response.AddHeader("Content-Disposition", "attachment;Filename=PENGADAAN_LANGSUNG.csv");

	    IDictionary<string, IList<string>> totals = new Dictionary<string, IList<string>>();

    	
    // write header
	    StringBuilder outstr = new StringBuilder();
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"NAMAKEGIATAN\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"NAMAPAKET\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"KODESKPD\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"TANGGALKONTRAK\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"PAGU\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"HPS\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"NILAIKONTRAK\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"PEMENANG\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"KETERANGAN\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"PEJABATPENGADAAN\"");
	    if(outstr.Length > 0)
        {
		    outstr.Append(",");
        }
	    outstr.Append("\"MENGETAHUI\"");
	    output.Append(outstr);
	    output.Append("\r\n");

    // write data rows
	    for(int i = 0; i < collection.Count; ++ i)
	    {
            object totalValue = null;
		    outstr.Remove(0, outstr.Length);
            Control control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", collection[i].NAMAKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
    		    outstr.Append('"' + Control.HTMLEncodeSpecialChars(control_NAMAKEGIATAN.GetData()) + '"');
            Control control_NAMAPAKET = new Control("NAMAPAKET", collection[i].NAMAPAKET, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
    		    outstr.Append('"' + Control.HTMLEncodeSpecialChars(control_NAMAPAKET.GetData()) + '"');
            Control control_KODESKPD = new Control("KODESKPD", collection[i].KODESKPD, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
                control_KODESKPD.Value = func.GetLookupValue(control_KODESKPD.FieldInfo);
		    string value_KODESKPD = control_KODESKPD.DisplayLookupWizard();
		    if(value_KODESKPD.Length > 0)
			    outstr.Append('"' + Control.HTMLEncodeSpecialChars(value_KODESKPD) + '"');

            Control control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", collection[i].TANGGALKONTRAK, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
    		    outstr.Append('"' + Control.HTMLEncodeSpecialChars(control_TANGGALKONTRAK.GetData()) + '"');
            Control control_PAGU = new Control("PAGU", collection[i].PAGU, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
    		    outstr.Append('"' + Control.HTMLEncodeSpecialChars(control_PAGU.GetData()) + '"');
            Control control_HPS = new Control("HPS", collection[i].HPS, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
    		    outstr.Append('"' + Control.HTMLEncodeSpecialChars(control_HPS.GetData()) + '"');
            Control control_NILAIKONTRAK = new Control("NILAIKONTRAK", collection[i].NILAIKONTRAK, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
    		    outstr.Append('"' + Control.HTMLEncodeSpecialChars(control_NILAIKONTRAK.GetData()) + '"');
            Control control_PEMENANG = new Control("PEMENANG", collection[i].PEMENANG, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
    		    outstr.Append('"' + Control.HTMLEncodeSpecialChars(control_PEMENANG.GetData()) + '"');
            Control control_KETERANGAN = new Control("KETERANGAN", collection[i].KETERANGAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
                control_KETERANGAN.Value = func.GetLookupValue(control_KETERANGAN.FieldInfo);
		    string value_KETERANGAN = control_KETERANGAN.DisplayLookupWizard();
		    if(value_KETERANGAN.Length > 0)
			    outstr.Append('"' + Control.HTMLEncodeSpecialChars(value_KETERANGAN) + '"');

            Control control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", collection[i].PEJABATPENGADAAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
                control_PEJABATPENGADAAN.Value = func.GetLookupValue(control_PEJABATPENGADAAN.FieldInfo);
		    string value_PEJABATPENGADAAN = control_PEJABATPENGADAAN.DisplayLookupWizard();
		    if(value_PEJABATPENGADAAN.Length > 0)
			    outstr.Append('"' + Control.HTMLEncodeSpecialChars(value_PEJABATPENGADAAN) + '"');

            Control control_MENGETAHUI = new Control("MENGETAHUI", collection[i].MENGETAHUI, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    if(outstr.Length > 0)
            {
			    outstr.Append(",");
            }
                control_MENGETAHUI.Value = func.GetLookupValue(control_MENGETAHUI.FieldInfo);
		    string value_MENGETAHUI = control_MENGETAHUI.DisplayLookupWizard();
		    if(value_MENGETAHUI.Length > 0)
			    outstr.Append('"' + Control.HTMLEncodeSpecialChars(value_MENGETAHUI) + '"');

		    output.Append(outstr);
		    output.Append("\r\n");
	    }

    //	display totals
	    bool first = true;
    
    }

    private void ExportToWord()
    {
        Response.AddHeader("Content-type", "application/vnd.ms-word");
	    Response.AddHeader("Content-Disposition", "attachment;Filename=PENGADAAN_LANGSUNG.doc");

	    output.Append("<html>");
	    output.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=Windows-1252\">");
	    output.Append("<body>");
	    output.Append("<table border=1>");

	    WriteTableData();

	    output.Append("</table>");
	    output.Append("</body>");
	    output.Append("</html>");
    }

    private void  ExportToExcel()
    {
	    Response.AddHeader("Content-type", "application/vnd.ms-excel");
	    Response.AddHeader("Content-Disposition", "attachment;Filename=PENGADAAN_LANGSUNG.xls");

	    output.Append ("<html>");
	    output.Append ("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\">");
    	
	    output.Append ("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=Windows-1252\">");
	    output.Append ("<body>");
	    output.Append ("<table border=1>");

	    WriteTableData();

	    output.Append ("</table>");
	    output.Append ("</body>");
	    output.Append ("</html>");
    }

    private string XMLNameEncode(string strValue)
    {	
        StringBuilder newString = new StringBuilder();
        foreach(char ch in strValue)
        {
            if(!xmlRejects.ContainsKey(ch))
            {
                newString.Append(ch);
            }
        }
	    return newString.ToString();
    }

    private string PrepareForExcel(string str)
    {
        if(string.IsNullOrEmpty(str))
        {
            return str;
        }
	    string ret = Control.HTMLEncodeSpecialChars(str);
	    if (str.StartsWith("="))
        {
		    ret = "&#61;" + str.Substring(1);
        }
	    return ret;

    }

    private void ExportToXML()
    {
        Response.AddHeader("Content-type", "text/xml");
	    Response.AddHeader("Content-Disposition", "attachment;Filename=PENGADAAN_LANGSUNG.xml");


	    output.Append ("<?xml version=\"1.0\" encoding=\"Windows-1252\" standalone=\"yes\"?>\r\n");
	    output.Append ("<table>\r\n");
	    for(int i = 0; i < collection.Count; ++ i)
	    {
		    output.Append("<row>\r\n");
		    string field_NAMAKEGIATAN = Control.HTMLEncodeSpecialChars(XMLNameEncode("NAMAKEGIATAN"));
		    output.Append("<" + field_NAMAKEGIATAN + ">");
            Control control_NAMAKEGIATAN = new Control("NAMAKEGIATAN", collection[i].NAMAKEGIATAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    output.Append(Control.HTMLEncodeSpecialChars(control_NAMAKEGIATAN.GetData()));
		    output.Append("</" + field_NAMAKEGIATAN + ">\r\n");
		    string field_NAMAPAKET = Control.HTMLEncodeSpecialChars(XMLNameEncode("NAMAPAKET"));
		    output.Append("<" + field_NAMAPAKET + ">");
            Control control_NAMAPAKET = new Control("NAMAPAKET", collection[i].NAMAPAKET, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    output.Append(Control.HTMLEncodeSpecialChars(control_NAMAPAKET.GetData()));
		    output.Append("</" + field_NAMAPAKET + ">\r\n");
		    string field_KODESKPD = Control.HTMLEncodeSpecialChars(XMLNameEncode("KODESKPD"));
		    output.Append("<" + field_KODESKPD + ">");
            Control control_KODESKPD = new Control("KODESKPD", collection[i].KODESKPD, false, smarty, this.Request, builder, MODE.MODE_EXPORT);

            control_KODESKPD.Value = func.GetLookupValue(control_KODESKPD.FieldInfo);
		    output.Append(Control.HTMLEncodeSpecialChars(control_KODESKPD.DisplayLookupWizard()));
    		
		    output.Append("</" + field_KODESKPD + ">\r\n");
		    string field_TANGGALKONTRAK = Control.HTMLEncodeSpecialChars(XMLNameEncode("TANGGALKONTRAK"));
		    output.Append("<" + field_TANGGALKONTRAK + ">");
            Control control_TANGGALKONTRAK = new Control("TANGGALKONTRAK", collection[i].TANGGALKONTRAK, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    output.Append(Control.HTMLEncodeSpecialChars(control_TANGGALKONTRAK.GetData()));
		    output.Append("</" + field_TANGGALKONTRAK + ">\r\n");
		    string field_PAGU = Control.HTMLEncodeSpecialChars(XMLNameEncode("PAGU"));
		    output.Append("<" + field_PAGU + ">");
            Control control_PAGU = new Control("PAGU", collection[i].PAGU, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    output.Append(Control.HTMLEncodeSpecialChars(control_PAGU.GetData()));
		    output.Append("</" + field_PAGU + ">\r\n");
		    string field_HPS = Control.HTMLEncodeSpecialChars(XMLNameEncode("HPS"));
		    output.Append("<" + field_HPS + ">");
            Control control_HPS = new Control("HPS", collection[i].HPS, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    output.Append(Control.HTMLEncodeSpecialChars(control_HPS.GetData()));
		    output.Append("</" + field_HPS + ">\r\n");
		    string field_NILAIKONTRAK = Control.HTMLEncodeSpecialChars(XMLNameEncode("NILAIKONTRAK"));
		    output.Append("<" + field_NILAIKONTRAK + ">");
            Control control_NILAIKONTRAK = new Control("NILAIKONTRAK", collection[i].NILAIKONTRAK, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    output.Append(Control.HTMLEncodeSpecialChars(control_NILAIKONTRAK.GetData()));
		    output.Append("</" + field_NILAIKONTRAK + ">\r\n");
		    string field_PEMENANG = Control.HTMLEncodeSpecialChars(XMLNameEncode("PEMENANG"));
		    output.Append("<" + field_PEMENANG + ">");
            Control control_PEMENANG = new Control("PEMENANG", collection[i].PEMENANG, false, smarty, this.Request, builder, MODE.MODE_EXPORT);
		    output.Append(Control.HTMLEncodeSpecialChars(control_PEMENANG.GetData()));
		    output.Append("</" + field_PEMENANG + ">\r\n");
		    string field_KETERANGAN = Control.HTMLEncodeSpecialChars(XMLNameEncode("KETERANGAN"));
		    output.Append("<" + field_KETERANGAN + ">");
            Control control_KETERANGAN = new Control("KETERANGAN", collection[i].KETERANGAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);

            control_KETERANGAN.Value = func.GetLookupValue(control_KETERANGAN.FieldInfo);
		    output.Append(Control.HTMLEncodeSpecialChars(control_KETERANGAN.DisplayLookupWizard()));
    		
		    output.Append("</" + field_KETERANGAN + ">\r\n");
		    string field_PEJABATPENGADAAN = Control.HTMLEncodeSpecialChars(XMLNameEncode("PEJABATPENGADAAN"));
		    output.Append("<" + field_PEJABATPENGADAAN + ">");
            Control control_PEJABATPENGADAAN = new Control("PEJABATPENGADAAN", collection[i].PEJABATPENGADAAN, false, smarty, this.Request, builder, MODE.MODE_EXPORT);

            control_PEJABATPENGADAAN.Value = func.GetLookupValue(control_PEJABATPENGADAAN.FieldInfo);
		    output.Append(Control.HTMLEncodeSpecialChars(control_PEJABATPENGADAAN.DisplayLookupWizard()));
    		
		    output.Append("</" + field_PEJABATPENGADAAN + ">\r\n");
		    string field_MENGETAHUI = Control.HTMLEncodeSpecialChars(XMLNameEncode("MENGETAHUI"));
		    output.Append("<" + field_MENGETAHUI + ">");
            Control control_MENGETAHUI = new Control("MENGETAHUI", collection[i].MENGETAHUI, false, smarty, this.Request, builder, MODE.MODE_EXPORT);

            control_MENGETAHUI.Value = func.GetLookupValue(control_MENGETAHUI.FieldInfo);
		    output.Append(Control.HTMLEncodeSpecialChars(control_MENGETAHUI.DisplayLookupWizard()));
    		
		    output.Append("</" + field_MENGETAHUI + ">\r\n");
		    output.Append("</row>\r\n");
	    }
	    output.Append("</table>\r\n");
    }

    private void Export()
    {
        string type = (string)Request["type"];
        if(type=="excel")
        {
		    ExportToExcel();
        }
	    else if(type=="word")
        {
		    ExportToWord();
        }
	    else if(type=="xml")
        {
		    ExportToXML();
        }
	    else if(type=="csv")
        {
		    ExportToCSV();
        }
        else
        {
            throw new NotImplementedException(type);
        }
    }

    private void BuildPagination()
    {
        int nPageSize = 0;
	    if(Request["records"] != null && Request["records"].ToString() =="page" && numrows > 0)
	    {
		    mypage = PageNumber;
		    int maxRecords = numrows;
		    smarty.Add("records_found",numrows);
		    int maxpages=(int)Math.Ceiling((double)maxRecords/PageSize);
		    if(mypage > maxpages)
            {
			    mypage = maxpages;
            }
		    if( mypage < 1) 
            {
			    mypage = 1;
            }
        }
    }

    private void BuildBody()
    {
        body = new Hashtable();
        if(options)
        {
	        smarty.Add("rangeheader_block",true);
	        smarty.Add("range_block",true);
        }
        body["begin"]="<form action=\"PENGADAAN_LANGSUNG_export.aspx\" method=get id=frmexport name=frmexport>";
        body["end"]="</form>";
        smarty.Add("body",body);
    }

    private void GetSearchRows()
    {
        string oCol = OwnerColumn;
        string oID = OwnerID;
        IDictionary<string, object> par = new Dictionary<string, object>();
                if(string.IsNullOrEmpty(SearchField))
        {
            if(par.Count > 0)
            {
                collection = controller.FetchByAllParameters(SearchOption, SearchFor, (PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID, par);
                numrows = controller.FetchByAllParametersCount(SearchOption, SearchFor, oCol, oID, par);
            }
            else
            {
                collection = controller.FetchByAllParameters(SearchOption, SearchFor, (PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID);
                numrows = controller.FetchByAllParametersCount(SearchOption, SearchFor, oCol, oID);
            }
        }
        else
        {
            if(par.Count > 0)
            {
                collection = controller.FetchByParameter(SearchField, SearchOption, SearchFor, (PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID, par);
                numrows = controller.FetchByParameterCount(SearchField, SearchOption, SearchFor, oCol, oID, par);
            }
            else
            {
                collection = controller.FetchByParameter(SearchField, SearchOption, SearchFor, (PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID);
                numrows = controller.FetchByParameterCount(SearchField, SearchOption, SearchFor, oCol, oID);
            }
        }
    }

    private void GetAdvancedSearchRows()
    {
        string[] asearchfield = this.Request.Form.GetValues("asearchfield[]");
        if(asearchfield == null)
        {
            asearchfield = Asearchfield;
        }
        IDictionary<string, object> par = new Dictionary<string, object>();
        string oCol = OwnerColumn;
        string oID = OwnerID;
                if(par.Count > 0)
        {
            collection = controller.FetchForAdvancedSearch(asearchfield,
            Asearchopt,
            Asearchfor,
            Asearchfor2,
            Asearchnot,
            (Asearchtype == "and"),
            (PageNumber - 1) * PageSize, 
            PageSize, 
            OrderBy, 
            oCol, oID, par);

        numrows = controller.FetchForAdvancedSearchCount(asearchfield,
            Asearchopt,
            Asearchfor,
            Asearchfor2,
            Asearchnot,
            (Asearchtype == "and"),
            (PageNumber - 1) * PageSize, 
            PageSize, 
            OrderBy, 
            oCol, oID, par);
        }
        else
        {
        collection = controller.FetchForAdvancedSearch(asearchfield,
            Asearchopt,
            Asearchfor,
            Asearchfor2,
            Asearchnot,
            (Asearchtype == "and"),
            (PageNumber - 1) * PageSize, 
            PageSize, 
            OrderBy, 
            oCol, oID);

        numrows = controller.FetchForAdvancedSearchCount(asearchfield,
            Asearchopt,
            Asearchfor,
            Asearchfor2,
            Asearchnot,
            (Asearchtype == "and"),
            (PageNumber - 1) * PageSize, 
            PageSize, 
            OrderBy, 
            oCol, oID);
        }
    }

    private void GetAllRows()
    {
        if (Selection == null)
        {
            if(all)
            {
                collection = controller.FetchAll(OrderBy, OwnerColumn, OwnerID);
                numrows = controller.FetchAllCount(OwnerColumn, OwnerID);
            }
            else
            {
                collection = controller.FetchAllPaged((PageNumber - 1) * PageSize, PageSize, OrderBy, OwnerColumn, OwnerID);
                numrows = controller.FetchAllCount(OwnerColumn, OwnerID);
            }
        }
        else
        {
            StringBuilder columns = new StringBuilder();
                    columns.Append("KODEPENGADAANLANGSUNG");
                    columns.Append('\0');
                collection = controller.FetchSelected(columns.ToString().Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries), 
                    Selection, 
                    OrderBy, 
                    OwnerColumn, OwnerID);
            numrows = collection.Count;
            Selection = null;
        }
    }

    private void GetData()
    {
        if (Search == 0 && Selection == null)
        {
            GetSearchRows();
        }
        else if(Search == 2 && Selection == null)
        {
            GetAdvancedSearchRows();
        }
        else
        {
            GetAllRows();
        }
    }

    
    private int PageSize
    {
        get
        {
            return (int)SessionPropertyGet(strTableName + "_pagesize", gPageSize);
        }
        set
        {
            SessionPropertySet(strTableName + "_pagesize", value);
        }
    }

    private int PageNumber
    {
        get
        {
            return (int)SessionPropertyGet(strTableName + "_pagenumber", 1);
        }
        set
        {
            SessionPropertySet(strTableName + "_pagenumber", value);
        }
    }

    private string GoTo
    {
        get
        {
            return (string)SessionPropertyGet(strTableName + "goto", string.Empty);
        }
        set
        {
            SessionPropertySet(strTableName + "goto", value);
        }
    }

    private string SearchFor
    {
        get
        {
            return (string)SessionPropertyGet("SearchFor", string.Empty);
        }
        set
        {
            SessionPropertySet("SearchFor", value);
        }
    }

    private string SearchOption
    {
        get
        {
            return (string)SessionPropertyGet("SearchOption", string.Empty);
        }
        set
        {
            SessionPropertySet("SearchOption", value);
        }
    }

    private string SearchField
    {
        get
        {
            return (string)SessionPropertyGet("SearchField", string.Empty);
        }
        set
        {
            SessionPropertySet("SearchField", value);
        }
    }

    private string OrderBy
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

    private int Search
    {
        get
        {
            return (int)SessionPropertyGet(strTableName + "_search", -1);
        }
        set
        {
            SessionPropertySet(strTableName + "_search", value);
        }
    }

    private IDictionary<string, string> Asearchopt
    {
        get
        {
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchopt", new Dictionary<string, string>());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchopt", value);
        }
    }

    private IDictionary<string, string> Asearchfor
    {
        get
        {
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchfor", new Dictionary<string, string>());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfor", value);
        }
    }

    private string[] Asearchfield
    {
        get
        {
            return (string[])SessionPropertyGet(strTableName + "_asearchfield", null);
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfield", value);
        }
    }

    private IDictionary Asearchfortype
    {
        get
        {
            return (IDictionary)SessionPropertyGet(strTableName + "_asearchfortype", new Hashtable());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfortype", value);
        }
    }

    private IDictionary<string, string> Asearchfor2
    {
        get
        {
            return (IDictionary<string, string>)SessionPropertyGet(strTableName + "_asearchfor2", new Dictionary<string, string>());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchfor2", value);
        }
    }

    private IDictionary<string, bool> Asearchnot
    {
        get
        {
            return (IDictionary<string, bool>)SessionPropertyGet(strTableName + "_asearchnot", new Dictionary<string, bool>());
        }
        set
        {
            SessionPropertySet(strTableName + "_asearchnot", value);
        }
    }

    
    private string Asearchtype
    {
        get
        {
            return (string)SessionPropertyGet("type", string.Empty);
        }
        set
        {
            SessionPropertySet("type", value);
        }
    }

 
    private string[] Selection
    {
        get
        {
            return (string[])SessionPropertyGet("Selection", null);
        }
        set
        {
            SessionPropertySet("Selection", value);
        }
    }

    private string MasterTable
    {
        get
        {
            return (string)SessionPropertyGet(strTableName + "_mastertable", string.Empty);
        }
        set
        {
            SessionPropertySet(strTableName + "_mastertable", value);
        }
    }
}

