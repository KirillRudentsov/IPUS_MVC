using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;
using Kendo_Example.Models;

namespace Kendo_Example.SupportClasses
{
    public class WrapperContextMenuItemsBuilder
    {
       
        public ContextMenuBuilder build(ContextMenuBuilder _in, Items items)
        {
            ContextMenuBuilder res = _in;

            foreach (var item in items.Item)
            {
                if (item.ContextMenuItemType == ContextMenuItemType.Separator)
                {
                    res.Items(item1 => item1.Add().Separator(true));
                }
                else
                {
                    res.Items(item2 => {

                        var i = item2.Add().Separator(false).Text(item.Title)
                        .HtmlAttributes(new { action = Enum.GetName(typeof(ColumnType), item.Action) });

                        if (item.Action == ColumnType.GridLink)
                            i.Action(item.DataSource.Action, item.DataSource.Controller_name,
                                new { filename = item.DataSource.key_link })
                                .ImageUrl(item.IconUrl);

                        if (item.Action == ColumnType.ProcessDesignerLink)
                            i.Action(item.DataSource.Action, item.DataSource.Controller_name, new { })
                            .ImageUrl(item.IconUrl);

                    });
                    
                }
            }

            return res;
        }

    }
}