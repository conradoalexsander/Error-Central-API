using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ErrorCentral.Data.Repository
{
    public class LogRepository : BaseRepository<Log>, ILogRepository
    {
        public LogRepository(Context context) : base(context)
        {
        }

        public override void Add(Log entity)
        {
            entity.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _context.Log.Add(entity);
            _context.Log.Include(p => p.Organization);
            _context.SaveChanges(); //necessário para incluir uma alteração no banco
        }

        public override List<Log> SelectAll()
        {
            return _context.Log.Include(p => p.Organization).ToList();
        }

        public void DeleteMany(List<int> ids)
        {
            var entities = _context.Log.Where(x => ids.Contains(x.Id));
            _context.Log.RemoveRange(entities);
            _context.SaveChanges();
        }
    }
}