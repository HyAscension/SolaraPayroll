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
using System.Text.Json;
using BusinessLogic;
using Windows.UI.Popups;
using Windows.Globalization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PayrollApp
{
    public class PayRoll
    {
        private DateTime paydate;
        private List<Employee> e;
        

        public string TotalAll
        {
            get
            {
                DateTime payDate = DateTime.Today;
                int totalEmp = 0;
                decimal totalPay = 0;
                decimal totalBonus = 0;
                decimal totalDeductions = 0;
                foreach (Employee emps in e)
                {
                    totalEmp++;
                    totalPay += emps.CalculatePay();
                    totalBonus += emps.Bonus();
                    totalDeductions += emps.IncomeTax(emps.CalculatePay());
                }

                return $"Employee Count: {totalEmp} | Net Pay: ${Math.Round(totalPay, 2)} | Net Bonus: ${Math.Round(totalBonus, 2)} | Net Deductions: ${Math.Round(totalDeductions, 2)}";
            }
        }

        public PayRoll(DateTime current, Employee emps)
        {
            paydate = current;
            e.Add(emps);
        }

        public List<string> ProcessPayRoll()
        {
            List<string> fullInfo = new List<string>();
            foreach (Employee emps in e)
            {
                fullInfo.Add($"{emps.Sin} {emps.FirstName} {emps.LastName} - Net: ${Math.Round(emps.CalculatePay(), 2)} - Bonus: ${Math.Round(emps.Bonus(), 2)} - Deductions: ${Math.Round(emps.IncomeTax(emps.CalculatePay()), 2)}");
            }
            return fullInfo;
        }
    }

    public sealed partial class MainPage : Page
    {
        public static List<Employee> empList = Data.GetDataRecords();
        public static string EmpName { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            cboEmpType.Items.Add("");
            cboEmpType.Items.Add("Hourly");
            cboEmpType.Items.Add("Salary");
            cboEmpType.Items.Add("Software Developer");
            cboEmpType.Items.Add("Supply Manager");
            foreach (Employee emp in empList)
            {
                lvEmpList.Items.Add(emp.ToString());
            }

            //PayRoll roll = new PayRoll(DateTime.Now, empList);
            //List<string> pr = roll.ProcessPayRoll();
            //for (int i = 0; i < empList.Count; i++)
            //{
            //    lvStatements.Items.Add(pr[i]);
            //}
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
                    EmpName = emp.FirstName;
                    Employee person = empList.FirstOrDefault(p => p.FirstName == EmpName);
                    string jsonE = JsonSerializer.Serialize<Employee>(person);
                    this.Frame.Navigate(typeof(EditPage), jsonE);
                }
            }
            
        }

        private async void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //just switch over to the new page
                this.Frame.Navigate(typeof(AddPage));
            }
            catch (Exception ex)
            {
                MessageDialog message = new MessageDialog(ex.Message);
                await message.ShowAsync();
            }
        }

        private void lvTimesheet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnNewPayment_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewPaymentPage));
        }
    }
}
