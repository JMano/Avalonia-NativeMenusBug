using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.LogicalTree;
using Avalonia.Markup.Xaml;

namespace Avalonia.TestNativeMenus.Views
{
    public class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);

            // var parentWindow = Owner;
            // if (parentWindow == null) return;
            //
            // var parentMenu = NativeMenu.GetMenu(parentWindow);
            // if (parentMenu == null) return;
            //
            // var nativeMenu = NativeMenu.GetMenu(this);
            // if (nativeMenu == null) return;
            //
            // nativeMenu.Items.Clear();
            //
            // CopyNativeMenu(parentMenu, nativeMenu);
        }
        
        private void CopyNativeMenu(NativeMenu originalNativeMenu, NativeMenu nativeMenu) {
            foreach (var item in originalNativeMenu.Items)
            {
                if (item is not NativeMenuItem originalNativeMenuItem) continue;

                var nativeMenuItem = new NativeMenuItem
                {
                    Header = $"{originalNativeMenuItem.Header}-inner",
                    IsEnabled = originalNativeMenuItem.IsEnabled,
                    Command = originalNativeMenuItem.Command
                };
                nativeMenu.Items.Add(nativeMenuItem);

                if (originalNativeMenuItem.Menu == null) continue;

                nativeMenuItem.Menu = new NativeMenu();
                CopyNativeMenu(originalNativeMenuItem.Menu, nativeMenuItem.Menu);
            }
        }
    }
}