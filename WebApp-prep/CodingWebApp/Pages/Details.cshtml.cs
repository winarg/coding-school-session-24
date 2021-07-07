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
    public class DetailsModel : PageModel
    {

        [BindProperty]
        public ListItem SelectedListItem { get; set; }

        private IItemStorage _storage { get; set; }

        public DetailsModel(IItemStorage storage)
        {
            _storage = storage;
        }

        public void OnGet(int id)
        {
            if (id == 0)
            {
                SelectedListItem = new ListItem();
                return;
            }

            SelectedListItem = _storage.GetById(id);
        }

        public IActionResult OnPost()
        {
            _storage.AddItem(SelectedListItem);

            return RedirectToPage("List");
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("List");
        }

        public IActionResult OnPostDelete()
        {
            _storage.RemoveItem(SelectedListItem.Id);
            return RedirectToPage("List");
        }
    }
}
