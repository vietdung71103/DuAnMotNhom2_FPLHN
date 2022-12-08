using _2.BUS.IServices;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BUS.Services
{
    public class QuenMatKhau : IQuenMatKhau
    {
        IQLNhanVienServices _services;
        public QuenMatKhau()
        {
            _services = new QLNhanVienServices();
        }
        public string GuiEmail(string email, string password)
        {
            try
            {

                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("vietdung71103@gmail.com");
                mail.Subject = "Bạn đã sử dụng chức năng quên mật khẩu";

                mail.Body = "Chào bạnị. Mật khẩu mới truy cạp phần mềm là " + password;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new System.Net.NetworkCredential("vietdung71103@gmail.com", "Helo@"); // ***use valid credentials***
                smtp.Port = 587;


                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Send(mail);
                return "Một Email phục hồi mật khẩu đã được gửi tới bạn";
            }
            catch (Exception e)
            {
                return (e.Message);
            }
        }

        public string MaHoa(string password)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptData = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptData.Append(encrypt[i].ToString());
            }

            return encryptData.ToString();
        }

        public string RandomMa(int size, bool chuthuong)
        {
            StringBuilder _builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                _builder.Append(ch);
            }

            if (chuthuong)
                return _builder.ToString().ToLower();

            return _builder.ToString();
        }

        public int RandomSo(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void Update(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
