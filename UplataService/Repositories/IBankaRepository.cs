using System;
using UplataService.Entities.cs;

namespace UplataService.Repositories
{
	public interface IBankaRepository
	{
		List<Banka> getAllBanke();

        Banka getBankaById(Guid id);

		void deleteBanka(Guid id);

		void updateBanka(Banka banka);

        Banka postBanka(Banka banka);

		bool SaveChanges();

	}

}

