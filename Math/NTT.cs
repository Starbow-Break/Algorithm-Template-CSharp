namespace ProblemSolving.Math;

public static class NTT
{
    public const int Mod = 998244353;
    private const int W = 3;

    public static int[] FFT(int[] poly, bool inverse = false)
    {
        int polySize = 1;
        while (polySize < poly.Length)
        {
            polySize *= 2;
        }
        
        int unit = MathI.ModPow(W, (Mod - 1) / polySize, Mod);
        if (inverse)
        {
            unit = MathI.ModPow(unit, Mod - 2, Mod);
        }
        
        int[] p = new int[polySize];
        for (int i = 0; i < polySize; i++)
        {
            int idx = 0;
            for (int j = 1, a = polySize / 2; j < polySize; j <<= 1, a >>= 1)
            {
                if ((i & j) > 0)
                {
                    idx += a;
                }
            }
            
            p[i] = (idx >= poly.Length ? 0 : poly[idx]);
        }

        for (int s = 2; s <= polySize; s *= 2)
        {
            int w = MathI.ModPow(unit, polySize / s, Mod);
            for (int i = 0; i < polySize; i += s)
            {
                int curW = 1;
                for (int j = i; j < i + s / 2; j++, curW = (int)(1L * curW * w % Mod))
                {
                    int te = p[j];
                    int to = p[j + s / 2];

                    p[j] = (int)((1L * curW * to + te) % Mod);
                    p[j + s / 2] = (int)((1L * (Mod - curW) * to + te) % Mod);
                }
            }
        }

        if (inverse)
        {
            int invSize = MathI.ModPow(polySize, Mod - 2, Mod);
            p = p.Select(x => (int)(1L * x * invSize % Mod)).ToArray();
        }
        
        return p;
    }
}