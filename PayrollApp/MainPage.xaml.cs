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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PayrollApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Employee> empList = Data.GetDataRecords();

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
        }

        private void cboEmpType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvEmpList.Items.Clear();
            foreach (Employee emp in empList)
            {
                if (cboEmpType.SelectedItem.ToString() == "Hourly")
                {
                    if (emp is Hourly)
                    {
                        lvEmpList.Items.Add(emp.ToString());
                    }
                }
                else if (cboEmpType.SelectedItem.ToString() == "Salary")
                {
                    if (emp is Salary)
                    {
                        lvEmpList.Items.Add(emp.ToString());
                    }
                }
            }
        }
    }
}
