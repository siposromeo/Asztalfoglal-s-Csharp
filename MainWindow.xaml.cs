using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asztalfoglalas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AsztalfoglalasContext context = new AsztalfoglalasContext();
        public MainWindow()
        {
            InitializeComponent();
            SetStatus(true);
            context.Foglalas.Load();
            context.Asztal.Load();

            lista_DG.ItemsSource = context.Foglalas.Local.ToObservableCollection();
            asztal_CBX.ItemsSource = context.Asztal.Local.ToObservableCollection();
            asztal_CBX.DisplayMemberPath = "Megnevezes";
        }
        private void SetStatus(bool listazas)
        {
            lista_DG.IsEnabled = gombok_SP.IsEnabled = listazas;
            adatok_Grid.IsEnabled = !listazas;
        }

        private void uj_BTN_Click(object sender, RoutedEventArgs e)
        {
            SetStatus(false);
            adatok_Grid.DataContext = new Foglalas()
            {
                Datum = DateTime.Today
            };
        }

        private void mod_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (lista_DG.SelectedItem != null)
            {
                SetStatus(false);
            }
        }

        private void torol_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (lista_DG.SelectedItem != null)
            {
                if (MessageBox.Show("Biztosan törölni akarja a foglalást?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Foglalas f = (Foglalas)lista_DG.SelectedItem;
                    context.Foglalas.Remove(f);
                    context.SaveChanges();
                }
            }
        }

        private bool KotelezoEll(Foglalas f)
        {
            if (String.IsNullOrWhiteSpace(f.Nev))
            {
                nev_TXB.Focus();
                return false;
            }
            if (f.Asztal == null)
            {
                asztal_CBX.IsDropDownOpen = true;
                return false;
            }
            if (datum_DP.SelectedDate == null)
            {
                datum_DP.Focus();
                return false;
            }
            if (int.TryParse(letszam_TXB.Text, out int letszam) && letszam > 0 && f.Asztal.Ferohely >= letszam)
            {
                letszam_TXB.Focus();
                return false;
            }
            return true;
        }

        private void mentes_btn_Click(object sender, RoutedEventArgs e)
        {
            Foglalas f = (Foglalas)adatok_Grid.DataContext;
            if (KotelezoEll(f))
            {
                if (f.ID == 0)
                {
                    context.Foglalas.Add(f);
                }
                else
                {
                    context.Entry(f).State = EntityState.Modified;
                }
                context.SaveChanges();
                SetStatus(true);
                lista_DG.SelectedItem = f;
            }
        }

        private void megse_btn_Click(object sender, RoutedEventArgs e)
        {
            Foglalas f = (Foglalas)adatok_Grid.DataContext;
            if (f.ID != 0)
            {
                context.Entry(f).State = EntityState.Unchanged;
                lista_DG.Items.Refresh();
            }
            SetStatus(true);
            lista_DG.SelectedItem = null;
            adatok_Grid.DataContext = null;
        }

        private void lista_DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            adatok_Grid.DataContext = lista_DG.SelectedItem;
        }
    }
}
