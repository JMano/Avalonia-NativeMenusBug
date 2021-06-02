using System;
using System.Diagnostics;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace Avalonia.TestNativeMenus.Views
{
    public class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);

            // var nativeMenu = NativeMenu.GetMenu(this);
            // if (nativeMenu == null) return;
            //
            // var item1 = new NativeMenuItem { Menu = new NativeMenu(), Header = "Item1" };
            // item1.Menu.Items.Add(new NativeMenuItem {Header = "Item-1-1", IsEnabled = true, IsChecked = false, Command = new CenasCommand() });
            // item1.Menu.Items.Add(new NativeMenuItem {Header = "Item-1-2", IsEnabled = false, Command = new CenasCommand()});
            // var item13 = new NativeMenuItem {Header = "Item-1-3", IsEnabled = true};
            // item13.Click += delegate { Debug.WriteLine("Item1-3-Cenas"); };
            // item1.Menu.Items.Add(item13);
            // var item14 = new NativeMenuItem {Header = "Item-1-3", IsEnabled = false};
            // item14.Click += delegate { Debug.WriteLine("Item1-4-Cenas"); };
            // item1.Menu.Items.Add(item14);
            //
            // var item2 = new NativeMenuItem { Menu = new NativeMenu(), Header = "Item2" };
            // item2.Menu.Items.Add(new NativeMenuItem {Header = "Item-2-1"});
            //
            // var item3 = new NativeMenuItem { Menu = new NativeMenu(), Header = "Item3" };
            // item3.Menu.Items.Add(new NativeMenuItem {Header = "Item-3-1"});
            // item3.Menu.Items.Add(new NativeMenuItem {Header = "Item-3-2", IsEnabled = true});
            //
            // nativeMenu.Items.Add(item1);
            // nativeMenu.Items.Add(item2);
            // nativeMenu.Items.Add(item3);
        }

        private void Button_OnClick_Dialog(object? sender, RoutedEventArgs e)
        {
            var dialogWindow = new DialogWindow();
            dialogWindow.ShowDialog(this);
        }

        private void Button_OnClick_Normal(object? sender, RoutedEventArgs e)
        {
            var dialogWindow = new DialogWindow();
            dialogWindow.Show(this);
        }
    }

    class CenasCommand : ICommand {
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Debug.WriteLine(("CENAS"));
        }

        public event EventHandler? CanExecuteChanged;
    }
}