using DragDropBlazorServer.Data;
using DragDropBlazorServer.Data.Enum;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Pages
{
    public class KanbanBase : ComponentBase
    {
        public List<ItemAtividade> ListaAtividade { get; set; }

        protected string UltimaAtividadeAtualizada { get; set; }

        public KanbanBase()
        {
            ListaAtividade = new List<ItemAtividade>();
            UltimaAtividadeAtualizada = string.Empty;
        }

        protected override void OnInitialized()
        {
            for (int i = 1; i <= 5; i++)
            {
                ListaAtividade.Add(new ItemAtividade
                {
                    Id = i,
                    Titulo = string.Concat("Atividade " , i),
                    Descricao = string.Concat("Descrição da Atividade ", i),
                    StatusAtividade = Status.Iniciado,
                    UltimaAtualizacao = DateTime.Now
                });
            }
        }

        public void StatusUpdate(ItemAtividade atividade) 
        {
            UltimaAtividadeAtualizada = atividade.Titulo;
        }
    }
}
