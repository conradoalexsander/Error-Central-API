using AutoMapper;
using ErrorCentral.Application.DTOs;
using ErrorCentral.Application.ServiceInterfaces;
using ErrorCentral.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ErrorCentral.Test.Application
{
    /// Fake Data
    /// powered by https://mockaroo.com/
    ///
    public class FakeContext
    {
        private Dictionary<Type, string> DataFileNames { get; } =
           new Dictionary<Type, string>();

        private string FileName<T>()
        {
            return DataFileNames[typeof(T)];
        }

        public IMapper Mapper { get; }

        public FakeContext()
        {
            DataFileNames.Add(typeof(Log), $"TestData{Path.DirectorySeparatorChar}log.json");
            DataFileNames.Add(typeof(LogDTO), $"TestData{Path.DirectorySeparatorChar}log.json");
            DataFileNames.Add(typeof(LogAddDTO), $"TestData{Path.DirectorySeparatorChar}log.json");
            DataFileNames.Add(typeof(LogUpdateDTO), $"TestData{Path.DirectorySeparatorChar}log.json");
            DataFileNames.Add(typeof(Organization), $"..\\..\\TestData{Path.DirectorySeparatorChar}organization.json");
            DataFileNames.Add(typeof(OrganizationDTO), $"..\\..\\..\\TestData{Path.DirectorySeparatorChar}organization.json");
            DataFileNames.Add(typeof(OrganizationAddDTO), $"..\\..\\..\\TestData{Path.DirectorySeparatorChar}organization.json");

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Log, LogDTO>().ReverseMap();
                cfg.CreateMap<Organization, OrganizationDTO>().ReverseMap();

                cfg.CreateMap<Log, LogAddDTO>().ReverseMap();
                cfg.CreateMap<Organization, OrganizationAddDTO>().ReverseMap();

                cfg.CreateMap<Log, LogUpdateDTO>().ReverseMap();

                cfg.CreateMap<IdentityUser, UserDTO>().ReverseMap();

                cfg.CreateMap<IdentityUser, UserIdDTO>().ReverseMap();
            });

            this.Mapper = configuration.CreateMapper();
        }

        public List<T> Get<T>()
        {
            string content = File.ReadAllText(FileName<T>());
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public Mock<IOrganizationService> FakeOrganizationService()
        {
            var service = new Mock<IOrganizationService>();

            service.Setup(x => x.SelectById(It.IsAny<int>())).
                Returns((int id) => Get<OrganizationDTO>().FirstOrDefault(x => x.Id == id));

            service.Setup(x => x.Add(It.IsAny<OrganizationAddDTO>()));

            service.Setup(x => x.SelectAll()).
                Returns(() => Get<OrganizationDTO>());

            return service;
        }

        public Mock<IErrorService> FakeErrorService()
        {
            var service = new Mock<IErrorService>();

            return service;
        }
    }
}