using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationManagement.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IMedicationRepository MedicationRepository { get; }
        public void Save();
    }
}
