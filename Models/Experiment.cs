namespace ProyectoClaseQ2.Models;

public class Experiment
{
    // representa un experimento o prueba que un usuario este realizando
    // funcionalidad principal despues de hacer el login
    
    public string Id { get; set; } 
    
    // titulo de lo que intento hacer
    
    public string Title { get; set; } = string.Empty;
    
    // el resultado de si funciono o nel
    public string Result { get; set; } = string.Empty;
    
    // usuiaroi que creo el experimento/ prueba
    public string UserId { get; set; } = string.Empty;
    
    
    // exito o fracasado
    public bool Succes { get; set; } = false;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}