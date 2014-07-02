using System;

namespace Wrox.ProCSharp.Generics
{
    class Program
    {
        static void Main()
        {
       
            //协变，子类传递给父类，存在安全的隐式转换
            //逆变，父类传递给子类
            //一个可变性和子类到父类转换的方向一样，就称作协变；而如果和子类到父类的转换方向相反，就叫抗变！
            IIndex<Rectangle> rectangles = RectangleCollection.GetRectangles();
            //协变,把Rectangle assign to Shape
            IIndex<Shape> shapes = rectangles;

            for (int i = 0; i < shapes.Count; i++)
            {
                Console.WriteLine(shapes[i]);
            }


            IDisplay<Shape> shapeDisplay = new ShapeDisplay();
            shapeDisplay.Show(rectangles[0]);
            IDisplay<Rectangle> rectangleDisplay = shapeDisplay;
            rectangleDisplay.Show(rectangles[0]);
            

            Console.ReadLine();
            

        }

    }
}
