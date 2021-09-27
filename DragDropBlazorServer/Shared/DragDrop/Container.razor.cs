
using DragDropBlazorServer.Data;
using DragDropBlazorServer.Data.Enum;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Shared.DragDrop
{
    public class ContainerBase : ComponentBase
    {
        [Parameter]
        public List<ItemAtividade> ListaAtividade { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<ItemAtividade> AtualizaStatusAtividade { get; set; }

        public ItemAtividade AtividadeAtual { get; set; }

        public async Task AtualizarAtividadeAsync(Status NovoStatus) 
        {
            var Tarefa = ListaAtividade.SingleOrDefault(x => x.Id == AtividadeAtual.Id);

            if (!Equals(Tarefa, null)) 
            {
                Tarefa.StatusAtividade = NovoStatus;
                Tarefa.UltimaAtualizacao = DateTime.Now;

                await AtualizaStatusAtividade.InvokeAsync(AtividadeAtual);
            }
        }
    }
}
