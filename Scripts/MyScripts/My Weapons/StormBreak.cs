using System;
using Server;

namespace Server.Items
{
	public class StormBreak : Bardiche
	{
		public override int ArtifactRarity{ get{ return 19; } }		// Edited
		public override int AosMinDamage{ get{ return 19; } }
		public override int AosMaxDamage{ get{ return 20; } }
		public override float MlSpeed { get { return 3.5f; } }
		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }

		[Constructable]
		public StormBreak()
		{
			Hue = 0x4F2;
			Attributes.WeaponDamage = 40;
			Attributes.AttackChance = 15;
			Attributes.DefendChance = 15;
       		WeaponAttributes.HitLightning = 50;
			WeaponAttributes.HitLowerDefend = 50;
			Attributes.BonusStr =8;
			Attributes.WeaponSpeed = 20;
			
		}

				public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = 0;
			phys = pois = fire =  0;
			nrgy = 50;
			cold = 50;
			
		}
		
		public StormBreak( Serial serial ) : base( serial )
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