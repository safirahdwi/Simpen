using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc.JQuery.DataTables;
using Ormawa.BusinessModel;
using Ormawa.Models;
using Ormawa.ViewModels;

namespace Ormawa.Controllers
{
    public class ReferensiController : Controller
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;
        private readonly Combobox _combobox;
        private readonly JabatanOrmawaRepo _repo;
        JabatanOrmawaVM vmod = new JabatanOrmawaVM();

        public ReferensiController(DBINTEGRASI_MASTER_BAYUPPKU2Context context, Combobox combobox, JabatanOrmawaRepo repo)
        {
            _context = context;
            _combobox = combobox;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var dataProviderUrl = Url.Action("DataTables");
            var viewModel = DataTablesHelper.DataTableVm<JabatanOrmawaRow>("dataTable", dataProviderUrl);

            viewModel.ShowFilterInput = true;
            viewModel.PageLength = 10;

            vmod.DataTableConfigVm = viewModel;

            return View(vmod);
        }

        // GET: Anggota/Create
        public IActionResult Add()
        {
            //Daftar Ormawa
            return View();
        }

        [HttpPost]
        public IActionResult Add(JabatanOrmawaVM vmod)
        {
            if (ModelState.IsValid)
            {
                _repo.AddJabatan(vmod);   
                //return RedirectToAction(nameof(Daftaranggota));
                return RedirectToAction("Index", "JabatanOrmawa");
            }
            return RedirectToAction("Index", "JabatanOrmawa");
        }
        public DataTablesResult<JabatanOrmawaRow> DataTables(DataTablesParam param)
        {
            var query = _repo.GetJenisJabatanList();

            var no = param.iDisplayStart + 1;
            return DataTablesResult.Create(query, param, row => new
            {
                // custom formatting
                Aksi = Buttonstring(row.Id)
            });
        }

        public string Buttonstring(int ID)
        {
            var res = "<div class='btn-group'>"
                         + "<a href='DaftarPrestasi/Edit/" + ID + "' class='btn btn-warning btn-sm btn-flat'>"
                           + "<span class='fa fa-pencil'></span>"
                         + "</a>"
                         + "<a href='/DaftarPrestasi/Detail/" + ID + "' class='btn btn-primary btn-sm btn-flat'>"
                           + "<span class='fa fa-calendar-o'></span>"
                         + "</a>"
                         + "<a href='/DaftarPrestasi/Delete/" + ID + "' class='btn btn-danger btn-sm btn-flat' data-target=\"#myModal\" data-toggle=\"modal\">"
                           + "<span class='fa fa-trash'></span>"
                         + "</a>"
                    + "</div>";
            return res;
        }

        public IActionResult Edit(int Id)
        {
            var a = _repo.GetDetailJabatan(Id);
            vmod = a;
            return View(vmod);
        }

        [HttpPost]
        public IActionResult Edit(JabatanOrmawaVM vmod)
        {
            if (ModelState.IsValid)
            {
                _repo.EditJabatan(vmod);
                //return RedirectToAction(nameof(Daftaranggota));
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "JabatanOrmawa");
        }

    }
}