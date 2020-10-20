using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace AccountingSystemUI.CustomizeWindow
{
    public static class WindowCustomizer
    {
        
        public static readonly DependencyProperty CanMaximize =
            DependencyProperty.RegisterAttached("CanMaximize", typeof(bool), typeof(Window),
                new PropertyMetadata(true, new PropertyChangedCallback(OnCanMaximizeChanged)));
        private static void OnCanMaximizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window window = d as Window;
            if (window != null)
            {
                RoutedEventHandler loadedHandler = null;
                loadedHandler = delegate
                {
                    if ((bool)e.NewValue)
                    {
                        WindowHelper.EnableMaximize(window);
                    }
                    else
                    {
                        WindowHelper.DisableMaximize(window);
                    }
                    window.Loaded -= loadedHandler;
                };

                if (!window.IsLoaded)
                {
                    window.Loaded += loadedHandler;
                }
                else
                {
                    loadedHandler(null, null);
                }
            }
        }
        public static void SetCanMaximize(DependencyObject d, bool value)
        {
            d.SetValue(CanMaximize, value);
        }
        public static bool GetCanMaximize(DependencyObject d)
        {
            return (bool)d.GetValue(CanMaximize);
        }
                
        public static class WindowHelper
        {
            private const Int32 GWL_STYLE = -16;
            private const Int32 WS_MAXIMIZEBOX = 0x00010000;

            [DllImport("User32.dll", EntryPoint = "GetWindowLong")]
            private extern static Int32 GetWindowLongPtr(IntPtr hWnd, Int32 nIndex);

            [DllImport("User32.dll", EntryPoint = "SetWindowLong")]
            private extern static Int32 SetWindowLongPtr(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);

            /// <summary>
            /// Disables the maximize functionality of a WPF window.
            /// </summary>
            ///The WPF window to be modified.
            public static void DisableMaximize(Window window)
            {
                lock (window)
                {
                    IntPtr hWnd = new WindowInteropHelper(window).Handle;
                    Int32 windowStyle = GetWindowLongPtr(hWnd, GWL_STYLE);
                    SetWindowLongPtr(hWnd, GWL_STYLE, windowStyle & ~WS_MAXIMIZEBOX);
                }
            }
            /// <summary>
            /// Enables the maximize functionality of a WPF window.
            /// </summary>
            ///The WPF window to be modified.
            public static void EnableMaximize(Window window)
            {
                lock (window)
                {
                    IntPtr hWnd = new WindowInteropHelper(window).Handle;
                    Int32 windowStyle = GetWindowLongPtr(hWnd, GWL_STYLE);
                    SetWindowLongPtr(hWnd, GWL_STYLE, windowStyle | WS_MAXIMIZEBOX);
                }
            }

            /// <summary>
            /// Toggles the enabled state of a WPF window's maximize functionality.
            /// </summary>
            ///The WPF window to be modified.
            public static void ToggleMaximize(Window window)
            {
                lock (window)
                {
                    IntPtr hWnd = new WindowInteropHelper(window).Handle;
                    Int32 windowStyle = GetWindowLongPtr(hWnd, GWL_STYLE);

                    if ((windowStyle | WS_MAXIMIZEBOX) == windowStyle)
                    {
                        SetWindowLongPtr(hWnd, GWL_STYLE, windowStyle & ~WS_MAXIMIZEBOX);
                    }
                    else
                    {
                        SetWindowLongPtr(hWnd, GWL_STYLE, windowStyle | WS_MAXIMIZEBOX);
                    }
                }
            }

          
        }
        
    }
}
