using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.DirectoryServices;



namespace AccountingSystemUI.Application
{
    public class WinHelper
    {
        /// <summary>
        /// IsAdministrator() apparently not work when UAC is enabled..
        /// </summary>
        /// <returns></returns>
        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            if (identity != null)
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            return false;
        }
        public static IList<IWinAccount> GetWinUsers()
        {
            IList<IWinAccount> result = new List<IWinAccount>();

            foreach (var adm in GetAdministrators())
            {
                result.Add(new WinAccount { Name = adm, IsAdmin = true });
            }
            foreach (var adm in GetUsers())
            {
                result.Add(new WinAccount { Name = adm, IsAdmin = false });
            }
            return result;
        }
        public static bool CreateWinAccount(IWinAccount winUser)
        {
            if (winUser == null) return false;
            bool isAdmin = winUser.IsAdmin;
            try
            {
                var groupPrincipal = GroupPrincipal.FindByIdentity(new PrincipalContext(ContextType.Machine),
                    IdentityType.Name, isAdmin ? GetSidAdminTypeStr() : GetSidUserTypeStr());
                if (groupPrincipal != null)
                {
                    using (var context = new PrincipalContext(ContextType.Machine))//, null, null, ContextOptions.Negotiate))
                    {
                        var user = new UserPrincipal(context)
                        {
                            Name = winUser.Name,
                            Enabled = true,
                            PasswordNeverExpires = true
                        };
                        //user.SetPassword("12345");
                        user.Save();
                        groupPrincipal.Members.Add(user);
                        groupPrincipal.Save();
                    }
                }
            }
            catch (PrincipalExistsException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message +
                    "\n\nПопробуйте отключить UAC или запустить\nпрограмму от имени администратора");
                return false;
            }
            return true;
        }
        public static IWinAccount GetCurrentWinAccount()
        {
            var isAdmin = GetAdministrators().Any(x => x.Equals(Environment.UserName)) ?
                 true : false;
            return new WinAccount
            {
                Name = Environment.UserName,
                IsAdmin = isAdmin
            };
        }
        public static IList<string> GetAdministrators()
        {
            var result = new List<string>();
            // get correct SidAdminType string for Find method
            var inex = GetSidAdminTypeStr().TakeWhile(c => c != '\\').Count();
            var sidTypeSubstr = GetSidAdminTypeStr().Substring(++inex);

            var localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName);
            var admGroup = localMachine.Children.Find(sidTypeSubstr, "group");
            object members = admGroup.Invoke("members", null);
            foreach (object groupMember in (IEnumerable)members)
            {
                DirectoryEntry member = new DirectoryEntry(groupMember);
                result.Add(member.Name);
            }
            return result;
        }
        public static IList<string> GetUsers()
        {
            var result = new List<string>();
            // get correct SidUserType string for Find method
            var sUsers = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null)
               .Translate(typeof(NTAccount)).ToString();
            var inex = sUsers.TakeWhile(c => c != '\\').Count();
            var sidTypeSubstr = sUsers.Substring(++inex);

            var localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName);
            var usrGroup = localMachine.Children.Find(sidTypeSubstr, "group");
            object members = usrGroup.Invoke("members", null);
            foreach (object groupMember in (IEnumerable)members)
            {
                DirectoryEntry member = new DirectoryEntry(groupMember);
                result.Add(member.Name);
            }
            return result;
        }
        private static string GetSidAdminTypeStr()
        {
            return new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null)
               .Translate(typeof(NTAccount)).ToString();
        }
        private static string GetSidUserTypeStr()
        {
            return new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null)
               .Translate(typeof(NTAccount)).ToString();
        }
    }
}
