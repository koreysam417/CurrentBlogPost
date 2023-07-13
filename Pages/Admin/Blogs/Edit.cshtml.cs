using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Blog.Web.Pages.Admin.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        [BindProperty]
        public IFormFile FeaturedImage { get; set; }


        public EditModel(IBlogPostRepository blogPostRepository)
        {
       
            this.blogPostRepository = blogPostRepository;
        }
        public async Task OnGet(Guid id)
        {

          BlogPost = await blogPostRepository.GetAsync(id);

            if (BlogPost != null)
            {

            }
        }

        public async Task<IActionResult> OnPostEdit()
        {

            try
            {
                //throw new Exception();

                await blogPostRepository.UpdateAsync(BlogPost);

                ViewData["Notification"] = new Notification
                {
                    Message = "Record updated successfully!",
                    Type = Enums.NotificationType.Success
                };
            }
            catch (Exception)
            {

                ViewData["Notification"] = new Notification
                {
                    Type = Enums.NotificationType.Error,
                    Message = "Something went wrong!"
                };

              
            }

            return Page();

        }

        public async Task<IActionResult> OnPostDelete()
        {
           var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);

            if (deleted)
            {


                var notification = new Notification
                {
                    Type = Enums.NotificationType.Success,
                    Message = "Blog post was deleted"
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Blogs/List");
            }

            return Page();

        }
    }
}
