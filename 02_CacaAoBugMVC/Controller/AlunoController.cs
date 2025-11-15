using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_CacaAoBugMVC.Model;

namespace _02_CacaAoBugMVC.Controller
{
    public class AlunoController
    {
        private readonly ValidaService validaService;
        private readonly AlunoService alunoService;
        private readonly List<Aluno> alunos;

        public AlunoController() //construtor para criar as instancias dentro da
        {
            validaService = new ValidaService();
            alunoService = new AlunoService();
            alunos = new List<Aluno>();
        }

        public bool AdicionaAluno(Aluno aluno, out string mensagemErro)
        {
            mensagemErro = string.Empty;
            //validação se o nome do aluno está correto
            if (!validaService.ValidaNome(aluno.Nome, out string erroNome))
            {
                mensagemErro = $"Nome inválido {erroNome}";
                return false;
            }

            aluno.Media = alunoService.CalcularMedia(aluno.Nota1, aluno.Nota2, aluno.Nota3); //calculo média

            aluno.Situacao = alunoService.ObterSituacao(aluno.Media);//atribui a situação

            alunos.Add(aluno); // adiciona na lista, zera todas as informações para inclusão das notas do próximo aluno

            return true;
        }
        //expressão Lambda
        public IReadOnlyList<Aluno> ObterAlunos() => alunos.AsReadOnly();

        public double ObterTaxaAprovacao() 
        {
            int total = alunos.Count;
            int aprovados = alunos.FindAll(a => a.Situacao == "Aprovado").Count;
            return alunoService.CalcularTaxaAprovacao(total, aprovados);
        }
        public ValidaService GetValidaService() => validaService;
        
    }
}
