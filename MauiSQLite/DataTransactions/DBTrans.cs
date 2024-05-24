using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiSQLite.Models;
using SQLite;


namespace MauiSQLite.DataTransactions
{
    public class DBTrans
    {
        public string dbPath;
        private SQLiteConnection conn;

        public DBTrans(string _dbPath)
        {
            this.dbPath = _dbPath;
        }

        public void Init1()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<StudentClass>();
            
            
            
        }
        public void Init2()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<UniversityClass>();

            
        }
        public void Init3()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<PaymentInfo>();
        }
        public void Init4()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<Applications>();
        }

        public List<StudentClass> GetAllStudents()
        {
            Init1();
            return conn.Table<StudentClass>().ToList();
        }
        public void Add(StudentClass student)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(student);
        }

        public void DeleteStudent(int student_ID)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new StudentClass { ID = student_ID});
        }


        public List<UniversityClass> GetAllUniversities()
        {
            Init2();
            return conn.Table<UniversityClass>().ToList();
        }

        public void AddUniversity(UniversityClass university)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(university);
        }

        public void DeleteUniversity(int university_ID)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new UniversityClass { ID = university_ID });
        }

        
        public List<MajorClass> GetAllMajors()
        {
            Init1();
            return conn.Table<MajorClass>().ToList();
        }

        public void AddMajor(MajorClass major)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(major);
        }

        public void DeleteMajor(int major_ID)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new MajorClass { ID = major_ID });
        }

        public List<PaymentInfo> GetAllPayments()
        {
            Init3();
            return conn.Table<PaymentInfo>().ToList();
        }
        public void AddPayment(PaymentInfo payment)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(payment);
        }

        public void DeletePayment(int payment_ID)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new PaymentInfo { ID = payment_ID });
        }
       
        public List<Applications> GetAllApplications()
        {
            Init4();
            return conn.Table<Applications>().ToList();
        }
        public void AddApplication(Applications app)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Insert(app);
        }

        public void DeleteApplication(int app)
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.Delete(new Applications { ApplicationID = app });
        }
    }
}
