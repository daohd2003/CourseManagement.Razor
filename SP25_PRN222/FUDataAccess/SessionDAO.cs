using FUBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FURepositories
{
    public class SessionDAO
    {
        public static List<Session> GetSessions()
        {
            var listSessions = new List<Session>();
            try
            {
                using var db = new Sp25Prn222Context();
                listSessions = db.Sessions.ToList();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while retrieving sessions: " + e.Message);
            }
            return listSessions;
        }
    }
}
