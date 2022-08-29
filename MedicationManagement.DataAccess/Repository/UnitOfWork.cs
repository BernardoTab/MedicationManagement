using MedicationManagement.DataAccess.DataContext;
using MedicationManagement.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationManagement.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IMedicationRepository MedicationRepository { get; }

        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            MedicationRepository = new MedicationRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
