using PatrochBlog.Core.Domain.Request;
using PatrochBlog.Core.Interfaces.Repository;
using PatrochBlog.Api.ResponseModel;
using PatrochBlog.Core.Domain;

namespace PatrochBlog.Api.Endpoints
{
    public static class CategoriesModule
    {
        public static void CategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/category", async (ICategoryRepository _categoryRepository) => 
            {
                var response = new Response<List<Category>>(true);
                var categories = await _categoryRepository.GetAllCategory();
                if (categories is null)
                {
                    response.Success = false;
                    response.ErrorMessage = "We Dont Have A Category";
                    return Results.BadRequest(response);
                }
                response.Data = categories;
                return Results.Ok(response);
            });
            app.MapGet("/category/{id}", async (int id , ICategoryRepository _categoryRepository) => 
            {
                var response = new Response<Category>(true);
                try
                {
                    response.Data = await _categoryRepository.GetCategoryById(id);
                    return Results.Ok(response);
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.ErrorMessage = ex.Message;
                    return Results.BadRequest(response);
                }
            });
            app.MapPost("/category", async (AddCategoryRequest request , ICategoryRepository _categoryRepository) => 
            {
                var response = new Response<string>(true);
                try
                {
                    var id = await _categoryRepository.AddCategory(new Core.Domain.Category 
                    {
                        CreatedDate = DateTime.UtcNow,
                        Title = request.Title,
                    });
                    response.Data = $"Category {id} Was Added";
                    return Results.Ok(response);

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.ErrorMessage= ex.Message;
                    return Results.BadRequest(response);
                }
            });
            app.MapPut("/category", async (EditCategoryRequest request , ICategoryRepository _categoryRepository) => 
            {
                var response = new Response<string>(true);

                try
                {
                    await _categoryRepository.EditCategory(new Core.Domain.Category 
                    {
                        Id = request.Id,
                        Title = request.Title
                    });
                    response.Data = "Category Edited";
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
