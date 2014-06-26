using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//扩展方法
//扩展方法在静态类中声明，定义一个静态方法，其中第一个参数定义了扩展的类型，this 是为了区别一般静态方法
namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Good job";
            s1.Foo();
            //下面这种调用方式是一样的。
            StringExtension.Foo(s1);
            string name = "Jack";
            string lady = "Rose";
            name.SayHello("like");
            lady.SayHello("love");

            StudentList studentSource = new StudentList();
            IEnumerable<Student> stu = studentSource.GetStudentByCity("beijing");
            foreach (var s in stu)
            {
                Console.WriteLine(string.Format("name:{0}  age:{1}  city:{2}", s.Name, s.Age, s.City));
            }
            Console.ReadKey();
        }
    }
    public static class StringExtension
    {
        public static void Foo(this string s)
        {
            Console.WriteLine("Foo invoked for {0}", s);
        }
        public static void SayHello(this string name, string content)
        {
            Console.WriteLine("Hello:{0} content: {1}", name, content);
        }
    }
    //学生类
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
    //集合类
    public class StudentList : List<Student>
    {
        public StudentList()
        {
            this.Add(new Student() { Name = "zhangsan", Age = 22, City = "beijing" });
            this.Add(new Student() { Name = "lisi", Age = 23, City = "beijing" });
            this.Add(new Student() { Name = "wagnwu", Age = 24, City = "nanjing" });
            this.Add(new Student() { Name = "Heer", Age = 25, City = "dongjing" });
        }
    }
    //扩展方法
    public static class StuListExtension
    {
        public static IEnumerable<Student> GetStudentByCity(this List<Student> stuList, string city)
        {
            //where 也是扩展方法
            var result = stuList.Where(s => s.City == city).Select(s => s);
            var res = from r in stuList
                      where r.City == city
                      select r;
            return res;
        }
    }
}
