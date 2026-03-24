// using System.Net;
// using System.Net.Mail;

// public class Mail
// {
//     public static void SendMail(int order)
//     {
//         try
//         {
//             //inftestmail0@gmail.com
//             var fromAddress = new MailAddress("inftestmail0@gmail.com", "The Rocket Cinema");
//             var toAddress = new MailAddress("inftestmail0@gmail.com", "Customer");
//             // toAddress email naar de echte gebruikers email
//             const string fromPassword = "qhjy ylfw ldas ewea";
//             string subject = $"Order {order} email confirmation";
//             string body = $"Hello, this confirms your order. Order number {order}";


//             var smtp = new SmtpClient
//             {
//                 Host = "smtp.gmail.com",
//                 Port = 587,
//                 EnableSsl = true,
//                 DeliveryMethod = SmtpDeliveryMethod.Network,
//                 Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
//                 Timeout = 20000
//             };

//             var message = new MailMessage(fromAddress, toAddress)
//             {
//                 Subject = subject,
//                 Body = body
//             };
//             var attachment = new Attachment($"qrcode{order}.png"); // path to your file
//             message.Attachments.Add(attachment);
//             {
//                 smtp.Send(message);
//             }

//             Console.WriteLine("Email sent successfully!");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("Error: " + ex.Message);
//         }
//     }
// }