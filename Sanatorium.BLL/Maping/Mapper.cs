using AutoMapper;
using Sanatorium.BLL.DTOs;
using Sanatorium.DAL.Entities;

namespace Sanatorium.BLL.Maping
{
    public class Mapper
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DoctorDto, Doctor>();
            cfg.CreateMap<Doctor, DoctorDto>();

            cfg.CreateMap<Illness, IllnessDto>();
            cfg.CreateMap<IllnessDto, Illness>();


            cfg.CreateMap<Patient, PatientDto>();
            cfg.CreateMap<PatientDto, Patient>();

            cfg.CreateMap<Procedure, ProcedureDto>();
            cfg.CreateMap<ProcedureDto, Procedure>();

            cfg.CreateMap<Reciept, RecieptDto>();
            cfg.CreateMap<RecieptDto, Reciept>();

            cfg.CreateMap<Room, RoomDto>();
            cfg.CreateMap<RoomDto, Room>();

            cfg.CreateMap<Voucher, VoucherDto>();
            cfg.CreateMap<VoucherDto, Voucher>();

            cfg.CreateMap<VoucherRoom, VoucherRoomDto>();
            cfg.CreateMap<VoucherRoomDto, VoucherRoom>();

            cfg.CreateMap<VoucherProcedure, VoucherProcedureDto>();
            cfg.CreateMap<VoucherProcedureDto, VoucherProcedure>();

            cfg.CreateMap<IllnessStatistic, IllnessStasticDto>();

            cfg.CreateMap<ProcedureStatistic, ProcedureStatisticDto>();

            cfg.CreateMap<NewPatientsStatistics, NewPatientsStatisticsDto>();

            cfg.CreateMap<AgeStatistics, AgeStatisticDto>();

        }).CreateMapper();

        public Patient MapFromDto(PatientDto patientDto)
        {
            return _mapper.Map<Patient>(patientDto);
        }

        public Room MapFromDto(RoomDto roomDto)
        {
            return _mapper.Map<Room>(roomDto);
        }

        public Doctor MapFromDto(DoctorDto doctorDto)
        {
            return _mapper.Map<Doctor>(doctorDto);
        }

        public Illness MapFromDto(IllnessDto illnessDto)
        {
            return _mapper.Map<Illness>(illnessDto);
        }

        public VoucherRoom MapFromDto(VoucherRoomDto voucherRoomDto)
        {
            return _mapper.Map<VoucherRoom>(voucherRoomDto);
        }

        public Voucher MapFromDto(VoucherDto voucherDto)
        {
            var voucher = new Voucher
            {
                CreationDate = voucherDto.CreationDate,
                ExpirationDate = voucherDto.ExpirationDate,
                Patient = new Patient { Id = voucherDto.PatientId },
                Illness = new Illness { Id = voucherDto.IllnessId },
                VoucherRooms = MapFromDtoVoucherRoom(voucherDto.VoucherRooms)
            };
            return voucher;
        }

        public IllnessDto MapToDto(Illness illness)
        {
            return _mapper.Map<IllnessDto>(illness);
        }

        public PatientDto MapToDto(Patient patient)
        {
            return _mapper.Map<PatientDto>(patient);
        }

        public ProcedureDto MapToDto(Procedure procedure)
        {
            return _mapper.Map<ProcedureDto>(procedure);
        }

        public RoomDto MapToDto(Room room)
        {
            return _mapper.Map<RoomDto>(room);
        }

        public Procedure MapFromDto(ProcedureDto procedureDto)
        {
            return _mapper.Map<Procedure>(procedureDto);
        }

        public DoctorDto MapToDto(Doctor doctor)
        {
            return _mapper.Map<DoctorDto>(doctor);
        }

        public RecieptDto MapToDto(Reciept reciept)
        {
            return _mapper.Map<RecieptDto>(reciept);
        }

        public List<RoomDto> MapToDto(List<Room> rooms)
        {
            return _mapper.Map<List<RoomDto>>(rooms);
        }

        public List<VoucherDto> MapToDto(List<Voucher> vouchers)
        {
            return _mapper.Map<List<VoucherDto>>(vouchers);
        }

        public List<IllnessDto> MapToDto(List<Illness> illnesses)
        {
            return _mapper.Map<List<IllnessDto>>(illnesses);
        }

        public List<ProcedureDto> MapToDto(List<Procedure> procedures)
        {
            return _mapper.Map<List<ProcedureDto>>(procedures);
        }

        public List<PatientDto> MapToDto(List<Patient> patients)
        {
            return _mapper.Map<List<PatientDto>>(patients);
        }

        public List<DoctorDto> MapToDto(List<Doctor> doctors)
        {
            return _mapper.Map<List<DoctorDto>>(doctors);
        }

        public List<RecieptDto> MapToDto(List<Reciept> reciepts)
        {
            return _mapper.Map<List<RecieptDto>>(reciepts);
        }

        public List<ProcedureStatisticDto> MapToDto(List<ProcedureStatistic> procedures)
        {
            return _mapper.Map<List<ProcedureStatisticDto>>(procedures);
        }

        public List<IllnessStasticDto> MapToDto(List<IllnessStatistic> illnesses)
        {
            return _mapper.Map<List<IllnessStasticDto>>(illnesses);
        }

        public List<NewPatientsStatisticsDto> MapToDto(List<NewPatientsStatistics> patients)
        {
            return _mapper.Map<List<NewPatientsStatisticsDto>>(patients);
        }

        public List<AgeStatisticDto> MapToDto(List<AgeStatistics> agePatients)
        {
            return _mapper.Map<List<AgeStatisticDto>>(agePatients);
        }

        private List<VoucherRoom> MapFromDtoVoucherRoom(List<VoucherRoomDto> voucherRooms)
        {
            return _mapper.Map<List<VoucherRoom>>(voucherRooms);
        }
    }
}
