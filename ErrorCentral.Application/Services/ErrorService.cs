using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using System;
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

        public void Add(Exception ex, string userName)
        {
            Error exceptionError = new Error()
            {
                CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                StackTrace = ex.StackTrace,
                UserName = userName,
                Message = ex.Message
            };

            _repo.Add(exceptionError);
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