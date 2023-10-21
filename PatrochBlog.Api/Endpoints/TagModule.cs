using PatrochBlog.Api.ResponseModel;
using PatrochBlog.Core.Domain;
using PatrochBlog.Core.Domain.Request.Tag;
using PatrochBlog.Core.Interfaces.Repository;


namespace PatrochBlog.Api.Endpoints
{
    public static class TagModule
    {
        public static void TagEndpoint(this WebApplication app)
        {
            app.MapGet("/tag", async (ITagRepository _tagRepository) => 
            {
                var response = new Response<List<Tag>>(true);
                try
                {
                    var tags = await _tagRepository.GetAllTags();
                    if (tags is null)
                    {
                        response.Success = false;
                        response.ErrorMessage = "We Can't Find Tag";
                        return Results.BadRequest(response);
                    }

                    response.Data = tags;
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.ErrorMessage = ex.Message;
                    return Results.BadRequest(response);
                }
                
               
            });

            app.MapGet("/tag/{id}", async (int id , ITagRepository _tagRepository) => 
            {
                var response = new Response<Tag>(true);
                try
                {
                    var tag = await _tagRepository.GetTagById(id);
                    if (tag is null)
                    {
                        response.Success = false;
                        response.ErrorMessage = "We Can't Find this Tag";
                    }
                    response.Data = tag;
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.ErrorMessage = ex.Message;
                    return Results.BadRequest(response);    
                }
            });

            app.MapPost("/tag", async (AddTagRequest request , ITagRepository _tagRepository) => 
            {
                var response = new Response<string>(true);
                try
                {
                    var tagId = await _tagRepository.AddTag(new Tag()
                    {
                        CreatedTime = DateTime.Now,
                        Title = request.Title,
                    });
                    response.Data = "Tag was Added";
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    response.Success = false;   
                    response.ErrorMessage = ex.Message;
                    return Results.BadRequest(response);
                }
            });

            app.MapPut("/tag", async (EditTagRequest request , ITagRepository _tagRepository) =>
            {
                var response = new Response<string>(true);
                try
                {
                    await _tagRepository.EditTag(new Tag() 
                    {
                        Id = request.Id,
                        Title = request.Title
                    });
                    response.Data = "Tag Was Edited";
                    return Results.Ok(response);

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.ErrorMessage = ex.Message;
                    return Results.BadRequest(response);
                }
            });

            app.MapDelete("/tag", async (DeleteTagRequest request , ITagRepository _tagRepository) => 
            {
                var response = new Response<string>(true);
                try
                {
                    await _tagRepository.DeleteTag(request.Id);
                    response.Data = "Tag Was Deleted";
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
