using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf;
using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _repository;

        private readonly IDoctorRepository _doctorRepository;

        private Mapper _mapper = new();

        public VoucherService(IVoucherRepository repository, IDoctorRepository doctorRepository) 
        {
            _repository= repository;
            _doctorRepository= doctorRepository;
        }

        public async Task AddVoucherAsync(VoucherDto voucherDto, CancellationToken cancellationToken)
        {
            var entity = _mapper.MapFromDto(voucherDto);
            await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<byte[]> GenerateDirectionPdf(int id, CancellationToken cancellationToken)
        {
            var voucher = await _repository.GetOneAsync(id, cancellationToken);
            var doctor = await _doctorRepository.GetOneForDirectionAsync(voucher.Id, voucher.Illness.Type, cancellationToken);
            voucher.Doctor = doctor;
            await _repository.UpdateAsync(voucher, cancellationToken);

            using var pdfReader = new PdfReader(@"C:\Users\Михаил\source\repos\Mikhail-Beloded\sanatorium\Sanatorium.BLL\OutputReciept.pdf");
            using var stream = new MemoryStream();
            using var writer = new PdfWriter(stream);
            using var pdf = new PdfDocument(pdfReader, writer);

            var page = pdf.GetPage(1);
            var canvas = new PdfCanvas(page);

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 600)
                  .ShowText($"Direction")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 580)
                  .ShowText($"Doctor: {doctor.FullName}")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 560)
                  .ShowText($"Specialization: {doctor.Specialization}")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 540)
                  .ShowText($"Illness: {voucher.Illness.Name}")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 520)
                  .ShowText($"Patient: {voucher.Patient.FullName}")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 500)
                  .ShowText($"File created: {DateTime.Now.Date.ToShortDateString()}")
                  .EndText();
            pdf.Close();

            return stream.ToArray();
        }

        public async Task<List<VoucherDto>> GetAllVouchers(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<List<VoucherDto>> GetAllVouchersWithoutDoctors(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllVouchersWithoutDoctors(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<List<VoucherDto>> GetAllVouchersWithoutProcedures(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAllVouchersWithoutProcedures(cancellationToken);
            return _mapper.MapToDto(entities);
        }
      
    }
}
