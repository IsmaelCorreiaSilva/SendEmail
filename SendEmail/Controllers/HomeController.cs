using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;
using System.Net.Mail;
using System.Net.Mime;

namespace SendEmail.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Email email)
        {         

            if (ModelState.IsValid)
            {
                try
                {
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("email-sender", "name-sender");
                        mailMessage.To.Add(new MailAddress(email.EmailAddress));
                        mailMessage.Subject = email.Subject;
                        mailMessage.Body = email.Message;
                        mailMessage.Priority = MailPriority.Normal;

                        if (email.File != null)
                        {
                            var attachment = new Attachment(email.File.OpenReadStream(), email.File.FileName);
                            mailMessage.Attachments.Add(attachment);
                        }

                        using (SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com",587))
                        {
                            smtpClient.EnableSsl= true;
                            smtpClient.Credentials = new System.Net.NetworkCredential("email-outlook", "password");
                            smtpClient.Send(mailMessage);
                        }

                    }
                
                    return RedirectToAction("SuccessSend", "Home");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("ErrorSend", "Home");
                }
                
            }
            return View(email);

        }   
        
        public ActionResult SuccessSend()
        {
            return View();
        }
        public ActionResult ErrorSend()
        {
            return View();
        }
    }
}