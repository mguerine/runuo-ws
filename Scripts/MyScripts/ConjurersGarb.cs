using System;
using Server;

namespace Server.Items
{
	public class ConjurersGarb : Robe
	{

		public override int InitMinHits{ get{ return 150; } }
		public override int InitMaxHits{ get{ return 150; } }
		
		public override bool CanFortify{ get{ return false; } }

		[Constructable]
		public ConjurersGarb()
		{
			Name = "Conjurer's Garb";
			Attributes.DefendChance = 5;
			Attributes.Luck = 140;
			Attributes.RegenMana = 2;
			Hue = 1141; //  0x1B5;
		}

		public ConjurersGarb( Serial serial ) : base( serial )
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