using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CascadingDropDownApp.Models;

namespace CascadingDropDownApp.Gateway
{
    public class UniversityLibraryGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityLibraryConnectionString"].ConnectionString;

        public bool IsBookCodeExist(string bookCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Book WHERE BookCode = @BookCode";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("BookCode", SqlDbType.NVarChar);
            command.Parameters["BookCode"].Value = bookCode;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }

        public bool IsBookTitleExist(string bookTitle)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Book WHERE BookTitle = @BookTitle";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("BookTitle", SqlDbType.NVarChar);
            command.Parameters["BookTitle"].Value = bookTitle;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;

        }

        public int SaveBook(Book aBook)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Book VALUES (@BookCode, @BookTitle, @BookQuantity, @BookAuthor, @BookPublisher, @BookRemaining)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("BookCode", SqlDbType.VarChar);
            command.Parameters["BookCode"].Value = aBook.BookCode;
            command.Parameters.Add("BookTitle", SqlDbType.VarChar);
            command.Parameters["BookTitle"].Value = aBook.BookTitle;
            command.Parameters.Add("BookQuantity", SqlDbType.Int);
            command.Parameters["BookQuantity"].Value = aBook.BookQuantity;
            command.Parameters.Add("BookAuthor", SqlDbType.VarChar);
            command.Parameters["BookAuthor"].Value = aBook.BookAuthor;
            command.Parameters.Add("BookPublisher", SqlDbType.VarChar);
            command.Parameters["BookPublisher"].Value = aBook.BookPublisher;
            command.Parameters.Add("BookRemaining", SqlDbType.VarChar);
            command.Parameters["BookRemaining"].Value = aBook.BookQuantity;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsStudentIDExist(string studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Student WHERE StudentID = @StudentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("StudentID", SqlDbType.NVarChar);
            command.Parameters["StudentID"].Value = studentId;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }

        public int SaveStudent(UniversityStudent aStudent)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Student VALUES (@StudentID, @StudentName, @StudentEmail, @StudentContactNo)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("StudentID", SqlDbType.VarChar);
            command.Parameters["StudentID"].Value = aStudent.StudentId;
            command.Parameters.Add("StudentName", SqlDbType.VarChar);
            command.Parameters["StudentName"].Value = aStudent.StudentName;
            command.Parameters.Add("StudentEmail", SqlDbType.NVarChar);
            command.Parameters["StudentEmail"].Value = aStudent.StudentEmail;
            command.Parameters.Add("StudentContactNo", SqlDbType.NVarChar);
            command.Parameters["StudentContactNo"].Value = aStudent.StudentContactNo;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Book> GetAllBooks()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Book";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Book> allBooks = new List<Book>();

            while (reader.Read())
            {
                Book aBook = new Book()
                {
                    BookCode = reader["BookCode"].ToString(),
                    BookTitle = reader["BookTitle"].ToString(),
                    BookAuthor = reader["BookAuthor"].ToString(),
                    BookPublisher = reader["BookPublisher"].ToString(),
                    BookQuantity = (int)reader["BookQuantity"],
                    BookRemaining = (int)reader["BookRemaining"]
                };
                allBooks.Add(aBook);
            }
            reader.Close();
            connection.Close();
            return allBooks;
        }

        public List<UniversityStudent> GetAllStudents()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Student";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<UniversityStudent> allStudents = new List<UniversityStudent>();

            while (reader.Read())
            {
                UniversityStudent aStudent = new UniversityStudent()
                {
                    StudentId = reader["StudentID"].ToString(),
                    StudentName = reader["StudentName"].ToString(),
                    StudentContactNo = reader["StudentContactNo"].ToString(),
                    StudentEmail = reader["StudentEmail"].ToString(),
                };
                allStudents.Add(aStudent);
            }
            reader.Close();
            connection.Close();
            return allStudents;
        }

        public UniversityStudent GetStudentInfoByStudentId(string studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Student WHERE StudentID = '" + studentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            UniversityStudent aStudentInfo = new UniversityStudent();
            if (reader.HasRows)
            {
                reader.Read();
                aStudentInfo.StudentName = reader["StudentName"].ToString();
                aStudentInfo.StudentEmail = reader["StudentEmail"].ToString();
                aStudentInfo.StudentContactNo = reader["StudentContactNo"].ToString();
            }
            reader.Close();
            connection.Close();
            return aStudentInfo;
        }

        public Book GetBookInfoByBookCode(string bookCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Book WHERE BookCode = '" + bookCode + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Book aBook = new Book();
            if (reader.HasRows)
            {
                reader.Read();
                aBook.BookCode = reader["BookCode"].ToString();
                aBook.BookTitle = reader["BookTitle"].ToString();
                aBook.BookAuthor = reader["BookAuthor"].ToString();
                aBook.BookQuantity = (int) reader["BookRemaining"];
            }
            reader.Close();
            connection.Close();
            return aBook;
        }

        public int BorrowBook(BorrowBooks aBorrowRequest)
        {
            int newQuantity = (aBorrowRequest.BookQuantity - 1);
            SqlConnection connection = new SqlConnection(connectionString);
            string updateQuantityQuery = "UPDATE Book SET BookRemaining ='" + newQuantity + "' WHERE BookCode = '"+aBorrowRequest.BookTitle+"'; ";
            SqlCommand updateQuantityCommand = new SqlCommand(updateQuantityQuery, connection);

            string query = "INSERT INTO BorrowBook VALUES (@StudentID, @BookCode)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("StudentID", SqlDbType.VarChar);
            command.Parameters["StudentID"].Value = aBorrowRequest.StudentID;
            command.Parameters.Add("BookCode", SqlDbType.VarChar);
            command.Parameters["BookCode"].Value = aBorrowRequest.BookTitle;
            connection.Open();

            updateQuantityCommand.ExecuteNonQuery();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<BorrowBooks> ViewBorrowedBooks(string studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM BorrowedBookStudentWise WHERE StudentID ='" + studentId + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BorrowBooks> allBorrowedBooks= new List<BorrowBooks>();

            while (reader.Read())
            {
                BorrowBooks aBorrowedBook = new BorrowBooks()
                {
                    BookTitle = reader["BookTitle"].ToString(),
                    BookAuthor = reader["BookAuthor"].ToString(),
                    BookCode = reader["BookCode"].ToString(),
                 };
                allBorrowedBooks.Add(aBorrowedBook);
            }
            reader.Close();
            connection.Close();
            return allBorrowedBooks;
        }

        public List<BorrowBooks> ViewBookStatus(string bookCode)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM BookStatusWithStudentInfo WHERE BookCode ='" + bookCode + "'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<BorrowBooks> borrowBookStudent = new List<BorrowBooks>();

            while (reader.Read())
            {
                BorrowBooks aborrowBookStudent = new BorrowBooks()
                {
                    StudentID = reader["StudentID"].ToString(),
                    StudentName = reader["StudentName"].ToString(),
                    StudentContactNo = reader["StudentContactNo"].ToString(),
                };
                borrowBookStudent.Add(aborrowBookStudent);
            }
            reader.Close();
            connection.Close();
            return borrowBookStudent;
        }

        public int ReturnBorrow(string studentId, string bookCode)
        {
           SqlConnection connection = new SqlConnection(connectionString);
            string updateQuantityQuery = "UPDATE Book SET BookRemaining = BookRemaining+1 WHERE BookCode = '" +bookCode+ "'; ";
            SqlCommand updateQuantityCommand = new SqlCommand(updateQuantityQuery, connection);

            string query = "DELETE FROM BorrowBook WHERE StudentID = '"+studentId+"' AND BookCode = '"+bookCode+"'; ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            updateQuantityCommand.ExecuteNonQuery();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsBorrowedBookExist(BorrowBooks aBorrowRequest)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM BorrowBook WHERE BookCode = '" + aBorrowRequest.BookTitle + "' AND StudentID = '" + aBorrowRequest .StudentID+ "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            reader.Close();
            connection.Close();
            return isExist;
        }
    }
}