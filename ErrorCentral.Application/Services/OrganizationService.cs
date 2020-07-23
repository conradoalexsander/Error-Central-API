using AutoMapper;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using System.Collections.Generic;

namespace ErrorCentral.Application.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _repo;
        private readonly IMapper _mapper;

        public OrganizationService(IOrganizationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Add(OrganizationAddDTO entity)
        {
            _repo.Add(_mapper.Map<Organization>(entity));
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public List<OrganizationDTO> SelectAll()
        {
            return _mapper.Map<List<OrganizationDTO>>(_repo.SelectAll());
        }

        public OrganizationDTO SelectById(int id)
        {
            return _mapper.Map<OrganizationDTO>(_repo.SelectById(id));
        }

        public void Update(OrganizationDTO entity)
        {
            _repo.Update(_mapper.Map<Organization>(entity));
        }
    }
}