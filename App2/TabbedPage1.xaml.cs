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
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
        }

        public void SetUserName(string userName)
        {
            foreach (var page in this.Children)
            {
                if (page is Page1 page1)
                {
                    page1.SetUserName(userName);
                    break;
                }
            }
        }
    }
}