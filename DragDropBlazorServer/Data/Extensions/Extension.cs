using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace DragDropBlazorServer.Data.Extensions
{
    public static class Extension
    {
        public static bool IsNull(this object itemObject) =>
            itemObject == null;

        public static bool IsNullOrEmpty<TSource>(this IList<TSource> list) =>
            list == null || list.Count == 0;

        public static string ObterDescricaoDeEnum(this Enum enumerador)
        {
            if (enumerador == null)
                return string.Empty;

            Type tipo = enumerador.GetType();
            string nome = Enum.GetName(tipo, enumerador);

            string descricao = enumerador.ToString();

            if (nome != null)
            {
                FieldInfo campo = tipo.GetField(nome);
                if (campo != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(campo,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                        if (attr.Description != null)
                            descricao = attr.Description;
                }
            }
            return (descricao);
        }

        public static Dictionary<Enum, string> ObterTypeDescricaoEnum(Type enumerador)
        {
            var query = (from l in Enum.GetValues(enumerador).Cast<object>().OrderBy(x => (Enum)x).ToList()
                         select new { enumType = (Enum)l, descricao = ObterDescricaoDeEnum((Enum)l) })
                    .ToDictionary(x => x.enumType, x => x.descricao);

            var itemT = query.Where(x => x.Value == "Conciliado").FirstOrDefault();

            if (!Equals(itemT, null) && !Equals(itemT.Value, null))
            {
                var queryEditada = new Dictionary<Enum, string>();


                var queryTMP = query.Select(x => x);

                foreach (var item in queryTMP)
                    if (!Equals(item.Value, itemT.Value))
                        queryEditada.Add(item.Key, item.Value);

                queryEditada.Add(itemT.Key, itemT.Value);

                return queryEditada;
            }

            return query;
        }
    }
}
