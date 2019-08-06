using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class JabatanOrmawaVM
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public DataTableConfigVm DataTableConfigVm { get; set; }

        public IEnumerable<SelectListItem> ListJabatan { get; set; }
    }
}
