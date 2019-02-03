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
            var allPostsResponse = Actions.GetAllPosts();

            Assert.That(allPostsResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            PostsListModel allPosts = Methods.DeserializeResponse<PostsListModel>(allPostsResponse);

            Assert.That(allPosts.posts[postId].userId, Is.EqualTo(userId));
            Assert.That(allPosts.posts[postId].title, Is.EqualTo(title));
            Assert.That(allPosts.posts[postId].body, Is.EqualTo(body));
        }

        [Test]
        public void CreateSimplePost()
        {
            var createdPostResponse = Actions.CreatePost(1, "postTitle", "postBody");

            Assert.That(createdPostResponse.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            PostIdResponseModel createdPost = Methods.DeserializeResponse<PostIdResponseModel>(createdPostResponse);

            Assert.That(createdPost.id, Is.EqualTo(101));
        }

        [Test]
        public void UpdateRandomPost()
        {
            int postId = Generator.GetRandomNumber(100);
            var updatedPostResponse = Actions.UpdatePost(postId, 1, "newTitle", "newBody");

            Assert.That(updatedPostResponse.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            PostIdResponseModel updatedPost = Methods.DeserializeResponse<PostIdResponseModel>(updatedPostResponse);

            Assert.That(updatedPost.id, Is.EqualTo(postId));
        }

    }
}
