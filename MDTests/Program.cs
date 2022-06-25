using MDApp;
namespace MDTest
{
    public class Program
    {
        private static Videohandler handler = new();
        public static void Main()
        {
            DownloadPlaylistMP4();
            Thread.Sleep(100000);
        }
        private static void DownloadPlaylistMP3()
        {
            try
            {
                handler.DownloadPlaylist("https://www.youtube.com/watch?v=HA1srD2DwaI&list=OLAK5uy_kZ2MLSNGjLRXP7OfUMs23Qv57SBRTIZIk", VideoType.MP3, () => Console.WriteLine("Done"));
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
                handler.DownloadPlaylist("https://www.youtube.com/watch?v=gfW1Fhd9u9Q&list=PLlrATfBNZ98edc5GshdBtREv5asFW3yXl", VideoType.MP4, () => Console.WriteLine("Done"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}