using System;

namespace CursoDesignPatterns
{
    public class CalculadorDeImpostos
    {
        public void RealizaCalculo(Orcamento orcamento, string imposto)
        {
            if ("IMCS".Equals(imposto))
            {
                double icms = orcamento.Valor * 0.1;
                Console.WriteLine(icms);
            }
            else if ("ISS".Equals(imposto))
            {
                double iss = orcamento.Valor * 0.06;
                Console.WriteLine(iss);
            }
        }
    }
}