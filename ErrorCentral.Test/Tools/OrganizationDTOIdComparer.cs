using ErrorCentral.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Test.Tools
{
    public class OrganizationDTOIdComparer : IEqualityComparer<OrganizationDTO>
    {
        public bool Equals(OrganizationDTO x, OrganizationDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(OrganizationDTO obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}