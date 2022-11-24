# SoftwareDesignExam

## Pensum, hva bør være med
- [ ] UML diagrammer.
- [ ] C# .NET, med en del finesser fra språket: properties!, evt. operator overloading, …
- [ ] SOLID (beskriv gjennom dokumentasjonen hvilke prinsipper dere har fokus på).
- [ ] Design patterns (plukk noen få av de vi har lært om: prøver man å benytte alle blir det kaos).
  - [x] Factory
  - [ ] Decorator
  - [ ] Singelton
- [ ] Refactoring (sørg for at koden holdes oversiktlig og lett å sette seg inn i). Beskriv refactoring
  prosessen deres, den kan være vanskelig å se ut fra koden.
- [ ] Lagdeling.
- [ ] Unit testing. Merk: Det er omfattende å skrive nok unit tests til å dekke en hel løsning.
  Derfor ok om man bare benytter det på deler av løsningen. Men beskriv i så fall hva dere
  velger å teste og hvorfor. Implementer tester slik at dere får vist bredden av hva dere kan
  om unit testing.
- [ ] Multithreading / event-basert kode (pass i så fall på at dere skriver trådsikker kode).
- [ ] Parprogrammering. Beskriv i så fall hvordan dere benytter dette, samt erfaringene dere har
  gjort dere.
- [ ] Bruk av versjonskontroll.



using Model.Base.Weapons.Abstract;
using Model.Decorator.Abstract;

namespace Model.Base.Weapons
{

    //TODO: refactor til abstract weapon?
    public class GoldSword : Weapon
    {
        #region private fileds
        private CharacterInfo? _target;
        private Weapon? _enemyWeapon;
        private int _counter = 0;
        #endregion

        #region constructor
        public GoldSword() : base() {
            _target = null;
            Description = "You have a 100% chance to disarm a enemy and adds 2000 to base damage";
        }
        #endregion

        #region overrides
        public override double GetDamage() {
            if (_target == null) {
                CheckIfYouDisarmEnemy();

            }

            return Damage +2000;
        }
       

        public override void SetTarget(CharacterInfo target) {
            this._target = target;
        }
        #endregion

        #region private methods
        private void CheckIfYouDisarmEnemy() {
            if (_counter == 0) {
                Random random = new Random();
                var chance = random.Next(100);
                if (chance <= 100) {
                    _enemyWeapon = _target?.GetWeapon();
                    _target?.SetWeapon(new NoWeapon());
                }

            }
            else if (_counter == 4) {
                if (_enemyWeapon != null) {
                    _target?.SetWeapon(_enemyWeapon);
                    _target = null;
                    _counter = 0;
                }
            }
            else {
                _counter++;
            }
        }
        #endregion
    }
}