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
        List<Employee> empList = Data.GetDataRecords();
        

        public NewPaymentPage()
        {
            this.InitializeComponent();
            lvEmps.Items.Clear();
            foreach (Employee emp in empList)
            {
                lvEmps.Items.Add(emp.ToString());
            }
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var test = lvEmps.SelectedItems;
            List<string> strEmp = new List<string>();
            string output = "";
            foreach (var t in test)
            {
                strEmp.Add(t.ToString());
            }
            foreach (string strE in strEmp)
            {
                output = strE.Substring(strE.Length - 10);
                foreach (Employee em in empList)
                {
                    if (em.Phone == output)
                    {
                        PayRoll pr = new PayRoll(dtpkPayment.Date.DateTime, em);
                        this.Frame.Navigate(typeof(MainPage));
                    }
                }
            }
            var message = new MessageDialog(output);
            await message.ShowAsync();
            //PayRoll pr = new PayRoll(dtpkPayment.Date.DateTime, );
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
