using dal.Model;
using dal.Persistence;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace TestFC
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ListAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void gvFinancialInstruments_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Deleting") 
            {
                Delete(sender, e);
            }
            else
            {
                ShowSelectedData(sender, e);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FinancialInstrumentDAL fiDal = new FinancialInstrumentDAL();
                FinancialInstrument fi = new FinancialInstrument();
               
                fi.strName = txtName.Text;
                fi.vlMarketValue= Convert.ToDouble(txtMarketvalue.Text);
                fi.intType = Convert.ToInt32(ddlType.SelectedValue);

                if (txtIdFinancialInstrument.Text=="")
                { 
                    fiDal.Insert(fi);
                    lblInfo.Text = "Financial Instrument Inserted!";
                    divInfo.Attributes.CssStyle.Clear();
                    divInfo.Attributes.CssStyle.Add("style", "display: block");

                }
                else
                {
                    fi.idFinancialInstrument = Convert.ToInt32(txtIdFinancialInstrument.Text);
                    fiDal.Update(fi);
                    showMsg("Financial Instrument Updated!");
                }
                
                ListAll();
                Clear();
            }
            catch (Exception ex)
            {
                showError(new Exception("Fill the fields correctly! / ErrorLog:" + ex.Message));
            }

        }
        protected void btnClear_Click(object sender, EventArgs e) {
         Clear();
            lblInfo.Text = "";
        }

        protected void ShowSelectedData(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                FinancialInstrumentDAL fiDal = new FinancialInstrumentDAL();
                FinancialInstrument fi = new FinancialInstrument();

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvFinancialInstruments.Rows[index];
                fi = fiDal.FindbyId(Convert.ToInt32(gvRow.Cells[0].Text));
                txtIdFinancialInstrument.Text = fi.idFinancialInstrument.ToString();
                txtName.Text = fi.strName;
                ddlType.SelectedValue = fi.intType.ToString();
                txtCategory.Text = fi.strCategory;
                txtMarketvalue.Text = fi.vlMarketValue.ToString();
                txtdtInsert.Text = fi.dtInsert.ToString();
            }
            catch (Exception ex)
            {
                showError(ex);
            }
           
        }
        protected void Delete(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                FinancialInstrumentDAL fiDal = new FinancialInstrumentDAL();
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvFinancialInstruments.Rows[index];
                fiDal.Delete(Convert.ToInt32(gvRow.Cells[0].Text));
                ListAll();
                Clear();
                showMsg("Financial Instrument Deleted!");
            }
            catch (Exception ex)
            {
                showError(ex);
            }
        }
        private void ListAll()
        {
            try
            {
                FinancialInstrumentDAL fiDal = new FinancialInstrumentDAL();

                gvFinancialInstruments.DataSource = fiDal.FindAll();
                gvFinancialInstruments.DataBind();
            }
            catch (Exception ex)
            {
                showError(ex);
            }

        }
        private void Clear()
        {
            txtIdFinancialInstrument.Text = "";
            txtName.Text = "";
            txtCategory.Text = "";
            txtMarketvalue.Text = "";
            txtdtInsert.Text = "";
            ddlType.SelectedIndex = 0;
        }
        private void showError(Exception ex)
        {

            lblInfo.Text = "Error: " + ex.Message;
            lblInfo.BackColor = Color.Red;
            lblInfo.ForeColor = Color.White;
        }
        private void showMsg(String msg)
        {

            lblInfo.Text = "Info: " + msg;
            lblInfo.BackColor = Color.Blue;
            lblInfo.ForeColor = Color.White;
        }
    }
}