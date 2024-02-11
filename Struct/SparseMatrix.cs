//sparse matrix is a representation for a low number of non-zero elements in the matrix
//and i'm using a single dimension vector to represent such matrix, for optimize memory allocation
struct SparseMatrix()
{
    public int M { get; set; }
    public int N { get; set; }
    public int Num { get; set; }

    public Elements[] elements = [];

    public void Create()
    {
        int i;
        System.Console.WriteLine("Enter Dimensions");
        M = int.Parse(Console.ReadLine());
        N = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Now enter num of non-zeros elements");
        Num = int.Parse(Console.ReadLine());
        elements = new Elements[Num];
        System.Console.WriteLine("Now enter  non-zeros elements");
        for (i = 0; i < Num; i++)
        {
            elements[i].i = int.Parse(Console.ReadLine());
            elements[i].j = int.Parse(Console.ReadLine());
            elements[i].x = int.Parse(Console.ReadLine());
        }

    }

    public void Display()
    {
        int i, j, k = 0;
        for (i = 0; i < M; i++)
        {
            for (j = 0; j < N; j++)
            {
                if (k < Num && i == elements[k].i && j == elements[k].j)
                    System.Console.Write(elements[k++].x + " ");
                else System.Console.Write("0 ");
            }
            System.Console.WriteLine();
        }

    }

    public SparseMatrix Add(ref SparseMatrix s1, ref SparseMatrix s2)
    {
        int i = 0, j = 0, k = 0;
        if (s1.M != s2.M || s1.N != s2.N) return s1;
        SparseMatrix sum = new()
        {
            M = s1.M,
            N = s1.N,
            elements = new Elements[s1.Num + s2.Num],
        };

        //this condition is better write in my notation ~\Matrix\SparseMatrix.txt line 60
        while (i < s1.Num && j < s2.Num)
        {

            //rows in this case
            if (s1.elements[i].i < s2.elements[j].i)
                sum.elements[k++] = s1.elements[i++];
            else if (s1.elements[i].i > s2.elements[j].i)
                sum.elements[k++] = s1.elements[j++];
            else
            {
                //columns
                if (s1.elements[i].j < s2.elements[j].j)
                    sum.elements[k++] = s1.elements[i++];
                else if (s1.elements[i].j > s2.elements[j].j)
                    sum.elements[k++] = s1.elements[j++];
                else
                {
                    //and finally if row and column match you just sum the element x
                    sum.elements[k] = s1.elements[i];
                    sum.elements[k++].x = s1.elements[i++].x + s2.elements[j++].x;
                }
            }

        }
        for (; i < s1.Num; i++) sum.elements[k++] = s1.elements[i];
        for (; j < s2.Num; j++) sum.elements[k++] = s2.elements[j];
        sum.M = s1.M;
        sum.N = s1.N;
        sum.Num = k;
        return sum;
    }

}
