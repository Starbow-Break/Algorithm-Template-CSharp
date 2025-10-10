namespace ProblemSolving.FastIO;

public static class Writer
{
    private static StreamWriter _writer
        = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
    
    public static void Write(string s) => _writer.Write(s);
    public static void Write<T>(T s)
        =>_writer.Write(s?.ToString() ?? System.String.Empty);

    public static void WriteImmediately(string s)
    {
        Write(s);
        Flush();
    }
    
    public static void WriteImmediately<T>(T s)
    {
        Write(s);
        Flush();
    }

    public static void WriteLine(string s) => _writer.WriteLine(s);
    public static void WriteLine<T>(T s)
        =>_writer.WriteLine(s?.ToString() ?? System.String.Empty);
    
    public static void WriteLineImmediately(string s)
    {
        WriteLine(s);
        Flush();
    }
    
    public static void WriteLineImmediately<T>(T s)
    {
        WriteLine(s);
        Flush();
    }
    
    public static void Flush() => _writer.Flush();
    public static void Close() => _writer.Close();
}