using Drive.Data;

namespace Drive.Repository
{
  public class Repository<T> : IRepository<T> where T : class
  {

    private readonly MyDbContext _context;
    public Repository(MyDbContext context)
    {
      _context = context;
    }
    public void Add(T entity)
    {
      _context.Set<T>().Add(entity);
      _context.SaveChanges();
    }
    public void Delete(T entity)
    {
      _context.Set<T>().Remove(entity);
      _context.SaveChanges();
    }
    public void Update(T entity)
    {
      _context.Set<T>().Update(entity);
      _context.SaveChanges();
    }
    public T GetById(string id)
    {
      return _context.Find<T>(id);
    }
    public List<T> GetAll()
    {
      return _context.Set<T>().ToList();
    }
  }
}
