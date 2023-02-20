using System;

namespace Zalba.Repositories
{
    public interface IZalba
    {

        public interface Repositories
        {
            List<Entities.Zalba> getZalba();

            Entities.Zalba getZalbabyID(Guid id);

            ZalbaConfirmationDto postConfirmation(Entities.Zalba zl);

            ZalbaConfirmatioDto updateConfirmation(Entities.Zalba zl);

            void deleteZalba(Guid id);
            bool saveChanges();

        }
    }
}
