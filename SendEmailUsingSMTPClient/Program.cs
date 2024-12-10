using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main()
    {
        // Configure email settings (Replace with actual values)
        string fromEmail = "your-email@gmail.com"; // Sender's email address
        string smtpServer = "smtp.gmail.com"; // SMTP server address for Gmail
        int port = 587; // Port for TLS (587) or SSL (465)
        string username = "your-email@gmail.com"; // Gmail username (email address)
        string password = "your-app-password"; // Gmail app password (if 2FA enabled)
        bool useSSL = true; // Enable SSL/TLS encryption for secure connection

        // Recipient email address (Replace with the recipient's email)
        string toEmail = "recipient-email@example.com";

        // Create a new MailMessage object
        MailMessage mail = new MailMessage(fromEmail, toEmail)
        {
            Subject = "Demo: Email Successfully Sent Using .NET 8 and C#", // Subject for the demo
            Body = "Hello,\n\n" +
                   "This is a demo email to demonstrate sending emails Using .NET 8 and C#. The email was successfully sent through the SMTP server.\n\n" +
                   "This is not a production email and is for testing purposes only.\n\n" +
                   "Best regards,\n" +
                   "Demo Application" // Body for the demo email
        };

        // Configure the SMTP client for sending the email
        SmtpClient smtpClient = new SmtpClient(smtpServer, port)
        {
            Credentials = new NetworkCredential(username, password), // Provide credentials for authentication
            EnableSsl = useSSL, // Ensure secure connection using SSL/TLS
            Timeout = 10000 // Set a timeout for the SMTP client (10 seconds)
        };

        try
        {
            // Attempt to send the email
            smtpClient.Send(mail);
            Console.WriteLine("Demo email sent successfully.");
        }
        catch (Exception ex)
        {
            // Catch any exceptions and display a user-friendly error message
            Console.WriteLine("An error occurred while sending the email: " + ex.Message);
        }
        finally
        {
            // Ensure proper disposal of resources
            mail.Dispose();
            smtpClient.Dispose();
        }
    }
}