﻿#pragma checksum "..\..\..\..\tb\User\User.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A377458359A9C0D35A04320521BCFC08D589A95B52E7962927295B54E1DE04C3"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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
using System.Windows.Shell;
using 交易平台.tb.User;


namespace 交易平台.tb.User {
    
    
    /// <summary>
    /// User
    /// </summary>
    public partial class User : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image touxiang;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label 基本信息;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn1;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label 用户号;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox 昵称;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label 邮箱;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox 密码;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label 性别;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label 用户等级;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label 信誉等级;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\tb\User\User.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label 注册时间;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/交易平台;component/tb/user/user.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\tb\User\User.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.touxiang = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.基本信息 = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btn1 = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\tb\User\User.xaml"
            this.btn1.Click += new System.Windows.RoutedEventHandler(this.btn1_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.用户号 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.昵称 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.邮箱 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.密码 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.性别 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.用户等级 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.信誉等级 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.注册时间 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

