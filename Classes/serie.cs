using System;
using CadastroSeries.Enum;

namespace CadastroSeries.Classes
{
    public class serie : Base
    {
        private Genero genero;
        private string titulo;
        private string descricao;
        private int ano;

        private bool excluido;

        public serie(int id,Genero genero , string titulo , string descricao, int ano)
        {   
            this.Id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }


        public override string ToString()
        {
            return $" Genero: {this.genero}{Environment.NewLine} Titulo: {this.titulo}{Environment.NewLine} Descricao: {this.descricao}{Environment.NewLine} ano: {this.ano}{Environment.NewLine} Excluido : {this.excluido}{Environment.NewLine}";
        }

        public string retornaTitulo(){
            return this.titulo;
        }

        public int retornaID(){
            return this.Id;
        }

        public bool retornaExcluido(){
            return this.excluido;
        }

        public void excluir(){
            this.excluido = true;
        }

    }
}