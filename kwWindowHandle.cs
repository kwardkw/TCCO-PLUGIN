﻿#region Namespaces
using System;
using System.Diagnostics;
using System.Windows.Forms;
#endregion

namespace RoomEditorApp
{
    /// <summary>
    /// Wrapper class for converting 
    /// IntPtr to IWin32Window.
    /// </summary>
    public class kwWindowHandle : IWin32Window
    {
        IntPtr _hwnd;

        public kwWindowHandle(IntPtr h)
        {
            Debug.Assert(IntPtr.Zero != h,
              "expected non-null window handle");

            _hwnd = h;
        }

        public IntPtr Handle
        {
            get
            {
                return _hwnd;
            }
        }
    }
}
