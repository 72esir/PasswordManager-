using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.InteropServices;
using System.Windows.Controls;

public static class SecurePasswordHelper
{
    public static string GetPassword(PasswordBox passwordBox)
    {
        if (passwordBox == null)
            throw new ArgumentNullException(nameof(passwordBox));

        var secureString = passwordBox.SecurePassword;
        var ptr = Marshal.SecureStringToBSTR(secureString);
        try
        {
            return Marshal.PtrToStringBSTR(ptr);
        }
        finally
        {
            Marshal.ZeroFreeBSTR(ptr);
        }
    }
}
