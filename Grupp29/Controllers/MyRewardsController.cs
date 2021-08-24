using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grupp29.Models;

namespace Grupp29.Controllers
{
    public class MyRewardsController : Controller
    {
        // GET: MyRewards
        public ActionResult MyRewards()
        {
            return View();
        }

        public List<Forum> GetForumPostRewardFromAuthor(string author)
        {

            ApplicationDbContext dbContext = new ApplicationDbContext();
            var listOfMatchingForumPosts = new List<Forum>();
            var listOfAllForumPosts = dbContext.Fora.ToList();

            foreach (Forum forumPost in listOfAllForumPosts)
            {
                if (forumPost.Creator.Equals(author))
                {
                    listOfMatchingForumPosts.Add(forumPost);
                }

            }
            return listOfMatchingForumPosts;

        }
        public List<ForumPostComment> GetCommentRewardFromAuthor(string author)
        {

            ApplicationDbContext dbContext = new ApplicationDbContext();
            var listOfMatchingComments = new List<ForumPostComment>();
            var listOfAllComments = dbContext.ForumPostComments.ToList();

            foreach (ForumPostComment comment in listOfAllComments)
            {
                if (comment.Author.Equals(author))
                {
                    listOfMatchingComments.Add(comment);
                }

            }
            return listOfMatchingComments;

        }
    }
}