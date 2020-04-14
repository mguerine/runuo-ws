using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	
	public class IllusionTwist : Kryss
	{

		public override int AosMinDamage{ get{ return 14; } }
		public override int AosMaxDamage{ get{ return 16; } }

		public override int InitMinHits{ get{ return 255; } }
		public override int InitMaxHits{ get{ return 255; } }


		[Constructable]
		public IllusionTwist()
		{
			ItemID = 0x1400;
            Name = "Illusion Twist";
           	Hue = 1953;
			//Label1="Mystara Artifact";
			Attributes.WeaponDamage = 40;
			WeaponAttributes.HitHarm = 40;
			Attributes.CastSpeed = 1;
			Attributes.DefendChance = 10;
			Attributes.SpellChanneling = 1;
	   
            
		}


        	public IllusionTwist( Serial serial ) : base( serial )
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

			if ( ItemID == 0x1401 )
				ItemID = 0x1400;
		}
	}
}