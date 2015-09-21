using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndianaWhiskey
{
    public partial class InvoiceEntry : Form
    {
        private string invoiceID = "";

        public InvoiceEntry(int UserID)
        {
            InitializeComponent();
            if (UserID <= 0)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
            else
            {
                this.pageHeader1.SetHeader("Invoice Entry", UserID, this.Width);
                PopulateControls();
            }
        }

        private void PopulateControls()
        {
            Common.PopulateComboBox("usp_UOMList", cboUOM, "Description", "UOMID", null, this.BindingContext);
            Common.PopulateComboBox("usp_CompanyList", cboCompany, "Name", "CompanyID", null, this.BindingContext);
            cboUOM.SelectedIndex = -1;
            cboCompany.SelectedIndex = -1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cboUOM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddMaterial();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMaterial();
        }

        private string StartInvoice()
        {
            string strCompanyID = "";
            string strInvoiceID = "";

            if (cboCompany.SelectedIndex < 0 && (cboCompany.Text.Trim().Length == 0 || txtCompanyAddress.Text.Trim().Length == 0))
            {
                MessageBox.Show("Please select or enter the company name and address.");
                cboCompany.Focus();
                strInvoiceID = "";
            }
            else if (txtInvoiceNumber.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter the invoice number.");
                txtInvoiceNumber.Focus();
                strInvoiceID = "";
            }
            else if (dteInvoice.Value == null)
            {
                MessageBox.Show("Please enter the invoice date.");
                dteInvoice.Focus();
                strInvoiceID = "";
            }
            else
            {
                // All validation passed -> add invoice
                strCompanyID = AddUpdateCompany();

                DB db = new DB();
                db.AddParam("@CompanyID", strCompanyID);
                db.AddParam("@InvoiceNumber", txtInvoiceNumber.Text.Trim());
                db.AddParam("@InvoiceDate", dteInvoice.Value.ToString("MM/dd/yyyy"));
                DataTable dtInvoice = db.SQLResults("usp_InvoiceAddUpdate");

                if (dtInvoice != null && dtInvoice.Rows != null && dtInvoice.Rows.Count > 0)
                {
                    if (dtInvoice.Rows[0]["InvoiceID"] != null && dtInvoice.Rows[0]["InvoiceID"] != DBNull.Value)
                        strInvoiceID = dtInvoice.Rows[0]["InvoiceID"].ToString();
                }
            }

            return strInvoiceID;
        }

        private void AddMaterial()
        {
            string strUOMID = "", strMaterialID = "", strInvoiceID = "";

            strInvoiceID = StartInvoice();
            if (strInvoiceID.Trim().Length == 0 || strInvoiceID == "0")
            {
                // Invoice validation failed, just return
                return;
            }
            else if (cboMaterial.SelectedIndex < 0 && cboMaterial.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select or enter a Material.");
                cboMaterial.Focus();
                return;
            }
            else if (txtQty.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a quantity received.");
                txtQty.Focus();
                return;
            }
            else if (txtCost.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please enter a cost.");
                txtCost.Focus();
                return;
            }
            else if (cboUOM.SelectedIndex < 0 && cboUOM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please select or enter a unit of measure.");
                cboUOM.Focus();
                return;
            }
            else
            {
                // All validation passed -> add material to invoice
                if (cboUOM.SelectedIndex < 0)
                    strUOMID = AddUOM();
                else
                    strUOMID = cboUOM.SelectedValue.ToString();

                if (cboMaterial.SelectedIndex < 0)
                    strMaterialID = AddNewMaterial(strUOMID);
                else
                    strMaterialID = cboMaterial.SelectedValue.ToString();

                DB db = new DB();
                db.AddParam("@InvoiceID", strInvoiceID);
                db.AddParam("@MaterialID", strMaterialID);
                db.AddParam("@Qty", txtQty.Text.Trim());
                db.AddParam("@Cost", txtCost.Text.Trim());
                db.SQLResults("usp_InvoiceMaterialAdd");

                LoadMaterials();
            }
        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddMaterial();
            }
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CompanyID = 0;

            if (cboCompany.SelectedIndex >= 0 && int.TryParse(cboCompany.SelectedValue.ToString(), out CompanyID))
            {
                txtCompanyAddress.Text = GetCompanyAddress(CompanyID.ToString());
            }
        }

        private string AddUOM()
        {
            string uomID = "";

            DB db = new DB();
            db.AddParam("@UOM", cboUOM.Text.Trim());
            DataTable dt = db.SQLResults("usp_UOMAdd");
            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["UOMID"] != null && dt.Rows[0]["UOMID"] != DBNull.Value)
                    uomID = dt.Rows[0]["UOMID"].ToString();
            }
            db.CleanUp();

            return uomID;
        }

        private string AddNewMaterial(string uomID)
        {
            string materialID = "";

            DB db = new DB();
            db.AddParam("@MaterialID", cboMaterial.SelectedIndex < 0 ? "0" : cboMaterial.SelectedValue);
            db.AddParam("@Description", cboMaterial.Text.Trim());
            db.AddParam("@Qty", txtQty.Text.Trim());
            db.AddParam("@Cost", txtCost.Text.Trim());
            db.AddParam("@UOMID", uomID);
            DataTable dtMaterial = db.SQLResults("usp_MaterialAddUpdate");
            db.CleanUp();

            if (dtMaterial != null && dtMaterial.Rows != null && dtMaterial.Rows.Count > 0)
            {
                if (dtMaterial.Rows[0]["MaterialID"] != null && dtMaterial.Rows[0]["MaterialID"] != DBNull.Value)
                    materialID = dtMaterial.Rows[0]["MaterialID"].ToString();
            }

            return materialID;
        }

        private string AddUpdateCompany()
        {
            string companyID = "";

            DB db = new DB();
            db.AddParam("@Name", cboCompany.Text.Trim());
            db.AddParam("@Address", txtCompanyAddress.Text.Trim());
            DataTable dtCompany = db.SQLResults("usp_CompanyAddUpdate");
            db.CleanUp();

            if (dtCompany != null && dtCompany.Rows != null && dtCompany.Rows.Count > 0)
            {
                if (dtCompany.Rows[0]["CompanyID"] != null && dtCompany.Rows[0]["CompanyID"] != DBNull.Value)
                    companyID = dtCompany.Rows[0]["CompanyID"].ToString();
            }

            return companyID;
        }

        private string GetCompanyAddress(string companyID)
        {
            string address = "";

            DB db = new DB();
            db.AddParam("@CompanyID", companyID);
            DataTable dtCompany = db.SQLResults("usp_CompanyGet");
            if (dtCompany != null && dtCompany.Rows != null && dtCompany.Rows.Count > 0 && dtCompany.Rows[0]["Address"] != null && dtCompany.Rows[0]["Address"] != DBNull.Value)
                address = dtCompany.Rows[0]["Address"].ToString();
            db.CleanUp();

            return address;
        }

        private void txtCost_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddMaterial();
            }
        }

        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            int materialID = 0;
            if (cboMaterial.SelectedIndex >= 0 && int.TryParse(cboMaterial.SelectedValue.ToString(), out materialID))
            {
                DB db = new DB();
                db.AddParam("@MaterialID", materialID);
                DataTable dtMat = db.SQLResults("usp_MaterialGet");
                if (dtMat.Rows != null && dtMat.Rows.Count > 0)
                {
                    if (dtMat.Rows[0]["CurrentCost"] != null && dtMat.Rows[0]["CurrentCost"] != DBNull.Value)
                        txtCost.Text = dtMat.Rows[0]["CurrentCost"].ToString();
                    if (dtMat.Rows[0]["UOMID"] != null && dtMat.Rows[0]["UOMID"] != DBNull.Value)
                        cboUOM.SelectedValue = dtMat.Rows[0]["UOMID"].ToString();
                }
                db.CleanUp();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void LoadMaterials()
        {
            DB db = new DB();
            db.AddParam("@InvoiceNumber", txtInvoiceNumber.Text.Trim());
            DataTable dtMaterials = db.SQLResults("usp_InvoiceMaterialList");
            db.CleanUp();

            dgMaterials.DataSource = dtMaterials;
        }
    }
}
