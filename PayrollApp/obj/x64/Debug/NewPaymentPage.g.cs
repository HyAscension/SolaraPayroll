﻿#pragma checksum "C:\Users\GiaHyMac\Documents\GitHub\SolaraPayroll\PayrollApp\NewPaymentPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BF5B0D5BC15D08A80E3FD8DEBBD3ECAC4A13022B174C3C13DCA927EC80A8A38B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PayrollApp
{
    partial class NewPaymentPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // NewPaymentPage.xaml line 15
                {
                    this.lvEmps = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 3: // NewPaymentPage.xaml line 17
                {
                    this.dtpkPayDate = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 4: // NewPaymentPage.xaml line 18
                {
                    this.btnSubmit = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnSubmit).Click += this.btnSubmit_Click;
                }
                break;
            case 5: // NewPaymentPage.xaml line 19
                {
                    this.btnCancel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnCancel).Click += this.btnCancel_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
