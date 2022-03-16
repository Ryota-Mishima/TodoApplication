using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TodoApplication
{
    /// <summary>
    /// CompleteListPage.xaml の相互作用ロジック
    /// </summary>
    public partial class CompleteListPage : Page
    {
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static CompleteListPage _singleCompleteList = new CompleteListPage();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CompleteListPage()
        {
            InitializeComponent();
            CompleteListViewName.ItemsSource = TodoListPage.GetInstance()._completeList;
        }

        /// <summary>
        /// シングルトンインスタンスの呼び出し関数
        /// </summary>
        /// <returns>シングルトンインスタンス</returns>
        public static CompleteListPage GetInstance()
        {
            return _singleCompleteList;
        }

        /// <summary>
        /// TodoListPageへ画面遷移する関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TodoList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(TodoListPage.GetInstance());
        }
    }
}
