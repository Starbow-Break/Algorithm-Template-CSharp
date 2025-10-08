namespace ProblemSolving.String;

/*
 * Class implementing a KMP algorithm
 * Author : STARBOW
 */

public static class KMP
{
    public static int[] GetFail(string str)
    {
        var fail = new int[str.Length];

        for (int i = 1, j = 0; i < str.Length; i++)
        {
            while (j > 0 && str[i] != str[j])
            {
                j = fail[j];
            }

            if (str[i] == str[j])
            {
                j++;
            }

            fail[i] = j;
        }

        return fail;
    }

    public static int[] FindAllIndex(string source, string target)
    {
        List<int> result = new();
        
        var fail = GetFail(target);
        for (int i = 0, j = 0; i < source.Length; i++)
        {
            while (j > 0 && j < target.Length && source[i] != target[j])
            {
                j = fail[j];
            }
            
            if (source[i] == target[j])
            {
                if (++j == fail.Length)
                {
                    result.Add(i - fail.Length + 1);
                }
            }
        }
        
        return result.ToArray();
    }
}