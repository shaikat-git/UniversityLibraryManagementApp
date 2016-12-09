using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CascadingDropDownApp.Gateway;
using CascadingDropDownApp.Models;
using Microsoft.Owin.Security.Facebook;

namespace CascadingDropDownApp.Manager
{
    public class UniversityLibraryManager
    {
        UniversityLibraryGateway aUniversityLibraryGateway = new UniversityLibraryGateway();
        public string SaveBook(Book aBook)
        {
            bool IsBookCodeExist = aUniversityLibraryGateway.IsBookCodeExist(aBook.BookCode);
            bool IsBookTitleExist = aUniversityLibraryGateway.IsBookTitleExist(aBook.BookTitle);

            if (IsBookCodeExist)
            {
                return "Sorry Book Code already exists";
            }
            else
            {
                if (IsBookTitleExist)
                {
                    return "Sorry Book Title already exists";
                }
                else
                {
                    int rowAffected = aUniversityLibraryGateway.SaveBook(aBook);

                    if (rowAffected > 0)
                    {
                        return "Book Has Been Saved";
                    }
                    else
                    {
                        return "Sorry Book Save Failed";
                    }

                }
            }
        }

        public string SaveStudent(UniversityStudent aStudent)
        {
            bool IsStudentIDExist = aUniversityLibraryGateway.IsStudentIDExist(aStudent.StudentId);

            if (IsStudentIDExist)
            {
                return "Sorry Student Code already exists";
            }
            else
            {
                int rowAffected = aUniversityLibraryGateway.SaveStudent(aStudent);

                    if (rowAffected > 0)
                    {
                        return "Student Has Been Saved";
                    }
                    else
                    {
                        return "Student Book Save Failed";
                    }
            }
        }

        public List<Book> GetAllBooks()
        {
            return aUniversityLibraryGateway.GetAllBooks();
        }

        public List<UniversityStudent> GetAllStudents()
        {
            return aUniversityLibraryGateway.GetAllStudents();
        }

        public UniversityStudent GetStudentInfoByStudentId(string studentId)
        {
            return aUniversityLibraryGateway.GetStudentInfoByStudentId(studentId);
        }

        public Book GetBookInfoByBookCode(string bookCode)
        {
            return aUniversityLibraryGateway.GetBookInfoByBookCode(bookCode);
        }

        public string BorrowBook(BorrowBooks aBorrowRequest)
        {
            bool IsBorrowedBookExist = aUniversityLibraryGateway.IsBorrowedBookExist(aBorrowRequest);

             if (IsBorrowedBookExist)
             {
                 return "Sorry! Already Borrowed this Book to this Student";
             }
            else
            {
                if (aBorrowRequest.BookQuantity > 0)
                {
                    int rowAffected = aUniversityLibraryGateway.BorrowBook(aBorrowRequest);

                    if (rowAffected > 0)
                    {
                        return "Borrowed Saved";
                    }
                    else
                    {
                        return "Borrowed Failed";
                    }

                }
                return "Sorry No Book in Stock";
            }

        }

        public List<BorrowBooks> GetBorrowedBookByStudentId(string studentId)
        {
            return aUniversityLibraryGateway.ViewBorrowedBooks(studentId);
        }

        public List<BorrowBooks> GetBookStatusByBookCode(string bookCode)
        {
            return aUniversityLibraryGateway.ViewBookStatus(bookCode);
        }

        public string ReturnBorrow(string studentId, string bookCode)
        {
            int rowAffected = aUniversityLibraryGateway.ReturnBorrow(studentId, bookCode);

            if (rowAffected > 0)
            {
                return "Return Borrowed Successful";
            }
            else
            {
                return "Return Borrowed Failed";
            }
        }
    }
}