using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App7.Interfaces
{


    public interface ISoundProvider
    {
      Task PlaySoundAsync(string filename);
    }


}
