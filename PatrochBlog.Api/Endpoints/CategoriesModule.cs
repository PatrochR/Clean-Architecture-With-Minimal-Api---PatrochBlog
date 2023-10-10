using PatrochBlog.Core.Domain.Request;
using PatrochBlog.Core.Interfaces.Repository;

namespace PatrochBlog.Api.Endpoints
{
    public static class CategoriesModule
    {
        public static void CategoryEndpoints(this WebApplication app)
        {
            app.MapGet("/category", async (ICategoryRepository _categoryRepository) => 
            {
                var categories = await _categoryRepository.GetAllCategory();
                if (categories is null)
                {
                    return Results.Ok("We Dont Have Category");
                }
                return Results.Ok(categories);
            });
            app.MapGet("/category/{id}", async (int id , ICategoryRepository _categoryRepository) => 
            {
                try
                {
                    return Results.Ok(await _categoryRepository.GetCategoryById(id));
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            app.MapPost("/category", async (AddCategoryRequest request , ICategoryRepository _categoryRepository) => 
            {
                try
                {
                    var id = await _categoryRepository.AddCategory(new Core.Domain.Category 
                    {
                        CreatedDate = DateTime.UtcNow,
                        Title = request.Title,
                    });
                    return Results.Ok($"Category {id} Was Added");

                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            app.MapPut("/category", async (EditCategoryRequest request , ICategoryRepository _categoryRepository) => 
            {
                try
                {
                    await _categoryRepository.EditCategory(new Core.Domain.Category 
                    {
                        Id = request.Id,
                        Title = request.Title
                    });
                    return Results.Ok("Category Edited");
                }
                catch (Exception ex)
                {
                    return Results.Ok(ex.Message);
                }
            });
        }
    }
}
