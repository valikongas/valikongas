using API_Nr7_Uzrasine.Data;
using API_Nr7_Uzrasine.Object;

namespace API_Nr7_Uzrasine.BusinessLogic
{
    public class CategoryService
    {
    
        private readonly ApiDbContext _apiDbContext;
        public CategoryService( ApiDbContext apiDbContext)
        {
      
            _apiDbContext = apiDbContext;
        }

        public bool CreateCategory(string name, UserUzrasine user)
        {
            try
            {
                var newCategory = new CategoryUzrasine
                {
                    Name = name,
                    User = user,
                    Message = new List<MessageUzrasine>()
                };

                _apiDbContext.CategoriesUZrasine.Add(newCategory);
                _apiDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCategoryName(string categoryOldName, string newName, UserUzrasine user)
        {
            try
            {
                var category = _apiDbContext.CategoriesUZrasine.FirstOrDefault(c => c.Name == categoryOldName && c.User.Id == user.Id);
                if (category != null)
                {
                    category.Name = newName;
                    _apiDbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool DeleteCategory(string categoryName, UserUzrasine user)
        {
            try
            {
                var category = _apiDbContext.CategoriesUZrasine.FirstOrDefault(c => c.Name == categoryName && c.User.Id == user.Id);

                if (category != null)
                {
                    // Retrieve messages associated with the category  
                    var messages = _apiDbContext.MessagesUzrasine.Where(m => m.Category.Id == category.Id).ToList();

                    foreach (var message in messages)
                    {
                        // Remove pictures associated with each message  
                        var pictures = _apiDbContext.Pictures.Where(p => p.Message.Id == message.Id).ToList();
                        _apiDbContext.Pictures.RemoveRange(pictures);

                        // Remove the message itself  
                        _apiDbContext.MessagesUzrasine.Remove(message);
                    }

                    // Remove the category  
                    _apiDbContext.CategoriesUZrasine.Remove(category);
                    _apiDbContext.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CategoryExists(string name, UserUzrasine user)
        {
            return _apiDbContext.CategoriesUZrasine.Any(c => c.Name == name && c.User.Id == user.Id);
        }

        public List<CategoryUzrasine> GetUserCategories(string userName)
        {
            return _apiDbContext.CategoriesUZrasine
                .Where(category => category.User.Username == userName)
                .ToList();
        }
    }
}
