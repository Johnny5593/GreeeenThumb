using GreenThumb;
using System.Windows;

namespace GreeeenThumb
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var context = new YourDbContext())
            {
                var plants = context.Plants.ToList();
                var plantNames = string.Join(", ", plants.Select(p => p.PlantName));
                MessageBox.Show($"Plants in the database: {plantNames}");
            }
        }
    }
}
