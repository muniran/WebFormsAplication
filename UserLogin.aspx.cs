using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLogin : System.Web.UI.Page
{
    string connectionstring = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dt;
    string query = string.Empty;
    static int flag;
    DataTable dtAuth;

    public object CookieHelper { get; private set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string loginCookie = Convert.ToString(Request.Cookies["loginCookie"]);
            if (!string.IsNullOrEmpty(loginCookie))
            {
                if (Request.Cookies["loginCookie"].Value != null)
                {
                    ListPrograms("GetPaidPrograms");
                    lblmsg.Visible = true;
                    lnklogoff.Visible = true;
                    lnkUpdate.Visible = true;
                    pnllogin.Visible = false;
                }
            }
            else
                ListPrograms("GetAllPrograms");
        }
        else
        {
            ListPrograms("GetAllPrograms");
        }
    }

    protected void logincontrol_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            bool Authenticated = false;
            Authenticated = UserAuthentication(logincontrol.UserName, logincontrol.Password);
            e.Authenticated = Authenticated;
            lblmsg.Text = string.Empty;
            if (Authenticated)
            {
                query = "GetPaidPrograms";
                lblmsg.Text = "User logged in successfully!!";
            }
            else
            {
                query = "GetAllPrograms";
                lblmsg.Text = "";
            }
            ListPrograms(query);
            
            HttpCookie loginCookie1 = new HttpCookie("loginCookie");
            loginCookie1.Value = "true";
            loginCookie1.Expires = DateTime.Now.AddMinutes(20);
            loginCookie1.HttpOnly = false;
            Response.Cookies.Add(loginCookie1);
        }
        catch (Exception ex)
        {
            lblmsg.Visible = true;
            lblmsg.Text = ex.ToString();
        }
    }
    private bool UserAuthentication(string UserName, string Password)
    {
        con = new SqlConnection(connectionstring);
        query = "AuthenticateUserNamePass";
        cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@UserName", UserName);
        cmd.Parameters.AddWithValue("@Password", Password);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        dtAuth = new DataTable();
        da.Fill(dtAuth);
        cmd.Dispose();
        cmd = null;
        
        if (dtAuth != null)
        {
            if (dtAuth.Rows.Count > 0)
            {
                HttpCookie loginID = new HttpCookie("loginid");
                loginID.Value = dtAuth.Rows[0]["UserID"].ToString();
                loginID.Expires = DateTime.Now.AddMinutes(20);
                loginID.HttpOnly = false;
                Response.Cookies.Add(loginID);
                return true;
            }
            else
                return false;
        }
        else
            return false;

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
    private void ListPrograms(string query)
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

    protected void lnklogoff_Click(object sender, EventArgs e)
    {
        pnllogin.Visible = true;
        lnklogoff.Visible = false;
        lnkUpdate.Visible = false;
        ListPrograms("GetAllPrograms");
        Request.Cookies["loginCookie"].Value = "false";
    }
    private void getRegistartionList()
    {
        string getRegistration = "GetRegistartions";
        con = new SqlConnection(connectionstring);
        cmd = new SqlCommand(getRegistration, con);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        cmd.Dispose();
        cmd = null;
    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        string loginid = Convert.ToString(Request.Cookies["loginid"]);
        if (!string.IsNullOrEmpty(loginid))
        {
            if (Request.Cookies["loginid"].Value != null)
            {
                ListPrograms("GetPaidPrograms");
                lblmsg.Visible = true;
                lnklogoff.Visible = true;
                lnkUpdate.Visible = true;
                pnllogin.Visible = false;
            }
            int id = Convert.ToInt32(Request.Cookies["loginid"].Value);
            Response.Redirect("EditMyProfile.aspx?id=" + id);
        }
        
    }
}