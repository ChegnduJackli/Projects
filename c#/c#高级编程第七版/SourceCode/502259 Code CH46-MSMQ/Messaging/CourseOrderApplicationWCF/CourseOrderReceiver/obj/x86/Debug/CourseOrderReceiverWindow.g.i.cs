﻿#pragma checksum "..\..\..\CourseOrderReceiverWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E6C83E572B1C5854771736EFBC16D27F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.20506.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Wrox.ProCSharp.Messaging {
    
    
    /// <summary>
    /// CourseOrderReceiverWindow
    /// </summary>
    public partial class CourseOrderReceiverWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.Label labelOrders;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.ListBox listOrders;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.Label labelCourse;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.Label labelCompany;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.Label labelContact;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.TextBox textCourse;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.TextBox textCompany;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.TextBox textContact;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.Label labelPriority;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\CourseOrderReceiverWindow.xaml"
        internal System.Windows.Controls.Button buttonProcessOrder;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CourseOrderReceiver;component/courseorderreceiverwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CourseOrderReceiverWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.labelOrders = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.listOrders = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.labelCourse = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.labelCompany = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.labelContact = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.textCourse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.textCompany = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.textContact = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.labelPriority = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.buttonProcessOrder = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\CourseOrderReceiverWindow.xaml"
            this.buttonProcessOrder.Click += new System.Windows.RoutedEventHandler(this.buttonProcessOrder_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
