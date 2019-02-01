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


        public IRestResponse GetPost(int id)
        {
            return SendRequest(Method.GET, ConfigurationAPI.baseURL, Resources.posts + "/" + id);
        }

        public IRestResponse GetAllPosts()
        {
            return SendRequest(Method.GET, ConfigurationAPI.baseURL, Resources.posts);
        }

        public IRestResponse CreatePost(int userId, string title, string body)
        {
            PostCreateModel post = new PostCreateModel(userId, title, body);
            return SendRequest(Method.POST, ConfigurationAPI.baseURL, Resources.posts, body: post);
        }
    }
}
