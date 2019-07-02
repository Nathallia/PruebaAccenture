using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Accenture.NL.Models;

namespace Accenture.NL.Services
{
    public class User : Base, Interface.IUser
    {
        private readonly string _urlApi;

        public User()
        {
            _urlApi = $"{ConfigurationManager.AppSettings["API"]}/{ConfigurationManager.AppSettings["Users"]}";
        }

        public DtoUser GetUser(int id)
        {
            DtoUser user = new DtoUser();
            var text = client.DownloadString($"{_urlApi}/{id}");
            object desSerializedObject = _serializer.DeserializeObject(text);

            if (desSerializedObject != null)
            {
                var userKeyValue = (Dictionary<string, object>)desSerializedObject;
                user = new DtoUser
                {
                    Id = (int)userKeyValue["id"],
                    Name = userKeyValue["name"].ToString(),
                    Username = userKeyValue["username"].ToString(),
                    Email = userKeyValue["email"].ToString(),
                };
            }

            return user;
        }

        public List<DtoUser> GetUsers()
        {
            List<DtoUser> users = new List<DtoUser>();
            var text = client.DownloadString(_urlApi);
            object desSerializedObject = _serializer.DeserializeObject(text);

            if (desSerializedObject != null)
            {
                var respuesta = (object[])desSerializedObject;
                foreach (var item in respuesta)
                {
                    var dataUser = (Dictionary<string, object>)item;
                    DtoUser user = new DtoUser
                    {
                        Id = (int)dataUser["id"],
                        Name = dataUser["name"].ToString(),
                        Username = dataUser["username"].ToString(),
                        Email = dataUser["email"].ToString(),
                    };

                    users.Add(user);
                }
            }

            return users;
        }
    }
}
