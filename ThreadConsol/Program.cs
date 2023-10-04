namespace ThreadConsol
{
    public class Program
    {
        // Instantiation of global variables
        public static int mainSum = 0;
        public static int checkSum = 0;
        public static object tLock = new object();
        static void Main(string[] args)
        {
            // 3 threads that should start and wait.
            Thread t1 = new Thread(new ThreadStart(DoWork));
            t1.Start();
            t1.Join();
            Thread t2 = new Thread(new ThreadStart(DoWork));
            t2.Start();
            t2.Join();
            Thread t3 = new Thread(new ThreadStart(DoWork));
            t3.Start();
            t3.Join();

        
            Console.WriteLine($"Checksum = {checkSum}");
        }

        public static void DoWork() 
        {

            int mysum = 0;
            for(int i = 0; i < 200; i++) 
            {
            Thread.Sleep(5);
            Random random = new Random();
            int add = random.Next(0, 10);

             lock (tLock) 
                { mysum += add;
                    mainSum += add;
                    checkSum += add; 
                }

            }
        Console.WriteLine($"mysum = {mysum}");
        Console.WriteLine($"Checksum = {checkSum}");

        }
}
}