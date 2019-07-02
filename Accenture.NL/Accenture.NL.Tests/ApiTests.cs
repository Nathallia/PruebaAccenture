using Accenture.NL.Models;
using Accenture.NL.Services;
using Accenture.NL.Services.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accenture.NL.Tests
{

    [TestFixture]
    public class ApiTests
    {

        [Test]
        public void Getusers()
        {
            IUser bl = new User();
            List<DtoUser> list = bl.GetUsers();
            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetusersById()
        {
            IUser bl = new User();
            DtoUser user = bl.GetUser(2);
            Assert.IsTrue(user.Id == 2);
        }

        [Test]
        public void GetAlbumsByUserId()
        {
            IAlbum bl = new Album();
            List<DtoAlbum> list = bl.GetAlbumsByUserId(2);
            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void GetPostByUserId()
        {
            IPost bl = new Post();
            List<DtoPost> list = bl.GetPostsByUserId(2);
            Assert.IsTrue(list.Count > 0);
        }
    }
}
