using AutoMapper;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Domain.Model;
using ErrorCentral.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repo;
        private readonly IMapper _mapper;

        public LogService(ILogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Add(LogAddDTO entity)
        {
            _repo.Add(_mapper.Map<Log>(entity));
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public void DeleteMany(List<int> ids)
        {
            _repo.DeleteMany(ids);
        }

        public List<LogDTO> SelectAll()
        {
            return _mapper.Map<List<LogDTO>>(_repo.SelectAll());
        }

        public LogDTO SelectById(int id)
        {
            return _mapper.Map<LogDTO>(_repo.SelectById(id));
        }

        public void Update(LogUpdateDTO entity)
        {
            Log updatedLog = _repo.SelectById(entity.Id);
            updatedLog.Title = entity.Title;
            updatedLog.Description = entity.Description;
            updatedLog.Level = entity.Level;
            _repo.Update(_mapper.Map<Log>(updatedLog));
        }
    }
}