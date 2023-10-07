using Microsoft.EntityFrameworkCore;
using MyApi.DA.EF;
using MyApi.Transversal.Entidades;


namespace MyApi.BL.Person
{
    public partial interface IBlPerson
    {
        Task<BeResponse<BePerson>> Login(BePerson model);
    }
    public partial class BlPerson : IBlPerson
    {
        public async Task<BeResponse<BePerson>> Login(BePerson model)
        {
            BeResponse<BePerson> response = new();
            try
            {
                var usuario = await (
                    from u in context.Person
                    select new BePerson
                    {
                        Name = u.Name,
                        FirstSurname = u.FirstSurname,
                        SecondSurname = u.SecondSurname,
                        State = u.State,
                    }).FirstOrDefaultAsync();

                if (usuario == null)
                {
                    response.Status = false;
                    response.Message = "Usuario o contraseña incorrectos";
                }
                else
                {
                    response.Status = true;
                    response.Message = "Usuario autenticado";
                    response.Data = usuario;
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
