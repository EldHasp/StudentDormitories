using StDorModel;
using StDorModelLibrary.Interfaces;
using StDorViewLibrary;
using StDorViewModel;
using System;
using System.Windows;

namespace StudentDormitories
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>Модель</summary>
        private readonly IStDorModel model;
        /// <summary>ViewModel</summary>
        private readonly MainViewModel viewModel;
        /// <summary>Главное окно</summary>
        private readonly Window mainWindow;

        /// <summary>Конструктор по умолчанию</summary>
        public App()
            :this(new StDorModelXML())
        {}

        public App(IStDorModel model)
        {
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            viewModel = new MainViewModel(Dispatcher, model);
            viewModel.ExceptionEvent += ShowException;

            mainWindow = new Window()
            {
                Width = 1000,
                Height = 800,
                Content = new MainUС(),
                DataContext = viewModel
            };

        }

        /// <summary>Обработчик события старта приложения</summary>
        /// <param name="sender">Не используется</param>
        /// <param name="e">Не используется</param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mainWindow.Show();
            LoadModelAsync((string)Resources["DefaultSourceXML"]);
        }

        /// <summary>Асинхронный метод загрузки Модели</summary>
        /// <param name="source">Строка источника загрузки</param>
        private async void LoadModelAsync(string source)
        {
            try
            {
                await model.LoadAsync(source);
                viewModel.SetDormitories();
            }
            catch (Exception ex)
            {
                ShowException(this, nameof(LoadModelAsync), ex);
            }
        }

        /// <summary>Метод вывода сообщения об исключении</summary>
        /// <param name="sender">Источник исключения</param>
        /// <param name="nameMetod">Метод в котором возникло исключение</param>
        /// <param name="exc">Параметры исключения</param>
        private void ShowException(object sender, string nameMetod, Exception exc)
            => MessageBox.Show($"{sender}.{nameMetod}\r\n{exc}\r\n{exc.Message}");
    }
}
