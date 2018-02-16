using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con ;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dt;
    string query = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ListPrograms("GetAllPrograms");
        }
        catch (Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = ex.ToString();
        }
        finally
        {
            lblmsg.Visible = true;
        }
    }

    private void ListPrograms( string query)
    {
        con = new SqlConnection(connectionstring);
        cmd = new SqlCommand(query, con);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        grdPrograms.DataSource = dt;
        grdPrograms.DataBind();
        cmd.Dispose();
        cmd = null;

    }
    protected void regSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            string statementType = string.Empty;
            int flag = InsertUpdateRecord("insert", "");
            if (flag < 0)
            {
                lblmsg.Text = "Record Saved successfully!!";
                lblmsg.Visible = true;
            }
            else
            {
                lblmsg.Text = "Record not Saved!!";
                lblmsg.Visible = true;
            }
        }
        catch(Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = ex.ToString();
        }
    }
    private int InsertUpdateRecord(string statementType,string ID)
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
        int recordsAffected = cmd.ExecuteNonQuery();
        clearfields();
        cmd.Dispose();
        cmd = null;
        return recordsAffected;
    }
    private void clearfields()
    {
        txtUsername.Text = "";
        txtPassword.Text = "";
        txtFirstname.Text = "";
        txtLastName.Text = "";
    }

    protected void btnReg_Click(object sender, EventArgs e)
    {
        pnlRegistartion.Visible = true;
        lblmsg.Visible = false;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserLogin.aspx");
    }

    protected void grdPrograms_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                int rowIndex = e.Row.RowIndex;
                rowIndex++;
                HyperLink myLink = new HyperLink();
                myLink.NavigateUrl = "ProgramDetails.aspx?id=" + rowIndex;
                if (cell.Controls.Count > 0)
                {
                    while (cell.Controls.Count > 0)
                        myLink.Controls.Add(cell.Controls[0]);
                }
                else
                    myLink.Text = cell.Text;
                cell.Controls.Add(myLink);
            }
        }
    }

    


    
}