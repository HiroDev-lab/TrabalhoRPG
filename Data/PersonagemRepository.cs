public class PersonagemRepository
{
    private readonly PersonagemContext _context;

    public PersonagemRepository(PersonagemContext context)
    {
        _context = context;
    }

    public void Salvar(PersonagemModel personagem)
    {
        _context.Personagens.Add(personagem);
        _context.SaveChanges();
    }

    public List<PersonagemModel> ListarTodos()
    {
        return _context.Personagens.ToList();
    }

    public PersonagemModel? BuscarPorId(int id)
    {
        return _context.Personagens.Find(id);
    }

    public void Deletar(int id)
    {
        var personagem = _context.Personagens.Find(id);
        if (personagem != null)
        {
            _context.Personagens.Remove(personagem);
            _context.SaveChanges();
        }
    }
}
