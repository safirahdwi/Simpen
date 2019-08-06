using Mvc.JQuery.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.ViewModels
{
    public class JabatanOrmawaRow
    {
        [DataTables]
        public int Id { get; set; }
        [DataTables]
        public string Nama { get; set; }
    }
}
