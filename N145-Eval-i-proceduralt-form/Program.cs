using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading;

string cultureCode = "en-US";   // da-DK, en-US
CultureInfo newCulture = new CultureInfo(cultureCode);
Thread.CurrentThread.CurrentCulture = newCulture;// Set the formatting culture (dates, numbers, currency)
Thread.CurrentThread.CurrentUICulture = newCulture;// Set the UI culture (which localized string resources to load)
Console.WriteLine($"Culture set to: {cultureCode}");

double Eval(string formel)
{
    formel = Regex.Replace(formel, @"\s+", ""); // Remove all whitespace characters

    List<string> stNumbers = new List<string>();
    List<string> stOperators = new List<string>();
    string currentNumber = "";

    // Loop through each character in 'formel'
    for (int i = 0; i < formel.Length; i++)
    {
        char c = formel[i];
        //Console.WriteLine(c);

        switch (c)
        {
            case '+':
            case '-':
            case '*':
            case '/':
                if (!string.IsNullOrEmpty(currentNumber))
                {
                    stNumbers.Add(currentNumber);
                    currentNumber = "";
                }
                if (c == '-' && (i == 0 || "+-*/".Contains(formel[i - 1])))
                {
                    // It's a negative sign, not an operator
                    currentNumber += c; // Append '-' to the current number
                }
                else
                {
                    stOperators.Add(c.ToString());
                }
                break;
            case var digit when char.IsDigit(digit) || digit == '.':
                currentNumber += c;
                break;
            default:
                // Ignore other characters (like spaces)
                break;
        }
    }
    if (!string.IsNullOrEmpty(currentNumber))
    {
        stNumbers.Add(currentNumber);
    }

    //// Example output
    //Console.WriteLine("Numbers:");
    //foreach (var num in stNumbers)
    //    Console.WriteLine(num);

    //Console.WriteLine("Operators:");
    //foreach (var op in stOperators)
    //    Console.WriteLine(op);
    if (!(stNumbers.Count- stOperators.Count==1))
    {
        throw new ArgumentException("Antal tal og operatorer stemmer ikke overens");
    }
    double result = double.Parse(stNumbers[0]);
    for (int i = 0; i < stOperators.Count; i++)
    {
        switch (stOperators[i])
        {
            case "+":
                result += double.Parse(stNumbers[i + 1]);
                break;
            case "-":
                result -= double.Parse(stNumbers[i + 1]);
                break;
            case "*":
                result *= double.Parse(stNumbers[i + 1]);
                break;
            case "/":
                result /= double.Parse(stNumbers[i + 1]);
                break;

        }
    }

    return result;
}

//Console.WriteLine(Eval("10 + 5.5 * 2 / 0.5 - 3")); // correct output: 29 Returns 59 :( It doesn't know how to multiply and divide before it can add and subtract. The order of the factors is NOT equally valid
//Console.WriteLine(Eval("1+2+3")); // Output: 6
//Console.WriteLine(Eval("10+20")); // Output: 30
//Console.WriteLine(Eval("5")); // Output: 5
//Console.WriteLine(Eval("1+1+1+1+1")); // Output: 5
//Console.WriteLine(Eval("1 + 1 +1+ 1+1")); // Output: 5
//Console.WriteLine(Eval("1+1+1+1+1+1+1+1+1")); // Output: 9
Console.WriteLine(Eval("-5--1")); // Output: -4

// Error handling
//Console.WriteLine(Eval("5+")); // Output: Error
Console.WriteLine(Eval("")); // Output: Same Error

Console.ReadKey();

