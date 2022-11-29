using AutoMapper;
using HR.Leave.Management.Application.DTOs.LeaveAllocation;
using HR.Leave.Management.Application.DTOs.LeaveRequest;
using HR.Leave.Management.Application.DTOs.LeaveType;
using HR.Leave.Management.Domain;

namespace HR.Leave.Management.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveType Mapping

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();

            #endregion LeaveType Mapping

            #region LeaveAllocation Mapping

            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            #endregion LeaveAllocation Mapping

            #region LeaveRequest Mapping

            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, ChangeLeaveRequestApprovalDto>().ReverseMap();

            #endregion LeaveRequest Mapping
        }
    }
}