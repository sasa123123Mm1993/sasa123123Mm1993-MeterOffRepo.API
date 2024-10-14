using AutoMapper;
using MeterOff.Core.Interfaces;
using MeterOff.Core.Models;
using MeterOff.Core.Models.Dto.CMaintenenceMetersOff;
using MeterOff.Core.Models.Dto.ControlCard;
using MeterOff.Core.Models.Dto.MeterOffReasons;
using MeterOff.Core.Models.Dto.SmallDepartmentDtos;
using MeterOff.Core.Models.Dto.UserDto;
using MeterOff.Core.Models.Identity;
using MeterOff.Core.Models.Infrastructure;
using MeterOff.Core.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MeterOff.Core.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();


            //CreateMap<InsertCUploadMainteneceMetersOffReasonInput, CUploadMainteneceMetersOffReason>();
            //CreateMap<CUploadMainteneceMetersOffReason, UploadMeterOffReasonsOutput>();
            // CreateMap<UploadMeterOffReasonsOutput, CUploadMainteneceMetersOffReason>();
            CreateMap<CUploadMainteneceMetersOffReason, UploadMeterOffReasonsOutput>();

            CreateMap<CMaintenenceMetersOff, InsertCMaintenenceMetersOffInput>();
            CreateMap<InsertCMaintenenceMetersOffInput, CMaintenenceMetersOff>();

            CreateMap<CMaintenenceMetersOffOutput, CMaintenenceMetersOff>();
            CreateMap<InsertCMaintenenceMetersOffInput, CMaintenenceMetersOffOutput>();

            CreateMap<CMaintenenceMetersOff, InsertCMaintenenceMetersOffInput>();
            CreateMap<InsertCMaintenenceMetersOffInput, CMaintenenceMetersOff>();


            CreateMap<SmallDepartment_User, SmallDepartmentUserDtoOutput>();
            CreateMap<SmallDepartmentUserDtoOutput, SmallDepartment_User>();


            CreateMap<ControlCard, InsertControlCardInput>();
            CreateMap<InsertControlCardInput, ControlCard>();


            CreateMap<UserDetails, ApplicationUser>();
            CreateMap<ApplicationUser, UserDetails>();

            CreateMap<ApplicationUser, GetAllUsersWithDepartmentsOutput>()
           .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.SmallDepartments));
            //.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles.Select(o => o.Role)));

            //  CreateMap<AppRole, UserRoleDto>()
            //.ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.UserRoles.Select(ud => ud.Role)));

            CreateMap<EditUserInput, Task<EditUserInput>>();
            CreateMap<InsertUserInput, Task<InsertUserInput>>();
            CreateMap<Task<InsertUserInput>, InsertUserInput>();
           



            CreateMap<SmallDepartment_UserDto, SmallDepartment_User>();
            CreateMap<SmallDepartment_User, SmallDepartment_UserDto>();

            CreateMap<AppUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, AppUserDto>();

            CreateMap<SmallDepartment, SmallDepartmentDto>();
            CreateMap<SmallDepartmentDto, SmallDepartment>();


            CreateMap<AppRole, AppRoleDto>();
            CreateMap<AppRoleDto, AppRole>();


            CreateMap<ApplicationUser, userData>();





        }
    }
}
