namespace GithubActionBuildTests.Models
{
    public class Calculator
    {
        private int A { get; set; }
        private int B { get; set; }

        public Calculator(int a, int b)
        {
            A = a;
            B = b;
        }

        public int Sum()
        {
            return A + B;
        }

        public int Min() 
        {
            return A - B;
        }

        public int Mult() 
        {
            return A * B;
        }

        public double Div()
        {
            return A / B;
        }

        public int Minimum() 
        {
            return A < B ? A : B;
        }
    }
}
