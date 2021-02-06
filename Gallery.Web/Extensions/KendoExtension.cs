using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gallery.Web.Extensions
{
    public static class KendoExtension
    {
        public static TDataSourceBuilder DefaultSort<TModel, TDataSourceBuilder>(this AjaxDataSourceBuilderBase<TModel, TDataSourceBuilder> builder)
            where TModel : class
            where TDataSourceBuilder : AjaxDataSourceBuilderBase<TModel, TDataSourceBuilder>
        {
            return builder.Sort(model => model.Add("ChangedWhen").Descending());
        }

        public static void RemoveDefaultSort(this DataSourceRequest request)
        {
            if (request.Sorts.Count > 1)
            {
                var defaultSort = request.Sorts.SingleOrDefault(sort => sort.Member == "ChangedWhen");
                if (defaultSort != null)
                {
                    request.Sorts.Remove(defaultSort);
                }
            }
        }
    }
}