using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using Sanatorium.BLL.DTOs;
using Sanatorium.BLL.IServices;
using Sanatorium.BLL.Maping;
using Sanatorium.DAL.Repositories;

namespace Sanatorium.BLL.Services
{
    public class RecieptService : IRecieptService
    {
        private readonly IRecieptRepository _repository;

        private readonly Mapper _mapper = new Mapper();

        public RecieptService(IRecieptRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteRecieptAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            await _repository.DeleteRecieptAsync(entity, cancellationToken);
        }

        public async Task<byte[]> GeneratePdfReciept(int id, CancellationToken cancellationToken)
        {
            var reciept = await _repository.GetOneWithPatient(id, cancellationToken);
            using var pdfReader = new PdfReader(@"C:\Users\Михаил\source\repos\Mikhail-Beloded\sanatorium\Sanatorium.BLL\OutputReciept.pdf");
            using var stream = new MemoryStream();
            using var writer = new PdfWriter(stream);
            using var pdf = new PdfDocument(pdfReader, writer);

            var page = pdf.GetPage(1);
            var canvas = new PdfCanvas(page);
             
            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200,600)
                  .ShowText($"Reciept {reciept.Id}")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 580)
                  .ShowText($"Date: {reciept.CreateDate}")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 560)
                  .ShowText($"Sum: {reciept.Sum}")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 540)
                  .ShowText($"Type: {reciept.Type}")
                  .EndText();

            canvas.BeginText()
                  .SetFontAndSize(PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN), 14)
                  .SetFillColor(new DeviceRgb(42, 44, 62))
                  .MoveText(200, 520)
                  .ShowText($"Patient: {reciept.Voucher.Patient.FullName}")
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

        public async Task<List<RecieptDto>> GetAll(CancellationToken cancellationToken)
        {
            var entities = await _repository.GetAll(cancellationToken);
            return _mapper.MapToDto(entities);
        }

        public async Task<RecieptDto?> GetOneAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetOneAsync(id, cancellationToken);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return _mapper.MapToDto(entity);
        }
    }
}
