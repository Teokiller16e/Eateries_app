using System.Threading.Tasks;
using Android.Content;
using Android.Media;
using App7.Droid;
using App7.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidSoundProvider))]

namespace App7.Droid
{

    public class AndroidSoundProvider : ISoundProvider
    {
        Context _context { get; set; }
        public Task PlaySoundAsync(string filename)
        {
            // Create media player
            var player = new MediaPlayer();

            // Create task completion source to support async/await
            var tcs = new TaskCompletionSource<bool>();

            // Open the resource

            var fd = Xamarin.Forms.Forms.Context.Assets.OpenFd(filename);

            // Hook up some events
            player.Prepared += (s, e) => {
                player.Start();
            };

            player.Completion += (sender, e) => {
                tcs.SetResult(true);
            };

            // Start playing
            player.SetDataSource(fd.FileDescriptor); player.Prepare();

            return tcs.Task;
        }
    }
}