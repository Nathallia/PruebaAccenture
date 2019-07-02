using Accenture.NL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accenture.NL.Services
{
    public class Post : Base, Interface.IPost
    {
        private readonly string _urlApi;

        public Post()
        {
            _urlApi = ConfigurationManager.AppSettings["API"];
        }

        public List<DtoPost> GetPostsByUserId(int userId)
        {
            string endpointPost = ConfigurationManager.AppSettings["Posts"];

            List<DtoPost> posts = new List<DtoPost>();
            var text = client.DownloadString($"{_urlApi}/{endpointPost}?userId={userId}");
            object desSerializedObject = _serializer.DeserializeObject(text);

            if (desSerializedObject != null)
            {
                var respuesta = (object[])desSerializedObject;
                foreach (var item in respuesta)
                {
                    var dataPost = (Dictionary<string, object>)item;
                    DtoPost Post = new DtoPost
                    {
                        Id = (int)dataPost["id"],
                        Title = dataPost["title"].ToString(),
                        UserId =(int)dataPost["userId"],
                        Body = dataPost["body"].ToString(),
                        Comments = GetCommentsByCommentId((int)dataPost["id"])
                    };

                    posts.Add(Post);
                }
            }

            return posts;
        }

        private List<DtoComment> GetCommentsByCommentId(int postId)
        {
            string endpointComment = ConfigurationManager.AppSettings["Comments"];

            List<DtoComment> comments = new List<DtoComment>();
            var text = client.DownloadString($"{_urlApi}/{endpointComment}?postId={postId}");
            object desSerializedObject = _serializer.DeserializeObject(text);

            if (desSerializedObject != null)
            {
                var respuesta = (object[])desSerializedObject;
                foreach (var item in respuesta)
                {
                    var dataComment = (Dictionary<string, object>)item;
                    DtoComment Comment = new DtoComment
                    {
                        Id = (int)dataComment["id"],
                        Name = dataComment["name"].ToString(),
                        PostId = (int)dataComment["postId"],
                        Body = dataComment["body"].ToString(),
                        Email = dataComment["email"].ToString(),
                    };

                    comments.Add(Comment);
                }
            }

            return comments;
        }
    }
}
