using System;

// Calculator class that performs arithmetic operations
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }
}

// Logger class that logs messages
public class Logger
{
    public void Log(string message)
    {
        Console.WriteLine($"Logging: {message}");
    }
}

// Poltergeist class that passes messages between Calculator and Logger
public class Poltergeist
{
    private readonly Calculator _calculator;
    private readonly Logger _logger;

    public Poltergeist(Calculator calculator, Logger logger)
    {
        _calculator = calculator;
        _logger = logger;
    }

    public int AddAndLog(int a, int b)
    {
        // Pass the numbers to the calculator
        int result = _calculator.Add(a, b);

        // Log the operation
        _logger.Log($"Adding {a} and {b} resulted in {result}");

        return result;
    }

    public int SubtractAndLog(int a, int b)
    {
        // Pass the numbers to the calculator
        int result = _calculator.Subtract(a, b);

        // Log the operation
        _logger.Log($"Subtracting {b} from {a} resulted in {result}");

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create instances of Calculator and Logger
        Calculator calculator = new Calculator();
        Logger logger = new Logger();

        // Create an instance of Poltergeist
        Poltergeist poltergeist = new Poltergeist(calculator, logger);

        // Use the Poltergeist to add and log numbers
        int sum = poltergeist.AddAndLog(5, 3);
        Console.WriteLine($"Sum: {sum}");

        // Use the Poltergeist to subtract and log numbers
        int difference = poltergeist.SubtractAndLog(10, 7);
        Console.WriteLine($"Difference: {difference}");
    }
}