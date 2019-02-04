using FinalTask.Framework.API;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Framework.API.Models;
using static FinalTask.Framework.API.Models.Posts;
using FinalTask.Framework;

namespace FinalTask.TestsAPI
{
    [TestFixture]
    class APITests : BaseTestAPI
    {



        [Test]
        [TestCaseSource(typeof(Data.PostsData), "Posts")]
        public void CheckFirstFourPosts(int postId, int userId, string title, string body)
        {
            IRestResponse allPostsResponse = Actions.GetAllPosts();

            Assert.That(allPostsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            List<PostModel> allPosts = deserializer.Deserialize<List<PostModel>>(allPostsResponse);

            var post = (PostModel)allPosts.Where(x => x.id == postId).First();
            Assert.That(post.userId, Is.EqualTo(userId));
            Assert.That(post.title, Is.EqualTo(title));
            Assert.That(post.body, Is.EqualTo(body.Replace("\\n", "\n")));
        }

        [Test]
        public void CreateSimplePost()
        {
            IRestResponse createdPostResponse = Actions.CreatePost(1, "postTitle", "postBody");

            Assert.That(createdPostResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            PostIdModel createdPost = deserializer.Deserialize<PostIdModel>(createdPostResponse);

            Assert.That(createdPost.id, Is.EqualTo(101));
        }

        [Test]
        public void UpdateRandomPost()
        {
            int postId = Generator.GetRandomNumber(100);
            IRestResponse updatedPostResponse = Actions.UpdatePost(postId, 1, "newTitle", "newBody");

            Assert.That(updatedPostResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            PostIdModel updatedPost = deserializer.Deserialize<PostIdModel>(updatedPostResponse);

            Assert.That(updatedPost.id, Is.EqualTo(postId));
        }

    }
}
