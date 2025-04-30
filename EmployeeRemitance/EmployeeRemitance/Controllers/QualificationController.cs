using EmployeeRemitance. Interfaces;
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
            return View ( );
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
    }
}
