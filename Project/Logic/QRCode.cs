using QRCoder;
using System.Diagnostics;
class QRCodeGen
{
    private static readonly MovieAccess _movieAccess = new();

    public static MovieModel? GetByID(int? id)
    {
        return _movieAccess.GetById(id);
    }
    public static void QrCodeGeneration(string? email, int orderId, int? movieId, string? seatId)
    {
        string text = "";
        if (movieId != null)
        {
            MovieModel QrMovie = GetByID(movieId);

            text = $"Movie Title: {QrMovie.Title}, MovieId:{movieId},Auditorium:{QrMovie.LocationId}, SEAT{seatId}, Date: {QrMovie.Date}, Start Time: {QrMovie.StartTime}";
        }
        else
        {
            text = "Confirmed.";
        }

        string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"qrcode{orderId}.png");


        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
        PngByteQRCode qrCode = new PngByteQRCode(qrData);

        byte[] qrBytes = qrCode.GetGraphic(20);
        File.WriteAllBytes(filePath, qrBytes);

        // Console.WriteLine($"QR code saved as {filePath}");

        Process.Start(new ProcessStartInfo
        {
            FileName = filePath,
            UseShellExecute = true
        });
        Mail.SendMail(orderId, email);
    }
}