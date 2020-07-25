using ErrorCentral.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Application.ServiceInterfaces
{
    public interface IErrorService
    {
        void Add(Exception ex, string userName);

        Error SelectById(int id);

        void Delete(int id);

        List<Error> SelectAll();
    }
}