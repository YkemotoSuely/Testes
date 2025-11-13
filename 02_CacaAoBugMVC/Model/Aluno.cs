
namespace _02_CacaAoBugMVC.Model
{
    public class Aluno //Classe de objeto relacional
    {
        //private string nome = string.Empty;
        //metodos acessadores:

        //public string getNome()
        //{
        //    return nome;
        //}

        //public void setNome(string nome)
        //{
        //    this.nome = nome;
        //}

        //declaração de propriedades
        public string Nome { get; set; } = string.Empty;
        public double Nota1 { get; set; }
        public double Nota2 { get; set; }
        public double Nota3 { get; set; }
        public double Media {  get; set; }
        public string Situacao { get; set; } = string.Empty ;

    }
}
