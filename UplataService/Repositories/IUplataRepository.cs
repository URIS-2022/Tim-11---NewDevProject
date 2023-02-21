using System;
using UplataService.Entities.cs;

namespace UplataService.Repositories
{
	public interface IUplataRepository
    {
		List<Uplata> getAllUplate();

		Uplata getUplataById(Guid id);

		void deleteUplata(Guid id);

		Uplata postUplata(Uplata uplata);

		void updateUplata(Uplata uplata);

		bool SaveChanges();

		bool checkIfUserExist(string username, string password);
	}
}

