using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{

    public class Giant : Character,IFighter,IGatherer
    {
        private int attackPoints;
        private bool attackUpdated;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
            this.attackUpdated = false;
        }

        public int AttackPoints
        {
            get { return this.attackPoints;}
            private set { this.attackPoints = value; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone && !this.attackUpdated)
            {
                this.AttackPoints += 100;
                this.attackUpdated = true;
                return true;
            }

            return false;
        }
    }
}
