namespace ProyectoClaseQ2.Models;

public class User
{
    // representar un user en el sistema
    //nesta clase es lo que vamos a guadar en firestore y leer
    
    public string Id { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
   
     
    // la contraseña  siempre ira hasheada, nunca en texto planoi
    public string PasswordHash { get; set; } = string.Empty;
    
    // colocar un rol por defecto
     public string Role { get; set; } = "user";
     
     // para saber cuando se cre el registro
     public DateTime Created { get; set; } = DateTime.UtcNow; 
}