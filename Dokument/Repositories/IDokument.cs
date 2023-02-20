using System;
using Dokument.DtoModels;

namespace Dokument.Repositories
{
    public interface IDokument
    {


        
            List<Entities.Dokument> getDokument();

            Entities.Dokument getDokumentByID(Guid id);

            DokumentConfirmationDto postDokument(Entities.Dokument dok);

            DokumentConfirmationDto updateDokument(Entities.Dokument dok);

            void deleteDokument(Guid id);
            bool saveChanges();
        Entities.Dokument updateDokument(Guid dokumentUid, DokumentUpdateDto requestDto);
        Entities.Dokument DokumentCreation(DokumentCreation requestDto);
    }
}
