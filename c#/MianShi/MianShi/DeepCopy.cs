using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MianShi
{
    class DeepCopy
    {
        public void Run()
        {
       
            Student s1 = new Student("Vivi", 28);
            Console.WriteLine("s1=[" + s1 + "]");
           Student s2 = (Student)s1.ShallowCopy();
            //Student s2 = (Student)s1.DeepCopy(); 
            Console.WriteLine("s2=[" + s2 + "]"); //此处s2和s1内容相同 
            Console.WriteLine("-----------------------------");
            //修改s2的内容 
            s2.Name = "tianyue";
            s2.Age = 25;
            s2.Room.RoomID = 2;
            s2.Room.RoomName = "Room2";
            Console.WriteLine("s1=[" + s1 + "]");
            Console.WriteLine("s2=[" + s2 + "]");
            //浅拷贝时两个对象并未完全“分离”，改变顶级对象的内容，不会对另一个对象产生影响，
            //但改变子对象的内容，则两个对象同时被改变。

            //深拷贝时两个对象是完全“分离”的，改变其中一个，不会影响到另一个对象；
            //这种差异的产生，即是取决于拷贝子对象时复制内存还是复制指针。深拷贝为子对象重新分配了一段内存空间，并复制其中的内容；
            //浅拷贝仅仅将指针指向原来的子对象。

            Person person = new Person();
            person.Name = new Name("deng", "li");
            person.Age = 123;
            person.Address = "ChengDu";

            //Person p2 =(Person)person.Clone();
            Person p2 = person.Clone(true);
            p2.Age = 100;
            p2.Name = new Name("Zhang", "San");
            p2.Address = "SG";

            //再次打印两个对象以比较 
            //Console.ReadLine();
        }
    }
    /// <summary>
    /// 深拷贝接口
    /// </summary>
    interface IDeepCopy
    {
        object DeepCopy();
    }

    /// <summary>
    /// 浅拷贝接口
    /// </summary>
    interface IShallowCopy
    {
        object ShallowCopy();
    }
    /// <summary>
    /// 教室信息
    /// </summary>
    class ClassRoom : IDeepCopy, IShallowCopy
    {
        public int RoomID = 1;
        public string RoomName = "Room1";

        public override string ToString()
        {
            return "RoomID=" + RoomID + "\tRoomName=" + RoomName;
        }
        public object DeepCopy()
        {
            ClassRoom r = new ClassRoom();
            r.RoomID = this.RoomID;
            r.RoomName = this.RoomName;
            return r;
        }
        public object ShallowCopy()
        {
            //直接使用内置的浅拷贝方法返回
            return this.MemberwiseClone();
        }
    }
    class Student : IDeepCopy, IShallowCopy
    {
        //为了简化，使用public 字段
        public string Name;
        public int Age;
        //自定义类型，假设每个Student只拥有一个ClassRoom
        public ClassRoom Room = new ClassRoom();

        public Student()
        {
        }
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public object DeepCopy()
        {
            Student s = new Student();
            s.Name = this.Name;
            s.Age = this.Age;
            s.Room = (ClassRoom)this.Room.DeepCopy();
            return s;
        }
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return "Name:" + Name + "\tAge:" + Age + "\t" + Room.ToString();
        }
    }
    [Serializable]
    public class Person : ICloneable
    {
        public int Age { get; set; }
        public string Address { get; set; }
        public Name Name { get; set; }
        public object Clone()
        {
            Person tem = new Person();
            tem.Address = this.Address;
            tem.Age = this.Age;
            tem.Name = new Name(this.Name.FristName, this.Name.LastName);
            return tem;
        }

        public Person Clone(bool isDeepCopy)
        {
            Person footman;
            if (isDeepCopy)
            {
                //序列化是将对象或对象图形转换为线性字节序列，以存储或传输到另一个位置的过程。
　　            //反序列化是接受存储的信息并利用它重新创建对象的过程。
                //　注意：通过序列化和反序列化实现深拷贝，其和其字段类型必须标记为可序列化类型，既添加特性(Attribute)[Serializable]。
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(memoryStream, this);
                    memoryStream.Position = 0;
                    footman = (Person)formatter.Deserialize(memoryStream);
                    memoryStream.Close();
                }
            }
            else
                footman = (Person)this.MemberwiseClone();
            return footman;
        }
    }
     [Serializable]
    public class Name
    {
        public Name(string frisName, string lastName)
        {
            FristName = frisName;
            LastName = lastName;
        }
        public string FristName { get; set; }
        public string LastName { get; set; }
    }
}
