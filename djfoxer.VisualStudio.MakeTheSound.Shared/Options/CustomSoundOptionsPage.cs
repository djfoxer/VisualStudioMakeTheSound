using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace djfoxer.VisualStudio.MakeTheSound.Shared.Options
{
    [ComVisible(true)]
    [Guid("84F13607-F9CC-4F88-A757-486638B51263")]
    public class CustomSoundOptionsPage : UIElementDialogPage
    {
        protected override UIElement Child
        {
            get
            {
                var page = new CustomSoundOptions
                {
                    customSoundOptionsPage = this
                };
                page.Initialize();
                return page;
            }
        } 
    }
}
