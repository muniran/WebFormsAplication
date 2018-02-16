using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditMyProfile : System.Web.UI.Page
{
    string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dt;
    string query = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
            FillRequestedProfileData(Request.QueryString["id"].ToString());
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int flag = InsertUpdateRecord("Update", txtuserid.Text);
        if (flag > 0)
        {
            lblmsg.Text = "Record updated successfully!!";
            lblmsg.Visible = true;
        }
        else
        {
            lblmsg.Text = "Record not updated!!";
            lblmsg.Visible = true;
        }
    }
    private int InsertUpdateRecord(string statementType, string ID)
    {
        string saveRegistration = "AddRegistartions";
        con = new SqlConnection(connectionstring);
        cmd = new SqlCommand(saveRegistration, con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@id", SqlDbType.VarChar, 30).Value = ID;
        cmd.Parameters.Add("@Username", SqlDbType.VarChar, 30).Value = txtUsername.Text;
        cmd.Parameters.Add("@UserPassword", SqlDbType.VarChar, 30).Value = txtPassword.Text;
        cmd.Parameters.Add("@Firstname", SqlDbType.VarChar, 30).Value = txtFirstname.Text;
        cmd.Parameters.Add("@Lastname", SqlDbType.VarChar, 30).Value = txtLastName.Text;
        cmd.Parameters.Add("@StatementType", SqlDbType.VarChar, 30).Value = statementType;
        con.Open();
        int rowsaffected= cmd.ExecuteNonQuery();
        cmd.Dispose();
        cmd = null;
        con.Close();
        return rowsaffected;
    }
    private void FillRequestedProfileData(string id)
    {
        string getRegistration = "GetRegistartionBYID";
        con = new SqlConnection(connectionstring);
        cmd = new SqlCommand(getRegistration, con);
        cmd.Parameters.Add("@userID", SqlDbType.VarChar, 30).Value = id;
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        FillProfileData(dt);
        pnlRegistartion.Visible = true;
        cmd.Dispose();
        cmd = null;
    }
    private void FillProfileData(DataTable dt)
    {
        txtuserid.Text = dt.Rows[0]["UserID"].ToString();
        txtUsername.Text = dt.Rows[0]["Username"].ToString();
        txtPassword.Text = dt.Rows[0]["UserPassword"].ToString();
        txtFirstname.Text = dt.Rows[0]["Firstname"].ToString();
        txtLastName.Text = dt.Rows[0]["LastName"].ToString();
    }
}