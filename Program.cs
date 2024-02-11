class Program
{
    static void Main(string[] args)
    {
        SparseMatrix sparse1 = new(), sparse2 = new(), sparse3 = new();
        // sparseMatrix.Create();
        // sparseMatrix.Display();
        System.Console.WriteLine("First Matrix");
        sparse1.Create();
        System.Console.WriteLine("Second Matrix");
        sparse2.Create();
        sparse3 = sparse3.Add(ref sparse1, ref sparse2);
        System.Console.WriteLine("Sum of elements");
        sparse3.Display();
    }
}