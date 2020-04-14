using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	
	public class HolyAvenger : Longsword
	{
		public override int ArtifactRarity{ get{ return 19; } }		// Edited
		public override int AosStrengthReq{ get{ return 35; } }
		public override int AosMinDamage{ get{ return 15; } }
		public override int AosMaxDamage{ get{ return 16; } }

		public override int DefHitSound{ get{ return 0x237; } }
		public override int DefMissSound{ get{ return 0x23A; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }
		[Constructable]
		public HolyAvenger() //: base( 0xF61 )
		{
			Name = "Holy Avenger";
           	Hue = 0x47E;
			//Label1="Mystara Artifact";
			Slayer = SlayerName.Silver;
			Slayer2 = SlayerName.Exorcism;
			WeaponAttributes.HitLeechMana = 40;
			WeaponAttributes.HitLeechStam = 40;
			WeaponAttributes.HitLeechHits = 40;
            Attributes.WeaponDamage = 40;
	    	Attributes.WeaponSpeed = 40;
			Attributes.Luck = 350;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = 0;
			pois = fire = 0;
			phys = 50;
			cold = 25;
			nrgy = 25;
		}

        public HolyAvenger(Serial serial): base(serial)
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