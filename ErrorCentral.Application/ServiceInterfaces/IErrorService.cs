using ErrorCentral.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Application.ServiceInterfaces
{
    public interface IErrorService
    {
        void Add(Error entity);

        Error SelectById(int id);

        void Delete(int id);

        List<Error> SelectAll();
    }
}