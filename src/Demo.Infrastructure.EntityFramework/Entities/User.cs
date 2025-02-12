namespace Demo.Infrastructure.EntityFramework.Entities;

public class User
{
    
    public int Id { get; set; } // Chiave primaria
    public string Name { get; set; } // Nome dell'utente
    public string Email { get; set; } // Email dell'utente

    // Relazioni
    public List<Task> Tasks { get; set; } // Relazione uno-a-molti con i Task
}