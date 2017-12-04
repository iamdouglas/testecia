using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using NHibernate.Linq;

namespace TesteSeusConhecimentos.Infra
{
    public class EnterpriseUserRepository : IEnterpriseUserRepository
    {
        public EnterpriseUserRepository() { }

        public IList<EnterpriseUser> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {

                var query = (from e in session.Query<EnterpriseUser>()
                             //join en in session.Query<Enterprise>() on e.Enterprise.IdEnterprise equals en.IdEnterprise
                             //join u in session.Query<User>() on e.IdUser equals u.IdUser
                             select e);

                return query.ToList();
            }
        }

        public IList<EnterpriseUser> GetByUserId(int idUser)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                var query = (from e in session.Query<EnterpriseUser>()
                             join en in session.Query<Enterprise>() on e.IdEnterprise equals en.IdEnterprise
                             join u in session.Query<User>() on e.IdUser equals u.IdUser
                             where u.IdUser == idUser
                             select e);

                return query.ToList();
            }
        }
        public IList<EnterpriseUser> GetByEnterpriseId(int idEnterprise)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                var query = (from e in session.Query<EnterpriseUser>()
                             join en in session.Query<Enterprise>() on e.IdEnterprise equals en.IdEnterprise
                             join u in session.Query<User>() on e.IdUser equals u.IdUser
                             where en.IdEnterprise == idEnterprise
                             select e);

                return query.ToList();
            }
        }
        public EnterpriseUser GetByEnterpriseUserId(int idEnterprise, int userId)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                var query = (from e in session.Query<EnterpriseUser>()
                             join en in session.Query<Enterprise>() on e.IdEnterprise equals en.IdEnterprise
                             join u in session.Query<User>() on e.IdUser equals u.IdUser
                             where e.IdEnterprise == idEnterprise && e.IdUser == userId
                             select e);

                return query.FirstOrDefault();
            }
        }

        public void Delete(int enterpriseId, int userId)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        EnterpriseUser enterpriseUser = GetByEnterpriseUserId(enterpriseId, userId);
                        if (enterpriseUser != null)
                        {
                            session.Delete(enterpriseUser);
                            transacao.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar usuário: " + e.Message);
                    }
                }
            }
        }

        public void Save(EnterpriseUser enterpriseUser)
        {
            if (enterpriseUser.IsNew())
                Add(enterpriseUser);
            else
                Update(enterpriseUser);
        }

        private void Add(EnterpriseUser enterpriseUser)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(enterpriseUser);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao relacionar usuario x empresa: " + e.Message);
                    }
                }
            }
        }

        private void Update(EnterpriseUser enterprise)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(enterprise);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar empresa: " + e.Message);
                    }
                }
            }
        }

    }
}
