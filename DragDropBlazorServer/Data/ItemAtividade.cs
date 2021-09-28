using DragDropBlazorServer.Data.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Data
{
    public class ItemAtividade
    {
        public ItemAtividade()
        {
            Id = Guid.NewGuid();
            StatusAtividade = StatusAtividade.Iniciado;
            UltimaAtualizacao = DateTime.Now;
            Cor = "#808080";
        }

        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public StatusAtividade StatusAtividade { get; set; }
        public string Cor { get; set; }
        public string CorTexto
        {
            get => $"color:{Cor};";
        }
        public string BordaCard
        {
            get => $"border-left: .25rem solid {Cor} !important;";
        }
    }
}
