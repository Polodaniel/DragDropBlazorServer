using DragDropBlazorServer.Data;
using DragDropBlazorServer.Data.Enumeradores;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Shared.DragDrop
{
    public class ListaAtividadeBase : ComponentBase
    {
        [CascadingParameter]
        public Container Container { get; set; }

        [Parameter]
        public StatusAtividade Status { get; set; }

        [Parameter]
        public StatusAtividade[] StatusPermitidos { get; set; }

        public List<ItemAtividade> ListaAtividade { get; set; }

        public string dropClass = "";

        public ListaAtividadeBase()
        {
            ListaAtividade = new List<ItemAtividade>();
        }

        protected override void OnParametersSet()
        {
            ListaAtividade.Clear();
            ListaAtividade.AddRange(Container.ListaAtividade.Where(x => x.StatusAtividade == Status));
        }

        protected void OnDragEnter() 
        {
            if (Status == Container.AtividadeAtual.StatusAtividade)
                return;

            if (StatusPermitidos != null && !StatusPermitidos.Contains(Container.AtividadeAtual.StatusAtividade))
                dropClass = "no-drop";
            else
                dropClass = "can-drop";
        }

        protected void OnDragLeave() 
        {
            dropClass = "";
        }

        protected async Task OnDrop() 
        {
            dropClass = "";

            if (StatusPermitidos != null && !StatusPermitidos.Contains(Container.AtividadeAtual.StatusAtividade))
                return;

            await Container.AtualizarAtividadeAsync(Status);
        }
    }
}
