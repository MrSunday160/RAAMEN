[Intro]
2540124122 - Justin Thejasukmana (Solo Queue frfr)

PSD LAB Project
RAAMEN Web Application
.NET 4.7.2

Basic Code Flow

	The basic code flow scenario that I use is: View -> Controller -> Repository -Factory-> Handler

	Repository will be the only one that have direct access to db, no other class will have this access.
	Factory will be exclusively used for constructors and returning it.
	 Handler will exclusively be used for update, insert, delete, and all other logics. Will need repository db access to add to db.

Known issues:

	Crystal report producing unexpected results, even though back-end logic is valid.

	Order Queue page produces duplicate rows, but not necessarily wrong because each row contains different ramenID, only same headerID, etc.

Please reade notes.txt for detailed progress