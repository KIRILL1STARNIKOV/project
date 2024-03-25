using static finYcurs.forms.WindowIntro;
using finYcurs.Frame.FrameWelcom.framerec;
using System;
using System.Collections.Generic;
using System.Linq;
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
namespace finYcurs.Frame.FrameWelcom
{
    /// <summary>
    /// Логика взаимодействия для FrameBaseFalse.xaml
    /// </summary>
    public partial class FrameBaseFalse : Page
    {
        public FrameBaseFalse()
        {
            InitializeComponent();
        }

        private void OpenNewFrame(object sender, RoutedEventArgs e)
        {
            // Создание экземпляра новой страницы или пользовательского контента
            frameforbaseone newPage = new frameforbaseone(); // Замените frameforbaseone на имя вашей новой страницы или пользовательского контента

            // Получение родительского элемента Frame
            System.Windows.Controls.Frame parentFrame = Window.GetWindow(this).FindName("FrameChangedWelcom") as System.Windows.Controls.Frame;

            // Замена содержимого фрейма на новую страницу или пользовательский контент
            parentFrame.Navigate(newPage);
        }
    }
}
