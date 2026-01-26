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
        string firstName;
        firstName = "Bob";
        int num = 3;
        double num2 = 34.4;
        //两种不同的字符串插值方式，Console是类名，WriteLine是方法名
        Console.WriteLine("两种不同的字符串插值方式(Console是类名 WriteLine是方法名):");
        Console.WriteLine("Hello, " + firstName + "! You have " + num + " messages in your inbox. The temperature is " + num2 + " celsius.");
        Console.WriteLine($"Hello, {firstName}! You have {num} messages in your inbox. The temperature is {num2} celsius.");//字符串内插
        Console.WriteLine(firstName);
    }

    public static void Concatenation()//C#入门，第一部分，第五单元
    {
        string firstName = "Bob";
        string greeting = "Hello";
        string message = greeting + " " + firstName + "! ";//中间变量
        message = $"Hello {firstName}!";//字符串内插
        Console.WriteLine(message);
        //写代码时应该尽量避免中间变量，正确输出为：
        Console.WriteLine(greeting + " " + firstName + "! " + "(避免中间变量版输出)");
        Console.WriteLine($"{greeting}! {firstName}! (无中间变量且字符串内插)");
        //在下方示例中，$ 符号允许引用括号内的 projectName 变量，而 @ 符号允许使用未转义的 \ 字符。@为逐字文本前缀符号。
        string projectName = "First-Project";
        Console.WriteLine($@"C:\Output\{projectName}\Data");
        Console.WriteLine();
        //代码挑战：
        string projectName2 = "ACME";
        string russianMessage = "\u041f\u043e\u0441\u043c\u043e\u0442\u0440\u0435\u0442\u044c \u0440\u0443\u0441\u0441\u043a\u0438\u0439 \u0432\u044b\u0432\u043e\u0434";//Unicode 编码表示“查看俄语输出”
        Console.WriteLine($@"View English output: c:\Exercise\{projectName2}\data.txt");
        Console.WriteLine($@"{russianMessage}: c:\Exercise\{projectName2}\ru-RU\data.txt");
        //代码挑战修正：
        string englishLocation = $@"c:\Exercise\{projectName2}\data.txt";
        Console.WriteLine($"View English output:\n\t{englishLocation}\n");// \n换行，\t制表符
        string russianLocation = $@"c:\Exercise\{projectName2}\ru-RU\data.txt";
        Console.WriteLine($"{russianMessage}:\n\t{russianLocation}\n");
    }
    public static void UnusedMethod()//C#入门，第一部分，第六单元
    {
        // 这个方法目前没有被调用
    }

}