using System;
using Server;

namespace Server.Items
{
	public class DryadsBlessing : PeerlessKey
	{
		public override int Lifespan{ get{ return 21600; } }
	
		[Constructable]
		public DryadsBlessing() : base( 0x21C )
		{
			Weight = 1.0;
			Hue = 0x488; // TOOD check
		}

		public DryadsBlessing( Serial serial ) : base( serial )
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

