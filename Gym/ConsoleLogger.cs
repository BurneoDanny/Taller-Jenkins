namespace Gym;

public class ConsoleLogger: IOutputLogger
{
    public void WriteLine(string line)
    {
        Console.WriteLine(line);
    }

    public string ReadLine()
    {
        return Console.ReadLine()!;
    }
}