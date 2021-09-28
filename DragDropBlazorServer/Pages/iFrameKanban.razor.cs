using DragDropBlazorServer.Data;
using DragDropBlazorServer.Shared.Dialog;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Pages
{
    public class IFrameKanbanBase : ComponentBase
    {
        [Inject]
        public IDialogService DialogService { get; set; }

        public List<ItemAtividade> ListaAtividade { get; set; }

        protected string UltimaAtividadeAtualizada { get; set; }

        public IFrameKanbanBase()
        {
            ListaAtividade = new List<ItemAtividade>();
            UltimaAtividadeAtualizada = string.Empty;
        }

        protected override void OnInitialized()
        {
    
        }

        public void StatusUpdate(ItemAtividade atividade)
        {
            UltimaAtividadeAtualizada = atividade.Titulo;
        }

        public async void NovaAtividade()
        {
            var ParametersDialog = new DialogParameters();

            var OptionDialog = new DialogOptions();
            OptionDialog.MaxWidth = MaxWidth.Medium;
            OptionDialog.CloseButton = false;
            OptionDialog.DisableBackdropClick = true;
            OptionDialog.Position = DialogPosition.Center;

            var Dialog = DialogService.Show<NovaAtividadeDialog>($"Nova Atividade", ParametersDialog, OptionDialog);
            var Result = await Dialog.Result;

            if (!Result.Cancelled)
            {
                var NovaAtividade = (ItemAtividade)Result.Data;

                if (!Equals(NovaAtividade, null))
                {
                    ListaAtividade.Add(NovaAtividade);

                    StateHasChanged();
                }
            }
        }
    }
}
