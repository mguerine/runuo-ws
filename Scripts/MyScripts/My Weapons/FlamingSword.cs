using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	
	public class FlamingSword : VikingSword
	{
		public override int ArtifactRarity{ get{ return 19; } }		// Edited
		public override int AosStrengthReq{ get{ return 90; } }
		public override int AosMinDamage{ get{ return 17; } }
		public override int AosMaxDamage{ get{ return 24; } }

		public override int OldStrengthReq{ get{ return 90; } }
		public override float MlSpeed { get { return 3.25f; } }
		
		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		[Constructable]
		public FlamingSword() //: base( 0x13b9 )
		{
      		Name = "Flaming Sword";
       		Hue = 0x7AD;
//			Label1="Mystara Artifact";
    		WeaponAttributes.ResistFireBonus = 20;
			
			Attributes.WeaponDamage = 40;
			Attributes.AttackChance = 15;
	    	Attributes.CastSpeed = 1;
			Attributes.DefendChance = 15;
       		WeaponAttributes.HitFireball = 50;
			Attributes.WeaponSpeed = 30;
	    	Layer = Layer.TwoHanded;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
		    chaos = direct = 0;
			phys = pois = cold = nrgy = 0;
			fire = 100;
		}

        public FlamingSword(Serial serial): base(serial)
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