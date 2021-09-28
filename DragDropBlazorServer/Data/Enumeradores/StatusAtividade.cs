using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Data.Enumeradores
{
    public enum StatusAtividade
    {
        [Description("Iniciado")]
        Iniciado = 0,

        [Description("Em Desenvolvimento")]
        EmDesenvolvimento = 2,

        [Description("Em Teste")]
        EmTeste = 4,

        [Description("Finalizado")]
        Finalizado = 6
    }
}
