using Assignment7.Classes;
using Assignment7.UI.Wpf.Windows;
using System.Diagnostics;
using System.IO;
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
    /// The manager for handling sightings.
    /// </summary>
    private SightingManager sightingManager;

    /// <summary>
    /// The manager for handling animals.
    /// </summary>
    private AnimalManager animalManager;

    /// <summary>
    /// The data store for storing data.
    /// </summary>
    private DataStore dataStore;

    /// <summary>
    /// The path to the data store.
    /// </summary>
    private static readonly string _datastorePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "DataStore");

    /// <summary>
    /// The base directory of the application.
    /// </summary>
    private static readonly string _appDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

    /// <summary>
    /// The file name for storing sightings.
    /// </summary>
    private static readonly string sightingsFileName = "Sightings.json";

    /// <summary>
    /// The file name for storing animals.
    /// </summary>
    private static readonly string animalsFileName = "Animals.json";
    #endregion
    #region Properties

    /// <summary>
    /// Gets the data store.
    /// </summary>
    public DataStore DataStore
    {
        get => dataStore;
    }

    /// <summary>
    /// Gets the animal manager.
    /// </summary>
    public AnimalManager AnimalManager
    {
        get => animalManager;
    }

    /// <summary>
    /// Gets the sighting manager.
    /// </summary>
    public SightingManager SightingManager
    {
        get => sightingManager;
    }

    /// <summary>
    /// Gets the path to the data store.
    /// </summary>
    public static string DataStorePath
    {
        get => _datastorePath;
    }

    /// <summary>
    /// Gets the base directory of the application.
    /// </summary>
    public static string AppDirectory
    {
        get => _appDirectory;
    }
    #endregion
    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
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
    /// Reads the sightings from the data store.
    /// </summary>
    private void ReadSightings()
    {
        DataStore.ReadFromJsonFile(new Assignment7.Classes.File(DataStorePath, sightingsFileName), sightingManager.ListOfSightings);
    }

    /// <summary>
    /// Reads the animals from the data store.
    /// </summary>
    private void ReadAnimals()
    {
        DataStore.ReadFromJsonFile(new Assignment7.Classes.File(DataStorePath, animalsFileName), animalManager.ListOfAnimals);
    }

    /// <summary>
    /// Handles the click event of the history button.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    private void btnHistory_Click(object sender, RoutedEventArgs e)
    {
        AnimalManager animalManagerCopy = AnimalManager.DeepCopy();
        SightingManager sightingManagerCopy = SightingManager.DeepCopy(); //FIXED: Not working? Seems to be... Working

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
    /// Saves the sightings to the data store.
    /// </summary>
    /// <param name="window">The history window.</param>
    private void SaveSightings(HistoryWindow window)
    {
        DataStore.SaveToJsonFile(new Assignment7.Classes.File(DataStorePath, sightingsFileName), window.SightingManager.ListOfSightings);
    }

    /// <summary>
    /// Saves the sightings to the data store.
    /// </summary>
    private void SaveSightings()
    {
        DataStore.SaveToJsonFile(new Assignment7.Classes.File(DataStorePath, sightingsFileName), SightingManager.ListOfSightings);
    }

    /// <summary>
    /// Handles the click event of the manage animals button.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
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
    /// Saves the animals to the data store.
    /// </summary>
    private void SaveAnimals()
    {
        DataStore.SaveToJsonFile(new Assignment7.Classes.File(DataStorePath, animalsFileName), animalManager.ListOfAnimals);
    }

    /// <summary>
    /// Handles the click event of the add sighting button.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    private void btnAddSighting_Click(object sender, RoutedEventArgs e)
    {
        AnimalManager animalManagerCopy = animalManager.DeepCopy();

        if (animalManager.ListOfAnimals.Count == 0)
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
    /// Handles the click event of the exit menu button.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    private void menuBtnExit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    /// <summary>
    /// Handles the click event of the about menu button.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    private void menuBtnAbout_Click(object sender, RoutedEventArgs e)
    {
        AboutWindow window = new AboutWindow();
        window.ShowDialog();
    }

    /// <summary>
    /// Handles the mouse down event of the window.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }
    }

    /// <summary>
    /// Handles the click event of the clear images menu button.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
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

    /// <summary>
    /// Opens the specified PDF file in the default browser.
    /// </summary>
    /// <param name="filePath">The path to the PDF file.</param>
    private void OpenPdfInBrowser(string filePath)
    {
        Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
    }

    /// <summary>
    /// Handles the click event of the Quick Start Guide menu button.
    /// </summary>
    /// <param name="sender">The sender of the event.</param>
    /// <param name="e">The event arguments.</param>
    private void menuBtnQSG_Click(object sender, RoutedEventArgs e)
    {
        string filePath = Path.Combine(AppDirectory, "Doc", "QSG.pdf");
        OpenPdfInBrowser(filePath);
    }
    #endregion

}
