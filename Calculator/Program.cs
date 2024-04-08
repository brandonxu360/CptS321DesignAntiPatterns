using System;

// Calculator class that performs arithmetic operations and logs messages
public class Calculator
{
    private readonly Logger _logger;

    public Calculator(Logger logger)
    {
        _logger = logger;
    }

    public int AddAndLog(int a, int b)
    {
        int result = a + b;
        _logger.Log($"Adding {a} and {b} resulted in {result}");
        return result;
    }

    public int SubtractAndLog(int a, int b)
    {
        int result = a - b;
        _logger.Log($"Subtracting {b} from {a} resulted in {result}");
        return result;
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

class Program
{
    static void Main(string[] args)
    {
        // Create an instance of Logger
        Logger logger = new Logger();

        // Create an instance of Calculator
        Calculator calculator = new Calculator(logger);

        // Use the Calculator to add and log numbers
        int sum = calculator.AddAndLog(5, 3);
        Console.WriteLine($"Sum: {sum}");

        // Use the Calculator to subtract and log numbers
        int difference = calculator.SubtractAndLog(10, 7);
        Console.WriteLine($"Difference: {difference}");
    }
}