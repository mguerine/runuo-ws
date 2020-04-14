// Edited by: Mark Ribeiro

using System;
using Server.Items;

namespace Server.Items
{
	public class ArrowStone : Item
	{
		[Constructable]
		public ArrowStone() : base( 0xED4 )
		{
			Movable = false;
			Hue = 1957;
			Name = "an arrow stone";
		}

		public override void OnDoubleClick( Mobile from )
		{
                  
		
         	Arrow Arrow = new Arrow( 100 );
			Bolt Bolt = new Bolt( 100 );
		   	from.AddToBackpack( Arrow );
			from.AddToBackpack( Bolt );
			from.SendMessage( "You received some arrows and bolts." );
		}

		public ArrowStone( Serial serial ) : base( serial )
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
