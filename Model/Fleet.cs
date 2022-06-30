using System.Collections.Generic;
using Vsite.BattleShip.Model;

namespace Vsite.Battleship.Model
{
    public enum HitResult
    {
        Missed,
        Hit,
        Sunken
    }

    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            var ship = new Ship(squares);
            ships.Add(ship);
        }

        public HitResult Shoot(int row, int column)
        {
            foreach (var ship in ships)
            {
                var hitResult = ship.Shoot(row, column);
                if (hitResult == HitResult.Sunken)
                {
                    this.currentSunkenShip = ship;
                }

                if (hitResult != HitResult.Missed)
                    return hitResult;
            }
            return HitResult.Missed;
        }

        public IEnumerable<Ship> Ships
        { get { return ships; } }

        public Ship CurrentSunkenShip
        {
            get { return currentSunkenShip; }
        }

        private List<Ship> ships = new List<Ship>();
        private Ship currentSunkenShip = null;
    }
}