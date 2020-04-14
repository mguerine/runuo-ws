//GM Arthanys - Mystara Shard: www.mystara.com.br

using System;
using Server.Gumps;
using Server.Regions;



namespace Server.Items
{
	public class ResPedra : Item
	{
		[Constructable]
		public ResPedra() : base( 0xED4 )
		{
			Movable = false;
			Hue = 1953;
			Name = "a resurection Stone";
			//Light = LightType.Circle300;
		}

		public ResPedra( Serial serial ) : base( serial ) 
     		{ 
      		}

		public override bool HandlesOnMovement{ get{ return true; } } // Tell the core that we implement OnMovement

			public override void OnMovement( Mobile m, Point3D oldLocation )
			{
				while ( (m.Body == 749) && (m.Hits < 1) )
				{ 
				m.SendMessage("Voce aparenta estar morto");
				break;
				}
				if ( Parent == null && Utility.InRange( Location, m.Location, 1 ) && !Utility.InRange( Location, oldLocation, 1 ) )
				{
					if ( (m.Hits < 1) && (m.Body != 749))
						{
							

							m.X = 2691;
							m.Y = 2203;
							m.Z = 0;
							
							m.SendGump( new ResurrectGump( m ) );
						


					
						}
				}
			}

			
		public override void OnDoubleClick( Mobile m )
		{
		
			
			m.SendMessage("Voce Nem esta morto!!!");
			
			
		}		 

		public override void OnDoubleClickDead( Mobile m )
		{
			
				
				m.X = 2691;
				m.Y = 2203;
				m.Z = 0;


			m.SendGump( new ResurrectGump( m ) );
		
			
			

			
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
