using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Threading;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.DirectoryServices;
using System.Security.Permissions;
//using Microsoft.Office.Interop.Excel;


namespace AccSysUI.ViewModel
{
    partial class M1
    {
        public M1()
        {
            InitializeComponent();
            //txtFirst.Text = g.ToString("D");
            btnMyButton.Click += new RoutedEventHandler(foo);
        }
        private void foo(object sender, RoutedEventArgs e)
        {
            //If you are validating on a domain
            //PrincipalContext pcon = new PrincipalContext(ContextType.ApplicationDirectory);
            //if (pcon.ValidateCredentials(txtFirst.Text,
            //                           txtLast.Text,
            //                           ContextOptions.Negotiate))
            //{
            //    //User is authenticated
            //}
            //String Domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            var sAdministrators = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null)
                .Translate(typeof(NTAccount)).ToString();
            var res = sAdministrators.TakeWhile(c => c != '\\').Count();
            var sAdministrators1 = sAdministrators.Substring(++res);
            var lstUsers = new List<string>();
            var localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName);
            var admGroup = localMachine.Children.Find(sAdministrators1, "group");
            object members = admGroup.Invoke("members", null);
            foreach (object groupMember in (IEnumerable)members)
            {
                DirectoryEntry member = new DirectoryEntry(groupMember);
                lstUsers.Add(member.Name);
            }
            //var principial = Thread.CurrentPrincipal;


            var groupPrincipal = GroupPrincipal.FindByIdentity(new PrincipalContext(ContextType.Machine), IdentityType.Name, sAdministrators);
            ////WindowsIdentity identity = (WindowsIdentity)principial.Identity;
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            var isadmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            //var isAdmin = WindowsIdentity.GetCurrent();
            //var isAdmin1 = isAdmin.Groups;
            //var isAdmin2 = isAdmin1.Any(x => x.Value == sAdministrators);
            var currentUser = Environment.UserName;
            //var container = EnvironmentVariableTarget.

            using (var context = new PrincipalContext(ContextType.Machine, null, null, ContextOptions.Negotiate))
            {
                //PrincipalCollection pc;

                var userName = "newUser1";
                var password = "1K2O_48523456";
                //var wi = new WindowsIdentity(userName);
                //var newPrincipal = new WindowsPrincipal(wi);

                var user = new UserPrincipal(context)
                {
                    Name = userName,
                    Enabled = true
                };
                //var ps = new PrincipalSearcher().FindOne().Guid;
                //.FindOne();

                user.SetPassword(password);
                user.Save();
                groupPrincipal.Members.Add(user);
                groupPrincipal.Save();
                
                //user.Description = "описание";
                //PrincipalSearcher searcher = new PrincipalSearcher(user);
                //var users = searcher.FindAll().Cast<UserPrincipal>()
                //    .Where(x=>x.IsMemberOf()
                //user.IsMemberOf()
                //try
                //{
                //user.Save();

                //var t = "";
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("nooo");
                //    Console.ReadLine();
                //}
                //var txtLog = txtFirst.Text;
                //var txtPass = txtLast.Text;
                var check = context.ValidateCredentials("avg.joe", "1KO_48523456", ContextOptions.Negotiate);
                if (context.ValidateCredentials(userName, password, ContextOptions.Negotiate))
                    Console.WriteLine("Hooray!");
                Console.ReadLine();
                user.Dispose();
            }
        }
    }
}
