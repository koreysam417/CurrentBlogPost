using Blog.Web.Repositories;
using Blog.Web.Models.ViewModels;
using Blog.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Blog.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {

        private readonly IBlogPostRepository blogPostRepository;

        public BlogPost BlogPost { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;

        } 
        public async Task<IActionResult> OnGet(string urlHandle)
        {

           BlogPost = await blogPostRepository.GetAsync(urlHandle);

            return Page();

        }
    }
}
