namespace ProblemSolving.FastIO;

public static class Reader
{
    private static StreamReader _reader
        = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
    
#if NET7_0_OR_GREATER
    public static T ReadLine<T>() where T : IParsable<T>
        => T.Parse(ReadLine(), null);
    
    public static T[] ReadLineArray<T>() where T : IParsable<T>
        => ReadLineArray().Select(str => T.Parse(str, null)).ToArray();
#endif
    
    public static string ReadLine() => _reader.ReadLine()!;
    public static int ReadLineInt() => int.Parse(ReadLine());
    public static long ReadLineLong() => long.Parse(ReadLine());
    public static float ReadLineFloat() => float.Parse(ReadLine());
    public static double ReadLineDouble() => double.Parse(ReadLine());

    public static string[] ReadLineArray() => 
        _reader.ReadLine()!.Split();
    public static int[] ReadLineIntArray() 
        => ReadLineArray().Select(int.Parse).ToArray();
    public static long[] ReadLineLongArray() 
        => ReadLineArray().Select(long.Parse).ToArray();
    public static float[] ReadLineFloatArray() 
        => ReadLineArray().Select(float.Parse).ToArray();
    public static double[] ReadLineDoubleArray() 
        => ReadLineArray().Select(double.Parse).ToArray();

    public static void Close() => _reader.Close();
}