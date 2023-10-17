using Microsoft.AspNetCore.Builder;
using PatrochBlog.Api.ResponseModel;
using PatrochBlog.Core.Domain;
using PatrochBlog.Core.Interfaces.Repository;

namespace PatrochBlog.Api.Endpoints
{
    public static class PostModule
    {
        public static void PostEndpoints(this WebApplication app) 
        {
            
            app.MapGet("/post/getlatest/{count}", async (int count,IPostRepository _postRepository) => 
            {
                var response = new Response<List<Post>>(true);
                try
                {
                    response.Data = await _postRepository.GetLatestPosts(count);
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.ErrorMessage = ex.Message;
                    return Results.BadRequest(response);
                }
            });
        }
    }

}
