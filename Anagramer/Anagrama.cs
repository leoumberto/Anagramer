using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Anagramer.Core
{
    public class Anagrama
    {
        public string palavraOrigem { get; set; }
        public List<string> listaAnagramas = new List<string>(); 

        public void VerificarSeNomeEhVazioOuNulo()
        {
            if(String.IsNullOrEmpty(palavraOrigem))
                throw new Exception("Palavra origem não pode ser nula ou vazia.");
        }

        // procedure GerarAnagramas(string: palavra)
        public void GerarAnagramas(string palavra)
        {
            string novaPalavra = "";
            string palavraOrigem = palavra;
            var random = new Random();
            var numeroCombinacoes = ObterNumeroDeCombinacoes(palavraOrigem);

            while (listaAnagramas.Count < numeroCombinacoes)
            {
                palavra = palavraOrigem;
                
                while (palavra.Length > 0)
                {                
                    var indiceLetra = random.Next(0, palavra.Length);
                    novaPalavra += palavra[indiceLetra].ToString();
                    palavra = palavra.Remove(indiceLetra, 1);
                }

                if (!listaAnagramas.Contains(novaPalavra))
                    listaAnagramas.Add(novaPalavra);

                novaPalavra = "";
            }

            //if (listaAnagramas.Count < this.ObterNumeroDeCombinacoes(palavraOrigem))
            //    GerarAnagramas(palavraOrigem);

        }

        // function
        public int ObterNumeroDeCombinacoes(string palavra)
        {
            var quantidadeLetras = palavra.Length;
            var multiplicador = quantidadeLetras;
            
            while (multiplicador > 1)
            {
                quantidadeLetras *= (--multiplicador);

            }

            return quantidadeLetras;

        }

    }
}
