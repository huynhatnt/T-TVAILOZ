using ClientForm.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    static class Program
    {
        public static Models.ClientUser CurrentUser { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ensure Firebase initialized when first used (FirestoreService.Db used lazily)
            Application.Run(new LoginForm());
        }
    }
}
