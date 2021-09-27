using DragDropBlazorServer.Data.Enum;
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
            StatusAtividade = Status.Iniciado;
            UltimaAtualizacao = DateTime.Now;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public Status StatusAtividade { get; set; }
    }
}
