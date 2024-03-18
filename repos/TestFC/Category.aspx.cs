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
    public partial class _Category : Page
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
        protected void gvCategory_OnRowCommand(object sender, GridViewCommandEventArgs e)
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
                CategoryDAL ctDal = new CategoryDAL();
                Category ct = new Category();

                ct.strName = txtName.Text;
                ct.iniValue= Convert.ToDouble(txtIniValue.Text);
                ct.finValue = Convert.ToDouble(txtFinValue.Text);

               

                if (txtIdCategory.Text=="")
                {
                    if (ctDal.ExistsbyRange(0, Convert.ToDouble(txtIniValue.Text), Convert.ToDouble(txtFinValue.Text)))
                    {
                        showError(new Exception("Range Already Exists!!!"));
                    }
                    else
                    {
                        ctDal.Insert(ct);
                        showMsg("Category Inserted!");
                        Clear();
                    }
                }
                else
                {
                    ct.idCategory = Convert.ToInt32(txtIdCategory.Text);
                        if (ctDal.ExistsbyRange(Convert.ToInt32(txtIdCategory.Text), Convert.ToDouble(txtIniValue.Text), Convert.ToDouble(txtFinValue.Text)))
                        {
                            showError(new Exception("Range Already Exists!!!"));
                        }
                        else
                        {
                            ctDal.Update(ct);
                            showMsg("Category Updated!");
                        Clear();
                    }
                }
                ListAll();
                
                
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
                CategoryDAL ctDal = new CategoryDAL();
                Category ct = new Category();

                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvCategory.Rows[index];
                ct = ctDal.FindbyId(Convert.ToInt32(gvRow.Cells[0].Text));
                txtIdCategory.Text = ct.idCategory.ToString();
                txtName.Text = ct.strName;
                txtIniValue.Text = ct.iniValue.ToString();
                txtFinValue.Text = ct.finValue.ToString();
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
                CategoryDAL ctDal = new CategoryDAL();
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvRow = gvCategory.Rows[index];
                ctDal.Delete(Convert.ToInt32(gvRow.Cells[0].Text));
                ListAll();
                Clear();
                showMsg("Category Deleted!");
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
                CategoryDAL ctDal = new CategoryDAL();

                gvCategory.DataSource = ctDal.FindAll();
                gvCategory.DataBind();
            }
            catch (Exception ex)
            {
                showError(ex);
            }
        }
        private void Clear()
        {
            txtIdCategory.Text = "";
            txtName.Text = "";
            txtIniValue.Text = "";
            txtFinValue.Text = "";
        }

        private void showError(Exception ex) {

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