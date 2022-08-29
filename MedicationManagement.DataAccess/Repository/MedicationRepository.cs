using MedicationManagement.DataAccess.DataContext;
using MedicationManagement.DataAccess.Repository.IRepository;
using MedicationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedicationManagement.DataAccess.Repository
{
    public class MedicationRepository : Repository<Medication>,IMedicationRepository
    {


        private readonly ApplicationDbContext _db;
        public MedicationRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
    }
}
