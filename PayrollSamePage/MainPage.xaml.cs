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
using Windows.UI.ViewManagement;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PayrollSamePage
{
    public sealed partial class MainPage : Page
    {
        private static List<Employee> empList = Data.GetDataRecords();
        private Employee selectedPerson;

        private int ID { get; set; }
        private string EmpName { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            txtFirst.IsEnabled = false;
            txtLast.IsEnabled = false;
            txtSiN.IsEnabled = false;
            dtpInputDOB.IsEnabled = false;
            txtPhone.IsEnabled = false;
            txtStreet.IsEnabled = false;
            txtCity.IsEnabled = false;
            txtProvince.IsEnabled = false;
            txtZip.IsEnabled = false;
            txtEmail.IsEnabled = false;

            cboEmployeeType.IsEnabled = false;
            txtSalary.IsEnabled = false;
            txtHourWorked.IsEnabled = false;
            txtHourlyRate.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnAddNew.IsEnabled = false;
            btnCancel.IsEnabled = false;

            btnAddNew.Visibility = Visibility.Collapsed;

            cboEmpType.ItemsSource = new string[] { "", "Hourly", "Salary", "Software Developer", "Supply Manager" };
            lvEmpList.Items.Clear();
            lvEmpList.ItemsSource = empList;

        }

        private void cboEmpType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvEmpList.Items.Clear();
            foreach (Employee emp in empList)
            {
                if (cboEmpType.SelectedItem.ToString() == "Hourly")
                {
                    if (emp is Hourly)
                        lvEmpList.Items.Add(emp.ToString());
                }
                else if (cboEmpType.SelectedItem.ToString() == "Salary")
                {
                    if (emp is Salary)
                        lvEmpList.Items.Add(emp.ToString());
                }
                else if (cboEmpType.SelectedItem.ToString() == "Software Developer")
                {
                    if (emp is SoftwareDev)
                        lvEmpList.Items.Add(emp.ToString());
                }
                else if (cboEmpType.SelectedItem.ToString() == "Supply Manager")
                {
                    if (emp is SupplyManager)
                        lvEmpList.Items.Add(emp.ToString());
                }
                else
                {
                    lvEmpList.Items.Add(emp.ToString());
                }
            }
        }
        
        private void tbxEmpName_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvEmpList.Items.Clear();
            foreach (Employee emp in empList)
            {
                if (tbxEmpName.Text == emp.FirstName || tbxEmpName.Text == emp.LastName)
                {
                    lvEmpList.Items.Add(emp.ToString());
                }
                else if (tbxEmpName.Text == String.Empty)
                {
                    lvEmpList.Items.Add(emp.ToString());
                }
            }
        }

        private void dtpkHiredDate_SelectedDateChanged(DatePicker sender, DatePickerSelectedValueChangedEventArgs args)
        {
            lvEmpList.Items.Clear();
            foreach (Employee emp in empList)
            {
                if (dtpkHiredDate.Date.Date == emp.HireDate)
                {
                    lvEmpList.Items.Add(emp.ToString());
                }
            }
        }

        private void lvEmpList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboEmpType.IsEnabled = false;
            tbxEmpName.IsEnabled = false;
            dtpkHiredDate.IsEnabled = false;
            btnCreateNew.IsEnabled = false;
            lvEmpList.IsEnabled = false;

            txtFirst.IsEnabled = true;
            txtLast.IsEnabled = true;
            txtSiN.IsEnabled = true;
            dtpInputDOB.IsEnabled = true;
            txtPhone.IsEnabled = true;
            txtStreet.IsEnabled = true;
            txtCity.IsEnabled = true;
            txtProvince.IsEnabled = true;
            txtZip.IsEnabled = true;
            txtEmail.IsEnabled = true;

            cboEmployeeType.IsEnabled = true;
            txtSalary.IsEnabled = true;
            txtHourWorked.IsEnabled = true;
            txtHourlyRate.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnAddNew.IsEnabled = true;
            btnCancel.IsEnabled = true;

            for (int i = 0; i < lvEmpList.Items.Count; i++)
            {
                if (lvEmpList.SelectedIndex == i)
                {
                    selectedPerson = empList[i];
                    EmpName = empList[i].FirstName;
                    //string jsonE = JsonSerializer.Serialize<Employee>(person);
                    //this.Frame.Navigate(typeof(EditPage), jsonE);
                    txtFirst.Text = selectedPerson.FirstName;
                    txtLast.Text = selectedPerson.LastName;
                    txtSiN.Text = selectedPerson.Sin;
                    dtpInputDOB.Date = selectedPerson.BirthDate;
                    txtPhone.Text = selectedPerson.Phone;
                    txtStreet.Text = selectedPerson.Address.Street;
                    txtCity.Text = selectedPerson.Address.City;
                    txtProvince.Text = selectedPerson.Address.Province;
                    txtZip.Text = selectedPerson.Address.PostalCode;
                    txtEmail.Text = selectedPerson.Email;

                    if (selectedPerson is Hourly)
                    {
                        //set comployee combo box to hourly
                        cboEmployeeType.SelectedIndex = 0;
                        //disable some text boxes based on the type of employee
                        txtSalary.IsEnabled = false;
                        txtSalary.IsEnabled = false;
                        //declare a new class type and set
                        Hourly hourly = (Hourly)selectedPerson;
                        //set hourly wages and rates to the appropriate text boxes
                        txtHourWorked.Text = hourly.Hours.ToString();
                        txtHourlyRate.Text = hourly.Rate.ToString();
                    }
                    if (selectedPerson is Salary)
                    {
                        //similar things just like in hourly
                        cboEmployeeType.SelectedIndex = 1;
                        txtHourWorked.IsEnabled = false;
                        txtHourlyRate.IsEnabled = false;
                        txtSalary.IsEnabled = true;
                        Salary salary = (Salary)selectedPerson;
                        txtSalary.Text = salary.Amount.ToString();
                    }
                    if (selectedPerson is SoftwareDev)
                    {
                        cboEmployeeType.SelectedIndex = 2;
                        txtHourWorked.IsEnabled = false;
                        txtHourlyRate.IsEnabled = false;
                        txtSalary.IsEnabled = true;
                        SoftwareDev salary = (SoftwareDev)selectedPerson;
                        txtSalary.Text = salary.Bi_Weekly.ToString();
                    }
                    if (selectedPerson is SupplyManager)
                    {
                        cboEmployeeType.SelectedIndex = 3;
                        txtHourWorked.IsEnabled = false;
                        txtHourlyRate.IsEnabled = false;
                        txtSalary.IsEnabled = true;
                        SupplyManager salary = (SupplyManager)selectedPerson;
                        txtSalary.Text = salary.Salary.ToString();
                    }

                }
            }
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e)
        {
            cboEmpType.IsEnabled = false;
            tbxEmpName.IsEnabled = false;
            dtpkHiredDate.IsEnabled = false;
            btnCreateNew.IsEnabled = false;
            lvEmpList.IsEnabled = false;

            txtFirst.IsEnabled = true;
            txtLast.IsEnabled = true;
            txtSiN.IsEnabled = true;
            dtpInputDOB.IsEnabled = true;
            txtPhone.IsEnabled = true;
            txtStreet.IsEnabled = true;
            txtCity.IsEnabled = true;
            txtProvince.IsEnabled = true;
            txtZip.IsEnabled = true;
            txtEmail.IsEnabled = true;

            cboEmployeeType.IsEnabled = true;
            txtSalary.IsEnabled = true;
            txtHourWorked.IsEnabled = true;
            txtHourlyRate.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnAddNew.IsEnabled = true;
            btnCancel.IsEnabled = true;

            txtFirst.Text = "Gia Hy";
            txtLast.Text = "Vo";
            txtSiN.Text = "123456789";
            dtpInputDOB.Date = DateTime.Parse("5/18/2001");
            txtPhone.Text = "0987654321";
            txtStreet.Text = "3938 Wellington St";
            txtCity.Text = "Ottawa";
            txtProvince.Text = "ON";
            txtZip.Text = "K1A 0A2";
            txtEmail.Text = "vogiahy@gmail.com";

            txtSalary.Text = "6800";
            txtHourWorked.Text = String.Empty;
            txtHourlyRate.Text = String.Empty;

            btnUpdate.Visibility = Visibility.Collapsed;
            btnAddNew.Visibility = Visibility.Visible;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPerson is Hourly)
            {
                foreach (Hourly emp in empList.Where(p => p.FirstName == EmpName))
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
            if (selectedPerson is Salary)
            {
                foreach (Salary emp in empList.Where(p => p.FirstName == EmpName))
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
            if (selectedPerson is SoftwareDev)
            {
                foreach (SoftwareDev emp in empList.Where(p => p.FirstName == EmpName))
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
            if (selectedPerson is SupplyManager)
            {
                foreach (SupplyManager emp in empList.Where(p => p.FirstName == EmpName))
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
            lvEmpList.ItemsSource = null;
            lvEmpList.ItemsSource = empList;

            cboEmpType.IsEnabled = true;
            tbxEmpName.IsEnabled = true;
            dtpkHiredDate.IsEnabled = true;
            btnCreateNew.IsEnabled = true;
            lvEmpList.IsEnabled = true;

            txtFirst.IsEnabled = false;
            txtLast.IsEnabled = false;
            txtSiN.IsEnabled = false;
            dtpInputDOB.IsEnabled = false;
            txtPhone.IsEnabled = false;
            txtStreet.IsEnabled = false;
            txtCity.IsEnabled = false;
            txtProvince.IsEnabled = false;
            txtZip.IsEnabled = false;
            txtEmail.IsEnabled = false;

            cboEmployeeType.IsEnabled = false;
            txtSalary.IsEnabled = false;
            txtHourWorked.IsEnabled = false;
            txtHourlyRate.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnAddNew.IsEnabled = false;
            btnCancel.IsEnabled = false;
        }

        private async void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cboEmployeeType.SelectedIndex < 0)
                {
                    throw new Exception("Please pick a type of employee.");
                }
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
                        empList.Add(h);
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
                        empList.Add(s);
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
                        empList.Add(eng);
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
                        empList.Add(g);
                        break;
                }

                lvEmpList.ItemsSource = null;
                lvEmpList.ItemsSource = empList;

                btnUpdate.Visibility = Visibility.Visible;
                btnAddNew.Visibility = Visibility.Collapsed;

                cboEmpType.IsEnabled = true;
                tbxEmpName.IsEnabled = true;
                dtpkHiredDate.IsEnabled = true;
                btnCreateNew.IsEnabled = true;
                lvEmpList.IsEnabled = true;

                txtFirst.IsEnabled = false;
                txtLast.IsEnabled = false;
                txtSiN.IsEnabled = false;
                dtpInputDOB.IsEnabled = false;
                txtPhone.IsEnabled = false;
                txtStreet.IsEnabled = false;
                txtCity.IsEnabled = false;
                txtProvince.IsEnabled = false;
                txtZip.IsEnabled = false;
                txtEmail.IsEnabled = false;

                cboEmployeeType.IsEnabled = false;
                txtSalary.IsEnabled = false;
                txtHourWorked.IsEnabled = false;
                txtHourlyRate.IsEnabled = false;
                btnUpdate.IsEnabled = false;
                btnAddNew.IsEnabled = false;
                btnCancel.IsEnabled = false;
            }
            catch (Exception ex)
            {
                var message = new MessageDialog(ex.Message);
                await message.ShowAsync();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            lvEmpList.SelectedIndex = -1;

            cboEmpType.IsEnabled = true;
            tbxEmpName.IsEnabled = true;
            dtpkHiredDate.IsEnabled = true;
            btnCreateNew.IsEnabled = true;
            lvEmpList.IsEnabled = true;

            txtFirst.IsEnabled = false;
            txtLast.IsEnabled = false;
            txtSiN.IsEnabled = false;
            dtpInputDOB.IsEnabled = false;
            txtPhone.IsEnabled = false;
            txtStreet.IsEnabled = false;
            txtCity.IsEnabled = false;
            txtProvince.IsEnabled = false;
            txtZip.IsEnabled = false;
            txtEmail.IsEnabled = false;

            cboEmployeeType.IsEnabled = false;
            txtSalary.IsEnabled = false;
            txtHourWorked.IsEnabled = false;
            txtHourlyRate.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnAddNew.IsEnabled = false;
            btnCancel.IsEnabled = false;
        }

        private void cboEmployeeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
                    throw new Exception("Please pick a type of employee.");
            }
        }

        private void btnNewpayroll_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(NewPaymentPage));
        }

        private void lvStatements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
