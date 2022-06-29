using MDApp;
namespace MDTest
{
    public class Program
    {
        private static Videohandler handler = new();
        public static void Main()
        {
            //DownloadMP3();
            DownloadPlaylistMP3();
            //DownloadPlaylistMP4();
            Thread.Sleep(100000);
        }
        private static void DownloadMP3()
        {
            try
            {
                handler.DownloadAsMp3("https://www.youtube.com/watch?v=kXYiU_JCYtU");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        private static void DownloadPlaylistMP3()
        {
            try
            {
                handler.DownloadPlaylist("https://www.youtube.com/watch?v=kXYiU_JCYtU&list=PL_9VHR_SV37YyqnAksXhByuyq-zsE6tEp", VideoType.MP3, () => Console.WriteLine("Done"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void DownloadPlaylistMP4()
        {
            try
            {
                handler.DownloadPlaylist("https://www.youtube.com/watch?v=kXYiU_JCYtU&list=PL_9VHR_SV37YyqnAksXhByuyq-zsE6tEp", VideoType.MP4, () => Console.WriteLine("Done"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}