using Coding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingWebApp.Services
{
    public interface IItemStorage
    {
        public void AddItem(ListItem item);
        public void RemoveItem(int id);
        public List<ListItem> GetAllItems();
        public ListItem GetById(int id);
    }

        public class MemoryItemStorage : IItemStorage
        {
            private List<ListItem> innerList { get; set; }

            public MemoryItemStorage()
            {
                innerList = new List<ListItem>();
            }

            public void AddItem(ListItem item)
            {
                if (item.Id == 0)
                {
                    item.Id = innerList.Count + 1;
                    innerList.Add(item);
                    return;
                }

                var selectedItem = GetById(item.Id);
                selectedItem.Description = item.Description;
                selectedItem.Name = item.Name;
            }

            public List<ListItem> GetAllItems()
            {
                return innerList;
            }

            public ListItem GetById(int id)
            {
                return innerList.FirstOrDefault(item => item.Id == id);
            }

            public void RemoveItem(int id)
            {
                var selectedItem = GetById(id);
                if (selectedItem == null)
                    throw new Exception(string.Format("Item with id '{0}' was not found.", id));

                innerList.Remove(selectedItem);
            }
        }
}
