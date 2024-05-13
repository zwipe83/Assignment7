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
using Assignment7.UI.Wpf.Windows;
using Assignment7.Classes;
using System.IO.Packaging;

namespace Assignment7.UI.Wpf;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    #region Fields

    /// <summary>
    /// 
    /// </summary>

    private SightingManager sightingManager;

    /// <summary>
    /// 
    /// </summary>
    private AnimalManager animalManager;

    /// <summary>
    /// 
    /// </summary>
    private DataStore dataStore;

    /// <summary>
    /// 
    /// </summary>
    private static readonly string _datastorePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "DataStore");

    /// <summary>
    /// 
    /// </summary>
    private static readonly string _appDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
    #endregion
    #region Properties
    public DataStore DataStore
    {
        get => dataStore;
    }
    public AnimalManager AnimalManager
    {
        get => animalManager;
    }
    public SightingManager SightingManager
    {
        get => sightingManager;
    }
    public static string DataStorePath
    {
        get => _datastorePath;
    }
    public static string AppDirectory
    {
        get => _appDirectory;
    }
    #endregion
    #region Constructors
    /// <summary>
    /// 
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();

        sightingManager = new SightingManager();
        animalManager = new AnimalManager();
        dataStore = new DataStore();

        DataStore.ReadFromJsonFile(new File(DataStorePath, "Animals.json"), animalManager.ListOfAnimals);
        DataStore.ReadFromJsonFile(new File(DataStorePath, "Sightings.json"), sightingManager.ListOfSightings);
    }
    #endregion
    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnHistory_Click(object sender, RoutedEventArgs e)
    {
        AnimalManager animalManagerCopy = animalManager.DeepCopy();
        SightingManager sightingManagerCopy = SightingManager.DeepCopy(); //TODO: Not working?
        HistoryWindow window = new HistoryWindow(sightingManagerCopy, animalManagerCopy);
        window.ShowDialog();

        if (window.DialogResult.HasValue && window.DialogResult.Value)
        {
            DataStore.SaveToJsonFile(new File(DataStorePath, "Sightings.json"), window.SightingManager.ListOfSightings);
        }
        else
        {
            //Do nothing
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnManageAnimals_Click(object sender, RoutedEventArgs e)
    {
        //AnimalManager animalManagerCopy = new AnimalManager(animalManager);
        AnimalManager animalManagerCopy = animalManager.DeepCopy();
        AnimalManagerWindow window = new AnimalManagerWindow(animalManagerCopy);
        window.ShowDialog();

        if(window.DialogResult.HasValue && window.DialogResult.Value)
        {
            animalManager = window.AnimalManager.DeepCopy(); //FIXED: Deep copy?
            DataStore.SaveToJsonFile(new File(DataStorePath, "Animals.json"), animalManager.ListOfAnimals);
        }
        else
        {
            //Do nothing
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnAddSighting_Click(object sender, RoutedEventArgs e)
    {
        AnimalManager animalManagerCopy = animalManager.DeepCopy();
        SightingWindow window = new SightingWindow(new Sighting(), animalManagerCopy, false);
        
        window.ShowDialog();

        if (window.DialogResult.HasValue && window.DialogResult.Value)
        {
            SightingManager.AddSighting(window.Sighting);
            DataStore.SaveToJsonFile(new File(DataStorePath, "Sightings.json"), sightingManager.ListOfSightings);
        }
        else
        {
            //Do nothing...
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void menuBtnExit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
    private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
    private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
    private void PrintCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
    private void AboutCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void menuBtnAbout_Click(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
    #endregion

    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            DragMove();
    }
}