using Domain.Entities;

namespace WebApi.Services;

using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Colorspace;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

public class PdfService
{
    public void RenderStatement(Statement statement)
    {
        PdfReader reader = new(statement.Path);
        
        // TODO узнать как создать временный файл, который автоматически удалится

        var tempFile = Path.GetTempFileName();
        // Файл создается и возвращаетя полный путь
        // Результат файла лучше сохранить на базе данных за пользователем а затем удалить временный файл
        PdfWriter writer = new(tempFile);
        
        PdfDocument pdfDoc = new(reader, writer);
        
    }
}