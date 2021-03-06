using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Vsite.BattleShip.Model;

namespace Vsite.Battleship.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Inline
    }

    public class Gunnery
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            monitoringGrid = new EnemyGrid(rows, columns);
            this.squareEliminator = new SquareEliminator(rows, columns);
            shipsToShoot = new List<int>(shipLengths);
            ChangeToRandomTactics();
        }
        public Square NextTarget()
        {
            lastTarget = targetSelector.NextTarget();
            return lastTarget;
        }
        public bool ProcessHitResult(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    RecordOnMonitoringGrid(hitResult);
                    return true;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
                    RecordOnMonitoringGrid(hitResult);
                    if (currentTactics == ShootingTactics.Inline)
                        return true;
                    break;
                case HitResult.Sunken:
                    squaresHit.Add(lastTarget);
                    shipsToShoot.Remove(squaresHit.Count);
                    RecordOnMonitoringGrid(hitResult);
                    squaresHit.Clear();
                    break;
                default:
                    Debug.Assert(false);
                    return false;
            }

            if (this.shipsToShoot.Any())
            {
                ChangeCurrentTactics(hitResult);
                return true;
            }

            return false;
        }
        private void RecordOnMonitoringGrid(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Missed);
                    break;
                case HitResult.Hit:
                    monitoringGrid.ChangeSquareState(lastTarget.Row, lastTarget.Column, SquareState.Hit);
                    break;
                case HitResult.Sunken:
                    foreach (var s in squaresHit)
                    {
                        monitoringGrid.ChangeSquareState(s.Row, s.Column, SquareState.Sunken);
                    }
                    // TODO: mark surrounding squares as Missed
                    var toEliminate = this.squareEliminator.ToEliminate(squaresHit);
                    foreach (var s in toEliminate)
                    {
                        monitoringGrid.ChangeSquareState(s.Row, s.Column, SquareState.Eliminated);
                    }
                    break;
            }
        }
        public ShootingTactics ShootingTactics
        {
            get { return currentTactics; }
        }
        private void ChangeCurrentTactics(HitResult hitResult)
        {
            if (hitResult == HitResult.Sunken)
            {
                ChangeToRandomTactics();
            }
            else
            {
                switch (currentTactics)
                {
                    case ShootingTactics.Random:
                        ChangeToSurroundingTactics();
                        break;
                    case ShootingTactics.Surrounding:
                        ChangeToInlineTactics();
                        break;
                    default:
                        Debug.Assert(false);
                        break;
                }
            }
        }
        private void ChangeToSurroundingTactics()
        {
            currentTactics = ShootingTactics.Surrounding;
            targetSelector = new SurroundingShooting(monitoringGrid, squaresHit.First(), shipsToShoot[0]);
        }
        private void ChangeToInlineTactics()
        {
            currentTactics = ShootingTactics.Inline;
            targetSelector = new InlineShooting(monitoringGrid, squaresHit, shipsToShoot[0]);
        }
        private void ChangeToRandomTactics()
        {
            currentTactics = ShootingTactics.Random;
            targetSelector = new RandomShooting(monitoringGrid, shipsToShoot[0]);
        }

        private EnemyGrid monitoringGrid;
        private List<int> shipsToShoot;
        private Square lastTarget = new Square(0, 0);
        private List<Square> squaresHit = new List<Square>();
        private SquareEliminator squareEliminator;

        private ShootingTactics currentTactics = ShootingTactics.Random;
        private INextTarget targetSelector;
    }
}
