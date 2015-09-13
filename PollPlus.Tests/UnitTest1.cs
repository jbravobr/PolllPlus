using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PollPlus.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PollPlus.Domain.Enumeradores;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace PollPlus.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestaImportarCSVEMail()
        {
            List<Usuario> novosUsuario = new List<Usuario>();

            using (var stream = new StreamReader(@"C:\\email.csv"))
            {
                while (stream.Peek() >= 0)
                {
                    var linha = stream.ReadLine();
                    var valorLinha = linha.Split(';');

                    novosUsuario.Add(new Usuario
                    {
                        Nome = valorLinha[0].ToString(),
                        Email = valorLinha[1].ToString(),
                        Sexo = (EnumSexo)Enum.Parse(typeof(EnumSexo), valorLinha[2].ToString()),
                        Municipio = valorLinha[3].ToString(),
                        DDD = Convert.ToInt32(valorLinha[4]),
                        Telefone = valorLinha[5].ToString()
                    });
                }

                Assert.IsNotNull(novosUsuario);
            }
        }

        [TestMethod]
        public void TestaImportarCSVBlackList()
        {
            var listaPalavras = new List<BlackList>();

            using (var stream = new StreamReader(@"C:\\blacklist.txt", System.Text.Encoding.Default))
            {
                while (stream.Peek() >= 0)
                {
                    var linha = stream.ReadLine();

                    listaPalavras.Add(new BlackList
                    {
                        Texto = linha
                    });
                }

                Assert.IsNotNull(listaPalavras);
            }
        }

        [TestMethod]
        public void EnviaEmailComImagem()
        {
            var _mailMessage = new MailMessage("jbravo.br@gmail.com", "jbravo.br@gmail.com");

            _mailMessage.BodyEncoding = Encoding.UTF8;
            _mailMessage.HeadersEncoding = Encoding.UTF8;
            _mailMessage.IsBodyHtml = true;

            var _corpoMessage = new StringBuilder();

            _corpoMessage.Append(String.Format("<p>Está é a confirmação da criação do seu voucher número {0}.</p>", "00000000000000001"));
            _corpoMessage.AppendLine(String.Format("<p>Este voucher é valido até {0}.</p>", DateTime.Now.ToShortDateString()));
            _corpoMessage.AppendLine(String.Format("<p>{0}</p>", "Teste de Voucher com Imagem no e-mail"));
            _corpoMessage.AppendLine("Caso você não entenda do que este e-mail trata-se, favor desconsiderar o mesmo.");
            _corpoMessage.AppendLine("<img src=cid:ImagemPromo>");


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(_corpoMessage.ToString(), null, "text/html");

            var imgMail = @"C:\ImagemParaEmail\imagemTeste.jpg";

            LinkedResource mailImagem = new LinkedResource(imgMail);
            mailImagem.ContentId = "ImagemPromo";

            htmlView.LinkedResources.Add(mailImagem);

            _mailMessage.AlternateViews.Add(htmlView);

            _mailMessage.Subject = "Teste de envio com imagem";

            var _msgErro = string.Empty;
            var _envioOk = false;

            try
            {
                var _client = new SmtpClient();

                _client.Port = Convert.ToInt32(587);
                _client.DeliveryMethod = SmtpDeliveryMethod.Network;
                _client.EnableSsl = true;
                _client.DeliveryFormat = SmtpDeliveryFormat.International;
                _client.UseDefaultCredentials = false;
                _client.Host = "smtp.gmail.com";
                _client.Credentials = new NetworkCredential("jbravo.br@gmail.com", "r48xmxdmc44w");

                _client.Send(_mailMessage);
                _envioOk = true;
            }
            catch (Exception p_ex)
            {
                _msgErro = p_ex.Message;
            }

            Assert.IsTrue(_envioOk);
        }
    }
}
