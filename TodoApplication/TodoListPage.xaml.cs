using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TodoApplication
{
    /// <summary>
    /// TodoListPage.xaml の相互作用ロジック
    /// </summary>
    public partial class TodoListPage : Page
    {
        /// <summary>
        /// TodoList
        /// </summary>
        private ObservableCollection<ListViewItems> _todoList = new ObservableCollection<ListViewItems>();

        /// <summary>
        /// CompleteList
        /// </summary>
        public ObservableCollection<ListViewItems> _completeList = new ObservableCollection<ListViewItems>();

        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static TodoListPage _singleTodoList = new TodoListPage();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TodoListPage()
        {
            InitializeComponent();
            ListViewName.ItemsSource = _todoList;
        }

        /// <summary>
        /// シングルトンインスタンスの呼び出し関数
        /// </summary>
        /// <returns>シングルトンインスタンス</returns>
        public static TodoListPage GetInstance()
        {
            return _singleTodoList;
        }

        /// <summary>
        /// 追加ボタン押下関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton(object sender, RoutedEventArgs e)
        {
            GetInstance()._todoList.Add(new ListViewItems() { _selected = false, _contents = contents.Text, _date = calender.ToString() });
            ListViewName.ItemsSource = GetInstance()._todoList;
        }

        /// <summary>
        /// 完了ボタン押下関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteButton(object sender, RoutedEventArgs e)
        {
            //チェックが付いているTodoリストの項目を削除
            foreach (ListViewItems item in GetInstance()._todoList)
            {
                if (item._selected == true)
                {
                    GetInstance()._completeList.Add(item);
                }
            }
            foreach (ListViewItems item in GetInstance()._completeList)
            {
                GetInstance()._todoList.Remove(item);
            }
            ListViewName.ItemsSource = GetInstance()._todoList;
        }

        /// <summary>
        /// CompleteListPageへ画面遷移する関数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(CompleteListPage.GetInstance());
        }
    }

    /// <summary>
    /// TodoListの内容
    /// </summary>
    public class ListViewItems
    {
        /// <summary>
        /// チェックボックス
        /// </summary>
        public bool _selected { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string _contents { get; set; }

        /// <summary>
        /// 開始日時
        /// </summary>
        public string _date { get; set; }
    }
}
