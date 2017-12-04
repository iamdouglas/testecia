using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Relacionamentos : System.Web.UI.Page
    {
        private IEnterpriseRepository enterpriseRepository;
        private IUserRepository userRepository;
        private IEnterpriseUserRepository enterpriseUserRepository;

        public Relacionamentos()
        {
            this.enterpriseRepository = new EnterpriseRepository();
            this.userRepository = new UserRepository();
            this.enterpriseUserRepository = new EnterpriseUserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                CarregarDropDownEnterprise();
                CarregarDropDownUsers();
                var teste = enterpriseUserRepository.GetAll();
            }
        }
        private void CarregarDropDownEnterprise()
        {
            var enterprises = enterpriseRepository.GetAll();
            ddlEnterprise.DataTextField = "Name";
            ddlEnterprise.DataValueField = "IdEnterprise";
            ddlEnterprise.DataSource = enterprises.ToList();
            ddlEnterprise.DataBind();
        }
        private void CarregarDropDownUsers()
        {
            var users = userRepository.GetAll();
            ddlUser.DataTextField = "Name";
            ddlUser.DataValueField = "IdUser";
            ddlUser.DataSource = users.ToList();
            ddlUser.DataBind();
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            int idEnterpriseUser = 0;
            EnterpriseUser enterpriseUser = new EnterpriseUser(idEnterpriseUser,int.Parse(ddlEnterprise.SelectedValue),int.Parse(ddlUser.SelectedValue));
            enterpriseUserRepository.Save(enterpriseUser);

            Response.Redirect("~/Infocast/Users.aspx");
        }
    }
}