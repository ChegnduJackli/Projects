namespace Wrox.ProCSharp.Generics
{
    // covariant
    //泛型接口
    //在接口中的方法带泛型参数  
    //使用Out标注，表示该接口是协变的（子类可以传递给父类），不标注，是不变的
    //使用In标注，表示是抗变的，这样，接口只能把泛型类型T用作方法的输入
    public interface IIndex<out T>
    {
        T this[int index] { get; }
        int Count { get; }
    }


}
