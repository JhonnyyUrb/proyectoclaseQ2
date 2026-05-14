namespace ProyectoClaseQ2.DTOs;

public class ExperimentDto
{
    // lo que el fronted manda cuando alguien crea un experimento
    // NO VAMOS A INCLUIR EL USERID PORQUE LO VAMOS A SACAR DEL TOKEN
    
    public string Tittle { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
    public bool Success { get; set; } = false;
}