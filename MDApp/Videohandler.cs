using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using System.Web;

namespace MDApp
{
    public class Videohandler
    {
        private YoutubeClient youtube = new();
        public async Task<Video> GetMetaData(string url)
        {
            return await youtube.Videos.GetAsync(url);
        }

        public async Task<bool> DownloadAsMp4(string url)
        {
            var vid = await GetMetaData(url);
            return await DownloadMp4(vid);
        }
        private async Task<bool> DownloadMp4(Video vid)
        {
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(vid.Id);

            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{vid.Title}.{streamInfo.Container}");
            return true;
        }

        public async Task<bool> DownloadAsMp3(string url)
        {
            Video vid = await GetMetaData(url);
            StreamManifest streamManifest = await youtube.Videos.Streams.GetManifestAsync(vid.Id);

            IStreamInfo streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
            
            //Console.WriteLine(streamInfo.Container);
            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{vid.Title}.mp3");
            return true;
        }

        public async Task<bool> DownloadPlaylist(string url, VideoType type)
        {

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Url can not be empty");
            if (!url.Contains("youtube")) throw new ArgumentException("Only yt bro");

            string? playlistId = HttpUtility.ParseQueryString(url).Get("list");
            if (playlistId is null) throw new ArgumentException("This is not a playlist");

            var playList = await youtube.Playlists.GetAsync(playlistId);
            var videos = youtube.Playlists.GetVideosAsync(playList.Id);

            await foreach (var video in videos)
            {
                switch (type)
                {
                    case VideoType.MP4: await DownloadAsMp4(video.Url);
                        break;
                    case VideoType.MP3: await DownloadAsMp3(video.Url);
                        break;
                    default:
                        break;
                }
            }
            return true;
        }
    }
}