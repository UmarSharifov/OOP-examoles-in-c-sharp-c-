using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2._2
{
    enum Education
    {
        Specialist,
        Bachelor,
        SecondEducation,
        none
    };
    public interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
    internal class Person : IDateAndCopy
    {
        protected string name;
        protected string secondName;
        protected DateTime birth;
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
            birth = new DateTime(1970, 01, 01);
        }
        public DateTime Date { get { return birth; } set { birth = new DateTime(1970, 01, 01);} }
        public virtual new string ToString()
        {
            string str;
            str = "";
            str += name + " ";
            str += secondName + " ";
            str += birth.ToString();
            return str;
        }
        public virtual string ToShortString()
        {
            string str;
            str = "";
            str += name + " ";
            str += secondName + " ";
            return str;
        }
        public override bool Equals(object obj)
        {
            Person person2 = new Person();
            person2 = (Person)obj;
            bool fl = false;
            if (name == person2.name && secondName == person2.secondName && birth == person2.birth)
                fl = true;
            return fl;
        }
        public static bool operator ==(Person person2, Person person1)
            {
                bool fl = false;
                if (person1.name == person2.name && 
                person1.secondName == person2.secondName && 
                person1.birth == person2.birth)
                fl = true;
            return fl;
            }
        public static bool operator != (Person person2, Person person1)
        {
            bool fl = true;
            if (person1.name == person2.name &&
                person1.secondName == person2.secondName &&
                person1.birth == person2.birth)
                fl = false;
                return fl;
        }
        public override int  GetHashCode()
        {
            int commonHashCode = 0;
            int temp = name.GetHashCode();
            commonHashCode += temp;
            temp = secondName.GetHashCode();
            commonHashCode += temp;
            temp = birth.GetHashCode();
            commonHashCode += temp;
            return commonHashCode;
        }
        public virtual object DeepCopy()
        {
            Person person2 = new Person();
            person2.name = name;
            person2.secondName = secondName;
            person2.birth = birth;
            return person2;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public string getSecondName()
        {
            return secondName;
        }
        public void setSecondName(string secondName)
        {
            this.secondName = secondName;
        }
        
    }
    class Test
    {
        string name;
        bool testState;
        public Test(string name, bool testState)
        {
            this.name = name;
            this.testState = testState;
        }
        public Test()
        {
            name = "";
            testState = false;
        }
        public override string ToString()
        {
            string result = "";
            result += name + ' ';
            if (testState)
            {
                result += " Сдано /n";
            }
            else
            {
                result += " Не сдано /n";
            }
            return result;
        }

    }
    class Exam : IDateAndCopy
    {
        string examName;
        int examMark;
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
        public DateTime Date { get { return examDate; } set { examDate = new DateTime(1970, 01, 01); } }
        public object DeepCopy()
        {
            Exam exam2 = new Exam();
            exam2.examName = examName;
            exam2.examMark = examMark;
            exam2.examDate = examDate;
            return exam2;
        }

    }
    class Student : Person
    {
        
        Education education;
        int group;
        ArrayList offsets = new ArrayList();
        ArrayList exams = new ArrayList();
        int capacity = 0;
        char key_for_stop_adding;
        //List<Exam> exams = new List<Exam>();
        public Student(Person person, Education education, int group)
        {
            name = person.getName();
            secondName = person.getSecondName();
            birth = person.Date;
            this.education = education;
            try
            {
                if (group < 100 || group > 600)
                    throw new Exception("Введенное число не корректно с лимитом группы");
                this.group = group;
             }
            catch(Exception) 
            {
                this.group = 101;
            }
        }
        public Student()
        {
            Person person = new Person();
            name = person.getName();
            secondName = person.getSecondName();
            birth = person.Date;
            education = Education.none;
            group = 101;
        }
        public Person GetPerson()
        {
            Person p1 = new Person();
            p1.setName(name);
            p1.setSecondName(secondName);
            p1.Date = birth;
            return p1;
        }
        public Education GetEducation()
        {
            return education;
        }
        public int GetGroup()
        {
            return group;
        }
        public ArrayList GetExam()
        {
            return exams;
        }
        public void SetPerson(Person person)
        {

            name = person.getName();
            secondName = person.getSecondName();
            birth = person.Date;
        }
        public void SetEducation(Education education)
        {
            this.education = education;

        }
        public void SetGroup(int group)
        {
            this.group = group;
        }
        public void AddOffsets()
        {
            do
            {
                bool state = false;
                key_for_stop_adding = 't';
                Console.Write("Enter the name of offset: ");
                string tempname = Console.ReadLine();
                Console.Write("\nEnter state (1 passed, 0 unpassed): ");
                char tempstate = Char.Parse(Console.ReadLine());
                if (tempstate == '1')
                    state = true;
                else
                    state = false;
                //b tempmark = Convert.ToInt32(Console.ReadLine());
                Test offset = new Test(tempname, state);
                offsets.Add(offset);
                Console.WriteLine("\n if you want to stop addint press n, else press any key");
                key_for_stop_adding = char.Parse(Console.ReadLine());   
            } while (key_for_stop_adding != 'n');
        }
     
        public void AddExam()
        {
            Console.WriteLine("Enter the list of Exams\n");
            do
            {
                
                Console.Write("Enter the name of exam: ");
                string tempname = Console.ReadLine();
                Console.Write("\nEnter the mark of exam: ");
                int tempmark = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nEnter the date of exam (format //year//mount//day): ");
                DateTime tempDate = new DateTime(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
                Console.WriteLine("\n if you want to stop addint press n, else press any key");
                Exam temp = new Exam(tempname,tempmark,tempDate);
                exams.Add(temp);
                key_for_stop_adding = char.Parse(Console.ReadLine());
            } while (key_for_stop_adding != 'n');
            //this.exams.AddRange(exams);
        }
        public double GetTotalMark(ArrayList exams)
        {
            Exam temp = new Exam();
            double totalMark = 0;
            int quantity = 1;
            foreach(object o in exams)
            {
                temp = (Exam)o;
                totalMark += temp.getExamMark();
                quantity++;
            }
            if (quantity != 0)
                totalMark = totalMark / (quantity - 1);
            return totalMark;
        }
        public bool GetIndex(int index)
        {
            if (index == (int)education)
                return true;
            return false;
        }
        public void SetExam(ArrayList exam)
        {
            exams = exam;
        }
        public new string ToString()
        {
            Exam temp1 = new Exam();
            string result = " ФИО: ";
            string temp = " ";
            result += name.ToString() + "  " + secondName.ToString() + " " + Date.ToString() + " Образование ";
            result += education + " Группа  ";
            result += group.ToString() + " \n Список Экзаменов \n";
            foreach (object i in exams)
            {
                temp1 = (Exam)i;
                temp += temp1.ToString() + '\n';
            }
            result += temp;
            temp = " ";
            Test test = new Test();
            foreach(object i in offsets)
            {
                test = (Test)i;
                temp += test.ToString() + '\n';
            }
            result += temp;
            return result;
        }
        public new string ToShortString()
        {
            string result = "ФИО: ";
            result += name.ToString() + "  " + secondName.ToString() + " " + Date.ToString() + " Образование: ";
            result += education + " Группа:";
            result += group.ToString() + " Средний балл:";
            result += GetTotalMark(exams).ToString();
            return result;
        }
        public override  object DeepCopy()
        {
            Student a = new Student();
            a.setName(name);
            a.setSecondName(secondName);
            a.birth = birth;
            a.education = education;
            a.group = group;
            a.offsets = offsets;
            a.exams = exams;
            return a;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (object o in offsets)
            {
                yield return o;  
            }
            foreach (object o in exams)
            {
                yield return o;
            }
            //if (capacity !=1)
            //{
            //    object o = offsets;
            //    yield return o;
            //}
            //else
            //{
            //    object o = exams;
            //    yield return o;
            //}
            //if (offsets.Capacity != capacity)
            //{
            //    foreach (object o in offsets)
            //    {
            //        yield return o;
            //    }
            //}
            //else
            //{
            //    foreach (object o in exams)
            //    {
            //        yield return o;
            //    }
            //}
            //capacity = 1;
        }
        public IEnumerable GetEnumarator(int MarkBorder)
        {
            foreach(Exam current in exams)
            {
                int temp = current.getExamMark();
                if(MarkBorder < temp)
                    {
                    yield return current;
                    }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Person a = new Person("Umar", "Sharifor", new DateTime(1999, 06, 23));
            Person b = new Person("Umar", "Sharifor", new DateTime(1999, 06, 23));
            Console.WriteLine(" Object A: " + a.ToString() + " \n Object B: " + b.ToString());
            Console.WriteLine("\n We will change Object B.name will be SomeName and after show \n");
            b.setName("SomeName");
            Console.WriteLine(" Object A: " + a.ToString() + " \n Object B: " + b.ToString());
            Console.WriteLine("\n How we saw, the links of object is not same, we will go back and change\n" +
                "b.name to Umar and chack the values of objects A and B \n");
            b.setName("Umar");
            if (a == b)
                Console.WriteLine("the values of objects is equal\n");
            else
                Console.WriteLine("the values of objects is not equal\n");
            Console.WriteLine("Hash Code of object A " + a.GetHashCode());
            Console.WriteLine("Hash Code of object B " + b.GetHashCode());
            Student stud1 = new Student(new Person("Umar", "Sharifor", new DateTime(1999, 06, 23)), Education.Bachelor, 762);
            stud1.AddExam();
            stud1.AddOffsets();
            Console.WriteLine(stud1.ToString());
            Person studperson = stud1.GetPerson();
            Console.WriteLine(studperson.ToString());
            Student stud2 = new Student();
            object stud3 = stud1.DeepCopy();
            stud2 = (Student)stud3;
            Console.WriteLine(" first student" + stud1.ToString());
            Console.WriteLine(" second student" + stud3.ToString());
            Console.WriteLine("first and second student ofter changes\n");
            stud1.setName("Karim");
            Console.WriteLine("We changed the name of first student and show both students\n");
            Console.WriteLine(" first student" + stud1.ToString());
            Console.WriteLine(" second student" + stud3.ToString());
            Console.WriteLine("Спикос экзаменов и зачетов");
            foreach (object t in stud1)
            {
                if (t is Exam)
                {
                    Exam temp = (Exam)t;
                    Console.WriteLine(temp.ToString());
                }
                else
                {
                    Test temp = (Test)t;
                    Console.WriteLine(temp.ToString());
                }
            }
            Console.WriteLine("Список экзаменов у который оценка больше 3");
            foreach (object t in stud1.GetEnumarator(3))
            {
                Exam temp = (Exam)t;
                Console.WriteLine(temp.ToString());
            }

            Console.ReadLine();
        }
    }
}
