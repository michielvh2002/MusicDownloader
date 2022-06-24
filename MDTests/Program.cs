using MDApp;
namespace MDTest
{
    public class Program
    {
        public static void Main()
        {
            printAsync();
            Thread.Sleep(100000);
        }
        private static async void printAsync()
        {
            Videohandler handler = new();
            //var yes = await handler.GetMetaData("https://www.youtube.com/watch?v=l2hA8g1cNvQ");

            //Console.WriteLine(yes.Author);
            //Console.WriteLine(yes.Description);
            //Console.WriteLine(yes.Duration);

            try
            {
                //bool download = await handler.DownloadAsMp3("https://www.youtube.com/watch?v=HA1srD2DwaI&list=OLAK5uy_kZ2MLSNGjLRXP7OfUMs23Qv57SBRTIZIk");
                //if (download) Console.WriteLine("Succes");
                //else Console.WriteLine("Failed");

                await handler.DownloadPlaylist("https://www.youtube.com/watch?v=HA1srD2DwaI&list=OLAK5uy_kZ2MLSNGjLRXP7OfUMs23Qv57SBRTIZIk", VideoType.MP3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //try
            //{
            //    bool download = await handler.DownloadAsMp4("https://www.youtube.com/watch?v=MF1qEhBSfq4");
            //    if (download) Console.WriteLine("Succes");
            //    else Console.WriteLine("Failed");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}


        }
    }
}