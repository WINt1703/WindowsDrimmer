using System;
using System.Diagnostics;
using System.Windows.Media;
using System.Windows.Forms;

namespace WindowsDimmer.Base
{
    public class ControlOverlayWindow : IDisposable
    {
        private Form _overlay;
        private Process _process;

        public ControlOverlayWindow(Form overlay, Process process)
        {
            this._overlay = overlay;
            this._process = process;
        }

        public void ShowOverlay() => _overlay.Show();

        public void HideOverlay() => _overlay.Hide();

        public void Dispose() => _overlay.Dispose();

        public void SetColorOverlay(Color color) => _overlay.BackColor = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);

        public void SetOpasity(double opacity) => this._overlay.Opacity = opacity / 100;

        public void InitOverlayWindow(Color color, double opacity)
        {
            _overlay.FormBorderStyle = FormBorderStyle.None;
            _overlay.SetBounds(0, 0, 0, 0, BoundsSpecified.Location);

            SetLocation();
            SetColorOverlay(color);
            SetOverlay();
            SetOpasity(opacity);
        }

        private void SetLocation()
        {
            int tmpwidth = 0;
            int tmpheight = 0;
            int tmpLocationX = 0;
            int tmpLocationY = 0;

            foreach (Screen tmpscr in Screen.AllScreens)
            {
                if (_overlay.Location.X > tmpscr.WorkingArea.Location.X)
                    tmpLocationX = tmpscr.WorkingArea.Location.X;
             
                if (_overlay.Location.Y > tmpscr.WorkingArea.Location.Y)
                    tmpLocationY = tmpscr.WorkingArea.Location.Y;
              
                tmpwidth += tmpscr.WorkingArea.Width;
                tmpheight += tmpscr.WorkingArea.Height;
            }

            _overlay.Width = tmpwidth;
            _overlay.Height = tmpheight;
        }

        private void SetOverlay()
        {
            NativeMethods.SetWindowLong(_overlay.Handle, NativeMethods.GWL_EXSTYLE,
                NativeMethods.GetWindowLong(_overlay.Handle, NativeMethods.GWL_EXSTYLE)
                | (int)ExtendedWindowStyles.WS_EX_LAYERED
                | (int)ExtendedWindowStyles.WS_EX_TRANSPARENT
                | (int)ExtendedWindowStyles.WS_EX_TOOLWINDOW);
            
            NativeMethods.SetParent(_overlay.Handle, _process.MainWindowHandle);
        }
    }
}
