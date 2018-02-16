using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProgramDetails : System.Web.UI.Page
{
    string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dt;
    string query = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        query = "GetSelectedPrograms";
        getDetails(query);
    }
    private void getDetails(string query)
    {
        string id = string.Empty;
        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"].ToString();
        con = new SqlConnection(connectionstring);
        cmd = new SqlCommand(query, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@programID", SqlDbType.VarChar, 30).Value = id;
        da = new SqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        grdPrograms.DataSource = dt;
        grdPrograms.DataBind();
        cmd.Dispose();
        cmd = null;
    }
}