using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PollPlus.Service.Helpers
{
    public static class Util
    {
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
        /// Efetua a gravação de um token Gerado
        /// </summary>
        /// <param name="token"></param>
        //public static void GravaTokenGerado(Token token)
        //{
        //    var _repo = new TokenRepository();
        //    _repo.GravaToken(token);
        //}

        /// <summary>
        /// Valida a existência do token e marca como utilizado caso o token exista
        /// </summary>
        /// <param name="token"></param>
        //public static void ValidaEMarcaTokenComoUtilizado(Token token)
        //{
        //    var _repo = new TokenRepository();
        //    _repo.MarcaComoUtilizado(token.TokenNumero);
        //}
    }
}
