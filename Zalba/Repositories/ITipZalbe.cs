namespace Zalba.Repositories
{
    public class ITipZalbe
    {
        public interface Repositories
        {
            List<Entities.Zalba> getTipZalbe();

            Entities.Zalba getTipZalbeByID(Guid id);

            TipZalbeConfirmationDto postConfirmation(Entities.Zalba zl);

            TipZalbeConfirmationDto updateConfirmation(Entities.Zalba zl);

            void deleteZalba(Guid id);
            bool saveChanges();

        }
    }
}
