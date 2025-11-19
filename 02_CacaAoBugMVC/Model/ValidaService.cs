using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_CacaAoBugMVC.Model
{
    public class ValidaService
    {
        //padrão

        //mínimo 3 caracteres, sem caracteres repetidos 3x seguidas, sem espaços duplos

        // 🔥 Corrigido para permitir somente letras e espaços!

        private readonly string padraoNome =

            @"^(?!.*([A-Za-zÀ-ÖØ-öø-ÿ])\1\1)(?!.* {2,})(?=.{3,})[A-Za-zÀ-ÖØ-öø-ÿ ]+$";

        //padrão para notas:

        //0 a 10 (aceita vírgula ou ponto)

        private readonly string padraoNota = @"^(?:10(?:[.,]0+)?|[0-9](?:[.,][0-9]+)?)$";

        // ===========================

        // VALIDAR NOME (CORRIGIDO)

        // ===========================

        public bool ValidarNome(string nome, out string mensagemErro)

        {

            mensagemErro = string.Empty;

            if (string.IsNullOrEmpty(nome))

            {

                mensagemErro = "Nome vazio";

                return false;

            }

            // SE NÃO corresponder ao padrão, o nome é inválido

            if (!Regex.IsMatch(nome.Trim(), padraoNome))

            {

                mensagemErro = "\n\n- Mínimo 3 caracteres\n" +

                               "- Não pode ter 3 caracteres repetidos\n" +

                               "- Não pode ter espaços duplos\n" +

                               "- Só pode conter letras e espaços";

                return false;

            }

            return true; // válido

        }


        public bool ConverterNota(string notaEntrada, out double nota) 
        {
            nota = -1;

            if(string .IsNullOrEmpty(notaEntrada)) return false;

            //substitui a vírgula por ponto
            var notaDecimalVirgula = notaEntrada.Trim().Replace(",", ".");

            if(!Regex.IsMatch(notaDecimalVirgula, padraoNota)) return false;

            if (double.TryParse(notaDecimalVirgula, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out nota)) 
            {
                if(nota < 0 || nota > 10) 
                    return false;
                else
                    return true;
            }
            return false;
        }

    }
}
