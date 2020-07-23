using ErrorCentral.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Application.ServiceInterfaces
{
    public interface ILogService
    {
        void Add(LogAddDTO entity);

        void Update(LogUpdateDTO entity);

        LogDTO SelectById(int id);

        void Delete(int id);

        void DeleteMany(List<int> ids);

        List<LogDTO> SelectAll();
    }
}