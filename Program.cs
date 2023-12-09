using Permutation;

var str = "A3.&G,c}\\QOo-@hJ";
int n = str.Length;
int total = Factorial(n);

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"░░░▒▒▓ Calculate all permutation for '{str}' ");
Console.WriteLine($"░░░▒▒▓ Created by Hessam Hosseini 09-12-2023 ");
Console.WriteLine($"░░░▒▒▓ Total charachters : {n}");
Console.WriteLine($"░░░▒▒▓ Total permutations: {total}");
Console.WriteLine($"░░░▒▒▓ Output file       : {BufferWriter.FileName}");

Console.ForegroundColor = ConsoleColor.Yellow;

var buff = BufferWriter.GetInstance(total);

permute(str, 0, n - 1, buff);

buff.Save();

Console.ForegroundColor = ConsoleColor.Green ;
Console.WriteLine("... Write completed ...");
Console.WriteLine("....... Finished ......");
Console.ForegroundColor = ConsoleColor.Gray;

static void permute(string str, int l, int r, BufferWriter buff)
{
    if (l == r)
        buff.Add(str);
    else
    {
        for (int i = l; i <= r; i++)
        {
            str = swap(str, l, i);
            permute(str, l + 1, r, buff);
            str = swap(str, l, i);
        }

    }
}

/** 
* Swap Characters at position 
* @param a string value 
* @param i position 1 
* @param j position 2 
* @return swapped string 
*/
static string swap(string a, int i, int j)
{
    char temp;
    char[] charArray = a.ToCharArray();
    temp = charArray[i];
    charArray[i] = charArray[j];
    charArray[j] = temp;
    string s = new string(charArray);
    return s;
}


int Factorial(int f)
{
    if (f == 0)
        return 1;
    else
        return f * Factorial(f - 1);
}