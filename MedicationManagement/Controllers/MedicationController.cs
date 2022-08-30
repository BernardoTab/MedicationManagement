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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var medicationList = await _unitOfWork.MedicationRepository.GetAll();

                return Ok(medicationList);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMedication(Medication medication)
        {
            try
            {
                if (medication == null) return BadRequest(); //null request

                var medicationAlreadyInDB = await _unitOfWork.MedicationRepository.GetFirstOrDefault(u => u.Name == medication.Name);

                if (medicationAlreadyInDB != null)
                {
                    ModelState.AddModelError("Name", "Medication with that name already exists");
                    return BadRequest(ModelState); //medication already exists
                }

                medication.CreationDate = DateTime.Now; //Set the creation time to now
                var createdMedication = await _unitOfWork.MedicationRepository.Add(medication);
                _unitOfWork.Save();

                return CreatedAtAction(nameof(Medication),
                    new { id = createdMedication.Id }, createdMedication);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when creating new medication");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            try
            {
                var medicationToDelete = await _unitOfWork.MedicationRepository.GetFirstOrDefault(u => u.Id == id);

                if(medicationToDelete == null) return NotFound($"Medication with id = {id} was not found");

                _unitOfWork.MedicationRepository.Remove(medicationToDelete);
                _unitOfWork.Save();
                return Ok($"Medication with id={id} was deleted");
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when attempting to delete medication");

            }
            
        }
    }
}
