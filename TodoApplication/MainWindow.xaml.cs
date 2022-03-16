using System;
using System.Windows;

namespace TodoApplication
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // TodoListPageを表示する
            Uri todoListPageUri = new Uri("/TodoListPage.xaml", UriKind.Relative);
            frame.Source = todoListPageUri;
        }
    }
}
