using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2._1
{ 
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation,
        none
    };
    class Person
    {
        string name;
        string secondName;
        DateTime birth = new DateTime();

        public Person(string name, string secondName, DateTime birth)
        {
            this.name = name;
            this.secondName = secondName;
            this.birth = birth;
        }
        public Person()
        {
            name = "";
            secondName = "";
            birth = new DateTime(1970,01,01);
        }
        public string GetName()
        {
            return name;
        }
        public string GetSecondName()
        {
            return secondName;
        }
        public DateTime GetBirth()
        {
            return birth;
        }
        public int getYear()
        {
            return birth.Year;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetSecondName(string secondName)
        {
            this.secondName = secondName;
        }
        public void SetDate(DateTime birth)
        {
            this.birth = birth;
        }
        public void SetYear(int Year)
        {
            birth.AddYears(Year);
        }
        public override string ToString()
        {
            string str;
            str = "";
            str += name + " ";
            str += secondName + " ";
            str += birth.ToString();
            return str;
        }
        virtual public string ToShortString()
        {
            string str;
            str = "";
            str += name + " ";
            str += secondName + " ";
            return str;
        }
    }
    class Exam
    {
        string examName;
        int  examMark;
        DateTime examDate;
        public Exam(string examName, int examMark, DateTime examDate)
        {
            this.examName = examName;
            this.examMark = examMark;
            this.examDate = examDate;
        }
        public Exam()
        {
            examName = "None";
            examMark = 0;
            examDate = new DateTime(1970, 01, 01);
        }
        public override string ToString()
        {
            string str;
            str = "Имя предмета ";
            str += examName + " Оценка ";
            str += examMark.ToString() + " Время ";
            str += examDate.ToString();
            return str;
        }
        public int getExamMark()
        {
            return examMark;
        }
    }
    class Student
    {
        Person person;
        Education education;
        int group;
        List<Exam> exams = new List<Exam>();
        public Student(Person person, Education education, int group)
        {
            this.person = person;
            this.education = education;
            this.group = group;
        }
        public Student()
        {
            person = new Person();
            education = Education.none;
            group = 0000;
        }
        public Person GetPerson()
        {
            return person;
        }
        public Education GetEducation()
        {
            return education;
        }
        public int GetGroup()
        {
            return group;
        }
        public List<Exam> GetExam()
        {
            return exams ;
        }
        public void SetPerson(Person person)
        {
            this.person = person;
        }
        public void SetEducation(Education education)
        {
            this.education = education;
      
        }
        public void SetGroup(int group)
        {
            this.group = group;
        }
        public void SetExams(List<Exam> exams)
        {
            this.exams.Concat(exams);
        }
        public double GetTotalMark( List<Exam> exams)
        {
            double totalMark = 0;
            int quantity = 1;
            foreach(Exam currentMark in exams)
            {
                totalMark += currentMark.getExamMark();
                quantity += 1;
            }
            if(quantity != 0)
            totalMark = totalMark / (quantity-1);
            return totalMark;
        }
        public bool GetIndex(int index)
        {
            if (index == (int)education)
                return true;
            return false;
        }
        public void AddExam(List <Exam>exam)
        {
            exams = exam;
        }
        public override string ToString()
        {
            string result = " ФИО: ";
            string temp = " ";
            result += person.ToString() + " Образование ";
            result += education + " Группа  ";
            result += group.ToString() + " \n Список Экзаменов \n";
            foreach (Exam i in exams)
            {
                temp += i.ToString() + '\n';
            }
            result += temp;
            return result;
        }
        virtual public string ToShortString()
        {
            string result = "ФИО: ";
            result += person.ToString() + " Образование: ";
            result += education + " Группа:";
            result += group.ToString() + " Средний балл:";
            result += GetTotalMark(exams).ToString();
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student stud1 = new Student();
            Console.WriteLine(stud1.ToShortString());
            Education Bachelor = Education.Bachelor;
            Education SecondEducation = Education.SecondEducation;
            Education Specialist = Education.Specialist;
            Console.WriteLine("Индексы: \nБакалавр - " + (int)Bachelor +
                               "\nВторое образование - " + (int)SecondEducation +
                               "\nСпециалист - " + (int)Specialist);
            Student stud2 = new Student(new Person("Umar", "Sharifor", new DateTime(1999, 06, 23)), Bachelor, 762);
            Console.WriteLine(stud2.ToString());
            List<Exam> ex = new List<Exam>();
            ex.Add(new Exam("Информатика", 4, new DateTime(2018, 01, 20)));
            ex.Add(new Exam("Диффуры", 5, new DateTime(2018, 01, 27)));
            stud2.AddExam(ex);
            Console.WriteLine(stud2.ToString());
            Console.WriteLine(stud2.ToShortString());
        }
    }
}
