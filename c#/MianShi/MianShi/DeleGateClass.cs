using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MianShi
{
    public class DeleGateClass
    {
        public delegate void CheckDelegate(int number);//定义了一个委托CheckDelegate,它可以注册返回void类型且有一个int作为参数的函数

        public void Run()
        {
            //用函数CheckMod实例化上面的CheckDelegate 委托为deleGate
           // CheckDelegate deleGate = new CheckDelegate(CheckMod);
            CheckDelegate deleGate = CheckMod;//用函数CheckMod实例化上面的CheckDelegate 委托为deleGate
            deleGate(123);

            //泛型委托
            A<int, int> a = test;//将泛型委托委托<T1,T2>实例化为<int,int>，即表示有一个int类型参数且返回类型是int的函数，所以将test用来实例化委托
            Console.WriteLine(a(5));//输出5

            DelegateContainer delCon = new DelegateContainer();//构造类DelegateContainer的对象delCon
            MethodDemo metDemo = new MethodDemo();//构造类MethodDemo的对象metDemo
           ;
            delCon.delMethod += metDemo.DisplayMethod;//将函数DisplayMethod注册到委托实例delMethod，让其作为delMethod的委托函数

            delCon.delMethod();
            //调用委托实例delMethod的时候，就会调用在它上注册的委托函数DisplayMethod，那么在执行委托函数DisplayMethod时，其内部代码中的this，到底指的是
            //委托实例delMethod的调用对象delCon呢，还是委托函数DisplayMethod的调用对象metDemo呢？
            //我可以看到这里输出的结果是"Varible i is : 200",说明DisplayMethod内部的this指的是委托函数DisplayMethod本身的调用对象metDemo。这里大家很容易搞混淆，由于我们上面是通过
            //调用委托实例delCon.delMethod来调用委托函数metDemo.DisplayMethod的，看到delCon.delMethod()时大家潜意识可能就会认为由于调用委托实例delMethod的对象是delCon，就认为
            //调用委托实例delMethod上注册函数DisplayMethod的对象也是delCon，其实这是错误的。大家一定要记住委托实例只是一个壳子，它只是用来代表在其上注册的函数，但它并不会改变注册函数
            //的环境变量（比如函数的调用对象等），由于我们上面将委托函数DisplayMethod注册到委托实例delMethod时，使用的是delCon.delMethod += metDemo.DisplayMethod，所以函数的调用
            //对象始终都是等号右边的对象metDemo，而不会是左边的对象delCon，而调用等号左边的委托实例delCon.delMethod()时，相当于就是在执行等号右边的metDemo.DisplayMethod()，
            //所以委托函数DisplayMethod的调用对象始终是metDemo。

            //由此请大家一定要记住，调用委托实例的对象和调用委托函数的对象没有丝毫关系，要看委托函数是谁调用的，还得要看函数注册到委托实例时，等号右边注册函数前的调用对象是谁。
        }

      

        public void CheckMod(int number)
        {
            Console.WriteLine("CheckMod Method: " + number);
        }

        delegate T2 A<T1, T2>(T1 t);//定义有两个泛型（T1,T2）的委托，T2作为委托函数返回类型，T1作为委托函数参数类型

        static int test(int t)
        {
            return t;
        }
    }

    class DelegateContainer
    {
        public delegate void DelMethod();//定义一个无参数且无返回值的委托类型DelMethod

        public DelMethod delMethod;//定义委托类型DelMethod的委托实例delMethod

        public int i = 100;//定义一个int类型的变量i在类DelegateContainer之中，赋值100
    }

    //MethodDemo是定义委托函数DisplayMethod的类
    class MethodDemo
    {
        protected int i = 200;//定义一个int类型的变量i在类MethodDemo之中，赋值200

        //定义委托函数DisplayMethod
        public void DisplayMethod()
        {
            Console.WriteLine("Varible i is : " + this.i.ToString());//显示变量i的值，通过这里的值就可以知道委托函数DisplayMethod的调用对象是谁
        }
    }

}
