using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ppedv.TransportVisu.UI.WPF.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        protected void MeChanged([CallerMemberName] string propName = "")
        {
            if (!string.IsNullOrWhiteSpace(propName))
                OnPropChanged(propName);
        }
    }
}
