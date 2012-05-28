using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anagramer.Core;
using NUnit.Framework;


namespace Anagramer.Test
{
    [TestFixture]
    public class AnagramerTest
    {

        [Test]
        public void Posso_Ter_Anagrama()
        {
            var anagrama = new Anagrama();
            Assert.Pass();
        }

        [Test]
        public void Deve_Existir_Uma_Palavra_Origem()
        {
            var anagrama = new Anagrama();

            anagrama.palavraOrigem = "BIRO";

            Assert.AreEqual("BIRO", anagrama.palavraOrigem);
        }

        [Test]
        public void Palavra_Origem_Nao_Pode_Ser_Vazia()
        {
            var anagrama = new Anagrama();

            anagrama.palavraOrigem = "";

            Assert.Throws<Exception>(anagrama.VerificarSeNomeEhVazioOuNulo, "Palavra origem não pode ser vazia.");
        }

        [Test]
        public void Palavra_Origem_Nao_Pode_Ser_Nula()
        {
            var anagrama = new Anagrama();

            anagrama.palavraOrigem = null;

            Assert.Throws<Exception>(anagrama.VerificarSeNomeEhVazioOuNulo, "Palavra origem não pode ser nula.");
        }

        [Test]
        public void Palavra_Origem_Deve_Combinar_Letras_Para_Formar_Outras_Palavras()
        {
            var anagrama = new Anagrama();

            anagrama.palavraOrigem = "BIRO";
            anagrama.GerarAnagramas(anagrama.palavraOrigem);

            anagrama.listaAnagramas.ForEach(c => Console.WriteLine(c));

            Assert.Contains("BRIO", anagrama.listaAnagramas);
        }

        [Test]
        public void Devem_ser_Formados_Numero_de_Palavras_Conforme_Combinacao_Matematica()
        {
            var anagrama = new Anagrama();

            anagrama.palavraOrigem = "BIRO";
            anagrama.GerarAnagramas(anagrama.palavraOrigem);

            Assert.AreEqual(24, anagrama.ObterNumeroDeCombinacoes(anagrama.palavraOrigem));
        }
    }
}
