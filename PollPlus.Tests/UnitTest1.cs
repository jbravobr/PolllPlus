using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PollPlus.Domain;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PollPlus.Domain.Enumeradores;

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
    }
}
