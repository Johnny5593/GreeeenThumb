using GreenThumb;
using System.Windows;

namespace GreeeenThumb
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Exempel på hur du kan interagera med databasen från MainWindow
            using (var context = new YourDbContext())
            {
                // Exempel på att lägga till en ny växt i databasen
                var newPlant = new Plant { PlantName = "Sunflower" };
                context.Plants.Add(newPlant);
                context.SaveChanges();

                // Exempel på att hämta alla växter från databasen och visa dem i en MessageBox
                var plants = context.Plants.ToList();
                var plantNames = string.Join(", ", plants.Select(p => p.PlantName));
                MessageBox.Show($"Plants in the database: {plantNames}");
            }
        }
    }
}
