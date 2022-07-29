using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BusinessLogic;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PayrollApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewPaymentPage : Page
    {
        public NewPaymentPage()
        {
            this.InitializeComponent();
            lvEmps.Items.Clear();
            foreach (Employee emp in MainPage.empList)
            {
                lvEmps.Items.Add(emp.ToString());
            }
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var msg = new MessageDialog(lvEmps.SelectedItems.ToString());
            await msg.ShowAsync();
            var newEmpListForPR = new List<Employee>();
            foreach (Employee emp in MainPage.empList)
            {
                for (int i = 0; i < lvEmps.SelectedItems.Count; i++)
                {
                    if (lvEmps.SelectedItem.ToString().Contains(emp.FirstName))
                    {
                        newEmpListForPR.Add(emp);
                    }
                }
            }
            MainPage.newPR = new CalculatePayroll<Employee>(dtpkPayDate.Date.Date, newEmpListForPR);
            MainPage.Created = true;
            this.Frame.Navigate(typeof(MainPage));

            //if name selected = name in list
            //take the Employee object and add it into a new list
            //then take that new list and add it with the date into calculatepayroll class
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
