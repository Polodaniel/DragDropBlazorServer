using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DragDropBlazorServer.Data.Enum
{
    public enum Status
    {
        [Description("0 - Iniciado")]
        Iniciado = 0,

        [Description("2 - Em Desenvolvimento")]
        EmDesenvolvimento = 2,

        [Description("4 - Em Teste")]
        EmTeste = 4,

        [Description("6 - Finalizado")]
        Finalizado = 6
    }
}
