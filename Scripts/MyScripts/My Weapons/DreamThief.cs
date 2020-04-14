using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	
	public class DreamThief : VikingSword
	{
		public override int ArtifactRarity{ get{ return 19; } }		// Edited
		public override int AosStrengthReq{ get{ return 40; } }
		public override int AosMinDamage{ get{ return 18; } }
		public override int AosMaxDamage{ get{ return 21; } }
		public override float MlSpeed { get { return 3.5f; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		[Constructable]
		public DreamThief() //: base( 0x13B9)
		{
            Name = "Dream Thief";
           	Hue = 0x47E;
			//Label="Mystara Artifact";
            Attributes.WeaponDamage = 50;
	    	Attributes.WeaponSpeed = 60;
			WeaponAttributes.HitLeechMana = 35;
			WeaponAttributes.HitHarm = 50;
			Attributes.LowerManaCost = 8;
			Attributes.BonusInt = 8;
			

		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = 0;
			pois = fire = nrgy = 0;
			phys = 50;
			cold = 50;
			
		}

        public DreamThief(Serial serial): base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}