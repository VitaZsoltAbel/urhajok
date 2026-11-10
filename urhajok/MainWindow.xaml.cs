using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace urhajok
{
    public class Urhajoadatok
    {
        public string Nev { get; set; }
        public int Legenyseg { get; set; }
        public int MaxHatotav { get; set; }
        public int UzemenyagSzint { get; set; }
        public string Gyarto { get; set; }
        public string KuldetesStatusz { get; set; }
        public int InditasEve { get; set; }

        public Urhajoadatok(string nev, int legenysg, int maxHatotav, int uzemenyagSzint, string gyarto, string kuldetesStatusz, int inditasEve)
        {
            Nev = nev;
            Legenyseg = legenysg;
            MaxHatotav = maxHatotav;
            UzemenyagSzint = uzemenyagSzint;
            Gyarto = gyarto;
            KuldetesStatusz = kuldetesStatusz;
            InditasEve = inditasEve;
        }
    }

    public partial class MainWindow : Window
    {
        List<Urhajoadatok> urhajok = new List<Urhajoadatok>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AdatokBetoltese(object sender, RoutedEventArgs e)
        {
            urhajok = new List<Urhajoadatok>()
            {
                new Urhajoadatok("Falcon-9", 7, 550000, 87, "SpaceX", "Sikeres", 2020),
                new Urhajoadatok("Orion-X1", 4, 820000, 73, "NASA", "Folyamatban", 2023),
                new Urhajoadatok("StarRider", 12, 910000, 66, "Boeing", "Sikeres", 2019),
                new Urhajoadatok("SolarWind", 3, 300000, 92, "ESA", "Sikertelen", 2018),
                new Urhajoadatok("Galaxy-Cruiser", 18, 1200000, 54, "Blue Origin", "Sikeres", 2022),
                new Urhajoadatok("Nova-Prime", 10, 760000, 80, "Roscosmos", "Sikeres", 2017),
                new Urhajoadatok("Pioneer-VII", 6, 640000, 70, "NASA", "Folyamatban", 2024),
                new Urhajoadatok("Titan-Hawk", 14, 1050000, 48, "SpaceX", "Sikeres", 2021),
                new Urhajoadatok("CosmoJet", 5, 430000, 93, "JAXA", "Sikertelen", 2016),
                new Urhajoadatok("Nebula-FX", 11, 870000, 60, "ESA", "Sikeres", 2020)
            };

            datagrid.ItemsSource = urhajok;
            datagrid.Items.Refresh();
        }

        private void HanyUrhajoVan(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Az űrhajók száma: {urhajok.Count}");
        }


        private void LegnagyobbHatotav(object sender, RoutedEventArgs e)
        {
            var maxUrhajo = urhajok.OrderByDescending(u => u.MaxHatotav).FirstOrDefault();
            if (maxUrhajo != null)
            {
                MessageBox.Show($"A legnagyobb hatótávú űrhajó: {maxUrhajo.Nev} ({maxUrhajo.MaxHatotav} km)");
            }
        }


        private void SikeresKuldetesek(object sender, RoutedEventArgs e)
        {
            var sikeresek = urhajok.Where(u => u.KuldetesStatusz == "Sikeres").ToList();
            datagrid.ItemsSource = sikeresek;
            datagrid.Items.Refresh();
        }

        private void AtlagosLegenyseg(object sender, RoutedEventArgs e)
        {
            if (urhajok.Count > 0)
            {
                double atlag = urhajok.Average(u => u.Legenyseg);
                MessageBox.Show($"Az átlagos legénységszám: {atlag:F2}");
            }
        }

    }
}





