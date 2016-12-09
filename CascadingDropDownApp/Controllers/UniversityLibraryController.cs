using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownApp.Manager;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Controllers
{
    public class UniversityLibraryController : Controller
    {
        UniversityLibraryManager aUniversityLibraryManager = new UniversityLibraryManager();
        public ActionResult SaveBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveBook(Book aBook)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SaveBookMessage = aUniversityLibraryManager.SaveBook(aBook);
            }
            return View();
        }

        public ActionResult SaveStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudent(UniversityStudent aStudent)
        {
            if (ModelState.IsValid)
            {
                ViewBag.SaveStudentMessage = aUniversityLibraryManager.SaveStudent(aStudent);
            }
            return View();
        }
        public ActionResult BorrowBook()
        {
            List<UniversityStudent> allStudents = aUniversityLibraryManager.GetAllStudents();
            List<Book> allBooks = aUniversityLibraryManager.GetAllBooks();
            ViewBag.allStudents = allStudents;
            ViewBag.allBooks = allBooks;
            return View();
        }

        [HttpPost]
        public ActionResult BorrowBook(BorrowBooks aBorrowRequest)
        {
            List<UniversityStudent> allStudents = aUniversityLibraryManager.GetAllStudents();
            List<Book> allBooks = aUniversityLibraryManager.GetAllBooks();
            ViewBag.allStudents = allStudents;
            ViewBag.allBooks = allBooks;
            ViewBag.BorrowBookMessage = aUniversityLibraryManager.BorrowBook(aBorrowRequest);
            return View();
        }


        public JsonResult GetStudentInfoByStudentId(string studentId)
        {
            UniversityStudent studentinfo = aUniversityLibraryManager.GetStudentInfoByStudentId(studentId);

            return Json(studentinfo);
        }

        public JsonResult GetBookInfoByBookCode(string bookCode)
        {
            Book bookInfo = aUniversityLibraryManager.GetBookInfoByBookCode(bookCode);

            return Json(bookInfo);
        }

        public ActionResult ShowBorrowedBook()
        {
            List<UniversityStudent> allStudents = aUniversityLibraryManager.GetAllStudents();
            ViewBag.allStudents = allStudents;

            return View();
        }

        public JsonResult GetBorrowedBookByStudentId(string studentId)
        {
            List<BorrowBooks> courseInfo = aUniversityLibraryManager.GetBorrowedBookByStudentId(studentId);

            var courseInfoList = courseInfo.ToList();

            return Json(courseInfoList);
        }

        public ActionResult ShowBookStatus()
        {
            List<Book> allBooks = aUniversityLibraryManager.GetAllBooks();
            ViewBag.allBooks = allBooks;
            return View();

        }

        [HttpPost]
        public ActionResult ShowBookStatus(string BookTitle)
        {
            TempData["stdid"] = BookTitle;
            return RedirectToAction("BookStatusPdf", "UniversityLibrary");

        }
        public JsonResult GetBookStatusByBookCode(string bookCode)
        {
            List<BorrowBooks> bookStatusInfo = aUniversityLibraryManager.GetBookStatusByBookCode(bookCode);
            var bookStatusInfoList = bookStatusInfo.ToList();
            return Json(bookStatusInfoList);
        }

        public ActionResult BookStatusPdf()
        {
            string bookCode = TempData["stdid"].ToString();
            List<BorrowBooks> bookStatusInfo = aUniversityLibraryManager.GetBookStatusByBookCode(bookCode);
            ViewBag.bookStatus = bookStatusInfo;
            Book bookInfo = aUniversityLibraryManager.GetBookInfoByBookCode(bookCode);
            ViewBag.Bookinfo = bookInfo;
            return new Rotativa.ViewAsPdf("BookStatusPdf");
        }

        public ActionResult ShowAllBook()
        {
            List<Book> allBooks = aUniversityLibraryManager.GetAllBooks();
            ViewBag.allBooks = allBooks;
            return View();
        }

        public ActionResult ShowAllStudents()
        {
            List<UniversityStudent> allStudents = aUniversityLibraryManager.GetAllStudents();
            ViewBag.allStudents = allStudents;
            return View();
        }
        public ActionResult ReturnBook()
        {
            List<UniversityStudent> allStudents = aUniversityLibraryManager.GetAllStudents();
            ViewBag.allStudents = allStudents;
            return View();
        }

        [HttpPost]
        public ActionResult ReturnBook(string StudentID, string BorrowedBooks)
        {
            List<UniversityStudent> allStudents = aUniversityLibraryManager.GetAllStudents();
            ViewBag.allStudents = allStudents;
            ViewBag.ReturnBorrowMsg = aUniversityLibraryManager.ReturnBorrow(StudentID, BorrowedBooks);
            return View();
        }
    }


}