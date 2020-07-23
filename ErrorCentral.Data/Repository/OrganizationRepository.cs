using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ErrorCentral.Data.Repository
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(Context context) : base(context)
        {
        }

        public override List<Organization> SelectAll()
        {
            return _context.Organization.Include(p => p.Logs).ToList();
        }

        public override Organization SelectById(int id)
        {
            return _context.Organization.Include(p => p.Logs).FirstOrDefault(x => x.Id == id);
        }
    }
}