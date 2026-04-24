using System.Text.Json;

namespace cs_MVC_sprint.Models
{
    public interface IAuthorModel
    {
        List<Author> GetAllAuthors();
        Author GetAuthorById(int id);
        Author AddAuthor(Author author);
        Author DeleteAuthorById(int id);

    }
    public class AuthorModel : IAuthorModel
    {
        public List<Author> GetAllAuthors()
        {
            var filepath = "Resources/Authors.json";
            var json = File.ReadAllText(filepath);
            List<Author>? authors = JsonSerializer.Deserialize<List<Author>>(json);

            return authors.Select(author => new Author
            {
                Id = author.Id,
                Name = author.Name,
                Nationality = author.Nationality
            }).ToList();

        }
        public Author GetAuthorById(int id)
        {
            var filepath = "Resources/Authors.json";
            var json = File.ReadAllText(filepath);
            List<Author>? authors = JsonSerializer.Deserialize<List<Author>>(json);
            Author? author = authors.FirstOrDefault(a => a.Id == id);
            if (author == null)
                throw new Exception("ID doesn't match an author");

            return author;

        }
        public Author AddAuthor(Author author)
        {
            var filepath = "Resources/Authors.json";
            var json = File.ReadAllText(filepath);
            List<Author>? authors = JsonSerializer.Deserialize<List<Author>>(json);
            author.Id = authors[authors.Count - 1].Id + 1;
            authors.Add(author);
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filepath, JsonSerializer.Serialize(authors, options));
            return author;
        }
        public Author DeleteAuthorById(int id)
        {
            var filepath = "Resources/Authors.json";
            var json = File.ReadAllText(filepath);
            List<Author>? authors = JsonSerializer.Deserialize<List<Author>>(json);
            Author? author = authors.FirstOrDefault(a => a.Id == id);
            authors.Remove(author);
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(filepath, JsonSerializer.Serialize(authors, options));

            return author;
        }
    }
}
