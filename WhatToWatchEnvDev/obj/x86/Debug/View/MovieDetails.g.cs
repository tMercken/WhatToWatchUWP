﻿#pragma checksum "C:\Users\client\Source\Repos\WhatToWatchUWP\WhatToWatchEnvDev\View\MovieDetails.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A51449ACFE86289BE987FFFF79ADC62C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WhatToWatchEnvDev.View
{
    partial class MovieDetails : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.SplitViewMenu = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 2:
                {
                    this.IconListBox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 25 "..\..\..\View\MovieDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.IconListBox).SelectionChanged += this.IconListBox_SelectionChanged;
                    #line default
                }
                break;
            case 3:
                {
                    this.HomeListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 4:
                {
                    this.SearchListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 5:
                {
                    this.CategoryListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 6:
                {
                    this.FavoriteListBoxItem = (global::Windows.UI.Xaml.Controls.ListBoxItem)(target);
                }
                break;
            case 7:
                {
                    this.MainFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 8:
                {
                    this.MoviePoster = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 9:
                {
                    this.MovieTitleLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10:
                {
                    this.MovieTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11:
                {
                    this.MoviePopularityLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 12:
                {
                    this.MoviePopularity = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13:
                {
                    this.MovieVoteLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 14:
                {
                    this.MovieVote = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15:
                {
                    this.AddFavorites = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 16:
                {
                    this.RemoveFavorites = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 17:
                {
                    this.Hambutton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 18 "..\..\..\View\MovieDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.Hambutton).Click += this.Hambutton_Click;
                    #line default
                }
                break;
            case 18:
                {
                    this.BackButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 19 "..\..\..\View\MovieDetails.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.BackButton).Click += this.BackButton_Click;
                    #line default
                }
                break;
            case 19:
                {
                    this.WhatToWatchTitle = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

