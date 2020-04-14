// Edited by: Mark Ribeiro

using System; 
using Server.Mobiles; 

namespace Server.Items 
{ 
	public class EtherealUndeadSteed : EtherealMount 
	{ 

		[Constructable] 
		public EtherealUndeadSteed() : base( 11669, 0x3E90 )                            
		{ 
			Name = "Ethereal Undead Steed Statuette";
			ItemID = 9680;
 			MountedID = 16059;
			RegularID = 9680;
			LootType = LootType.Blessed;
                } 

		public EtherealUndeadSteed( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 

			writer.Write( (int) 0 ); 
		} 

		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 

			int version = reader.ReadInt();

			if ( Name != "Ethereal Undead Steed Statuette" )
				Name = "Ethereal Undead Steed Statuette";
		} 
	}
}
