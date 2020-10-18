using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OZI_lab1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserContext db = new UserContext();
            if (db.Users.Find("IvanchenkoA") == null)
            {
                db.Users.Add(new User { Name = "IvanchenkoA", Role = "admin", Password = "ІванченкоZ20", PasswordLength = 11, Blocked = false, Restriction = true });
            }
            
            db.SaveChanges();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
