using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_CacaAoBugMVC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Passagem de Parametro por Valor***");
            //Passa o conteúdo da variavel de origem para a variavel de destino
            //o método de destino não altera o valor da variavel do método de origem
            double valor = 10;
            if(PassagemParametroValor(valor)) 
            Console.WriteLine($"Valor do método Main -> PassagemParametroValor {valor}");

            Console.WriteLine("\n\n*** Passagem de Parametro por Referrência REF***");
            //Passa o endereço de memória da variavel de origem para a variavel de destino
            //a variavel de origem pode estar inicializada
            //o método de destino pode alterar o valor da variavel do método de origem
            double valor1 = 10;
            if (PassagemParametroReferenciaRef(ref valor1)) 
            {
                Console.WriteLine($"Valor do método Main -> PassagemParametroReferenciaRef {valor1}");
            }
            Console.WriteLine("\n\n*** Passagem de Parametro por Referrência OUT***");
            //Passa o endereço de memória da variavel de origem para a variavel de destino
            //a variavel de origem não pode estar inicializada
            //o método de destino deve  inicializar a variavel do método de origem
            //o método de destino pode alterar o valor da variável do método de origem
            double valor2;
            if (PassagemParametroReferenciaOut(out valor2))
            {
                Console.WriteLine($"Valor do método Main -> PassagemParametroReferenciaOut {valor2}");
            }
            Console.WriteLine("\n\n*** Passagem de Parametro por Referrência IN***");
            //Passa o endereço de memória da variavel de origem para a variavel de destino
            //a variavel de origem deve estar inicializada
            //o método de destino não deve alterar o valor da variavel do método de origem

            double valor3 = 100;
            if (PassagemParametroReferenciaIN(in valor3))
            {
                Console.WriteLine($"Valor do método Main -> PassagemParametroReferenciaIN {valor3}");
            }
        }

        public static bool PassagemParametroValor(double valor) 
        {
            valor = valor * 10;
            Console.WriteLine($"Valor do método PassagemParametroValor {valor}");
            return true;
        }
        public static bool PassagemParametroReferenciaRef(ref double valor1) 
        {
            valor1 = valor1 * 10;
            Console.WriteLine($"Valor do método PassagemParametroRef {valor1}");
            return true;
        } 
        public static bool PassagemParametroReferenciaOut(out double valor2) 
        {
            valor2 = 10;
            valor2 = valor2 * 10;
            Console.WriteLine($"Valor do método PassagemParametroRef {valor2}");
            return true;
        }
        public static bool PassagemParametroReferenciaIN(in double valor3)
        {
            Console.WriteLine($"Valor do método PassagemParametroIn {valor3}");
            return true;
        }
    }
}
