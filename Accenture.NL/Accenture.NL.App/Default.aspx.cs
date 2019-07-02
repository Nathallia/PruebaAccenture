using Accenture.NL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Accenture.NL.Models;

namespace Accenture.NL.Presentacion
{
    public partial class _Default : Page
    {
        private const string _posts = "PostComments";

        public static List<DtoPost> PostComments
        {
            get
            {
                return HttpContext.Current.Session[_posts] as List<DtoPost>;
            }
            set
            {
                HttpContext.Current.Session[_posts] = value;
            }
        }

        private const string _albums = "AlbumPhotos";

        public static List<DtoAlbum> AlbumPhotos
        {
            get
            {
                return HttpContext.Current.Session[_albums] as List<DtoAlbum>;
            }
            set
            {
                HttpContext.Current.Session[_albums] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divAlbums.Visible = divPosts.Visible = false;
                Services.Interface.IUser userService = new User();
                grdUser.DataSource = userService.GetUsers();
                grdUser.DataBind();
            }
        }

        protected void grdUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            divAlbums.Visible = divPosts.Visible = false;
            int rowIndex = Convert.ToInt32(e.CommandArgument); 
            int index = Convert.ToInt32(grdUser.DataKeys[rowIndex].Value);

            if (e.CommandName == "Post")
            {
                Services.Interface.IPost postService = new Post();
                divPosts.Visible = true;
                PostComments = postService.GetPostsByUserId(index);
                grdPosts.DataSource = PostComments;
                grdPosts.DataBind();
                grdComments.DataSource = null;
                grdComments.DataBind();
            }
            else if (e.CommandName == "Album")
            {
                Services.Interface.IAlbum albumService = new Album();
                divAlbums.Visible = true;
                grdPhoto.DataSource = null;
                grdPhoto.DataBind();
                AlbumPhotos = albumService.GetAlbumsByUserId(index);
                grdAlbum.DataSource = AlbumPhotos;
                grdAlbum.DataBind();
            }
        }

        protected void grdPosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            divAlbums.Visible = false;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int index = Convert.ToInt32(grdPosts.DataKeys[rowIndex].Value);

            if (e.CommandName == "Comment")
            {
                grdComments.DataSource = PostComments.FirstOrDefault(p=> p.Id == index).Comments.ToList();
                grdComments.DataBind();
            }
        }

        protected void grdAlbum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            divPosts.Visible = false;
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            int index = Convert.ToInt32(grdAlbum.DataKeys[rowIndex].Value);

            if (e.CommandName == "Photo")
            {
                grdPhoto.DataSource = AlbumPhotos.FirstOrDefault(p => p.Id == index).Photos.ToList();
                grdPhoto.DataBind();
            }
        }
    }
}