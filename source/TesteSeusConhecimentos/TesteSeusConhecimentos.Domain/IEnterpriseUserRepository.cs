using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface IEnterpriseUserRepository
    {
        IList<EnterpriseUser> GetAll();
        void Delete(int enterpriseId, int userId);
        IList<EnterpriseUser> GetByEnterpriseId(int idEnterprise);
        EnterpriseUser GetByEnterpriseUserId(int idEnterprise, int userId);
        IList<EnterpriseUser> GetByUserId(int idUser);
        /// <summary>
        /// Cria ou altera as relação de usuario x empresa
        /// </summary>
        /// <param name="enterprise"></param>
        void Save(EnterpriseUser enterpriseUser);
    }
}
