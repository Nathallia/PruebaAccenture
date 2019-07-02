using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accenture.NL.Models;

namespace Accenture.NL.Services
{
    public class Album : Base, Interface.IAlbum
    {
        private readonly string _urlApi;

        public Album()
        {
            _urlApi = ConfigurationManager.AppSettings["API"];
        }

        public List<DtoAlbum> GetAlbumsByUserId(int userId)
        {
            string endpointAlbum = ConfigurationManager.AppSettings["Albums"];

            List<DtoAlbum> albums = new List<DtoAlbum>();
            var text = client.DownloadString($"{_urlApi}/{endpointAlbum}?userId={userId}");
            object desSerializedObject = _serializer.DeserializeObject(text);

            if (desSerializedObject != null)
            {
                var respuesta = (object[])desSerializedObject;
                foreach (var item in respuesta)
                {
                    var dataAlbum = (Dictionary<string, object>)item;
                    DtoAlbum Album = new DtoAlbum
                    {
                        Id = (int)dataAlbum["id"],
                        Title = dataAlbum["title"].ToString(),
                        User = new DtoUser()
                        {
                            Id =(int)dataAlbum["userId"]
                        },
                        Photos = GetPhotosByPhotoId((int)dataAlbum["id"])
                    };

                    albums.Add(Album);
                }
            }

            return albums;
        }

        private List<DtoPhoto> GetPhotosByPhotoId(int albumId)
        {
            string endpointPhoto = ConfigurationManager.AppSettings["Photos"];

            List<DtoPhoto> photos = new List<DtoPhoto>();
            var text = client.DownloadString($"{_urlApi}/{endpointPhoto}?albumId={albumId}");
            object desSerializedObject = _serializer.DeserializeObject(text);

            if (desSerializedObject != null)
            {
                var respuesta = (object[])desSerializedObject;
                foreach (var item in respuesta)
                {
                    var dataPhoto = (Dictionary<string, object>)item;
                    DtoPhoto Photo = new DtoPhoto
                    {
                        Id = (int)dataPhoto["id"],
                        Title = dataPhoto["title"].ToString(),
                        AlbumId = (int)dataPhoto["albumId"],
                        ThumbnailUrl = dataPhoto["thumbnailUrl"].ToString(),
                        Url = dataPhoto["url"].ToString(),
                    };

                    photos.Add(Photo);
                }
            }

            return photos;
        }
    }
}
