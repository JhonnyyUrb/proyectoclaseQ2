using System.Security.Cryptography;
using System.Text;
using Google.Cloud.Firestore;
using ProyectoClaseQ2.DTOs;
using ProyectoClaseQ2.Models;

namespace ProyectoClaseQ2.Services;

public class AuthService
{
    // maneja tod0 lo relacionado a registro e inicio de sesion
    private readonly firebaseService _firebaseService;
    private readonly IConfiguration _configuration;

    public AuthService(FirestoreDb firebaseService, IConfiguration configuration)
    {
        _firebaseService = _firebaseService;
        _configuration = _configuration;
    }

    public async Task<User> Register(RegisterDto dto)
    {
        //primero verificamos que noe xista un usuario con ese correo 
         var collection  = _firebaseService.GetCollection("users");
         var existing = await collection
             .WhereEqualTo("Email", dto.Email)
             .GetSnapshotAsync();

         if (existing.Count >0)
         
             throw new Exception("YA EXISTE UN USER CON ESE CORREO ");
         
         //CREAMOS EL OBEJETO CON LA CONTRAEÑA HASHEADA

         var user = new User
         {
             Id = Guid.NewGuid().ToString(),
             FullName = dto.FullName,
             Email = dto.Email,
             PasswordHash = dto.Password,
             Role = "user",
             Created = DateTime.UtcNow
         };

                 // guardamos en fs usanod el id como nombre del doc
                 await collection.Document(user.Id).SetAsync(new Dictionary<string, object>
                 {
                     {"Id", user.Id},
                     {"fullName", user.FullName},
                     {"Email", user.Email},
                     {"PasswordHash", user.PasswordHash},
                     {"Role", user.Role},
                     {"Created", user.Created}
                 });
return user;

    }

    private string HashPassword(string password)
    
        {
           // SHA256
           var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
           return Convert.ToBase64String(bytes);
        }
    }

