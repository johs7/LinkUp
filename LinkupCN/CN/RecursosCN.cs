using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LinkupCN.CN
{
    public class RecursosCN
    {
        public static string ConvertirSha256(string clave)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(clave));
                foreach (Byte b in result)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
        public static bool EnviarCorreo(string correo, string asunto, string mensaje)
        {
            bool resultado = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("pinchep47@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;
                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("pinchep47@gmail.com", "wgcqkuvmikyzucpg"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };
                smtp.Send(mail);
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
            }
            return resultado;
        }
    }
}
