using finYcurs.Frame;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace finYcurs
{
    public partial class MainWin : Window
    {
        private List<Window> childWindows = new List<Window>();
        public MainWin()
        {
            InitializeComponent();
            forms.WindowIntro winint = new forms.WindowIntro();
          //  winint.Owner = this;
            winint.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            winint.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            // Установите второе окно поверх всех других окон
            winint.Topmost = true;
            winint.Show();
            childWindows.Add(winint);
            this.Closed += MainWindow_Closed;

            // Ниже все для того чтобы разобраться с Комбобоксом выбора месяца
            // Устанавливаем источник данных для месяца
            monthComboBox.ItemsSource = DateTimeFormatInfo.CurrentInfo.MonthNames;

            // Устанавливаем текущий месяц в комбо-бокс
            monthComboBox.SelectedIndex = DateTime.Now.Month - 1;


        }
        private void MainWindow_Closed(object sender, EventArgs e)
        {
            foreach (var childWindow in childWindows)
            {
                childWindow.Close();
            }
        }
        private void OpenContextMenu()
        {
            // Обработка команды открытия контекстного меню
            if (ContextMenu != null)
            {
                ContextMenu.IsOpen = true;
            }
        }
        private void DatePicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                datePicker.IsDropDownOpen = false;
            }
        }


        private void Button_MouseUp(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Проверяем, что контекстное меню для кнопки не является null
                if (button.ContextMenu != null)
                {
                    // Открываем или закрываем контекстное меню в зависимости от его текущего состояния
                    button.ContextMenu.IsOpen = !button.ContextMenu.IsOpen;
                }
            }
        }


        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
                return null;

            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            // Копирование выбранного текста в буфер обмена
            if (tbforcopy.SelectedText.Length > 0)
                Clipboard.SetText(tbforcopy.SelectedText);
        }

        private void CutButton_Click(object sender, RoutedEventArgs e)
        {
            // Вырезание выбранного текста в буфер обмена и удаление из текстового поля
            if (tbforcopy.SelectedText.Length > 0)
            {
                Clipboard.SetText(tbforcopy.SelectedText);
                tbforcopy.SelectedText = string.Empty;
            }
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            TabItem current = (TabItem)MainTab.SelectedItem;
            current.Visibility = Visibility.Collapsed;
        }


        private void PasteButton_Click(object sender, RoutedEventArgs e)
        {
            // Вставка текста из буфера обмена
            tbforcopy.SelectedText = Clipboard.GetText();
        }

        private TabItem JurnalTab;
        private bool isJurnalTabCreated = false;
        private TabItem MoveMoneyTab;
        private bool isMoveMoneyCreated = false;
        private TabItem AccoutTab;
        private bool isAccoutCreated = false;
        private TabItem BankInTab;
        private bool isBankInTabCreated = false;
        private TabItem BankOutTab;
        private bool isBankOutCreated = false;
        private TabItem CashboxTab;
        private bool isCashboxCreated = false;
        private TabItem EmproyeesTab;
        private bool isEmproyeesCreated = false;
        private TabItem CalculationSalaryTab;
        private bool isCalculationSalaryCreated = false;
        private TabItem IssueSalaryTab;
        private bool isIssueSalaryCreated = false;
        private TabItem OSandNMATab;
        private bool isOSandNMACreated = false;

        private void clickcreate(object sender, RoutedEventArgs e)
        {

            MainTab.Visibility = Visibility.Visible;
            TabItem tab_item = new TabItem();

            MenuItem clickedMenuItem = sender as MenuItem;
            if (clickedMenuItem != null)
            {
                if (clickedMenuItem.Name == "JurnalBut")
                {
                    if (!isJurnalTabCreated)
                    {
                        Button closeButton = new Button();
                        closeButton.Content = "X";
                        closeButton.Click += CloseTabButtonClick;
                        closeButton.Margin = new Thickness(5, -5, -5, -6);
                        closeButton.Style = (Style)FindResource("CloseButtonStyle");
                        JurnalTab = new TabItem();
                        JurnalTab.IsSelected = true;
                        JurnalTab.Name = "JurnalTab";
                        JurnalTab.SetResourceReference(TabItem.StyleProperty, "TabItemStyle");
                        JurnalTab.PreviewMouseDown += TB_ChangedFrame;
                        StackPanel headerPanel = new StackPanel();
                        headerPanel.Orientation = Orientation.Horizontal;
                        headerPanel.Children.Add(new TextBlock { Text = "Журнал" });
                        headerPanel.Children.Add(closeButton);
                        JurnalTab.Header = headerPanel;
                        MainTab.Items.Add(JurnalTab);
                        MainFrame.Content = new PageJurnal();
                        isJurnalTabCreated = true;
                    }


                }
                else if (clickedMenuItem.Name == "MoveMoneyBut")
                {
                    if (!isMoveMoneyCreated)
                    {

                        //создание кнопки на вкладке
                        Button closeButton = new Button();
                        closeButton.Content = "X";
                        closeButton.Click += CloseTabMoveClick;
                        closeButton.Margin = new Thickness(0, 0, 0, -6);
                        closeButton.Style = (Style)FindResource("CloseButtonStyle");
                        //добавление вкладки
                        MoveMoneyTab = new TabItem();
                        MoveMoneyTab.IsSelected = true;
                        //создание стакпанел, где вместе компануется название и кнопка
                        StackPanel headerPanel = new StackPanel();
                        headerPanel.Orientation = Orientation.Horizontal;
                        headerPanel.Children.Add(new TextBlock { Text = "Движение ценностей и услуг" });
                        headerPanel.Children.Add(closeButton);
                        MoveMoneyTab.Header = headerPanel;
                        // в табконтрол добавляется новая вклдака
                        MainTab.Items.Add(MoveMoneyTab);
                        //привязываем стиль
                        MoveMoneyTab.SetResourceReference(TabItem.StyleProperty, "TabItemStyle");
                        MainFrame.Content = new PageMoveMoney();
                        //часть для создания ограничения по кол-ву открытых страниц (макс 1)
                        MoveMoneyTab.PreviewMouseDown += TB_ChangedFrame;
                        isMoveMoneyCreated = true;
                    }
                }
                else if (clickedMenuItem.Name == "AccoutBut")
                {
                    if (!isAccoutCreated)
                    {
                        Button closeButton = new Button();
                        closeButton.Content = "X";
                        closeButton.Click += CloseAccoutClick;
                        closeButton.Margin = new Thickness(0, 0, 0, -6);
                        closeButton.Style = (Style)FindResource("CloseButtonStyle");

                        AccoutTab = new TabItem();
                        AccoutTab.IsSelected = true;
                        StackPanel headerPanel = new StackPanel();
                        headerPanel.Orientation = Orientation.Horizontal;
                        headerPanel.Children.Add(new TextBlock { Text = "Выписанные счета" });
                        headerPanel.Children.Add(closeButton);
                        AccoutTab.Header = headerPanel;
                        MainTab.Items.Add(AccoutTab);
                        AccoutTab.SetResourceReference(TabItem.StyleProperty, "TabItemStyle");
                        MainFrame.Content = new PageAccout();
                        AccoutTab.PreviewMouseDown += TB_ChangedFrame;
                        isAccoutCreated = true;
                    }

                }

                else if (clickedMenuItem.Name == "CashboxBut")
                {
                    if (!isCashboxCreated)
                    {
                        Button closeButton = new Button();
                        closeButton.Content = "X";
                        closeButton.Click += CloseCashboxClick;
                        closeButton.Margin = new Thickness(0, 0, 0, -6);
                        closeButton.Style = (Style)FindResource("CloseButtonStyle");

                        CashboxTab = new TabItem();
                        CashboxTab.IsSelected = true;
                        StackPanel headerPanel = new StackPanel();
                        headerPanel.Orientation = Orientation.Horizontal;
                        headerPanel.Children.Add(new TextBlock { Text = "Касса" });
                        headerPanel.Children.Add(closeButton);
                        CashboxTab.Header = headerPanel;
                        MainTab.Items.Add(CashboxTab);
                        CashboxTab.SetResourceReference(TabItem.StyleProperty, "TabItemStyle");
                        MainFrame.Content = new PageCashBox();
                        CashboxTab.PreviewMouseDown += TB_ChangedFrame;
                        isCashboxCreated = true;
                    }
                }
                else if (clickedMenuItem.Name == "EmproyeesBut")
                {
                    if (!isEmproyeesCreated)
                    {
                        Button closeButton = new Button();
                        closeButton.Content = "X";
                        closeButton.Click += CloseEmproyeesClick;
                        closeButton.Margin = new Thickness(0, 0, 0, -6);
                        closeButton.Style = (Style)FindResource("CloseButtonStyle");

                        EmproyeesTab = new TabItem();
                        EmproyeesTab.IsSelected = true;
                        StackPanel headerPanel = new StackPanel();
                        headerPanel.Orientation = Orientation.Horizontal;
                        headerPanel.Children.Add(new TextBlock { Text = "Сотрудники" });
                        headerPanel.Children.Add(closeButton);
                        EmproyeesTab.Header = headerPanel;
                        MainTab.Items.Add(EmproyeesTab);
                        EmproyeesTab.SetResourceReference(TabItem.StyleProperty, "TabItemStyle");
                        MainFrame.Content = new PageEmproyees();
                        EmproyeesTab.PreviewMouseDown += TB_ChangedFrame;
                        isEmproyeesCreated = true;
                    }
                }
                else if (clickedMenuItem.Name == "CalculationSalaryBut")
                {
                    if (!isCalculationSalaryCreated)
                    {
                        Button closeButton = new Button();
                        closeButton.Content = "X";
                        closeButton.Click += CloseCalculationSalaryClick;
                        closeButton.Margin = new Thickness(0, 0, 0, -6);
                        closeButton.Style = (Style)FindResource("CloseButtonStyle");

                        CalculationSalaryTab = new TabItem();
                        CalculationSalaryTab.IsSelected = true;
                        StackPanel headerPanel = new StackPanel();
                        headerPanel.Orientation = Orientation.Horizontal;
                        headerPanel.Children.Add(new TextBlock { Text = "Вычислить Зарплату" });
                        headerPanel.Children.Add(closeButton);
                        CalculationSalaryTab.Header = headerPanel;
                        MainTab.Items.Add(CalculationSalaryTab);
                        CalculationSalaryTab.SetResourceReference(TabItem.StyleProperty, "TabItemStyle");
                        MainFrame.Content = new PageCalculationSalary();
                        CalculationSalaryTab.PreviewMouseDown += TB_ChangedFrame;
                        isCalculationSalaryCreated = true;
                    }
                }
                else if (clickedMenuItem.Name == "IssueSalaryBut")
                {
                    if (!isIssueSalaryCreated)
                    {
                        Button closeButton = new Button();
                        closeButton.Content = "X";
                        closeButton.Click += IssueSalarClick;
                        closeButton.Margin = new Thickness(0, 0, 0, -6);
                        closeButton.Style = (Style)FindResource("CloseButtonStyle");

                        IssueSalaryTab = new TabItem();
                        IssueSalaryTab.IsSelected = true;
                        StackPanel headerPanel = new StackPanel();
                        headerPanel.Orientation = Orientation.Horizontal;
                        headerPanel.Children.Add(new TextBlock { Text = "Выдать Зарплату" });
                        headerPanel.Children.Add(closeButton);
                        IssueSalaryTab.Header = headerPanel;
                        MainTab.Items.Add(IssueSalaryTab);
                        IssueSalaryTab.SetResourceReference(TabItem.StyleProperty, "TabItemStyle");
                        MainFrame.Content = new PageIssueSalary();
                        IssueSalaryTab.PreviewMouseDown += TB_ChangedFrame;
                        isIssueSalaryCreated = true;
                    }

                }
                else if (clickedMenuItem.Name == "OSandNMABut")
                {
                    if (!isOSandNMACreated)
                    {
                        Button closeButton = new Button();
                        closeButton.Content = "X";
                        closeButton.Click += OSandNMAClick;
                        closeButton.Margin = new Thickness(0, 0, 0, -6);
                        closeButton.Style = (Style)FindResource("CloseButtonStyle");

                        OSandNMATab = new TabItem();
                        OSandNMATab.IsSelected = true;
                        StackPanel headerPanel = new StackPanel();
                        headerPanel.Orientation = Orientation.Horizontal;
                        headerPanel.Children.Add(new TextBlock { Text = "ОС и НМА" });
                        headerPanel.Children.Add(closeButton);
                        OSandNMATab.Header = headerPanel;
                        MainTab.Items.Add(OSandNMATab);
                        OSandNMATab.SetResourceReference(TabItem.StyleProperty, "TabItemStyle");
                        MainFrame.Content = new PageOSandNMA();
                        OSandNMATab.PreviewMouseDown += TB_ChangedFrame;
                        isOSandNMACreated = true;
                    }
                }
                else if (clickedMenuItem.Name == "recvizit")
                {
                    forms.FormsForRecvizit FFR = new forms.FormsForRecvizit();
                    FFR.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    FFR.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    // Установите второе окно поверх всех других окон
                    FFR.Topmost = true;
                    FFR.Show();
                    childWindows.Add(FFR);
                    
                }
                else if (clickedMenuItem.Name == "GroundBut")
                {

                }
            }

            tab_item.Style = (Style)FindResource("TabItemStyle");


        }


        private void CloseTabButtonClick(object sender, EventArgs e)
        {
            if (MainTab.SelectedItem == JurnalTab) // Проверяем, выбрана ли в данный момент закрываемая вкладка
            {
                TB_ChangedFrame(sender, e); // Если выбрана, вызываем событие изменения фрейма
                MainFrame.Content = null; // Очищаем содержимое фрейма
            }
            MainTab.Items.Remove(JurnalTab); // Удаляем вкладку из таб контрола
            isJurnalTabCreated = false; // Устанавливаем флаг создания вкладки в false
        }
        private void CloseTabMoveClick(object sender, EventArgs e)
        {
            if(MainTab.SelectedItem == MoveMoneyTab)
            {
                TB_ChangedFrame(sender, e);
                MainFrame.Content = null;
            }
            MainTab.Items.Remove(MoveMoneyTab);
            isMoveMoneyCreated = false;
        }
        private void CloseAccoutClick(object sender, EventArgs e)
        {
            if (MainTab.SelectedItem == AccoutTab)
            {
                TB_ChangedFrame(sender, e);
                MainFrame.Content = null;
            }
            MainTab.Items.Remove(AccoutTab);
            isAccoutCreated = false;
        }

        private void CloseCashboxClick(object sender, EventArgs e)
        {
            if (MainTab.SelectedItem == CashboxTab)
            {
                TB_ChangedFrame(sender, e);
                MainFrame.Content = null;
            }
            MainTab.Items.Remove(CashboxTab);
            isCashboxCreated = false;
        }
        private void CloseEmproyeesClick(object sender, EventArgs e)
        {
            if (MainTab.SelectedItem == EmproyeesTab)
            {
                TB_ChangedFrame(sender, e);
                MainFrame.Content = null;
            }
            MainTab.Items.Remove(EmproyeesTab);
            isEmproyeesCreated = false;
        }
        private void CloseCalculationSalaryClick(object sender, EventArgs e)
        {
            if (MainTab.SelectedItem == CalculationSalaryTab)
            {
                TB_ChangedFrame(sender, e);
                MainFrame.Content = null;
            }
            MainTab.Items.Remove(CalculationSalaryTab);
            isCalculationSalaryCreated = false;
        }
        private void IssueSalarClick(object sender, EventArgs e)
        {
            if (MainTab.SelectedItem == IssueSalaryTab)
            {
                TB_ChangedFrame(sender, e);
                MainFrame.Content = null;
            }
            MainTab.Items.Remove(IssueSalaryTab);
            isIssueSalaryCreated = false;
        }
        private void OSandNMAClick(object sender, EventArgs e)
        {
            if (MainTab.SelectedItem == OSandNMATab)
            {
                TB_ChangedFrame(sender, e);
                MainFrame.Content = null;
            }
            MainTab.Items.Remove(OSandNMATab);
            isOSandNMACreated = false;

        }

        private void CloseAllFramesAndTabs()
        {
            MainFrame.Content = null;

            // Очищаем вкладки таб контрола
            MainTab.Items.Clear();
            isOSandNMACreated = false;
            isIssueSalaryCreated = false;
            isCalculationSalaryCreated = false;
            isEmproyeesCreated = false;
            isCashboxCreated = false;
            isBankOutCreated = false;
            isBankInTabCreated = false;
            isAccoutCreated = false;
            isMoveMoneyCreated = false;
            isJurnalTabCreated = false;

        }
        private void ButCloseTab_Click(object sender, RoutedEventArgs e)
        {
            CloseAllFramesAndTabs();
        }
        private void TB_ChangedFrame(object sender, EventArgs e)
        {
            if (MainTab.SelectedItem == JurnalTab)
            {
                MainFrame.Navigate(new Frame.PageJurnal());
            }
            else if (MainTab.SelectedItem == MoveMoneyTab)
            {
                MainFrame.Navigate(new Frame.PageMoveMoney());
            }
            else if (MainTab.SelectedItem == AccoutTab)
            {
                MainFrame.Navigate(new Frame.PageAccout());
            }
            else if (MainTab.SelectedItem == CashboxTab)
            {
                MainFrame.Navigate(new Frame.PageCashBox());
            }
            else if (MainTab.SelectedItem == EmproyeesTab)
            {
                MainFrame.Navigate(new Frame.PageEmproyees());
            }
            else if (MainTab.SelectedItem == CalculationSalaryTab)
            {
                MainFrame.Navigate(new Frame.PageCalculationSalary());
            }
            else if (MainTab.SelectedItem == IssueSalaryTab)
            {
                MainFrame.Navigate(new Frame.PageIssueSalary());
            }
            else if (MainTab.SelectedItem == OSandNMATab)
            {
                MainFrame.Navigate(new Frame.PageOSandNMA());
            }
            if (MainTab.Items.Count > 0)
            {
                // Вкладки существуют

            }
            else
            {
                // Вкладок нет
                MainFrame.Content= null;
            }
        }

    }



}