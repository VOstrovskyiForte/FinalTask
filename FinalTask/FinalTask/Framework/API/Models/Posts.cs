using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework.API.Models
{
    public class Posts
    {

        public class CreatePostModel
        {
            public string title { get; set; }
            public string body { get; set; }
            public int userId { get; set; }

            public CreatePostModel(int userId, string title, string body)
            {
                this.userId = userId;
                this.title = title;
                this.body = body;
            }
        }

        public class PostModel
        {
            public int id { get; set; }
            public string title { get; set; }
            public string body { get; set; }
            public int userId { get; set; }
        }

        public class PostIdModel
        {
            public int id { get; set; }
        }

        public List<PostModel> PostsListModel { get; set; }



    }
}
