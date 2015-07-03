using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using PollPlus.Domain;
using PollPlus.Domain.Enumeradores;

namespace PollPlus.Helpers
{
    public class Util
    {
        /// <summary>
        /// Remove caracteres não numéricos
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveNaoNumericos(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }

        /// <summary>
        /// Valida se um cpf é válido
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static bool ValidaCPF(string cpf)
        {
            //Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
            cpf = Util.RemoveNaoNumericos(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }

        /// <summary>
        /// Responsável pelo envio de mensagens de e-mail
        /// </summary>
        /// <param name="message"></param>
        /// <param name="_msg"></param>
        /// <returns></returns>
        public static bool SendMail(MailMessage message)
        {
            var _envio = false;
            var _msgErro = string.Empty;

            try
            {
                var _client = new SmtpClient();

                _client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpPort"]);
                _client.DeliveryMethod = SmtpDeliveryMethod.Network;
                _client.EnableSsl = true;
                _client.DeliveryFormat = SmtpDeliveryFormat.International;
                _client.UseDefaultCredentials = false;
                _client.Host = ConfigurationManager.AppSettings["SmtpHost"];
                _client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SmtpLogin"], ConfigurationManager.AppSettings["SmtpSenha"]);

                _client.Send(message);
                _envio = true;
            }
            catch (Exception p_ex)
            {
                _msgErro = p_ex.Message;
            }

            return _envio;
        }

        /// <summary>
        /// Responsável por montar um objeto do tipo MailMenssage para envio de uma mensagem de e-mail pela aplicação
        /// </summary>
        /// <param name="destinatarios"></param>
        /// <param name="corpo"></param>
        /// <param name="titulo"></param>
        public static MailMessage MontaMailMessage(string destinatario, string corpo, string titulo)
        {
            var _mailMessage = new MailMessage(ConfigurationManager.AppSettings["SmtpLogin"].ToString(), destinatario);

            _mailMessage.BodyEncoding = Encoding.UTF8;
            _mailMessage.HeadersEncoding = Encoding.UTF8;
            _mailMessage.IsBodyHtml = true;
            _mailMessage.Body = corpo;
            _mailMessage.Subject = titulo;

            return _mailMessage;
        }

        /// <summary>
        /// Constante para uso do método de criptografia para aumentar o tamanho da chave final em bytes
        /// </summary>
        static string salt = "qHsfS0UZ5l6ntfm1Bwbq";

        /// <summary>
        /// Método para Criptografar uma senha
        /// </summary>
        /// <param name="p_senha">Senha plana</param>
        /// <returns>Base64 da String da Senha</returns>
        public static String EncriptarSenha(String p_senha)
        {
            if (String.IsNullOrEmpty(p_senha))
                throw new ArgumentException("A senha precisa ser preenchida!");

            byte[] passwordBytes = Encoding.UTF8.GetBytes(p_senha);
            byte[] saltBytes = Encoding.UTF8.GetBytes(Util.salt);

            byte[] encodedBytes = ProtectedData.Protect(passwordBytes, saltBytes, DataProtectionScope.LocalMachine);

            return Convert.ToBase64String(encodedBytes);
        }

        /// <summary>
        /// Descriptografa uma senha válida
        /// </summary>
        /// <param name="p_senha">Senha Plana</param>
        /// <returns>Base64 da Senha plana</returns>
        public static String DescriptarSenha(String p_senha)
        {
            if (String.IsNullOrEmpty(p_senha))
                throw new ArgumentException("A senha precisa ser preenchida!");

            byte[] encondedBytes = Convert.FromBase64String(p_senha);
            byte[] saltBytes = Encoding.UTF8.GetBytes(Util.salt);

            byte[] passwordBytes = ProtectedData.Unprotect(encondedBytes, saltBytes, DataProtectionScope.LocalMachine);

            return Encoding.UTF8.GetString(passwordBytes);
        }

        /// <summary>
        /// Gera Token de validação para alteração de senha
        /// </summary>
        /// <returns></returns>
        //public static int GeraTokenCadastroUsuarioSenha(string emailOrigem)
        //{
        //    var tokenNumber = 0;

        //    var _service = new TokenService();
        //    var gravou = false;

        //    while (!gravou)
        //    {
        //        tokenNumber = (new Random().Next() * 50) + (50 * 50 * (int)DateTime.Now.Ticks / 10) * (int)DateTime.Now.Second;
        //        gravou = _service.GravaToken(new Token { DataGeracao = DateTime.Now, EmailProprietario = emailOrigem, TokenNumero = tokenNumber, Utilizado = false });
        //    }

        //    return tokenNumber;
        //}

        /// <summary>
        /// Verifica se o Token informado é válido
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //public static bool ValidaToken(int token)
        //{
        //    var _serviceToken = new TokenService();

        //    return _serviceToken.ValidaToken(token, out _msg);
        //}

        public static bool SalvarImagem(HttpPostedFileBase file)
        {
            var path = ConfigurationManager.AppSettings["CaminhoParaSalvarImagens"];

            if (file.ContentLength > 0)
            {
                try
                {
                    var pathFinal = Path.Combine(path, file.FileName);

                    file.SaveAs(pathFinal);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }

        public static object ImportarCSV(EnumTipoImportacao tipo, HttpPostedFileBase file)
        {
            using (var stream = new StreamReader(file.InputStream, System.Text.Encoding.Default))
            {
                switch (tipo)
                {
                    case EnumTipoImportacao.Email:
                        return ImportarParaEmail(stream);
                    case EnumTipoImportacao.Voucher:
                        return null;
                    case EnumTipoImportacao.Blacklist:
                        return ImportarParaBlackList(stream);
                }

                return null;
            }
        }

        private static ICollection<Usuario> ImportarParaEmail(StreamReader stream)
        {
            List<Usuario> novosUsuario = new List<Usuario>();

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

            return novosUsuario;
        }

        private static ICollection<BlackList> ImportarParaBlackList(StreamReader stream)
        {
            List<BlackList> novosPalavras = new List<BlackList>();

            while (stream.Peek() >= 0)
            {
                var linha = stream.ReadLine();

                novosPalavras.Add(new BlackList
                {
                    Texto = linha
                });
            }

            return novosPalavras;
        }
    }
}