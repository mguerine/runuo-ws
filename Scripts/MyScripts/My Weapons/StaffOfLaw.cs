using System;
using Server;

namespace Server.Items
{
	public class StaffOfLaw : BlackStaff
	{
		public override int ArtifactRarity{ get{ return 19; } }

		public override int AosMinDamage{ get{ return 18; } }
		public override int AosMaxDamage{ get{ return 22; } }
		public override float MlSpeed { get { return 2.75f; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public StaffOfLaw()
		{
			Hue = 0x481;
			Attributes.WeaponDamage = 40;
			Attributes.AttackChance = 10;
			Attributes.DefendChance = 20;
       		WeaponAttributes.HitLightning = 35;
			WeaponAttributes.HitLeechMana = 50;
			Attributes.WeaponSpeed = 20;
			Attributes.BonusMana = 10;
	    	
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			phys = fire = chaos = direct = nrgy = 0;
			cold = 70;
			pois = 30;
		}

		public StaffOfLaw( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

