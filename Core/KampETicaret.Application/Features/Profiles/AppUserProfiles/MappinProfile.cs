using AutoMapper;
using KampETicaret.Application.Features.Commands.AppUserCommands.CreateAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.DeleteAppUser;
using KampETicaret.Application.Features.Commands.AppUserCommands.UpdateAppUser;
using KampETicaret.Application.Features.Queries.AppUserQueries.GetAllAppUser;
using KampETicaret.Application.Features.Queries.AppUserQueries.GetByNameAppUser;
using KampETicaret.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampETicaret.Application.Features.Profiles.AppUserProfiles
{
    public class MappinProfile:Profile
    {
        public MappinProfile()
        {
            CreateMap<CreateAppUserCommand, AppUser>().ReverseMap();
            CreateMap<CreateAppUserCommandDto,AppUser>().ReverseMap();

            CreateMap<UpdateAppUserCommand, AppUser>().ReverseMap();
            CreateMap<UpdateAppUserCommandDto, AppUser>().ReverseMap();

            CreateMap<DeleteAppUserCommand, AppUser>().ReverseMap();

            CreateMap<GetAllAppUserQueryDto, AppUser>().ReverseMap();

            CreateMap<GetByNameAppUserQueryDto, AppUser>().ReverseMap();
        }
    }
}
