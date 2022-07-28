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
    public sealed partial class EditPage : Page
    {
        private MessageDialog message;
        private Employee person;

        public EditPage()
        {
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                //extrace json string inside OnNavigateTo method
                base.OnNavigatedTo(e);
                string emp = e.Parameter.ToString();

                //set employee object to the employee by referencing the employee
                //list over in the mainpage
                person = MainPage.empList.FirstOrDefault(p => p.FirstName == MainPage.EmpName);

                //output values to the right text boxes
                txtFirst.Text = person.FirstName;
                txtLast.Text = person.LastName;
                txtSiN.Text = person.Sin;
                dtpInputDOB.Date = person.BirthDate;
                txtPhone.Text = person.Phone;
                txtStreet.Text = person.Address.Street;
                txtCity.Text = person.Address.City;
                txtProvince.Text = person.Address.Province;
                txtZip.Text = person.Address.PostalCode;
                txtEmail.Text = person.Email;


                if (person is Hourly)
                {
                    //set comployee combo box to hourly
                    cboEmployeeType.SelectedIndex = 0;
                    //disable some text boxes based on the type of employee
                    txtSalary.IsEnabled = false;
                    txtSalary.IsEnabled = false;
                    //declare a new class type and set
                    Hourly hourly = (Hourly)person;
                    //set hourly wages and rates to the appropriate text boxes
                    txtHourWorked.Text = hourly.Hours.ToString();
                    txtHourlyRate.Text = hourly.Rate.ToString();
                }
                if (person is Salary)
                {
                    //similar things just like in hourly
                    cboEmployeeType.SelectedIndex = 1;
                    txtHourWorked.IsEnabled = false;
                    txtHourlyRate.IsEnabled = false;
                    txtSalary.IsEnabled = true;
                    Salary salary = (Salary)person;
                    txtSalary.Text = salary.Amount.ToString();
                }
                if (person is SoftwareDev)
                {
                    cboEmployeeType.SelectedIndex = 2;
                    txtHourWorked.IsEnabled = false;
                    txtHourlyRate.IsEnabled = false;
                    txtSalary.IsEnabled = true;
                    SoftwareDev salary = (SoftwareDev)person;
                    txtSalary.Text = salary.Bi_Weekly.ToString();
                }
                if (person is SupplyManager)
                {
                    cboEmployeeType.SelectedIndex = 3;
                    txtHourWorked.IsEnabled = false;
                    txtHourlyRate.IsEnabled = false;
                    txtSalary.IsEnabled = true;
                    SupplyManager salary = (SupplyManager)person;
                    txtSalary.Text = salary.Salary.ToString();
                }
            }
            catch (Exception ex)
            {
                message = new MessageDialog(ex.Message);
                await message.ShowAsync();
            }
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //get class object of the employee from the employee list in main page
                person = MainPage.empList.FirstOrDefault(p => p.FirstName == MainPage.EmpName);
                if (person is Hourly)
                {
                    //for each employee type, where the employee have the same sin
                    //as the sin saved in mainpage, saved input data into emp object
                    foreach (Hourly emp in MainPage.empList.Where(p => p.FirstName == MainPage.EmpName))
                    {
                        emp.FirstName = txtFirst.Text;
                        emp.LastName = txtLast.Text;
                        emp.Sin = txtSiN.Text;
                        emp.BirthDate = dtpInputDOB.Date.Date;
                        emp.Phone = txtPhone.Text;
                        emp.Address = new Address
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            Province = txtProvince.Text,
                            PostalCode = txtZip.Text
                        };
                        emp.Email = txtEmail.Text;
                        emp.Hours = int.Parse(txtHourWorked.Text);
                        emp.Rate = decimal.Parse(txtHourlyRate.Text);
                    }
                }
                if (person is Salary)
                {
                    foreach (Salary emp in MainPage.empList.Where(p => p.FirstName == MainPage.EmpName))
                    {
                        emp.FirstName = txtFirst.Text;
                        emp.LastName = txtLast.Text;
                        emp.Sin = txtSiN.Text;
                        emp.BirthDate = dtpInputDOB.Date.Date;
                        emp.Phone = txtPhone.Text;
                        emp.Address = new Address
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            Province = txtProvince.Text,
                            PostalCode = txtZip.Text
                        };
                        emp.Email = txtEmail.Text;
                        emp.Amount = decimal.Parse(txtSalary.Text);
                    }
                }
                if (person is SoftwareDev)
                {
                    foreach (SoftwareDev emp in MainPage.empList.Where(p => p.FirstName == MainPage.EmpName))
                    {
                        emp.FirstName = txtFirst.Text;
                        emp.LastName = txtLast.Text;
                        emp.Sin = txtSiN.Text;
                        emp.BirthDate = dtpInputDOB.Date.Date;
                        emp.Phone = txtPhone.Text;
                        emp.Address = new Address
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            Province = txtProvince.Text,
                            PostalCode = txtZip.Text
                        };
                        emp.Email = txtEmail.Text;
                        emp.Bi_Weekly = decimal.Parse(txtSalary.Text);
                    }
                }
                if (person is SupplyManager)
                {
                    foreach (SupplyManager emp in MainPage.empList.Where(p => p.FirstName == MainPage.EmpName))
                    {
                        emp.FirstName = txtFirst.Text;
                        emp.LastName = txtLast.Text;
                        emp.Sin = txtSiN.Text;
                        emp.BirthDate = dtpInputDOB.Date.Date;
                        emp.Phone = txtPhone.Text;
                        emp.Address = new Address
                        {
                            Street = txtStreet.Text,
                            City = txtCity.Text,
                            Province = txtProvince.Text,
                            PostalCode = txtZip.Text
                        };
                        emp.Email = txtEmail.Text;
                        emp.Salary = decimal.Parse(txtSalary.Text);
                    }
                }
                this.Frame.Navigate(typeof(MainPage));
            }
            catch (Exception ex)
            {
                message = new MessageDialog(ex.Message);
                await message.ShowAsync();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
