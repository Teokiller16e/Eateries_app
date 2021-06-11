using App7.Interfaces;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace App7
{
    public class SoundService
    {
        private readonly ISoundProvider _soundProvider;

        public SoundService()
        {
            _soundProvider = DependencyService.Get<ISoundProvider>();
        }

        public  Task PlaySoundAsync(string filename)
        {
            return _soundProvider.PlaySoundAsync(filename);
        }
    }
}
