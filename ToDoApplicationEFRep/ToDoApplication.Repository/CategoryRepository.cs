using ToDoApplication.Logic.DataContext;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Repositories;

namespace ToDoApplication.Repository
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDataContext data) 
            : base(data)
        {
        }
    }
}