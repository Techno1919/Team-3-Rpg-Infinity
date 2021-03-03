using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RpgInfinity.Models.Repos
{
    public class UserRepo : IUserRepo
    {
        private string _connString = ConfigurationManager.ConnectionStrings["RPGInfinityEntities"].ConnectionString;
        private IList<User> _userList;

        public UserRepo()
        {
            if (Equals(_userList, null))
            {
                _userList = new List<User>();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var con = new SqlConnection(_connString))
            {
                //
                var cmd = new SqlCommand("SELECT * FROM Users", con);
                cmd.CommandType = CommandType.Text;
                //
                con.Open();
                //
                SqlDataReader rdr = cmd.ExecuteReader();
                //
                while (rdr.Read())
                {
                    //
                    var user = new User();
                    //
                    user.ID = Convert.ToInt32(rdr["Id"]);
                    user.Username = rdr["Username"].ToString();
                    user.Password = rdr["Password"].ToString();

                    //
                    // Add your object to your list
                    _userList.Add(user);
                }
            }
            //
            return _userList;
        }

        public bool SignUp(User user)
        {
            bool retVal = false;

            var users = GetAllUsers();

            foreach (var _user in users)
            {
                if (user.Username == _user.Username)
                {
                    return retVal;
                }
            }

            using (var con = new SqlConnection(_connString))
            {
                //
                // Set-up command
                var cmd = new SqlCommand("AddNewUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //
                // Define StoredProc parameters

                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                //
                // Open DB Connection
                con.Open();
                //
                // Execute command
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    retVal = true;
                }
            }
            //
            // Return Success / Failure
            return retVal;
        }

        public User LoginUser(User user)
        {
            User logUser = null;

            var users = GetAllUsers();

            foreach (var _user in users)
            {
                if (user.Username == _user.Username)
                {
                    if (user.Password == _user.Password)
                    {
                        logUser = _user;
                        break;
                    }
                }
            }

            return logUser;
        }
    }
}