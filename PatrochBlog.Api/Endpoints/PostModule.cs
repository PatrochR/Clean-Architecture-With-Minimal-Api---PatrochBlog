using Microsoft.AspNetCore.Builder;
using PatrochBlog.Core.Interfaces.Repository;

namespace PatrochBlog.Api.Endpoints
{
    public static class PostModule
    {
        public static void PostEndpoints(this WebApplication app) 
        {
            
            app.MapGet("/post/getlatest/{count}", async (int count,IPostRepository _postRepository) => 
            {
                try
                {
                    return Results.Ok(await _postRepository.GetLatestPosts(count));
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
        }
    }

}
