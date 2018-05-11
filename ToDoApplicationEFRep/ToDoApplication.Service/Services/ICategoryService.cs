
using System.Collections.Generic;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Service;

namespace ToDoApplication.Logic.Services
{
    public interface ICategoryService : IBaseService<Category>
    {
        IList<Category> GetCategories();

        bool EditCategoties(IList<Category> categories, bool saveChangesImmediately = true);
    }
}
