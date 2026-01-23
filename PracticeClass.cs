/*
笔记：C# 中常见关键字说明
- public：访问修饰符，外部也能调用这个类/方法。
- private：只有类内部能用（默认更安全）。
- static：属于“类本身”，不需要 new 对象就能调用。
- void：方法没有返回值；有返回值就用具体类型，比如 int、string。
什么时候用：
- 入口方法 Main 必须是 static。
- 只是工具方法、不需要保存状态时，用 static。
- 需要保存数据（有字段）时，用普通类，再 new。
- 不想被外部调用就用 private，需要被外部调用就用 public。
补充：
- protected：子类可以访问。
- internal：同一项目（程序集）内可访问。
- const：编译期常量，必须立刻赋值且不可改。
- readonly：运行时只读字段，只能在声明或构造函数里赋值。
- return：返回一个值（或提前结束方法）。
- 值类型/引用类型：值类型复制值，引用类型复制引用（指向同一对象）。
- new：创建对象并调用构造函数。
- 构造函数：和类同名，用来初始化对象。
- namespace：命名空间，用来组织/避免重名。
- using：引入命名空间，或用于资源释放（using 语句）。
*/
public static class PracticeClass
{
    public static void PracticeWrite()
    {
        //* *//
        string firstName;
        firstName = "Bob";
        int num = 3;
        double num2 = 34.4;
        //两种不同的字符串插值方式，Console是类名，WriteLine是方法名
        Console.WriteLine("两种不同的字符串插值方式(Console是类名 WriteLine是方法名):");
        Console.WriteLine("Hello, " + firstName + "! You have " + num + " messages in your inbox. The temperature is " + num2 + " celsius.");
        Console.WriteLine($"Hello, {firstName}! You have {num} messages in your inbox. The temperature is {num2} celsius.");
        Console.WriteLine(firstName);
    }
}