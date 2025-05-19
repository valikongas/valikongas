using API_Nr7_Uzrasine.Data;
using API_Nr7_Uzrasine.Object;
using Microsoft.EntityFrameworkCore;

namespace API_Nr7_Uzrasine.BusinessLogic
{
    public class MessageService
    {
        private readonly ApiDbContext _apiDbContext;
        public MessageService(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public bool CreateMessage(string content, string categoryName, UserUzrasine user, List<IFormFile> pictures)
        {
            try
            {
                var category = _apiDbContext.CategoriesUZrasine.FirstOrDefault(c => c.Name == categoryName && c.User.Id == user.Id);
                if (category != null)
                {
                    var newMessage = new MessageUzrasine
                    {
                        Text = content,
                        Category = category
                    };
                    if (pictures != null && pictures.Count > 0)
                    {
                        newMessage.Picture = new List<Picture>();
                        foreach (var picture in pictures)
                        {
                            using (var memoryStream = new MemoryStream())
                            {

                                picture.CopyToAsync(memoryStream);
                                var newPicture = new Picture
                                {
                                    Image = memoryStream.ToArray()
                                };
                                newMessage.Picture.Add(newPicture);
                            }
                        }
                    }
                    _apiDbContext.MessagesUzrasine.Add(newMessage);
                    _apiDbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteMessage(int mesaggeId, UserUzrasine user)
        {
            try
            {
                var message = _apiDbContext.MessagesUzrasine
                    .Include(m => m.Picture) // Užtikriname, kad paveikslėliai bus įkelti
                    .FirstOrDefault(m => m.Id == mesaggeId && m.Category.User.Id == user.Id);

                if (message != null)
                {
                    // Ištriname paveikslėlius, susijusius su žinute
                    if (message.Picture != null)
                    {
                        _apiDbContext.Pictures.RemoveRange(message.Picture);
                    }

                    // Ištriname pačią žinutę
                    _apiDbContext.MessagesUzrasine.Remove(message);
                    _apiDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
