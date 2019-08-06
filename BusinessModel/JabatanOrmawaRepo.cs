using Microsoft.EntityFrameworkCore;
using Ormawa.Models;
using Ormawa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.BusinessModel
{
    public class JabatanOrmawaRepo
    {
        private readonly DBINTEGRASI_MASTER_BAYUPPKU2Context _context;

        public JabatanOrmawaRepo(DBINTEGRASI_MASTER_BAYUPPKU2Context context)
        {
            _context = context;
        }

        public IQueryable<JabatanOrmawaRow> GetJenisJabatanList()
        {
            var query = from m in _context.JabatanOrmawa
                        select new JabatanOrmawaRow
                        {
                            Id = m.Id,
                            Nama = m.Nama
                        };
            return query;
        }

        public JabatanOrmawaVM GetDetailJabatan(int Id)
        {
            var edit = from m in _context.JabatanOrmawa
                       where m.Id == Id
                       select new JabatanOrmawaVM
                       {
                           Id = m.Id,
                           Nama = m.Nama
                       };
            return edit.FirstOrDefault();
        }

        public void AddJabatan(JabatanOrmawaVM vmod)
        {
            JabatanOrmawa ormawa = new JabatanOrmawa();
            ormawa.Id = vmod.Id;
            ormawa.Nama = vmod.Nama;
            _context.JabatanOrmawa.Add(ormawa);

            _context.SaveChanges();
        }

        public void EditJabatan(JabatanOrmawaVM vmod)
        {
            JabatanOrmawa ormawa = new JabatanOrmawa();
            ormawa.Id = vmod.Id;
            ormawa.Nama = vmod.Nama;
            _context.Entry(ormawa).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
