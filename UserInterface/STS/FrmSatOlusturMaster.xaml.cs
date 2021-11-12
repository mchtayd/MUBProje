using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserInterface.STS
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmSatOlusturMaster : ContentPage
    {
        public ListView ListView;

        public FrmSatOlusturMaster()
        {
            InitializeComponent();

            BindingContext = new FrmSatOlusturMasterViewModel();
            ListView = MenuItemsListView;
        }

        class FrmSatOlusturMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FrmSatOlusturMasterMenuItem> MenuItems { get; set; }

            public FrmSatOlusturMasterViewModel()
            {
                MenuItems = new ObservableCollection<FrmSatOlusturMasterMenuItem>(new[]
                {
                    new FrmSatOlusturMasterMenuItem { Id = 0, Title = "Page 1" },
                    new FrmSatOlusturMasterMenuItem { Id = 1, Title = "Page 2" },
                    new FrmSatOlusturMasterMenuItem { Id = 2, Title = "Page 3" },
                    new FrmSatOlusturMasterMenuItem { Id = 3, Title = "Page 4" },
                    new FrmSatOlusturMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}