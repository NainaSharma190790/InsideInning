using System;
using System.Collections.Generic;
using System.Text;

namespace InsideInning.Helper
{
    public struct Color
    {
        public static readonly Color Purple = 0xB455B6;
        public static readonly Color Blue = 0x3498DB;
        public static readonly Color DarkBlue = 0x2C3E50;
        public static readonly Color Green = 0x2E2EFE;
        public static readonly Color Gray = 0x738182;
        public static readonly Color LightGray = 0xB4BCBC;
        public static readonly Color Pink = 0xFF0040;
        public static readonly Color White = 0xFFFFFF;
        public static readonly Color iiGreen = 0x00ff00;
        public static readonly Color iiPurple = 0x0732a2;
        public static readonly Color iiEditTextColor = 0x2d5be3;
        public static readonly Color iiTextColor = 0x86a183;
        public static readonly Color Transparent = 0x00000000;
        public static readonly Color Lime = 0x6bf215;
        public static readonly Color LightRed = 0x0ff6666; // 0x00d4bb;
        public static readonly Color LightGreen = 0x00d4bb; 

        public double R, G, B;

        public static Color FromHex(int hex)
        {
            Func<int, int> at = offset => (hex >> offset) & 0xFF;
            return new Color
            {
                R = at(16) / 255.0,
                G = at(8) / 255.0,
                B = at(0) / 255.0
            };
        }

        public static implicit operator Color(int hex)
        {
            return FromHex(hex);
        }

        public Xamarin.Forms.Color ToFormsColor()
        {
            return Xamarin.Forms.Color.FromRgb((int)(255 * R), (int)(255 * G), (int)(255 * B));
        }

#if __ANDROID__
        public global::Android.Graphics.Color ToAndroidColor()
        {
            return global::Android.Graphics.Color.Rgb((int)(255 * R), (int)(255 * G), (int)(255 * B));
        }

        public static implicit operator global::Android.Graphics.Color(Color color)
        {
            return color.ToAndroidColor();
        }
#endif
    }
}

