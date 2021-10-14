using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SuivImmo.ViewModels
{
    class GestionPhotosViewModel : BaseViewModel
    {
        #region Attributs
        private ImageSource _image;
        #endregion

        #region Constructeurs
        public GestionPhotosViewModel()
        {
            this.pickPhoto();
        }
        #endregion
        #region Getters Setters
        public ImageSource Image
        {
            get
            {

                return _image;
            }

            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
                //SetProperty(ref _image, value);
            }
        }
        #endregion
        public async void pickPhoto()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {

                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            });

            //Image = ImageSource.FromFile("/storage/emulated/0/Android/data/com.companyname.suivimmo/files/Pictures/temp/20201004_210911_4.jpg");
            
            if (file == null)
                return;

            Image = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });
        }
    }
}
