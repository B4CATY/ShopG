using System;

namespace Shop
{
    public class Program
    {
        static void Main(string[] args)
        {
            Startup start = new Startup(); ;
            try
            {
                start.UserInteraction();
            }

            catch (ArgumentNullException)
            {
                
                Console.WriteLine("Not correct login.\nEnter your login again or u can sign up");

            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Not correct login.\nEnter your login again or u can sign up");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

            }
            /*finally
            {
                if (start.IsEnd)
                    start.UserInteraction();
            }*/
            
            
        }
    }
}
