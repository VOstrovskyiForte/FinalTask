using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Framework.API.Models;
using static FinalTask.Framework.API.Models.Posts;

namespace FinalTask.Framework.API
{
    public class Actions : Methods
    {


        public static IRestResponse GetPost(int postid)
        {
            return SendRequest(Method.GET, ConfigurationAPI.baseURL, Resources.posts + "/" + postid);
        }

        public static IRestResponse GetAllPosts()
        {
            return SendRequest(Method.GET, ConfigurationAPI.baseURL, Resources.posts);
        }

        public static IRestResponse GetAllPosts(int userId)
        {
            return SendRequest(Method.GET, ConfigurationAPI.baseURL, Resources.posts + "?userId=" + userId.ToString());
        }

        public static IRestResponse CreatePost(int userId, string title, string body)
        {
            PostCreateModel post = new PostCreateModel(userId, title, body);
            return SendRequest(Method.POST, ConfigurationAPI.baseURL, Resources.posts, body: post);
        }

        public static IRestResponse UpdatePost(int postId, int userId, string title, string body)
        {
            PostCreateModel newPost = new PostCreateModel(userId, title, body);
            return SendRequest(Method.PUT, ConfigurationAPI.baseURL, Resources.posts + "/" + postId, body: newPost);
        }

        public static IRestResponse DeletePost(int postId)
        {
            return SendRequest(Method.DELETE, ConfigurationAPI.baseURL, Resources.posts + "/" + postId);
        }

        //actions for other items to be added if necessary
    }
}
