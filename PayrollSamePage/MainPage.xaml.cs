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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PayrollSamePage
{
    public sealed partial class MainPage : Page
    {
        public static List<Employee> empList = Data.GetDataRecords();
        public Employee selectedPerson;
        public static bool Created = false;

        public static string EmpName { get; set; }

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
            btnCancel.IsEnabled = false;

            cboEmpType.Items.Add("");
            cboEmpType.Items.Add("Hourly");
            cboEmpType.Items.Add("Salary");
            cboEmpType.Items.Add("Software Developer");
            cboEmpType.Items.Add("Supply Manager");
            lvEmpList.Items.Clear();
            foreach (Employee emp in empList)
            {
                lvEmpList.Items.Add(emp.ToString());
            }

            if (Created == true)
            {
                //txtPaymentDate.Text = $"Payment Date: {newPR.PayDate.Date}";
                //lvStatements.ItemsSource = newPR.ProcessPayRoll();
            }
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
            foreach (Employee emp in empList)
            {
                if (lvEmpList.SelectedItem.ToString().Contains(emp.FirstName))
                {
                    cboEmpType.IsEnabled = false;
                    tbxEmpName.IsEnabled = false;
                    dtpkHiredDate.IsEnabled = false;
                    btnAddNew.IsEnabled = false;
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
                    btnCancel.IsEnabled = true;

                    EmpName = emp.FirstName;
                    selectedPerson = empList.FirstOrDefault(p => p.FirstName == EmpName);
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

        private async void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //just switch over to the new page
                //this.Frame.Navigate(typeof(AddPage));
            }
            catch (Exception ex)
            {
                //MessageDialog message = new MessageDialog(ex.Message);
                //await message.ShowAsync();
            }
        }

        private void btnNewpayroll_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(NewPaymentPage));
        }

        private void lvStatements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPerson is Hourly)
            {
                //for each employee type, where the employee have the same sin
                //as the sin saved in mainpage, saved input data into emp object
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

            cboEmpType.IsEnabled = true;
            tbxEmpName.IsEnabled = true;
            dtpkHiredDate.IsEnabled = true;
            btnAddNew.IsEnabled = true;
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
            btnCancel.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            cboEmpType.IsEnabled = true;
            tbxEmpName.IsEnabled = true;
            dtpkHiredDate.IsEnabled = true;
            btnAddNew.IsEnabled = true;
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
            btnCancel.IsEnabled = false;
        }
    }
}
