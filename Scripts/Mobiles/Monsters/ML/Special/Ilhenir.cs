using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Spells;
using Server.Network;
using System.Collections.Generic;
using Server.Engines.CannedEvil;

namespace Server.Mobiles
{
    [CorpseName("a corpse of Ilhenir")]
    public class Ilhenir : BaseChampion
    {
        public override ChampionSkullType SkullType { get { return ChampionSkullType.Power; } }

        public override Type[] UniqueArtifacts{ get { return new Type[] { }; } }

        public override Type[] SharedArtifacts{ get { return new Type[] {
			typeof( ANecromancerShroud ),
			typeof( LieutenantOfTheBritannianRoyalGuard ),
			typeof( OblivionsNeedle ),
			typeof( TheRobeOfBritanniaAri ) }; } }

        public override Type[] DecorationArtifacts{ get { return new Type[] {
            typeof( MonsterStatuette ),
            typeof( MonsterStatuette ),
            typeof( Pier ),
            typeof( SmallRockWater ),
            typeof( SmallRocksWater ) }; } }

        public override MonsterStatuetteType[] StatueTypes{ get{ return new MonsterStatuetteType[] { 	
            MonsterStatuetteType.RedDeath,
            MonsterStatuetteType.PlagueBeast }; } }

        [Constructable]
        public Ilhenir()
            : base(AIType.AI_Mage)
        {
			Name = "Ilhenir";
			Title = "the Stained";
			Body = 0x103;

            BaseSoundID = 589;

			SetStr( 1105, 1350 );
			SetDex( 82, 160 );
			SetInt( 505, 750 );

			SetHits( 9000 );

			SetDamage(21, 28);

			SetDamageType(ResistanceType.Physical, 60);
			SetDamageType(ResistanceType.Fire, 20);
			SetDamageType(ResistanceType.Poison, 20);

			SetResistance(ResistanceType.Physical, 55, 65);
			SetResistance(ResistanceType.Fire, 50, 60);
			SetResistance(ResistanceType.Cold, 55, 65);
			SetResistance(ResistanceType.Poison, 70, 90);
			SetResistance(ResistanceType.Energy, 65, 75);

			SetSkill(SkillName.EvalInt, 100);
			SetSkill(SkillName.Magery, 100);
			SetSkill(SkillName.Meditation, 0);
			SetSkill(SkillName.Poisoning, 5.4);
			SetSkill(SkillName.Anatomy, 117.5);
			SetSkill(SkillName.MagicResist, 120.0);
			SetSkill(SkillName.Tactics, 119.9);  
			SetSkill(SkillName.Wrestling, 119.9);

			Fame = 50000;
			Karma = -50000;

			VirtualArmor = 44;

            PackResources(8);
            PackTalismans(5);
        }

        public virtual void PackResources(int amount)
        {
            for (int i = 0; i < amount; i++)
                switch (Utility.Random(6))
                {
                    case 0: PackItem(new Blight()); break;
                    case 1: PackItem(new Scourge()); break;
                    case 2: PackItem(new Taint()); break;
                    case 3: PackItem(new Putrefication()); break;
                    case 4: PackItem(new Corruption()); break;
                    case 5: PackItem(new Muculent()); break;
                }
        }

        public virtual void PackItems(Item item, int amount)
        {
            for (int i = 0; i < amount; i++)
                PackItem(item);
        }

        public virtual void PackTalismans(int amount)
        {
            int count = Utility.Random(amount);

            for (int i = 0; i < count; i++)
                PackItem(new RandomTalisman());
        }

		public override void GenerateLoot()
		{
			AddLoot(LootPack.FilthyRich, 8);
		}

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            c.DropItem(new GrizzledBones());

            if (Utility.RandomDouble() < 0.6)
                c.DropItem(new ParrotItem());

            if (Utility.RandomDouble() < 0.05)
                c.DropItem(new GrizzledMareStatuette());

            if (Utility.RandomDouble() < 0.025)
                c.DropItem(new CrimsonCincture());

            if (Utility.RandomDouble() < 0.05)
            {
                switch (Utility.Random(5))
                {
                    case 0: c.DropItem(new GrizzleGauntlets()); break;
                    case 1: c.DropItem(new GrizzleGreaves()); break;
                    case 2: c.DropItem(new GrizzleHelm()); break;
                    case 3: c.DropItem(new GrizzleTunic()); break;
                    case 4: c.DropItem(new GrizzleVambraces()); break;
                }
            }
        }

		public override bool Unprovokable { get { return true; } }
		public override bool Uncalmable { get { return true; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }
        public override bool GivesMinorArtifact { get { return true; } }
        public override int TreasureMapLevel { get { return 5; } }

        public override void OnGaveMeleeAttack(Mobile defender)
        {
            base.OnGaveMeleeAttack(defender);

            if (Utility.RandomDouble() < 0.15)
                CacophonicAttack(defender);
        }

        public override void OnDamage(int amount, Mobile from, bool willKill)
        {
            if (Utility.RandomDouble() < 0.15)
                CacophonicAttack(from);

            if (Utility.RandomDouble() < 0.3)
                DropOoze();

            base.OnDamage(amount, from, willKill);
        }

		public override int GetAngerSound()
		{
			return 0x581;
		}

		public override int GetIdleSound()
		{
			return 0x582;
		}

		public override int GetAttackSound()
		{
			return 0x580;
		}

		public override int GetHurtSound()
		{
			return 0x583;
		}

		public override int GetDeathSound()
		{
			return 0x584;
		}

        public Ilhenir(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        private static Hashtable m_Table;

        public virtual void CacophonicAttack(Mobile to)
        {
            if (m_Table == null)
                m_Table = new Hashtable();

            if (to.Alive && to.Player && m_Table[to] == null)
            {
                to.Send(SpeedControl.WalkSpeed);
                to.SendLocalizedMessage(1072069); // A cacophonic sound lambastes you, suppressing your ability to move.
                to.PlaySound(0x584);

                m_Table[to] = Timer.DelayCall(TimeSpan.FromSeconds(30), new TimerStateCallback(EndCacophonic_Callback), to);
            }
        }

        private void EndCacophonic_Callback(object state)
        {
            if (state is Mobile)
                CacophonicEnd((Mobile)state);
        }

        public virtual void CacophonicEnd(Mobile from)
        {
            if (m_Table == null)
                m_Table = new Hashtable();

            m_Table[from] = null;

            from.Send(SpeedControl.Disable);
        }

        public static bool UnderCacophonicAttack(Mobile from)
        {
            if (m_Table == null)
                m_Table = new Hashtable();

            return m_Table[from] != null;
        }

        private DateTime m_NextDrop = DateTime.Now;

        public virtual void DropOoze()
        {
            int amount = Utility.RandomMinMax(1, 3);
            bool corrosive = Utility.RandomBool();

            for (int i = 0; i < amount; i++)
            {
                Item ooze = new StainedOoze(corrosive);
                Point3D p = new Point3D(Location);

                for (int j = 0; j < 5; j++)
                {
                    p = GetSpawnPosition(2);
                    bool found = false;

                    foreach (Item item in Map.GetItemsInRange(p, 0))
                        if (item is StainedOoze)
                        {
                            found = true;
                            break;
                        }

                    if (!found)
                        break;
                }

                ooze.MoveToWorld(p, Map);
            }

            if (Combatant != null)
            {
                if (corrosive)
                    Combatant.SendLocalizedMessage(1072071); // A corrosive gas seeps out of your enemy's skin!
                else
                    Combatant.SendLocalizedMessage(1072072); // A poisonous gas seeps out of your enemy's skin!
            }
        }

        public virtual Point3D GetSpawnPosition(int range)
        {
            return GetSpawnPosition(Location, Map, range);
        }

        public static Point3D GetSpawnPosition(Point3D from, Map map, int range)
        {
            if (map == null)
                return from;

            for (int i = 0; i < 10; i++)
            {
                int x = from.X + Utility.Random(range);
                int y = from.Y + Utility.Random(range);
                int z = map.GetAverageZ(x, y);

                if (Utility.RandomBool())
                    x *= -1;

                if (Utility.RandomBool())
                    y *= -1;

                Point3D p = new Point3D(x, y, from.Z);

                if (map.CanSpawnMobile(p) && map.LineOfSight(from, p))
                    return p;

                p = new Point3D(x, y, z);

                if (map.CanSpawnMobile(p) && map.LineOfSight(from, p))
                    return p;
            }

            return from;
        }
    }

    public class StainedOoze : Item
    {
        private bool m_Corrosive;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Corrosive
        {
            get { return m_Corrosive; }
            set { m_Corrosive = value; }
        }

        [Constructable]
        public StainedOoze()
            : this(false)
        {
        }

        [Constructable]
        public StainedOoze(bool corrosive)
            : base(0x122A)
        {
            Movable = false;
            Hue = 0x95;

            m_Corrosive = corrosive;
            Timer.DelayCall(TimeSpan.FromSeconds(30), new TimerCallback(Morph));
        }

        private Hashtable m_Table;

        public override bool OnMoveOver(Mobile m)
        {
            if (m_Table == null)
                m_Table = new Hashtable();

            if ((m is BaseCreature && ((BaseCreature)m).Controlled) || m.Player)
                m_Table[m] = Timer.DelayCall(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1), new TimerStateCallback(Damage_Callback), m);

            return base.OnMoveOver(m);
        }

        public override bool OnMoveOff(Mobile m)
        {
            if (m_Table == null)
                m_Table = new Hashtable();

            if (m_Table[m] is Timer)
            {
                Timer timer = (Timer)m_Table[m];

                timer.Stop();

                m_Table[m] = null;
            }

            return base.OnMoveOff(m);
        }

        public StainedOoze(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((bool)m_Corrosive);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Corrosive = reader.ReadBool();
        }

        private void Damage_Callback(object state)
        {
            if (state is Mobile)
                Damage((Mobile)state);
        }

        public virtual void Damage(Mobile m)
        {
            if (!m.Alive)
                StopTimer(m);

            if (m_Corrosive)
            {
                for (int i = 0; i < m.Items.Count; i++)
                {
                    IDurability item = m.Items[i] as IDurability;

                    if (item != null && Utility.RandomDouble() < 0.25)
                    {
                        if (item.HitPoints > 10)
                            item.HitPoints -= 10;
                        else
                            item.HitPoints -= 1;
                    }
                }
            }
            else
                AOS.Damage(m, 40, 0, 0, 0, 100, 0);
        }

        public virtual void Morph()
        {
            ItemID += 1;

            Timer.DelayCall(TimeSpan.FromSeconds(5), new TimerCallback(Decay));
        }

        public virtual void StopTimer(Mobile m)
        {
            if (m_Table[m] is Timer)
            {
                Timer timer = (Timer)m_Table[m];
                timer.Stop();
                m_Table[m] = null;
            }
        }

        public virtual void Decay()
        {
            if (m_Table == null)
                m_Table = new Hashtable();

            foreach (DictionaryEntry entry in m_Table)
                if (entry.Value is Timer)
                    ((Timer)entry.Value).Stop();

            m_Table.Clear();

            Delete();
        }
    }
}