using MedicationManagement.DataAccess.Repository.IRepository;
using MedicationManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicationManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public MedicationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var medication = _unitOfWork.MedicationRepository.GetAll();

            return Json(new { data = medication });
        }

        [HttpPost]
        public IActionResult PostMedication()
        {
            var medication = _unitOfWork.MedicationRepository.GetAll();

            return Json(new { data = medication });
        }

        [HttpDelete]
        public IActionResult DeleteMedication(int id)
        {
            var medication = _unitOfWork.MedicationRepository.GetFirstOrDefault(u => u.Id == id);
            if(medication != null)
            {
                _unitOfWork.MedicationRepository.Remove(medication);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Medication removed successfully!" });
            }
            else
            {
                return Json(new { success = false, message = "Cannot remove medication as it does not exist in the database" });
            }
        }
    }
}
