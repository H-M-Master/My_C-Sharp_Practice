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
    public static void PracticeWrite()//C#入门，第一部分，第一、二单元
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

    /*
    \r 表示回车，从最老的打字机引入的概念，表示回到本行的开始位置
    \n 换行，同样来自打印技术的术语，表示跳转到下一行。
    \r\n 连用，表示跳到下一行，并且返回到下一行的起始位置
    \t 一个占位符(tab键)，表式空格，对齐
    \b 使控制台的光标回退一格
    @ 消除转义字符作用
    */
    public static void Concatenation()//C#入门，第一部分，第三单元
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


    public static void ExecuteNumericalValue()//C#入门，第一部分，第四单元
    {
        int num1 = 12;
        int num2 = 7;
        string firstName = "Bob";
        Console.WriteLine($"num1 + num2 = {num1 + num2}");
        Console.WriteLine($"{firstName} sold {num1 + 7} widgets.");
        Console.WriteLine(firstName + " sold " + (num1 + 7) + " widgets.");
        
        //加减乘除
        int sum = 7 + 5;
        int difference = 7 - 5;
        int product = 7 * 5;
        int quotient = 7 / 5;
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {difference}");
        Console.WriteLine($"Product: {product}");
        Console.WriteLine($"Quotient: {quotient}");
        
        //使用文本小数数据添加代码以执行除法
        decimal decimalQuotient = 7.0m / 5;//为了使其正常运作，商（赋值运算符的左边）必须为 decimal 类型，且至少有一个被除数也必须为 类型（两者都可为 decimal 类型）decimal。
        //decimal decimalQuotient = 7 / 5.0m;此两种示例同样适用（等号左边不可以是int）
        //decimal decimalQuotient = 7.0m / 5.0m;
        //decimal decimalQuotientD = 7 / 5;此示例不适用
        Console.WriteLine($"Decimal quotient: {decimalQuotient}");
       
        //需要将类型 int 的两个变量相除，但不希望结果被截断，该怎么办？ 将 int 强制转换为 decimal，在值之前添加强制转换运算符
        int first = 7;
        int second = 5;
        decimal quotient2 = (decimal)first / (decimal)second;
        Console.WriteLine($"int 强制转换为 decimal 版 Decimal quotient: {quotient2}");
       
        //求余数
        int remainder = 7 % 5;
        Console.WriteLine($"7 / 5 remainder: {remainder}");
        Console.WriteLine();
        
        //C# 遵循与 PEMDAS 相同的顺序，但指数除外
        int value1 = 3 + 4 * 5;
        int value2 = (3 + 4 ) * 5;
        Console.WriteLine($"Without parentheses: {value1}");
        Console.WriteLine($"With parentheses: {value2}");  
        int value = 0;//now value is 0
        Console.WriteLine($"Initial value: {value}");
        value = value + 5;//now value is 5
        Console.WriteLine($"After value = value + 5: {value}");
        value += 5;//now value is 10 (加法赋值运算符)
        Console.WriteLine($"After value += 5: {value}");
        value ++;//now value is 11 （自增运算符）
        Console.WriteLine($"After value ++: {value}");
        value --;//now value is 10
        Console.WriteLine($"After value --: {value}");
        value -= 3;//now value is 7
        Console.WriteLine($"After value -= 3: {value}");
        value = value - 2;//now value is 5
        Console.WriteLine($"After value = value - 2: {value}");
        Console.WriteLine();
        
        //在 ++value 中一样在值之前使用运算符，则递增会在检索值之前出现
        int value3 = 1;
        value++;
        Console.WriteLine("First: " + value3);
        Console.WriteLine("Second: " + value3++);//先输出后递增
        Console.WriteLine("Third: " + value3);
        Console.WriteLine("Fourth: " + ++value3);//先递增后输出

        //代码挑战
        int fahrenheit = 94;
        decimal celsius = ((decimal)fahrenheit - 32) * 5 / 9; //celsius = (fahrenheit - 32m) * (5m / 9m)
        Console.WriteLine($"The temperature is {celsius} Celsius.");
    }

    /*
    项目概述
    你正在开发 Student Grading 应用程序，该应用程序可自动计算班级中每名学生的当前成绩。 应用程序的参数包括：
    你将获得一个包含四名学生及其五次作业成绩的简短列表。
    每个作业成绩都表示为一个整数值 (0 - 100)，其中 100 表示 100% 正确。
    总分按五次作业分数的平均分计算。
    应用程序需要执行基本的数学运算来计算每个学生的总分。
    应用程序需要输出/显示每名学生的姓名和总分。
    */
    public static void StudentGrading() //C#入门，第一部分，第五单元，计算和打印学生的成绩
    {
        // initialize variables - graded assignments 
        int currentAssignments = 5;

        int sophia1 = 93;
        int sophia2 = 87;
        int sophia3 = 98;
        int sophia4 = 95;
        int sophia5 = 100;

        int nicolas1 = 80;
        int nicolas2 = 83;
        int nicolas3 = 82;
        int nicolas4 = 88;
        int nicolas5 = 85;

        int zahirah1 = 84;
        int zahirah2 = 96;
        int zahirah3 = 73;
        int zahirah4 = 85;
        int zahirah5 = 79;

        int jeong1 = 90;
        int jeong2 = 92;
        int jeong3 = 98;
        int jeong4 = 100;
        int jeong5 = 97;

        int sophiaSum = sophia1 + sophia2 + sophia3 + sophia4 + sophia5;
        int nicolasSum = nicolas1 + nicolas2 + nicolas3 + nicolas4 + nicolas5;
        int zahirahSum = zahirah1 + zahirah2 + zahirah3 + zahirah4 + zahirah5;
        int jeongSum = jeong1 + jeong2 + jeong3 + jeong4 + jeong5;
        Console.WriteLine($"Sophia: {sophiaSum}");
        Console.WriteLine($"Nicolas: {nicolasSum}");
        Console.WriteLine($"Zahirah: {zahirahSum}");
        Console.WriteLine($"Jeong: {jeongSum}");
        Console.WriteLine();

        decimal sophiaScore = (decimal)sophiaSum / currentAssignments;
        decimal nicolasScore = (decimal)nicolasSum / currentAssignments;
        decimal zahirahScore =  (decimal)zahirahSum / currentAssignments;
        decimal jeongScore = (decimal)jeongSum / currentAssignments;
        Console.Write($"Student\tGrade\n ");
        Console.WriteLine($"Sophia\t{sophiaScore}\tA");
        Console.WriteLine($"Nicolas\t{nicolasScore}\tB");
        Console.WriteLine($"Zahirah\t{zahirahScore}\tB");
        Console.WriteLine($"Jeong\t{jeongScore}\tA");

    }
}