using ppedv.TransportVisu.Logic;
using ppedv.TransportVisu.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.TransportVisu.UI.WPF.ViewModels
{
    public class AnlagenViewModel : ViewModelBase
    {
        Core core = new Core();
        private bool zeigeKundennummer;

        public ObservableCollection<DatenplatzViewItem> DatenListe { get; set; } = new ObservableCollection<DatenplatzViewItem>();

        public bool ZeigeKundennummer
        {
            get => zeigeKundennummer;
            set
            {
                zeigeKundennummer = value;
                foreach (var item in DatenListe)
                {
                    if (item.Datenplatz?.Waesche != null)
                    {
                        if (value)
                            item.Text = item.Datenplatz.Waesche.Kundennummer;
                        else
                            item.Text = item.Datenplatz.Waesche.Artikelnummer;
                    }
                    else
                        item.Text = item.Datenplatz.Bezeichnung;

                }
            }
        }

        public AnlagenViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            DatenListe.Clear();

            Random ran = new Random();

            foreach (var dp in core.Repository.GetAll<Datenplatz>())
            {
                DatenListe.Add(new DatenplatzViewItem()
                {
                    Datenplatz = dp,
                    Text = dp.Bezeichnung,
                    PosLeft = ran.Next(0, 500),
                    PosTop = ran.Next(0, 200)
                });
            }
        }
    }

    public class DatenplatzViewItem : ViewModelBase
    {
        private string text;

        public Datenplatz Datenplatz { get; set; }
        public int PosLeft { get; set; }
        public int PosTop { get; set; }


        public string Text
        {
            get => text; 
            set
            {
                text = value;
                MeChanged();
            }
        }
    }
}
