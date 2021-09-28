using DragDropBlazorServer.Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Shared.DragDrop
{
    public class AtividadeBase : ComponentBase
    {
        [CascadingParameter]
        public Container Container { get; set; }

        [Parameter]
        public ItemAtividade AtividadeItem { get; set; }

        protected void OnDragStart(ItemAtividade Atividade) 
        {
            Container.AtividadeAtual = Atividade;
        }

        protected void RemoverAtividade(ItemAtividade Atividade) 
        {
           var item = Container.ListaAtividade.Where(x => x.Id == Atividade.Id).FirstOrDefault();

            if (!Equals(item, null)) 
            {
                Container.ListaAtividade.Remove(item);

                StateHasChanged();
            }
        }
    }
}
