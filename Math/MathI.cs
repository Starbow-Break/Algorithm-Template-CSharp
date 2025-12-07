namespace ProblemSolving.Math;

public static class MathI
{
    public static int ModPow(int a, int e, int mod)
    {
        int result = 1;
        int w = a;

        while (e > 0)
        {
            if (e % 2 == 1)
            {
                result = (int)(1L * result * w % mod);
            }
            
            w = (int)(1L * w * w % mod);
            e >>= 1;
        }

        return result;
    }
}