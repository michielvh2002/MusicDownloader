using MDApp;
namespace MDTest
{
    public class Program
    {
        private static Videohandler handler = new();
        public static void Main()
        {
            DownloadPlaylistMP3();
            Thread.Sleep(100000);
        }
        private static async void DownloadPlaylistMP3()
        {
            try
            {
                await handler.DownloadPlaylist("https://www.youtube.com/watch?v=HA1srD2DwaI&list=OLAK5uy_kZ2MLSNGjLRXP7OfUMs23Qv57SBRTIZIk", VideoType.MP3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static async void DownloadPlaylistMP4()
        {
            try
            {
                await handler.DownloadPlaylist("https://www.youtube.com/watch?v=HA1srD2DwaI&list=OLAK5uy_kZ2MLSNGjLRXP7OfUMs23Qv57SBRTIZIk", VideoType.MP4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}