using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BusinessLogic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace PayrollApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPage : Page
    {
        private MessageDialog message;

        public AddPage()
        {
            this.InitializeComponent();
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //add input data into class object to be add into employee list,
                //based on index of employee type combo box
                switch (cboEmployeeType.SelectedIndex)
                {
                    case 0:
                        Hourly h = new Hourly(txtSiN.Text);
                        h.FirstName = txtFirst.Text;
                        h.LastName = txtLast.Text;
                        h.BirthDate = dtpInputDOB.Date.Date;
                        h.Phone = txtPhone.Text;
                        h.Address = new Address
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            Province = txtProvince.Text,
                            PostalCode = txtZip.Text
                        };
                        h.Email = txtEmail.Text;
                        h.Hours = int.Parse(txtHourWorked.Text);
                        h.Rate = decimal.Parse(txtHourlyRate.Text);
                        MainPage.empList.Add(h);
                        break;
                    case 1:
                        Salary s = new Salary(txtSiN.Text);
                        s.FirstName = txtFirst.Text;
                        s.LastName = txtLast.Text;
                        s.BirthDate = dtpInputDOB.Date.Date;
                        s.Phone = txtPhone.Text;
                        s.Address = new Address
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            Province = txtProvince.Text,
                            PostalCode = txtZip.Text
                        };
                        s.Email = txtEmail.Text;
                        s.Amount = decimal.Parse(txtSalary.Text);
                        MainPage.empList.Add(s);
                        break;
                    case 2:
                        SoftwareDev eng = new SoftwareDev(txtSiN.Text, decimal.Parse(txtSalary.Text));
                        eng.FirstName = txtFirst.Text;
                        eng.LastName = txtLast.Text;
                        eng.BirthDate = dtpInputDOB.Date.Date;
                        eng.Phone = txtPhone.Text;
                        eng.Address = new Address
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            Province = txtProvince.Text,
                            PostalCode = txtZip.Text
                        };
                        eng.Email = txtEmail.Text;
                        MainPage.empList.Add(eng);
                        break;
                    case 3:
                        SupplyManager g = new SupplyManager(txtSiN.Text, decimal.Parse(txtSalary.Text));
                        g.FirstName = txtFirst.Text;
                        g.LastName = txtLast.Text;
                        g.BirthDate = dtpInputDOB.Date.Date;
                        g.Phone = txtPhone.Text;
                        g.Address = new Address
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            Province = txtProvince.Text,
                            PostalCode = txtZip.Text
                        };
                        g.Email = txtEmail.Text;
                        MainPage.empList.Add(g);
                        break;
                }
            }
            catch (Exception ex)
            {
                message = new MessageDialog(ex.Message);
                await message.ShowAsync();
            }
            this.Frame.Navigate(typeof(MainPage));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void cboEmployeeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //disable text boxes based on the selected employee type
                switch (cboEmployeeType.SelectedIndex)
                {
                    case 0:
                        txtHourWorked.IsEnabled = true;
                        txtHourlyRate.IsEnabled = true;
                        txtSalary.IsEnabled = false;
                        break;
                    case 1:
                        txtHourWorked.IsEnabled = false;
                        txtHourlyRate.IsEnabled = false;
                        txtSalary.IsEnabled = true;
                        break;
                    case 2:
                        txtHourWorked.IsEnabled = false;
                        txtHourlyRate.IsEnabled = false;
                        txtSalary.IsEnabled = true;
                        break;
                    case 3:
                        txtHourWorked.IsEnabled = false;
                        txtHourlyRate.IsEnabled = false;
                        txtSalary.IsEnabled = true;
                        break;
                    default:
                        throw new Exception("Select type of employee!");
                }
            }
            catch (Exception ex)
            {
                message = new MessageDialog(ex.Message);
                await message.ShowAsync();
            }
        }
    }
}
