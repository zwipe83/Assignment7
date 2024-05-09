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
    private static readonly string _imagesPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"); //Path to app folder Images folder

    /// <summary>
    /// 
    /// </summary>
    private static readonly string _datastorePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "DataStore");
    #endregion
    #region Properties
    public static string ImagesPath
    {
        get => _imagesPath;
    }
    public static string DataStorePath
    {
        get => _datastorePath;
    }
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
        HistoryWindow window = new HistoryWindow();
        window.ShowDialog();
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
            animalManager = window.AnimalManager; //TODO: Deep copy?
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
        SightingWindow window = new SightingWindow(new Sighting(), animalManagerCopy);
        
        window.ShowDialog();

        if (window.DialogResult.HasValue && window.DialogResult.Value)
        {
            SightingManager.AddSighting(window.Sighting);
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
    #endregion
}