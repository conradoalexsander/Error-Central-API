using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorCentral.Data.Repository
{
    public class ErrorRepository : IErrorRepository
    {
        protected readonly Context _context;

        public ErrorRepository(Context context)
        {
            _context = context;
        }

        public virtual void Add(Error entity)
        {
            _context.Error.Add(entity);
            _context.SaveChanges(); //necessário para incluir uma alteração no banco
        }

        public void Delete(int id)
        {
            var entity = _context.Error.FirstOrDefault(x => x.Id == id);
            _context.Error.Remove(entity);
            _context.SaveChanges();
        }

        public virtual List<Error> SelectAll()
        {
            return _context.Error.ToList();
        }

        public virtual Error SelectById(int id)
        {
            return _context.Error.FirstOrDefault(x => x.Id == id);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}