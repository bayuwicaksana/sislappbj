using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class StatusPengajuan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(Session["pusername"]  as string)) {
			Response.Redirect("login.aspx?message=expired");
		} else {
			if (!IsPostBack)
			{
				BindSKPD();
				SKPDList.SelectedValue = "0";
				BindJenisKegiatan();
				JenisList.SelectedValue = "0";
				BindPeriod();
				bulanList.Text = "";
				TahunList.Text = (DateTime.Now.Year - 0).ToString();
			}

			BindGrid();
		}
    }

    private void BindSKPD()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        SqlDataAdapter _adapter;
        System.Data.DataSet dset = null;
        System.Data.DataTable dtsource = null;

        string ssql = "select kodeskpd, deskripsi from skpd";

        try
        {
            conn.Open();

            dset = new DataSet("npdata");
            _adapter = new SqlDataAdapter();
            _adapter.SelectCommand = new SqlCommand(ssql, conn);
            _adapter.Fill(dset, "npdata");
            dtsource = dset.Tables["npdata"];

            SKPDList.DataTextField = "deskripsi";
            SKPDList.DataValueField = "kodeskpd";
            SKPDList.DataSource = dtsource;
            SKPDList.DataBind();

            SKPDList.Items.Add(new ListItem("", "0"));

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void BindJenisKegiatan()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        SqlDataAdapter _adapter;
        System.Data.DataSet dset = null;
        System.Data.DataTable dtsource = null;

        string ssql = "select kodejeniskegiatan, deskripsi from jeniskegiatan";

        try
        {
            conn.Open();

            dset = new DataSet("npdata");
            _adapter = new SqlDataAdapter();
            _adapter.SelectCommand = new SqlCommand(ssql, conn);
            _adapter.Fill(dset, "npdata");
            dtsource = dset.Tables["npdata"];

            JenisList.DataTextField = "deskripsi";
            JenisList.DataValueField = "kodejeniskegiatan";
            JenisList.DataSource = dtsource;
            JenisList.DataBind();

            JenisList.Items.Add(new ListItem("", "0"));

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void BindPeriod()
    {
        bulanList.Items.Add(new ListItem("", "0"));
        bulanList.Items.Add(new ListItem("Januari", "01"));
        bulanList.Items.Add(new ListItem("Pebruari", "02"));
        bulanList.Items.Add(new ListItem("Maret", "03"));
        bulanList.Items.Add(new ListItem("April", "04"));
        bulanList.Items.Add(new ListItem("Mei", "05"));
        bulanList.Items.Add(new ListItem("Juni", "06"));
        bulanList.Items.Add(new ListItem("Juli", "07"));
        bulanList.Items.Add(new ListItem("Agustus", "08"));
        bulanList.Items.Add(new ListItem("September", "09"));
        bulanList.Items.Add(new ListItem("Oktober", "10"));
        bulanList.Items.Add(new ListItem("November", "11"));
        bulanList.Items.Add(new ListItem("Desember", "12"));

        TahunList.Items.Add(new ListItem("", "0"));
        TahunList.Items.Add(new ListItem((DateTime.Now.Year -1).ToString(), (DateTime.Now.Year -1).ToString()));
        TahunList.Items.Add(new ListItem((DateTime.Now.Year - 0).ToString(), (DateTime.Now.Year - 0).ToString()));
        TahunList.Items.Add(new ListItem((DateTime.Now.Year + 1).ToString(), (DateTime.Now.Year + 1).ToString()));
    }

    private void BindGrid()
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        SqlDataAdapter _adapter;
        System.Data.DataSet dset = null;
        System.Data.DataTable dtsource = null;

        string where = " where 1=1 ";

        if (SKPDList.SelectedValue != "0")
            where += " and KODESKPD = '" + SKPDList.SelectedValue + "' ";

        if (JenisList.SelectedValue != "0")
            where += " and KODEJENISKEGIATAN = '" + JenisList.SelectedValue + "' ";

        if (bulanList.SelectedValue != "0")
            where += " and SUBSTRING([TANGGAL PENGAJUAN],4,2) = '" + bulanList.SelectedValue + "' ";

        if (TahunList.SelectedValue != "0")
            where += " and RIGHT([TANGGAL PENGAJUAN],4) = '" + TahunList.SelectedValue + "' ";

        string ssql = "select * from viewstatuspengajuan" + where;

        try
        {
            conn.Open();

            dset = new DataSet("npdata");
            _adapter = new SqlDataAdapter();
            _adapter.SelectCommand = new SqlCommand(ssql, conn);
            _adapter.Fill(dset, "npdata");
            dtsource = dset.Tables["npdata"];

            GridView1.DataSource = dtsource;
            GridView1.DataBind();
			
			//Response.Write(ssql);

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    protected void CariButton_Click(object sender, EventArgs e)
    {

    }
}