using ErrorCentral.Application.DTOs;

using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Application.ServiceInterfaces
{
    public interface IOrganizationService
    {
        void Add(OrganizationAddDTO entity);

        void Update(OrganizationDTO entity);

        OrganizationDTO SelectById(int id);

        void Delete(int id);

        List<OrganizationDTO> SelectAll();
    }
}