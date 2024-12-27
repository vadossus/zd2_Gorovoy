using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private Random random = new Random();
        private DateTime previousDate = DateTime.Today;

        public Page2()
        {
            InitializeComponent();
            CurrencyDatePicker.Date = DateTime.Today;
            UpdateCurrencyRates(DateTime.Today);
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            UpdateCurrencyRates(e.NewDate);
        }

        private void UpdateCurrencyRates(DateTime date)
        {
            double usdRate = 80.000;
            double eurRate = 86.000;

            if (date < previousDate)
            {
                double randomValue = random.NextDouble() * (2.450 - 0.100) + 0.100;
                usdRate -= randomValue;
                eurRate -= randomValue;
            }
            else if (date > previousDate)
            {
                double randomValue = random.NextDouble() * (2.450 - 0.100) + 0.100;
                usdRate += randomValue;
                eurRate += randomValue;
            }

            UsdRateLabel.Text = usdRate.ToString("N3");
            EurRateLabel.Text = eurRate.ToString("N3");
            previousDate = date;
        }
    }


}
