using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using YoutubeExplode.Converter;
using System.Web;
using System.Text.RegularExpressions;

namespace MDApp
{
    public class Videohandler
    {
        private YoutubeClient youtube = new();
        public async Task<Video> GetMetaData(string url)
        {
            return await youtube.Videos.GetAsync(url);
        }

        public async void DownloadAsMp4(string url)
        {
            var vid = await GetMetaData(url);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(vid.Id);

            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            string title = vid.Title;
            for (int i = 0; i < vid.Title.Length; i++)
            {
                if (vid.Title[i] != '/' && vid.Title[i] != '\\')
                {
                    title = vid.Title.Substring(0, i - 1);
                    break;
                }
            }

            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{title}.mp4");
        }

        public async void DownloadAsMp3(string url)
        {
            Video vid = await GetMetaData(url);
            StreamManifest streamManifest = await youtube.Videos.Streams.GetManifestAsync(vid.Id);

            IStreamInfo streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            string title = vid.Title;
            for (int i = 0; i < vid.Title.Length; i++)
            {
                if (vid.Title[i] != '/' && vid.Title[i] != '\\')
                {
                    title = vid.Title.Substring(0, i - 1);
                    break;
                }
            }

            await youtube.Videos.Streams.DownloadAsync(streamInfo, $"{title}.mp3");
        }

        public async void DownloadPlaylist(string url, VideoType type, Action a)
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
                    case VideoType.MP4: DownloadAsMp4(video.Url);
                        break;
                    case VideoType.MP3: DownloadAsMp3(video.Url);
                        break;
                    default:
                        break;
                }
            }
            a();
        }
    }
}