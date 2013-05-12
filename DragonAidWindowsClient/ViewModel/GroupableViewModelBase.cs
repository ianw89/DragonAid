using System;
using DragonAid.WindowsClient.Common;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace DragonAid.WindowsClient.ViewModel
{
    /// <summary>
    /// Base class for data intended to be displayed as part of a group (eg, as a tile in a Windows 8 app)
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class GroupableViewModelBase : BindableBase
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public GroupableViewModelBase()
        {
        }

        public GroupableViewModelBase(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            _uniqueId = uniqueId;
            _title = title;
            _subtitle = subtitle;
            _description = description;
            _imagePath = imagePath;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return _uniqueId; }
            set { SetProperty(ref _uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _subtitle = string.Empty;
        public string Subtitle
        {
            get { return _subtitle; }
            set { SetProperty(ref _subtitle, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private ImageSource _image;
        private String _imagePath;
        public ImageSource Image
        {
            get
            {
                if (_image == null && _imagePath != null)
                {
                    _image = new BitmapImage(new Uri(_baseUri, _imagePath));
                }
                return _image;
            }

            set
            {
                _imagePath = null;
                SetProperty(ref _image, value);
            }
        }

        public void SetImage(String path)
        {
            _image = null;
            _imagePath = path;
            OnPropertyChanged();
        }

        public override string ToString()
        {
            return Title;
        }
    }
}