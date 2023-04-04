using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoAspNetMvc.ViewModels
{
    public class Frete
    {
        public string CodigoFrete { get; set; }
        public bool Ativo { get; set; }
        public int PermiteValor { get; set; }
        public bool NecessitaTranportadora { get; set; }
        public string DescricaoPortugues { get; private set; }
        public string DescricaoIngles { get; set; }
        public string DescricaoEspanhol { get; set; }

        //public Frete()
        //{

        //}
        /// <summary>
        /// Controe objeto frete
        /// </summary>
        /// <param name="codigoFrete">Utilizar o codigo de frete "CIF" ou "FOB"</param>
        /// <param name="descricaoPortugues">Descrição em Portugues</param>
        /// <param name="descricaoIngles">Descrição em Ingles</param>
        /// <param name="descricaoEspanhol">Descrição em Espanhol</param>
        /// <param name="permiteValor">PermiteValor Indica se o frete permite valor: 0 - Não permite, 1 - Permite(opcional), 2 - Permite(obrigatório)</param>
        /// 
        public Frete(string codigoFrete, string descricaoPortugues, string descricaoIngles, string descricaoEspanhol, int permiteValor = 2)
        {

            Ativo = true;
            NecessitaTranportadora = true;
            CodigoFrete = codigoFrete;
            SetDescricaoPortugues(descricaoPortugues);
            DescricaoIngles = descricaoIngles;
            DescricaoEspanhol = descricaoEspanhol;

        }
        public void SetDescricaoPortugues(string descricao)
        {
            if (string.IsNullOrEmpty(descricao) || descricao.Length < 5 || descricao.Length > 50)
            {
                throw new InvalidOperationException("Atenção parametro invalidos!\nDescrição Português não pode ser nulo. Menor que 5 e maior que 50 caracteres.");
            }
            DescricaoPortugues = descricao;

        }
    }
}