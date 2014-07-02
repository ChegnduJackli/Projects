namespace Wrox.ProCSharp.Generics
{
    // contra-variant
    //泛型接口
    //在接口中的方法带泛型参数  
    //使用Out标注，表示该接口是协变的（子类可以传递给父类），不标注，是不变的
    //协变，表示返回类型只能是T
    //使用In标注，表示是抗变的，这样，接口只能把泛型类型T用作其他方法的输入
    public interface IDisplay<in T>
    {
        void Show(T item);
    }
}
