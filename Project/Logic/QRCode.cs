// using QRCoder;
// using System.Diagnostics;

// class Program
// {
//     public static int Order = 1;
//     // Wanneer de order betaald is, deze += 1. Wanneer niet, gewoon laten zoals die nu is
//     public static void Main()
//     {

//         string text = "Zaal 1, SEAT 123, Datum: 14-06-2026, Tijdstip: 14:40";
//         // text veranderen naar data die we gaan gebruiken? dus tijd plaats etc? Ook hier dus een data gebruiken die door de klant worden gekozen. 
//         string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"qrcode{Order}.png");


//         QRCodeGenerator qrGenerator = new QRCodeGenerator();
//         var qrData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
//         PngByteQRCode qrCode = new PngByteQRCode(qrData);

//         byte[] qrBytes = qrCode.GetGraphic(20);
//         File.WriteAllBytes(filePath, qrBytes);

//         Console.WriteLine($"QR code saved as {filePath}");

//         Process.Start(new ProcessStartInfo
//         {
//             FileName = filePath,
//             UseShellExecute = true
//         });
//         Mail.SendMail(Order);
//     }
// }