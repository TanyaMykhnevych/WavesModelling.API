using System;
using System.Collections.Generic;

namespace Waves.Services.Models.Shared
{
    public class ItemListModel<T>
    {
        public List<T> Items { get; set; }
        public Int32 TotalCount { get; set; }

        public ItemListModel()
        {
            Items = new List<T>();
        }
    }
}
