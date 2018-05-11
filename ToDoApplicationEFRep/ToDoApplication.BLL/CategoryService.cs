

using System.Collections.Generic;
using ToDoApplication.Logic.Entities;
using ToDoApplication.Logic.Repositories;
using ToDoApplication.Logic.Services;

namespace ToDoApplication.Service
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = _unitOfWork.Repository<Category>() as ICategoryRepository;
        }

        public bool EditCategoties(IList<Category> categories, bool saveChangesImmediately = true)
        {
            foreach (var entity in categories)
            {
                if (entity.TypeID == 0)
                {
                    _categoryRepository.Add(entity);
                }
                else
                {
                    _categoryRepository.Update(entity);
                }
            }

            if (saveChangesImmediately)
            {
                _unitOfWork.SaveChanges();
            }
            return true;
        }

        public IList<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }
    }
}
