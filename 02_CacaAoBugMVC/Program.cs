using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_CacaAoBugMVC.Controller;
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAoBugMVC
{
    internal class Program
    {
        static void Main()
        {
            // criando instãcia da MODEL
            AlunoController controller = new AlunoController();
            var validacao = controller.GetValidaService();

            
            while (true)
            {

                Console.Clear();
                Console.WriteLine("==== Sistema de Notas - Caça ao Bug MVC ====");

                string nome;
                while (true)
                {
                    while (true)
                    {
                        Console.Write("Informe o nome do aluno:");
                        nome = Console.ReadLine();

                        if (validacao.ValidarNome(nome, out string msgErro)) break;

                        Console.WriteLine($"Erro: \n{msgErro});\n");
                    }


                    double nota1 = Program.LerNota("1ª", validacao);
                    double nota2 = Program.LerNota("2ª", validacao);
                    double nota3 = Program.LerNota("3ª", validacao);

                    //--------------- Criar o objeto aluno e enviar para a Controller -------------------//

                    var aluno = new Aluno()
                    {
                        Nome = nome,
                        Nota1 = nota1,
                        Nota2 = nota2,
                        Nota3 = nota3,

                    };

                    if (controller.AdicionaAluno(aluno, out string mensagemErro))
                    {
                        Console.WriteLine($"\nMédia: {aluno.Media}");
                        Console.WriteLine($"\nSituação: {aluno.Situacao}");

                    }
                    else 
                    {
                        Console.WriteLine($"Erro: {mensagemErro}");  
                    }

                        Console.Write("Deseja cadastrar outro aluno? (S/N) ");
                    if (Console.ReadLine().ToUpper() != "S") break;    //ToUpper converte minuscula em maiúscula e compara 

                }

                //============ Estatísticas de Aprovação ==========//
                Console.WriteLine($"Taxa de Aprovação: {controller.ObterTaxaAprovacao():f2}%");

                Console.Write("Deseja reiniciar o sistema? (S/N) ");
                if (Console.ReadLine().ToUpper() != "S") break; 
            }
            
        }

        public static double LerNota(string nota, ValidaService validacao)
        {
            while (true) 
            {
                Console.Write($"Informe a {nota} nota: ");
                string entrada = Console.ReadLine();
                //return double.Parse(entrada);
                if(validacao.ConverterNota(entrada, out double valorNota)) return valorNota;

                Console.WriteLine("Nota inválida!Digite um número entre 0 e 10");
            }


        }


    }
}
