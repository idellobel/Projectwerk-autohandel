using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using B4.EE.DellobelI.Domain.Services.Abstract;
using Xamarin.Forms;

[assembly:Dependency(typeof(B4.EE.DellobelI.Droid.Services.PlatformSoundPlayer))]

namespace B4.EE.DellobelI.Droid.Services
{
    public class PlatformSoundPlayer : ISoundPlayer
    {
        private MediaPlayer _mediaPlayer;

        public Task PlaySound()
        {
            _mediaPlayer = MediaPlayer
                .Create(global::Android.App.Application.Context, Resource.Raw.munchausen);
            _mediaPlayer.Start();
            return Task.Delay(0);
        }
    }
}