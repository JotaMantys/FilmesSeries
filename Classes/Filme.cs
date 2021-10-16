using System;
using CadastroSeries.Enum;

namespace CadastroSeries.Classes
{
    public class Filme : Base
    {
        private Genero genero;
        private string titulo;
        private string descricao;
        private int ano;
        private int nota;
        private bool excluido;

        public Filme(int id,Genero genero , string titulo , string descricao,int ano,int nota)
        {
            this.Id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.nota = nota;
            this.excluido = false;
            
        }

        public override string ToString()
        {
            return $"Genero : {this.genero}{Environment.NewLine} Titulo: {this.titulo}{Environment.NewLine} Descrição: {this.descricao}{Environment.NewLine} Ano: {this.ano}{Environment.NewLine} nota: {this.nota}{Environment.NewLine}";
        }

        public void excluir()
        {
            this.excluido = true;
        }

        public string retornaTitulo(){
            return this.titulo;
        }

        public bool retornaExcluido()
        {
            return this.excluido;
        }

        public int retornaId(){
            return this.Id;
        }

    }
}