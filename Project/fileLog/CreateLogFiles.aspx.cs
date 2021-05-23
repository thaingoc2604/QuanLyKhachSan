using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace CreateLogFiles
{
	/// <summary>
	/// Summary description for CreateLogFiles1.
	/// </summary>
	public class CreateLogFiles1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TxtFilename;
		protected System.Web.UI.WebControls.Button BtnFind;
		protected System.Web.UI.WebControls.Label Msg;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BtnFind_Click(object sender, System.EventArgs e)
		{
			try
			{
				StreamReader sr = new StreamReader(this.TxtFilename.Text);
				sr.Read();
				sr.Close();
				Msg.Visible = true;
				Msg.Text = "File "+ this.TxtFilename.Text +" was found";
			}
			catch(Exception ex)
			{
				CreateLogFiles Err = new CreateLogFiles();
				Err.ErrorLog(Server.MapPath("Logs/ErrorLog"),ex.Message);
				Msg.Visible = true;
				Msg.Text = "Fatal error : "+ ex.Message + ", please find a complete error at ErrorLog file";
			}
		}
	}
}
