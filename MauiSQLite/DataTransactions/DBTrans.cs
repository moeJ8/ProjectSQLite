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
            Init();
        }
        public void Init()
        {
            conn = new SQLiteConnection(this.dbPath);
            conn.CreateTable<StudentClass>();
            conn.CreateTable<UniversityClass>();
            conn.CreateTable<PaymentInfo>();
            conn.CreateTable<Applications>();
        }

        /*public void Init1()
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
        }*/

        public List<StudentClass> GetAllStudents() //change the name acc ur reqs
        {
            
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
        public UniversityClass GetUniversityById(int id)
        {

            return conn.Find<UniversityClass>(id);
        }


        public List<MajorClass> GetAllMajors()
        {
           
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
