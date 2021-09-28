using DragDropBlazorServer.Data;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Shared.Dialog
{
    public class NovaAtividadeDialogBase : ComponentBase
    {
        [Inject]
        protected ISnackbar Snackbar { get; set; }

        [CascadingParameter]
        public MudDialogInstance MudDialog { get; set; }

        public ItemAtividade NovaAtividade { get; set; }

        public NovaAtividadeDialogBase() =>
            NovaAtividade = new ItemAtividade();

        protected override void OnInitialized()
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
        }

        public void Cancel() =>
           MudDialog.Cancel();

        public void Submit()
        {
            if (!string.IsNullOrEmpty(NovaAtividade.Titulo) || !string.IsNullOrWhiteSpace(NovaAtividade.Titulo))
                MudDialog.Close(DialogResult.Ok(NovaAtividade));
            else
                Snackbar.Add("Oops! O título é obrigatorio!", Severity.Error);
        }

        protected IEnumerable<string> MaxTituloCharacters(string ch)
        {
            if (!string.IsNullOrEmpty(ch) && 25 < ch?.Length)
                yield return "Máximo 25 characters";
        }

        protected IEnumerable<string> MaxDescricaoCharacters(string ch)
        {
            if (!string.IsNullOrEmpty(ch) && 200 < ch?.Length)
                yield return "Máximo 200 characters";
        }

    }
}
