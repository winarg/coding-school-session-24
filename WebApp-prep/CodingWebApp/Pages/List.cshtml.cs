using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coding.Model;
using CodingWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodingWebApp.Pages
{
    public class ListModel : PageModel
    {
        public List<ListItem> Items = new List<ListItem>();

        private IItemStorage _storage { get; set; }

        public ListModel(IItemStorage storage)
        {
            _storage = storage;
        }

        public void OnGet()
        {
            Items = _storage.GetAllItems();
        }
    }
}
