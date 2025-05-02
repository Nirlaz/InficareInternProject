using EmployeeRemitance. Interfaces;
using EmployeeRemitance. Models;
using Microsoft. AspNetCore. Mvc;

namespace EmployeeRemitance. Controllers
{
    public class QualificationController : Controller
    {
        private IQualificationRepository _qualificationRepository;
        public QualificationController ( IQualificationRepository qualificationRepository)
        {
            _qualificationRepository = qualificationRepository; 
        }
        public IActionResult Index ( )
        {
            var Qualifcaions = _qualificationRepository. GetAllQualification ( );
            return View ( Qualifcaions );
        }

        public IActionResult Create ( )
        {
            return View ();
        }
        public IActionResult Show ( int EmployeeId )
        {
            var Qualification = _qualificationRepository.GetQualificationById ( EmployeeId );
            ViewBag. EmployeeId = EmployeeId;
            return View ( Qualification);
        }

        public IActionResult DeleteFormEmployeeId ( int QualificationId , int EmployeeId )
        {
            var result =  _qualificationRepository.DeleteFormEmployeeId(QualificationId,EmployeeId);
            if ( result. Code == 202 )
            {
                return RedirectToAction ( "Show" , new { Id = EmployeeId } );
            }
            return NotFound ( Index );

        }

        [HttpPost]
        public IActionResult CreateQualification ( Qualification quali )
        {
            var result = _qualificationRepository.AddQualification(quali);
        
                return RedirectToAction ( "Index" );
           
            return NotFound ( );
        }

        public IActionResult Update ( int Id )
        {
            var qualification = _qualificationRepository.GetQualificationByQualificationId(Id);
            return View ( qualification );
        }

        [HttpPost]
        public IActionResult UpdateQualification ( Qualification qualification )
        {
            var result =  _qualificationRepository .UpdateQualification(qualification);
            if ( result. Code == 202 )
            {
                return RedirectToAction ( "Index" );
            }
            return NotFound ( Index );
        }



        public IActionResult Delete ( int QualificationId )
        {
            var result =  _qualificationRepository.DeleteQualification(QualificationId);
            if ( result. Code == 202 )
            {
                return RedirectToAction ( "Index" );
            }
            return NotFound ( Index );
        }
    }
}
