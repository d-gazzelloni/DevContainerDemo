namespace Demo.Infrastructure.EntityFramework.Entities;

public class Task
{
    public int Id { get; set; } // Chiave primaria
    public string Title { get; set; } // Titolo del task
    public string Description { get; set; } // Descrizione del task
    public bool IsCompleted { get; set; } // Stato completamento

    // Relazioni
    public int UserId { get; set; } // Chiave esterna
    public User User { get; set; } // Collegamento all'entità User
}