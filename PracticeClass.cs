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
using System.Diagnostics;
using System.Security.Cryptography;

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
        int value2 = (3 + 4) * 5;
        Console.WriteLine($"Without parentheses: {value1}");
        Console.WriteLine($"With parentheses: {value2}");
        int value = 0;//now value is 0
        Console.WriteLine($"Initial value: {value}");
        value = value + 5;//now value is 5
        Console.WriteLine($"After value = value + 5: {value}");
        value += 5;//now value is 10 (加法赋值运算符)
        Console.WriteLine($"After value += 5: {value}");
        value++;//now value is 11 （自增运算符）
        Console.WriteLine($"After value ++: {value}");
        value--;//now value is 10
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
        decimal zahirahScore = (decimal)zahirahSum / currentAssignments;
        decimal jeongScore = (decimal)jeongSum / currentAssignments;
        Console.Write($"Student\tGrade\n ");
        Console.WriteLine($"Sophia\t{sophiaScore}\tA");
        Console.WriteLine($"Nicolas\t{nicolasScore}\tB");
        Console.WriteLine($"Zahirah\t{zahirahScore}\tB");
        Console.WriteLine($"Jeong\t{jeongScore}\tA");
    }

    /*
    项目概述
    你正在开发一个学生 GPA 计算器，以帮助计算学生的整体成绩点平均值。 应用程序的参数包括：
    你获得学生的姓名和课堂信息。
    每个班级都有一个名称、学生的年级和该班级的信用小时数。
    应用程序需要执行基本的数学运算来计算给定学生的 GPA。
    应用程序需要输出/显示学生的姓名、课堂信息和 GPA。
    
    计算 GPA：
    将课程的成绩值乘以该课程的信用小时数。
    针对每个课程执行此作，然后将这些结果添加到一起。
    将所得的总和除以全部的学分数。
    */
    public static void StudentGPACaculator()
    {
        string studentName = "Sophia Johnson";
        string course1Name = "English 101";
        string course2Name = "Algebra 101";
        string course3Name = "Biology 101";
        string course4Name = "Computer Science I";
        string course5Name = "Psychology 101";

        int course1Credit = 3;
        int course2Credit = 3;
        int course3Credit = 4;
        int course4Credit = 4;
        int course5Credit = 3;

        int gradeA = 4;
        int gradeB = 3;

        int course1Grade = gradeA;
        int course2Grade = gradeB;
        int course3Grade = gradeB;
        int course4Grade = gradeB;
        int course5Grade = gradeA;
        Console.WriteLine($"{course1Name} {course1Grade} {course1Credit}");
        Console.WriteLine($"{course2Name} {course2Grade} {course2Credit}");
        Console.WriteLine($"{course3Name} {course3Grade} {course3Credit}");
        Console.WriteLine($"{course4Name} {course4Grade} {course4Credit}");
        Console.WriteLine($"{course5Name} {course5Grade} {course5Credit}");

        int totalCreditHours = 0;
        totalCreditHours += course1Credit;
        totalCreditHours += course2Credit;
        totalCreditHours += course3Credit;
        totalCreditHours += course4Credit;
        totalCreditHours += course5Credit;

        int totalGradePoints = 0;
        totalGradePoints += course1Credit * course1Grade;
        totalGradePoints += course2Credit * course2Grade;
        totalGradePoints += course3Credit * course3Grade;
        totalGradePoints += course4Credit * course4Grade;
        totalGradePoints += course5Credit * course5Grade;

        decimal gradePointAverage = (decimal)totalGradePoints / totalCreditHours;
        int leadingDigit = (int)gradePointAverage;
        int firstDigit = (int)(gradePointAverage * 10) % 10;//在此操作的上半部分，将小数点向右移动一位，并将其转换为整数。 在后半部分中，使用余数或取模运算符来获得除以 10 的余数，这将隔离整数中的最后一个数字。
        int secondDigit = (int)(gradePointAverage * 100) % 10;
        Console.WriteLine($"Final GPA: {leadingDigit}.{firstDigit}{secondDigit}");
        Console.WriteLine($"Student: {studentName}\n");
        Console.WriteLine("Course\t\t\tGrade\tCredit Hours");
        Console.WriteLine($"{course1Name}\t\t{course1Grade}\t\t{course1Credit}");
        Console.WriteLine($"{course2Name}\t\t{course2Grade}\t\t{course2Credit}");
        Console.WriteLine($"{course3Name}\t\t{course3Grade}\t\t{course3Credit}");
        Console.WriteLine($"{course4Name}\t{course4Grade}\t\t{course4Credit}");
        Console.WriteLine($"{course5Name}\t\t{course5Grade}\t\t{course5Credit}");

        Console.WriteLine($"Final GPA: {gradePointAverage}");

    }

    //C#入门，第二部分，第二单元
    public static void RandomDice()//无状态方法也称静态方法 -> 不引用或更改内存中存储的任何值的情况下正常工作
    {
        //类的实例称为 对象。 若要创建类的新实例，请使用 new 运算符。
        //new 运算符执行以下几项重要操作：
        //首先请求足够大的计算机内存地址，用于存储基于 Random 类的新对象。
        //创建新的对象，并将其存储在内存地址上。
        //它返回内存地址，以便它可以保存在 dice 对象中。
        Random dice = new Random();//这行代码创建Random类的新实例，以此创建名为 dice 的对象
        int roll = dice.Next(1, 7);//左闭右开区间, 有状态方法也称实例方法 -> 依赖于类的实例化对象来引用或更改内存中存储的值
        Console.WriteLine(roll);
        dice.Next(1, 7);//即使方法返回了值，也可以在不使用返回值的情况下调用该方法,但是，忽略返回值是毫无意义的。 调用 Next() 方法的原因是便于检索下一个随机值。

        Random dice2 = new();//使用最新版本的 .NET 运行时可以实例化对象，而无需重复类型名称（目标类型的构造函数调用）
        decimal randomValue = (decimal)dice2.Next(1, 100);//Next() Returns a random integer that is within a specified range.
        Console.WriteLine(randomValue);//so the decimal still output integer. e.g. 55

        //方法的重载:一个方法可以有多个版本，每个版本都有不同的参数列表。 这些不同版本的方法称为重载方法。
        //Next() 方法有多个重载版本。 例如，除了接受两个参数（表示范围的下限和上限）的版本外，还有一个不接受任何参数的版本以及一个只接受一个参数的版本。
        Random dice3 = new Random();
        int roll1 = dice3.Next();//不设置上下限
        int roll2 = dice3.Next(101);//设置上限
        int roll3 = dice3.Next(50, 101);//设置下限和上限
        Console.WriteLine($"First roll: {roll1}");
        Console.WriteLine($"Second roll: {roll2}");
        Console.WriteLine($"Third roll: {roll3}");
    }

    //Math类方法挑战
    //.	 成员访问运算符	 找到对象内部的成员	 myObject.DoSomething
    //() 方法调用运算符	 触发并执行该成员	 myObject.DoSomething()
    public static void MathClassChallenge()
    {
        int firstValue = 500;
        int secondValue = 600;
        int largerValue = Math.Max(firstValue, secondValue);
        Console.WriteLine(largerValue);
    }

    //C#入门，第二部分，第三单元
    public static void ifelseif()
    {
        Random dice1 = new Random();
        int roll1 = dice1.Next(1, 7);
        int roll2 = dice1.Next(1, 7);
        int roll3 = dice1.Next(1, 7);

        //下面是更加高级安全快速的.net 6.0 写法
        int roll4 = Random.Shared.Next(1, 7);//本质上是解决了种子重复问题的暗中进行的多次实例化
        int roll5 = Random.Shared.Next(1, 7);//内存复用：在同一个线程里，它复用同一个实例，不产生垃圾。
        int roll6 = Random.Shared.Next(1, 7);//无锁并发：多线程各走各的路，互不干扰，速度起飞。
        int total = roll4 + roll5 + roll6;
        Console.WriteLine($"Total:{roll4} + {roll5} + {roll6} = {total}");

        if ((roll4 == roll5) || (roll5 == roll6) || (roll4 == roll6))
        {
            if ((roll4 == roll5) && (roll5 == roll6))
            {
                total += 6;
                Console.WriteLine("Triple doubles! +6 bonus to total. Now total is " + total);
            }
            else
            {
                total += 2;
                Console.WriteLine("You rolled doubles! +2 bonus to total. Now total is " + total);
            }
        }


        if (total >= 16)
        {
            Console.WriteLine("You win a new car!");
        }
        else if (total >= 10)
        {
            Console.WriteLine("You win a new laptop!");
        }
        else if (total == 7)
        {
            Console.WriteLine("You win a trip for two to Hawaii!");
        }
        else
        {
            Console.WriteLine("You win a kitten!");
        }

        string message = " The quick brown fox jumps over the lazy dog.";
        bool result = message.Contains("dog");
        Console.WriteLine(result);
        if (message.Contains("fox"))
        {
            Console.WriteLine("What does the fox say?");
        }
    }

    //代码挑战
    public static void IncreasetSubscription()
    {
        int daysUntilExperation = Random.Shared.Next(12);//0-11
        int discountPercentage = 0;

        if (daysUntilExperation == 0)
        {
            Console.WriteLine("Your subscription has expired.");
        }
        else if (daysUntilExperation == 1)
        {
            discountPercentage = 20;
            Console.WriteLine($"Your subscription expires in {daysUntilExperation} day! Renew now and save {discountPercentage}%.");
        }
        else if (daysUntilExperation <= 5)
        {
            discountPercentage = 10;
            Console.WriteLine($"Your subscription expires in {daysUntilExperation} days! Renew now and save {discountPercentage}%.");
        }
        else if (daysUntilExperation <= 10)
        {
            discountPercentage = 5;
            Console.WriteLine($"Your subscription will expire soon! Renew now!");
        }
    }

    //C#入门，第二部分，第三单元
    public static void ArrayForeach()
    {
        string[] fraudukenOrderIDs = new string[3];//在计算机中创建可容纳3个字符串值数组的新实例
        //string[] fraudulentOrderIDs = [ "A123", "B456", "C789" ];
        fraudukenOrderIDs[0] = "A123";
        fraudukenOrderIDs[1] = "B456";
        fraudukenOrderIDs[2] = "C789";
        Console.WriteLine($"First: {fraudukenOrderIDs[0]}");
        Console.WriteLine($"Second: {fraudukenOrderIDs[1]}");
        Console.WriteLine($"Third: {fraudukenOrderIDs[2]}");

        fraudukenOrderIDs[0] = "F000";
        Console.WriteLine($"Reassigned First: {fraudukenOrderIDs[0]}");
        Console.WriteLine($"Length: {fraudukenOrderIDs.Length}");

        string[] names = ["Sophia", "Jackson", "Olivia", "Liam", "Ava", "Noah"];
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }

    //代码挑战
    public static void orderSurvey()
    {
        string[] OrderIDs = ["B123", "C234", "A345", "C15", "B177", "G3003", "C235", "B179"];
        foreach (string orderID in OrderIDs)
        {
            if (orderID.StartsWith("B"))
            {
                Console.WriteLine("Order IDs that require further investigation: " + orderID);
            }
        }
    }
    //C#入门，第二部分，第五单元
    //添加代码以说明 C# 编译器如何忽略空格
    public static void IgnoreSpaceBar()
    {
        //example 1
        Console
        .
        WriteLine
        (
            "Hello Example 1"
        )
        ;
        //example 2
        string firstWord = "Hello"; string lastWord = "Example 2"; Console.WriteLine(firstWord + " " + lastWord + "!");
    }

    //C#入门，第二部分，第六单元，引导式项目
    public static void StudentGrading2()//Basic on StudentGrading()
    {
        // initialize variables - graded assignments 
        int currentAssignments = 5;



        string[] StudentNames = ["Sophia", "Andrew", "Emma", "Logan"];

        int[] sophiaScores = [90, 86, 87, 98, 100, 94, 90];
        int[] andrewScores = [92, 89, 81, 96, 90, 89];
        int[] emmaScores = [90, 85, 87, 98, 68, 89, 89, 89];
        int[] loganScores = [90, 95, 87, 88, 96, 96];

        /*
        int[] sophiaScores = new int[] { 90, 86, 87, 98, 100 };
        int[] sophiaScores2 = { 90, 86, 87, 98, 100 };
        这两种写法没有任何区别，只是为了程序员少打几个字
        */

        Console.WriteLine("Student\t\tGrade\n");



        foreach (string name in StudentNames)
        {
            string currentLetterGrade;
            int Sum = 0;
            decimal FinalScore;
            int[] studentScores = new int[5];

            if (name == "Sophia")
            {
                studentScores = sophiaScores;
            }
            else if (name == "Andrew")
            {
                studentScores = andrewScores;
            }
            else if (name == "Emma")
            {
                studentScores = emmaScores;
            }
            else if (name == "Logan")
            {
                studentScores = loganScores;
            }

            int gradedAssignments = 0;
            foreach (int score in studentScores)
            {
                gradedAssignments++;
                if (gradedAssignments <= currentAssignments)
                {
                    Sum += score;
                }
                else
                {
                    Sum += score / 10;
                }

            }

            FinalScore = (decimal)Sum / currentAssignments;


            if (FinalScore <= 100 && FinalScore >= 97)
            {
                currentLetterGrade = "A+";
            }
            else if (FinalScore < 97 && FinalScore >= 93)
            {
                currentLetterGrade = "A";
            }
            else if (FinalScore < 93 && FinalScore >= 90)
            {
                currentLetterGrade = "A-";
            }
            else if (FinalScore < 90 && FinalScore >= 87)
            {
                currentLetterGrade = "B+";
            }
            else if (FinalScore < 87 && FinalScore >= 83)
            {
                currentLetterGrade = "B";
            }
            else if (FinalScore < 83 && FinalScore >= 80)
            {
                currentLetterGrade = "B-";
            }
            else
            {
                currentLetterGrade = "Below B-";
            }

            Console.WriteLine($"{name}\t\t{FinalScore}\t{currentLetterGrade}");
        }


    }

    //C#入门，第二部分，第七单元，挑战项目
    public static void Part2Challenge()
    {
        int examAssignments = 5;

        string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

        int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
        int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
        int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
        int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

        int[] studentScores = new int[10];

        string currentStudentLetterGrade = "";

        // display the header row for scores/grades
        Console.Clear();
        Console.WriteLine("Student\t\tExamScore\tOverall\tGrade\tExtra Credit\n");

        /*
        The outer foreach loop is used to:
        - iterate through student names 
        - assign a student's grades to the studentScores array
        - sum assignment scores (inner foreach loop)
        - calculate numeric and letter grade
        - write the score report information
        */
        foreach (string name in studentNames)
        {
            string currentStudent = name;

            if (currentStudent == "Sophia")
                studentScores = sophiaScores;

            else if (currentStudent == "Andrew")
                studentScores = andrewScores;

            else if (currentStudent == "Emma")
                studentScores = emmaScores;

            else if (currentStudent == "Logan")
                studentScores = loganScores;

            decimal sumAssignmentScores = 0;

            decimal currentStudentGrade = 0;

            int gradedAssignments = 0;

            decimal ExamScore = 0;

            int ExtraCredit = 0;

            int extraNum = 0;

            decimal pts = 0;


            /* 
            the inner foreach loop sums assignment scores
            extra credit assignments are worth 10% of an exam score
            */
            foreach (int score in studentScores)
            {
                gradedAssignments += 1;

                if (gradedAssignments <= examAssignments)
                {
                    sumAssignmentScores += score;
                    ExamScore += (score / 5m);
                }
                else
                {
                    sumAssignmentScores += (decimal)score / 10;
                    ExtraCredit += score;
                    extraNum++;
                }
            }

            currentStudentGrade = (decimal)(sumAssignmentScores) / examAssignments;
            ExtraCredit = ExtraCredit / extraNum;
            pts = (ExtraCredit / 10m) / examAssignments;

            if (currentStudentGrade >= 97)
                currentStudentLetterGrade = "A+";

            else if (currentStudentGrade >= 93)
                currentStudentLetterGrade = "A";

            else if (currentStudentGrade >= 90)
                currentStudentLetterGrade = "A-";

            else if (currentStudentGrade >= 87)
                currentStudentLetterGrade = "B+";

            else if (currentStudentGrade >= 83)
                currentStudentLetterGrade = "B";

            else if (currentStudentGrade >= 80)
                currentStudentLetterGrade = "B-";

            else if (currentStudentGrade >= 77)
                currentStudentLetterGrade = "C+";

            else if (currentStudentGrade >= 73)
                currentStudentLetterGrade = "C";

            else if (currentStudentGrade >= 70)
                currentStudentLetterGrade = "C-";

            else if (currentStudentGrade >= 67)
                currentStudentLetterGrade = "D+";

            else if (currentStudentGrade >= 63)
                currentStudentLetterGrade = "D";

            else if (currentStudentGrade >= 60)
                currentStudentLetterGrade = "D-";

            else
                currentStudentLetterGrade = "F";

            // Student         Grade
            // Sophia:         92.2    A-

            Console.WriteLine($"{currentStudent}\t\t{ExamScore}\t\t{currentStudentGrade}\t{currentStudentLetterGrade}\t{ExtraCredit} ({pts} pts)");
        }//Student\t\tExamScore\tOverall\tGrade\tExtra Credit\n

        // required for running in VS Code (keeps the Output windows open to view results)
        Console.WriteLine("\n\rPress the Enter key to continue");
        Console.ReadLine();

    }

    //C#入门，第三部分，第一单元， 向 C# 控制台应用程序添加逻辑
    public static void LogicBoolean()
    {
        Console.WriteLine("a" == "a");
        Console.WriteLine("a" == "A");
        Console.WriteLine(1 == 2);

        string myValue = "a";
        Console.WriteLine(myValue == "a");
        Console.WriteLine("a" == "a ");

        string value1 = " a";
        string value2 = "A ";
        string value3 = " b b b ";
        //对任何字符串值使用 ToUpper() 或 ToLower() 帮助程序方法，确保这两个字符串全部大写或全部小写。
        //对任何字符串值使用 Trim() 帮助程序方法，删除前导空格或尾随空格。
        Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());
        Console.Write(value3.Trim());
        Console.WriteLine("123445");

        Console.WriteLine("a" != "a");
        Console.WriteLine("a" != "A");
        Console.WriteLine(1 != 2);

        string pangram = "The quick brown fox jumps over the lazy dog.";
        string blank = " ";
        Console.WriteLine(pangram);//Contains()、StartsWith() 和 EndsWith()
        Console.WriteLine(pangram.StartsWith(pangram));
        Console.WriteLine(pangram.Contains(pangram));
        Console.WriteLine(pangram.Contains("fox"));
        Console.WriteLine(!pangram.Contains("fox"));
        Console.WriteLine(pangram.Contains("cow"));
        Console.WriteLine(pangram.Contains(blank));
    }

    //C#入门，第三部分，第一单元， 向 C# 控制台应用程序添加逻辑，条件运算符
    public static void LogicBooleanPractice()
    {
        int saleAmount = 1001;
        int discount = saleAmount > 1000 ? 100 : 50;//三元运算符
        Console.WriteLine($"Discount: {discount}");
        /* 在 C# 中，**“在大括号里写逻辑”**的一般原则是：
        如果是简单的变量名：{name}（不用加括号）
        如果是复杂的表达式、方法调用或运算符：{(score1 + score2) / 2}（建议或必须加括号）*/
        Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}");//直接在字符串插值中使用三元运算符
        Random coin = new Random();
        int flip = coin.Next(0, 2);//0 or 1
        //int flip = Random.Shared.Next(0,2);
        Console.WriteLine(flip == 0 ? "heads" : "tails");
        Console.WriteLine(coin.Next(0, 2) == 0 ? "heads" : "tails");
    }

    //C#入门，第三部分，第一单元， 向 C# 控制台应用程序添加逻辑，练习 - 使用布尔表达式完成挑战活动
    public static void LogicBooleanChallenge()
    {
        string permission = "Admin";//or Manager
        int adminLevel = Random.Shared.Next(0,101);
        Console.WriteLine(adminLevel);
        if(permission.Contains("Admin"))
        Console.WriteLine($"{(adminLevel > 55 ? "Welcome, Super Admin user." : "Welcome, Admin user.")}");
        else if(permission.Contains("Manager"))
        Console.WriteLine($"{(adminLevel > 20 ? "Contact an Admin for access." : "You do not have sufficient privileges.")}");
        else
        {
            Console.WriteLine("You do not have sufficient privileges.");
        }
    }

}