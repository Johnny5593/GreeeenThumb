using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace GreeeenThumb
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Skapa eller migrera databasen när applikationen startar
            using (var context = new YourDbContext())
            {
                context.Database.Migrate();
            }

            // Fortsätt med att starta huvudfönstret eller något annat i din applikation
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
