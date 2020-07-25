using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using System.Collections.Generic;

namespace ErrorCentral.Application.Services
{
    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository _repo;

        public ErrorService(IErrorRepository repo)
        {
            _repo = repo;
        }

        public void Add(Error entity)
        {
            _repo.Add(entity);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<Error> SelectAll()
        {
            return _repo.SelectAll();
        }

        public Error SelectById(int id)
        {
            return _repo.SelectById(id);
        }
    }
}