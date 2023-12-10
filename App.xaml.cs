using GreenThumb;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace GreeeenThumb
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var context = new YourDbContext())
            {
                context.Database.Migrate();

                var plantRepository = new Repository<Plant>(context);
                var unitOfWork = new UnitOfWork(context);
                var greenThumbRepository = new Repository<Plant>(context);

                var newPlant = new Plant { PlantName = "Rose" };
                plantRepository.Add(newPlant);
            }

            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
