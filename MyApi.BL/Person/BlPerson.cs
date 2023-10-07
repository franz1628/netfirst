using MyApi.DA.EF;

namespace MyApi.BL.Person
{
    public partial class BlPerson : IBlPerson
    {
        private readonly MyApiContext context;
        public BlPerson(MyApiContext context)
        {
            this.context = context;
        }
    }
}
