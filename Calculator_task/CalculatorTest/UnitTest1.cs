using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Xml.Serialization;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Test_Addition()
    {
        float first = 10;
        float second = 5;
        char opr = '+';
        string expectedResult = "The result of '10 + 5' is: 15";

        string actualResult = ExecuteProgramWithInput(opr, first, second);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Test_Subtraction()
    {
        float first = 10;
        float second = 5;
        char opr = '-';
        string expectedResult = "The result of '10 - 5' is: 5";

        string actualResult = ExecuteProgramWithInput(opr, first, second);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Test_Division()
    {
        float first = 10;
        float second = 2;
        char opr = '/';
        string expectedResult = "The result of '10 / 2' is: 5";

        string actualResult = ExecuteProgramWithInput(opr, first, second);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Test_Multiplication()
    {
        float first = 10;
        float second = 5;
        char opr = '*';
        string expectedResult = "The result of '10 * 5' is: 50";

        string actualResult = ExecuteProgramWithInput(opr, first, second);

        Assert.AreEqual(expectedResult, actualResult);
    }

    // Helper method to execute the program with given input
    private string ExecuteProgramWithInput(char opr, float first, float second)
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{opr}\n{first}\n{second}\n"));
            Calculator.Main(new string[0]);
            string output = sw.ToString().Trim();
            string finalResult = output.Substring(output.LastIndexOf("The result of"));
            return finalResult;
        }
    }
}
