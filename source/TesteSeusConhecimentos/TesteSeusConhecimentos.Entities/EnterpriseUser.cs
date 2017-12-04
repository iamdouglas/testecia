using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class EnterpriseUser
    {
        public virtual int IdEnterpriseUser { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual int IdUser { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public virtual User User { get; set; }

        public EnterpriseUser()
        { }

        public EnterpriseUser(int idEnterpriseUser, int idEnterprise, int idUser)
        {
            this.IdEnterpriseUser = idEnterpriseUser;
            this.IdEnterprise = idEnterprise;
            this.IdUser = idUser;
        }
        public virtual bool IsNew()
        {
            return this.IdEnterpriseUser == 0;
        }
    }
}
