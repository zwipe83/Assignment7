using Assignment7.Classes;
using Assignment7.UI.Wpf.Windows;
using System.Windows;
using System.Windows.Input;
using static Assignment7.Classes.FileManager;

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

    /// <summary>
    /// 
    /// </summary>
    private static readonly string sightingsFileName = "Sightings.json";

    /// <summary>
    /// 
    /// </summary>
    private static readonly string animalsFileName = "Animals.json";
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
        dataStore = new DataStore();

        ReadAnimals();
        ReadSightings();
    }

    #endregion
    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    private void ReadSightings()
    {
        DataStore.ReadFromJsonFile(new File(DataStorePath, sightingsFileName), sightingManager.ListOfSightings);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ReadAnimals()
    {
        DataStore.ReadFromJsonFile(new File(DataStorePath, animalsFileName), animalManager.ListOfAnimals);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnHistory_Click(object sender, RoutedEventArgs e)
    {
        AnimalManager animalManagerCopy = AnimalManager.DeepCopy();
        SightingManager sightingManagerCopy = SightingManager.DeepCopy(); //TODO: Not working?

        if (sightingManagerCopy.ListOfSightings.Count == 0)
        {
            MessageBox.Show(@"You should add a sighting first! Click on 'Add Sighting'.", "Info");
            return;
        }

        HistoryWindow window = new HistoryWindow(sightingManagerCopy, animalManagerCopy);
        window.ShowDialog();

        if (window.DialogResult.HasValue && window.DialogResult.Value)
        {
            sightingManager = window.SightingManager.DeepCopy();
            SaveSightings(window);
        }
        else
        {
            //Do nothing
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="window"></param>
    private void SaveSightings(HistoryWindow window)
    {
        DataStore.SaveToJsonFile(new File(DataStorePath, sightingsFileName), window.SightingManager.ListOfSightings);
    }
    /// <summary>
    /// 
    /// </summary>
    private void SaveSightings()
    {
        DataStore.SaveToJsonFile(new File(DataStorePath, sightingsFileName), SightingManager.ListOfSightings);
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
            SaveAnimals();
        }
        else
        {
            //Do nothing
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void SaveAnimals()
    {
        DataStore.SaveToJsonFile(new File(DataStorePath, animalsFileName), animalManager.ListOfAnimals);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnAddSighting_Click(object sender, RoutedEventArgs e)
    {
        AnimalManager animalManagerCopy = animalManager.DeepCopy();

        if(animalManager.ListOfAnimals.Count == 0)
        {
            MessageBox.Show(@"You should add an animal first! Click on 'Manage Animals'.", "Info");
            return;
        }

        SightingWindow window = new SightingWindow(new Sighting(), animalManagerCopy, false);

        window.ShowDialog();

        if (window.DialogResult.HasValue && window.DialogResult.Value)
        {
            SightingManager.AddSighting(window.Sighting);
            SaveSightings();
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        { 
            DragMove();
        }
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