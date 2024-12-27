using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            InterestRateSlider.Value = 0;
            InterestRateValueLabel.Text = $"Значение: {InterestRateSlider.Value:F2}%";
        }

        public void SetUserName(string userName)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                WelcomeLabel.Text = $"Здравствуйте, {userName}";
            });
        }

        void OnInterestRateSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            InterestRateValueLabel.Text = $"Значение: {e.NewValue:F2}%";
        }

        void OnCalculateClicked(object sender, EventArgs e)
        {
            if (double.TryParse(LoanAmountEntry.Text, out double loanAmount) &&
                int.TryParse(LoanTermEntry.Text, out int loanTerm) &&
                LoanTermUnitPicker.SelectedIndex != -1 &&
                PaymentTypePicker.SelectedIndex != -1 &&
                CalculationTypePicker.SelectedIndex != -1)
            {
                double interestRate = InterestRateSlider.Value;
                double monthlyRate = interestRate / 100 / 12;
                int numberOfPayments = loanTerm * (LoanTermUnitPicker.SelectedIndex == 0 ? 1 : 12);

                double monthlyPayment = 0;
                double totalAmount = 0;
                double overpayment = 0;

                bool isAnnuity = CalculationTypePicker.SelectedIndex == 0;

                if (isAnnuity)
                {
                    monthlyPayment = loanAmount * monthlyRate / (1 - Math.Pow(1 + monthlyRate, -numberOfPayments));
                    totalAmount = monthlyPayment * numberOfPayments;
                    overpayment = totalAmount - loanAmount;
                }
                else
                {
                    double remainingPrincipal = loanAmount;
                    for (int i = 0; i < numberOfPayments; i++)
                    {
                        double interestPayment = remainingPrincipal * monthlyRate;
                        double principalPayment = monthlyPayment - interestPayment;
                        remainingPrincipal -= principalPayment;
                    }
                    totalAmount = loanAmount + (loanAmount * interestRate * loanTerm / 100);
                    overpayment = totalAmount - loanAmount;
                }

                bool isMonthlyPayment = PaymentTypePicker.SelectedIndex == 0;

                if (!isMonthlyPayment)
                {
                    monthlyPayment /= 12;
                    totalAmount /= 12;
                    overpayment /= 12;
                }

                MonthlyPaymentLabel.Text = $"{monthlyPayment:C}";
                TotalAmountLabel.Text = $"{totalAmount:C}";
                OverpaymentLabel.Text = $"{overpayment:C}";
            }
            else
            {
                MonthlyPaymentLabel.Text = "Неверные входные данные";
                TotalAmountLabel.Text = "Неверные входные данные";
                OverpaymentLabel.Text = "Неверные входные данные";
            }
        }

    }
}