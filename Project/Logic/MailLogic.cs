using System.Net;
using System.Net.Mail;

public class Mail
{
    public static void SendMail(int order, string email)
    {
        try
        {
            //inftestmail0@gmail.com
            //ILikeBanana

            var fromAddress = new MailAddress("inftestmail0@gmail.com", "The Rocket Cinema");
            var toAddress = new MailAddress($"{email}", "Customer");
            // toAddress email naar de echte gebruikers email
            const string fromPassword = "qhjy ylfw ldas ewea";
            string subject = $"Order {order} email confirmation";
            string body = $"Dear Customer,\nThis mail confirms your order.\nOrder number {order}\nHave a great day!\nGreeting,\nThe Rocket Cinema Team";


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };

            var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            };
            var attachmentQR = new Attachment($"qrcode{order}.png"); // path to your file
            message.Attachments.Add(attachmentQR);
            {
                smtp.Send(message);
            }

            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}