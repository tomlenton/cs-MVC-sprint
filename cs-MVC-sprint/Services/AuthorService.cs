using cs_MVC_sprint.Models;



namespace cs_MVC_sprint.Services
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        Author AddAuthor(Author author);
        Author DeleteAuthorById(int id);
    }
    public class AuthorService : IAuthorService
    {

        public IAuthorModel _authorModel;
        public AuthorService (IAuthorModel authorModel)
        {
            _authorModel = authorModel;
        }
        public List<Author> GetAllAuthors()
        {
            return _authorModel.GetAllAuthors();
        }
        public Author GetAuthorById(int id)
        {
            return _authorModel.GetAuthorById(id);
        }
        public Author AddAuthor(Author author)
        {
            return _authorModel.AddAuthor(author);
        }

        public Author DeleteAuthorById(int id)
        {
            return _authorModel.DeleteAuthorById(id);
        }
    }
}
