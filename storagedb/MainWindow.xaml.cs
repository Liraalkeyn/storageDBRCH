using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using storagedb.Data;

// using storagedb.Data;

namespace storagedb;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        using (var dbContext = new StoragedbContext())
        {
            ListView.ItemsSource = dbContext.Departments.ToList();
        }
    }
    
}    