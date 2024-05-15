using Assignment7.Classes;
using Assignment7.UI.Wpf.Windows;
using System.Windows;
using System.Windows.Input;

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
    private FileManager fileManager;

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

    /// <summary>
    /// 
    /// </summary>
    public DataStore DataStore
    {
        get => dataStore;
    }

    /// <summary>
    /// 
    /// </summary>
    public AnimalManager AnimalManager
    {
        get => animalManager;
    }

    /// <summary>
    /// 
    /// </summary>
    public FileManager FileManager
    {
        get => fileManager;
    }

    /// <summary>
    /// 
    /// </summary>
    public SightingManager SightingManager
    {
        get => sightingManager;
    }

    /// <summary>
    /// 
    /// </summary>
    public static string DataStorePath
    {
        get => _datastorePath;
    }

    /// <summary>
    /// 
    /// </summary>
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
        fileManager = new FileManager();
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
            sightingManager = window.SightingManager.DeepCopy();
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

        if (window.DialogResult.HasValue && window.DialogResult.Value)
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
        AboutWindow window = new AboutWindow();
        window.ShowDialog();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
            DragMove();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void menuBtnClearImages_Click(object sender, RoutedEventArgs e)
    {
        List<AnimalId> animalIds = AnimalManager.GetAnimalIds();

        if (animalIds == null)
            return;

        List<string> orphanedImages = FileManager.FindOrphanedFiles(animalIds, "Images");

        if (orphanedImages.Count <= 0)
        {
            MessageBox.Show("No unused files were found in Images folder. All seems OK!", "Info");
            return;
        }

        // Show a confirmation dialog box
        MessageBoxResult result = MessageBox.Show("Unused files were found in Images folder, are your sure you want to delete them?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

        // Check the user's response
        if (result == MessageBoxResult.Yes)
        {
            FileManager.DeleteFiles(orphanedImages, "Images");
        }
        else
        {
            //Nothing...
        }
    }
    #endregion
}