namespace ConditionalCompilation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            #region ConstantsDeclaration

#if DEBUG
            const int x = 1;
            const int y = 2;
#else
            const int x = 3;
            const int y = 4;
#endif
            #endregion

            Console.WriteLine(x + y);
        }
    }
}
