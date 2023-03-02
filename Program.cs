using System;

class Program
{
    struct Cell
    {
        public int Pattern, Occurrences;

        public Cell(int pattern, int occurrences)
        {
            Pattern = pattern;
            Occurrences = occurrences;
        }
    }

    static void Main(string[] args)
    {
        int n = 100;

        // The sequence, start with [1]
        int[] sequence = new int[n];
        sequence[0] = 1;

        Cell[,] array = new Cell[n, n];

        for (int i = 0; i < n - 1; i++)
        {
            int max = 1;

            for (int j = 0; j <= i; j++)
            {
                // Pattern is saved as a base-10 number, could be done differently as well
                int pattern = sequence[i] + (i - 1 >= 0 && j - 1 >= 0 ? array[i - 1, j - 1].Pattern * 10 : 0);

                int length = j + 1;

                if (i - length < 0)
                {
                    // Index out of range: just add the pattern with an occurrence of 1
                    array[i, j] = new Cell(pattern, 1);
                    continue;
                }

                Cell prev = array[i - length, j];

                int occurrences = 1 + (prev.Pattern == pattern ? prev.Occurrences : 0);

                array[i, j] = new Cell(pattern, occurrences);

                max = Math.Max(max, occurrences);
            }

            sequence[i + 1] = max;
        }

        string output = "";

        foreach (int i in sequence)
        {
            output += i.ToString();
        }

        Console.WriteLine(output);
    }
}